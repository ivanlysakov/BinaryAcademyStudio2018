using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using BL.Service.Interfaces;

namespace DAL.Controllers
{
    [Produces("application/json")]
    [Route("api/Aircrews")]
    public class AircrewsController : Controller
    {
        IService<CrewDTO> service;

        public AircrewsController(IService<CrewDTO> service)
        {
            this.service = service;
        }

        // GET: api/Aircrews
        [HttpGet]
        public IEnumerable<CrewDTO> GetAll()
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
        public ICollection<HostessDTO> GetHostess(int id)
        {
            return service.GetById(id).Hostesses;
        }

        // POST: api/Aircrews
        [HttpPost]
        public void Post([FromBody] CrewDTO crew)
        {
            (service as AirCrewsService).Create(crew);
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