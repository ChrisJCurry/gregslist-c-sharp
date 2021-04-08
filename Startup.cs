using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using Repositories;
using Services;

namespace gregslist
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IDbConnection>(x => CreateDbConnection());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "gregslist", Version = "v1" });
            });

            services.AddCors(options =>
                   {
                       options.AddPolicy("CorsDevPolicy", builder =>
                           {
                               builder
                                       .WithOrigins(new string[]{
                            "http://localhost:8080",
                            "http://localhost:8081"
                                       })
                                       .AllowAnyMethod()
                                       .AllowAnyHeader()
                                       .AllowCredentials();
                           });
                   });

            services.AddTransient<CarsService>();
            services.AddTransient<JobsService>();
            services.AddTransient<HousesService>();

            services.AddTransient<CarRepository>();
            services.AddTransient<JobRepository>();
            services.AddTransient<HouseRepository>();

        }

        public IDbConnection CreateDbConnection()
        {
            string connectString = Configuration["db:gearhost"];
            return new MySqlConnection(connectString);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "gregslist v1"));
                app.UseCors("CorsDevPolicy");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
