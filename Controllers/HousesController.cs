using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HousesController : ControllerBase
    {

        private readonly HousesService _service;

        public HousesController(HousesService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<House>> Get()
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
        public ActionResult<House> GetOne(int id)
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
        public ActionResult<House> Create([FromBody] House house)
        {
            try
            {
                return Ok(_service.Create(house));
            }
            catch (SystemException err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<House> Edit(int id, [FromBody] House house)
        {
            try
            {
                house.Id = id;
                return Ok(_service.Edit(house));
            }
            catch (SystemException err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<House> Delete(int id)
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