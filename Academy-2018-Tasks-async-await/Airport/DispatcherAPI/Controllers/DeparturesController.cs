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
    [Route("api/Departures")]
    public class DeparturesController : Controller
    {
        IDepartureService service;

        public DeparturesController(IDepartureService  serv)
        {
            service = serv;
        }

        // GET: api/Departures
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.Get());
        }

        // GET: api/Departures/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            DepartureDTO ticket = await service.GetById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);

        }

        // POST: api/Departures
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DepartureDTO modelDTO)
        {
            if (modelDTO == null)
            {
                ModelState.AddModelError("", "Departure structure is wrong!!!");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Create(modelDTO);

            return Created("api/Departures", modelDTO);
        }

        // PUT: api/Departures/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DepartureDTO modelDTO)
        {
            if (modelDTO == null)
            {
                ModelState.AddModelError("", "Departure structure is wrong!!!");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Update(modelDTO);

            return Ok(modelDTO);

        }

        // DELETE: api/Departures/5
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
