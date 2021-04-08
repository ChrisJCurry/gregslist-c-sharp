using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {

        private readonly JobsService _service;

        public JobsController(JobsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Job>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (SystemException err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Job> GetOne(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (SystemException err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Job> Create([FromBody] Job job)
        {
            try
            {
                return Ok(_service.Create(job));
            }
            catch (SystemException err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Job> Edit(int id, [FromBody] Job job)
        {
            try
            {
                job.Id = id;
                return (_service.Edit(job));
            }
            catch (SystemException err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Job> Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (SystemException err)
            {
                return BadRequest(err.Message);
            }
        }

    }
}