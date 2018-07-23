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
    [Route("api/Airhostesses")]
    public class AirhostessesController : Controller
    {
        IService<HostessDTO> service;

        public AirhostessesController(IService<HostessDTO> serv)
        {
            service = serv;
        }

        // GET: api/Airhostesses
        [HttpGet]
        public IEnumerable<HostessDTO> GetAll()
        {
            return service.Get();

        }

        // GET: api/Airhostesses/5
        [HttpGet("{id}")]
        public HostessDTO Get(int id)
        {
            return service.GetById(id);
        }
        
        // POST: api/Airhostesses
        [HttpPost]
        public void Post(string firstname, string lastname, DateTime birthday, int crew)
        {
            (service as HostessesService).Create(firstname, lastname, birthday,crew);

        }

        // PUT: api/Airhostesses/5
        [HttpPut("{id}")]
        public void Put(string firstname, string lastname, DateTime birthday,  int id, int crew)
        {
            (service as HostessesService).Update(firstname, lastname, birthday, id,crew);

        }


        // DELETE: api/Airhostesses/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
