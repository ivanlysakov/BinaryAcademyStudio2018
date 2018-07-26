using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        IService<TicketDTO> service;

        public TicketsController(IService<TicketDTO> serv)
        {
            service = serv;
        }

        // GET: api/Tickets
        [HttpGet]
        public List<TicketDTO> GetAll()
        {
            return service.Get();
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public TicketDTO Get(int id)
        {
            return service.GetById(id);
        }

        // POST: api/Tickets
        [HttpPost]
        public void Post(string flightnumber, int price)
        {
            (service as TicketsService).Create(flightnumber, price);

        }

        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public void Put(string flightnumber, int price, int id)
        {
            (service as TicketsService).Update(flightnumber, price, id);

        }

        // PATCH: api/Tickets/5
        [HttpPatch("{id}")]
        public void Patch(int id, int price)
        {
            (service as TicketsService).Update(id, price);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
