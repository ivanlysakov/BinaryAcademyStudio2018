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
        public IActionResult GetAll()
        {
            return Ok(service.Get());
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var ticket = service.GetById(id);
                return Ok(ticket);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            
        }

        // POST: api/Tickets
        [HttpPost]
        public IActionResult Post([FromBody]TicketDTO ticketDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                service.Create(ticketDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return Ok(ticketDTO);
        }

        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]TicketDTO ticketDTO, int id)
        {
            ticketDTO.Id = id;

            try
            {
                service.Update(ticketDTO, id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(service.GetById(id));

        }

        // PATCH: api/Tickets/5
        [HttpPatch("{id}")]
        public void Patch(int id, int price)
        {
            (service as TicketsService).Update(id, price);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }
    }
}
