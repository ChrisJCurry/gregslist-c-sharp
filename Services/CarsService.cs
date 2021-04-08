using System;
using System.Collections.Generic;
using Models;
using Repositories;

namespace Services
{
    public class CarsService
    {

        private readonly CarRepository _repo;

        public CarsService(CarRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Car> Get()
        {
            return (_repo.Get());
        }

        internal Car Get(int id)
        {
            return (_repo.Get(id));
        }

        internal Car Create(Car car)
        {
            return (_repo.Create(car));
        }

        internal Car Edit(Car car)
        {
            Car original = Get(car.Id);

            original.Make = car.Make != null ? car.Make : original.Make;
            original.Model = car.Model != null ? car.Model : original.Model;
            original.Year = car.Year != null ? car.Year : original.Year;
            original.Price = car.Price > 0 ? car.Price : original.Price;
            original.Description = car.Description != null ? car.Description : original.Description;
            original.ImgUrl = car.ImgUrl != null ? car.ImgUrl : original.Description;

            return (_repo.Edit(original));
        }

        internal Car Delete(int id)
        {
            Car original = Get(id);
            _repo.Delete(id);
            return (original);
        }
    }
}