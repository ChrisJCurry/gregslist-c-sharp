using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Models;

namespace Repositories
{
    public class CarRepository
    {

        public readonly IDbConnection _db;

        public CarRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Car> Get()
        {
            string sql = "SELECT * FROM cars;";
            return _db.Query<Car>(sql);
        }

        internal Car Get(int id)
        {
            string sql = "SELECT * FROM cars WHERE id = @id;";
            return _db.QueryFirstOrDefault<Car>(sql, new { id });
        }

        internal Car Create(Car car)
        {
            string sql = @"
            INSERT INTO cars
            (make, model, description, year, price, imgUrl)
            VALUES
            (@Make, @Model, @Description, @Year, @Price, @ImgUrl);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, car);
            car.Id = id;
            return car;
        }

        internal Car Edit(Car car)
        {
            string sql = @"
            UPDATE cars
            SET
                make = @Make,
                model = @model,
                description = @Description,
                year = @Year,
                price = @Price,
                imgUrl = @ImgUrl
            WHERE id = @Id;
            SELECT * FROM cars WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Car>(sql, car);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM cars WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}