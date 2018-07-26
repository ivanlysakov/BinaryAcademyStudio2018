using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BL.Service.Interfaces;
using BL.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace DAL.Controllers
{
    [Produces("application/json")]
    [Route("api/Tickets")]
    public class TicketsController : Controller
    {
        ITicketsService service;

        public TicketsController(ITicketsService service)
        {
            this.service = service;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           return Ok(await service.Get());
        }
                
        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            TicketDTO ticket = await service.GetById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);

        }

        // POST: api/Tickets
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TicketDTO modelDTO)
        {
            if (modelDTO == null)
            {
                ModelState.AddModelError("", "Ticket structure is wrong!!!");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Create(modelDTO);

            return Created("api/Tickets", modelDTO);
        }

        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TicketDTO modelDTO)
        {
            if (modelDTO == null)
            {
                ModelState.AddModelError("", "Ticket structure is wrong!!!");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Update(id,modelDTO);

            return Ok(modelDTO);

        }

        
        // DELETE: api/Tickets/5
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
