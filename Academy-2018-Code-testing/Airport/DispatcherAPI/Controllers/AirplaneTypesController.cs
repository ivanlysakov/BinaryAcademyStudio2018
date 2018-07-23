using Microsoft.AspNetCore.Mvc;
using BL.Service.Services;
using Shared.DTO;
using System.Collections.Generic;

namespace DAL.Controllers
{
    [Produces("application/json")]
    [Route("api/AirplaneTypes")]
    public class AirplaneTypesController : Controller
    {
        IService<AirplaneTypeDTO> service;

        public AirplaneTypesController(IService<AirplaneTypeDTO> serv)
        {
            service = serv;
        }

        // GET: api/AirplaneTypes
        [HttpGet]
        public IEnumerable<AirplaneTypeDTO> GetAll()
        {
            return service.Get();

        }

        // GET: api/AirplaneTypes/5
        [HttpGet("{id}")]
        public AirplaneTypeDTO Get(int id)
        {
            return service.GetById(id);
        }

        // POST: api/AirplaneTypes
        [HttpPost]
        public void Post(string model , int capacity , int cargo)
        {
            (service as AirplaneTypesService).Create(model, capacity, cargo);
           
        }

        // PUT: api/AirplaneTypes/5
        [HttpPut("{id}")]
        public void Put(string model, int capacity, int cargo, int id)
        {
            (service as AirplaneTypesService).Update(model, capacity, cargo, id);

        }

        // DELETE: api/AirplaneTypes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
