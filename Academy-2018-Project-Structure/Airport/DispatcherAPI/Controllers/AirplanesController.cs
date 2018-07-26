using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BL.Service.Services;
using Shared.DTO;
using System.ComponentModel.DataAnnotations;
using DAL.Repository.EF;

namespace DAL.Controllers
{
    [Produces("application/json")]
    [Route("api/Airplanes")]
    public class AirplanesController : Controller
    {
        IService<AirplaneDTO> service;
        

        public AirplanesController(IService<AirplaneDTO> serv)
        {
            service = serv;
        }

        // GET: api/Airplanes
        [HttpGet]
        public List<AirplaneDTO> GetAll()
        {

          
            return service.Get();
            
        }

        // GET: api/Airplanes/5
        [HttpGet("{id}")]
        public AirplaneDTO Get(int id)
        {
            return service.GetById(id);
        }

        // POST: api/Airplanes
        [HttpPost]
        public void Post(string name, DateTime creationDate, TimeSpan lifetime, int type)
        {
                        
            (service as AirplanesService).Create(name, creationDate,  lifetime, type);
            
            

            
        }

        // PUT: api/Airplanes/5
        [HttpPut("{id}")]
        public void Put(string name, DateTime creationDate, TimeSpan lifetime, int type, int id)
        {

            (service as AirplanesService).Update(name, creationDate, lifetime, type, id);
           
        }

        // PATCH: api/Airplanes/5
        [HttpPatch("{id}")]
        public void Patch(int id, TimeSpan lifetime)
        {
            (service as AirplanesService).Update(id, lifetime);
        }


        // DELETE: api/Airplanes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
