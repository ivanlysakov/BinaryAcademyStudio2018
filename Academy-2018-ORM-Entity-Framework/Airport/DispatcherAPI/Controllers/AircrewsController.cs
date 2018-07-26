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
    [Route("api/Aircrews")]
    public class AircrewsController : Controller
    {
        IService<CrewDTO> service;

        public AircrewsController(IService<CrewDTO> serv)
        {
            service = serv;
        }

        // GET: api/Aircrews
        [HttpGet]
        public List<CrewDTO> GetAll()
        {
            return service.Get();

        }

        // GET: api/Aircrews/5
        [HttpGet("{id}")]
        public CrewDTO Get(int id)
        {
            return service.GetById(id);
        }



        // GET: api/Aircrews/5
        [HttpGet("{id}/Airhostesses")]
        public List<HostessDTO> GetHostess(int id)
        {
            return service.GetById(id).Hostesses;
        
        }



        // POST: api/Aircrews
        [HttpPost]
        public void Post(int pilotId, int[] hostess)
        {
            (service as AirCrewsService).Create(pilotId, hostess);
        }

        // PUT: api/Aircrews/5
        [HttpPut("{id}")]
        public void Put(int pilotId, int[] hostess, int id)
        {
            
            (service as AirCrewsService).Update(pilotId, hostess, id);
           
        }

        // DELETE: api/Aircrews/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}