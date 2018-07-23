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
    [Route("api/Pilots")]
    public class PilotsController : Controller
    {
        IPilotService service;

        public PilotsController(IPilotService serv)
        {
            service = serv;
        }

        // GET: api/Pilots
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.Get());
        }

        // GET: api/Pilots/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            PilotDTO ticket = await service.GetById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);

        }

        // POST: api/Pilots
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PilotDTO modelDTO)
        {
            if (modelDTO == null)
            {
                ModelState.AddModelError("", "Pilot structure is wrong!!!");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Create(modelDTO);

            return Created("api/Pilots", modelDTO);
        }

        // PUT: api/Pilots/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody] PilotDTO modelDTO)
        {
            if (modelDTO == null)
            {
                ModelState.AddModelError("", "Pilot structure is wrong!!!");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Update(id,modelDTO);

            return Ok(modelDTO);

        }

               
        // DELETE: api/Pilots/5
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
