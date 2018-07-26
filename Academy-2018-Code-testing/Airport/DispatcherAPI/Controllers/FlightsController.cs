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
    [Route("api/Flights")]
    public class FlightsController : Controller
    {
        IService<FlightDTO> service;

        public FlightsController(IService<FlightDTO> serv)
        {
            service = serv;
        }

        // GET: api/Flights
        [HttpGet]
        public IEnumerable<FlightDTO> GetAll()
        {
            return service.Get();
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        public FlightDTO Get(int id)
        {
            return service.GetById(id);
        }


        // POST: api/Flights
        [HttpPost]
        public void Post(string flightNumber, string departure, DateTime departureTime, string destination, DateTime arrivalTime, int[] tickets)
        {
            (service as FlightsService).Create(flightNumber, departure, departureTime, destination, arrivalTime, tickets);
        }

        // PUT: api/Flights/5
        [HttpPut("{id}")]
        public void Put(string flightNumber, string departure, DateTime departureTime, string destination, DateTime arrivalTime, int[] tickets, int id)
        {

            (service as FlightsService).Update(flightNumber, departure, departureTime, destination, arrivalTime, tickets, id);

        }

        // PATCH: api/Flights/5
        [HttpPatch("{id}")]
        public void Patch(int id, DateTime departuretime)
        {
            (service as FlightsService).Update(id, departuretime);
        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
