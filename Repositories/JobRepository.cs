using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Models;

namespace Repositories
{
    public class JobRepository
    {

        public readonly IDbConnection _db;

        public JobRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Job> Get()
        {
            string sql = "SELECT * FROM jobs;";
            return _db.Query<Job>(sql);
        }

        internal Job Get(int id)
        {
            string sql = "SELECT * FROM jobs WHERE id = @id;";
            return _db.QueryFirstOrDefault<Job>(sql, new { id });
        }

        internal Job Create(Job job)
        {
            string sql = @"
            INSERT INTO jobs
            (title, company, rate, hours, description)
            VALUES
            (@Title, @Company, @Rate, @Hours, @Description);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, job);
            job.Id = id;
            return job;
        }

        internal Job Edit(Job job)
        {
            string sql = @"
            UPDATE jobs
            SET
                title = @Title,
                company = @Company,
                rate = @Rate,
                hours = @Hours,
                description = @Description
            WHERE id = @Id;
            SELECT * FROM jobs WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Job>(sql, job);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM jobs WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }


    }
}