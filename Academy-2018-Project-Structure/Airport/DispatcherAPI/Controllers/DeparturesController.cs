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
    [Route("api/Departures")]
    public class DeparturesController : Controller
    {
        IService<DepartureDTO> service;

        public DeparturesController(IService<DepartureDTO> serv)
        {
            service = serv;
        }

        // GET: api/Departures
        [HttpGet]
        public List<DepartureDTO> GetAll()
        {
            return service.Get();

        }

        // GET: api/Departures/5
        [HttpGet("{id}")]
        public DepartureDTO Get(int id)
        {
            return service.GetById(id);
        }

        // POST: api/Departures
        [HttpPost]
        public void Post(string flightnumber, DateTime time, int crewid, int airplaneId)
        {
            (service as DeparturesService).Create(flightnumber, time, crewid, airplaneId);

        }

        // PUT: api/Departures/5
        [HttpPut("{id}")]
        public void Put(string flightnumber, DateTime time, int crewid, int airplaneId, int id)
        {
            (service as DeparturesService).Update(flightnumber, time, crewid, airplaneId, id);

        }

        // PATCH: api/Pilots/5
        [HttpPatch("{id}")]
        public void Patch(int id, DateTime time)
        {
            (service as DeparturesService).Update(id, time);
        }

        // DELETE: api/Departures/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
