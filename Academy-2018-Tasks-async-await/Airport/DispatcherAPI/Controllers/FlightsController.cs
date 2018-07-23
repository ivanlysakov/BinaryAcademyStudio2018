using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Service.Interfaces;
using BL.Service.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace DAL.Controllers
{
    [Produces("application/json")]
    [Route("api/Flights")]
    public class FlightsController : Controller
    {
        IFlightService service;

        public FlightsController(IFlightService serv)
        {
            service = serv;
        }

        // GET: api/Flights
       [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.Get());
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            FlightDTO flight = await service.GetById(id);
            if (flight == null)
            {
                return NotFound();
            }
            return Ok(flight);

        }
        [HttpGet("Delay")]
        public async Task<IActionResult> GetAllWithDelay()
        {
            return Ok(await service.GetWithDelay());
        }


        // POST: api/Flights
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FlightDTO modelDTO)
        {
            if (modelDTO == null)
            {
                ModelState.AddModelError("", "Flight structure is wrong!!!");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Create(modelDTO);

            return Created("api/Flights", modelDTO);
        }

        // PUT: api/Flights/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FlightDTO modelDTO)
        {
            if (modelDTO == null)
            {
                ModelState.AddModelError("", "Flight structure is wrong!!!");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Update(id, modelDTO);

            return Ok(modelDTO);

        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await service.Delete(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }
    }
}
