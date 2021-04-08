using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Models;

namespace Repositories
{
    public class HouseRepository
    {
        public readonly IDbConnection _db;

        public HouseRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<House> Get()
        {
            string sql = "SELECT * FROM houses;";
            return _db.Query<House>(sql);
        }

        internal House Get(int id)
        {
            string sql = "SELECT * FROM houses WHERE id = @id;";
            return _db.QueryFirstOrDefault<House>(sql, new { id });
        }

        internal House Create(House house)
        {
            string sql = @"
            INSERT INTO houses
            (bedrooms, bathrooms, levels, price, description, year, imgUrl)
            VALUES
            (@Bedrooms, @Bathrooms, @Levels, @Price, @Description, @Year, @ImgUrl);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, house);
            house.Id = id;
            return house;
        }

        internal House Edit(House house)
        {
            string sql = @"
            UPDATE houses
            SET
                bedrooms = @Bedrooms,
                bathrooms = @Bathrooms,
                levels = @Levels,
                price = @Price,
                description = @Description,
                year = @Year,
                imgUrl = @ImgUrl
            WHERE id = @Id
            SELECT * FROM houses WHERE id = @Id;";
            return _db.QueryFirstOrDefault<House>(sql, house);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM house WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}