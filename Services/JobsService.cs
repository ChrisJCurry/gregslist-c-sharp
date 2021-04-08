using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;

namespace Services
{
    public class JobsService
    {
        private readonly JobRepository _repo;

        public JobsService(JobRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Job> Get()
        {
            return _repo.Get();
        }

        internal Job Get(int id)
        {
            Job job = _repo.Get(id);
            if (job == null)
            {
                throw new Exception("Invalid id in Get(id)");
            }
            return job;
        }

        internal Job Create(Job job)
        {
            return _repo.Create(job);
        }

        internal Job Edit(Job job)
        {
            Job original = Get(job.Id);

            original.Title = job.Title != null ? job.Title : original.Title;
            original.Company = job.Company != null ? job.Company : original.Company;
            original.Hours = job.Hours != null ? job.Hours : original.Hours;
            original.Rate = job.Rate != null ? job.Rate : original.Rate;
            original.Description = job.Description != null ? job.Description : original.Description;

            return _repo.Edit(job);
        }

        internal Job Delete(int id)
        {
            Job original = Get(id);
            _repo.Delete(id);
            return original;
        }
    }
}