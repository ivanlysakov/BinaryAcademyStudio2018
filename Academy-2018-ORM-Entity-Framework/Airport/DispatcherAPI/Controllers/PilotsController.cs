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
    [Route("api/Pilots")]
    public class PilotsController : Controller
    {
        IService<PilotDTO> service;

        public PilotsController(IService<PilotDTO> serv)
        {
            service = serv;
        }

        // GET: api/Pilots
        [HttpGet]
        public List<PilotDTO> GetAll()
        {
            return service.Get();

        }

        // GET: api/Pilots/5
        [HttpGet("{id}")]
        public PilotDTO Get(int id)
        {
            return service.GetById(id);
        }

        // POST: api/Pilots
        [HttpPost]
        public void Post(string firstname, string lastname, DateTime birthday, int experience)
        {
            (service as PilotsService).Create(firstname, lastname, birthday, experience);

        }

        // PUT: api/Pilots/5
        [HttpPut("{id}")]
        public void Put(string firstname, string lastname, DateTime birthday, int experience, int id)
        {
            (service as PilotsService).Update(firstname, lastname, birthday, experience, id);

        }

        // PATCH: api/Pilots/5
        [HttpPatch("{id}")]
        public void Patch(int id, int experience)
        {
            (service as PilotsService).Update(id, experience);
        }


        // DELETE: api/Pilots/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
