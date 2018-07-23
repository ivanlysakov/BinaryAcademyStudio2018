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
        ICrewsService service;

        public AircrewsController(ICrewsService service)
        {
            this.service = service;
        }

        // GET: api/Aircrews
        [HttpGet]
        public async Task<List<CrewDTO>> GetAll()
        {
            return await service.Get();
        }

        // GET: api/Aircrews/5
        [HttpGet("{id}")]
        public async Task<CrewDTO> Get(int id)
        {
            return await service.GetById(id);
        }
        
        // GET: api/Aircrews/5
        [HttpGet("remoteApi")]
        public async Task<string> GetRemoteApi()
        {
            return await service.GetRemoteApi();
        }

        // POST: api/Aircrews
        [HttpPost]
        public async Task Post([FromBody] CrewDTO crew)
        {
            await service.Create(crew);
        }

        // PUT: api/Aircrews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CrewDTO modelDTO)
        {
            if (modelDTO == null)
            {
                ModelState.AddModelError("", "Ticket structure is wrong!!!");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Update(id, modelDTO);

            return Ok(modelDTO);

        }

        // DELETE: api/Aircrews/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.Delete(id);
        }
    }
}