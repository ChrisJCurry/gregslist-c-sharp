using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {

        private readonly CarsService _service;

        public CarsController(CarsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetOne(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Car> Create([FromBody] Car car)
        {
            try
            {
                return Ok(_service.Create(car));
            }
            catch (SystemException err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Car> Edit(int id, [FromBody] Car car)
        {
            try
            {
                car.Id = id;
                return Ok(_service.Edit(car));
            }
            catch (SystemException err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
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