using System;
using System.Collections.Generic;
using Models;
using Repositories;

namespace Services
{
    public class HousesService
    {
        private readonly HouseRepository _repo;

        public HousesService(HouseRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<House> Get()
        {
            return (_repo.Get());
        }

        internal House Get(int id)
        {
            return (_repo.Get(id));
        }

        internal House Create(House house)
        {
            return (_repo.Create(house));
        }

        internal House Edit(House house)
        {
            return (_repo.Edit(house));
        }

        internal House Delete(int id)
        {
            House original = Get(id);
            _repo.Delete(id);
            return (original);
        }
    }
}