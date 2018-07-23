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
using BL.Service.Interfaces;

namespace DAL.Controllers
{
    [Produces("application/json")]
    [Route("api/Airplanes")]
    public class AirplanesController : Controller
    {
        IAirplaneService service;
        

        public AirplanesController(IAirplaneService serv)
        {
            service = serv;
        }

        // GET: api/Airplanes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.Get());
        }

        // GET: api/Airplanes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            AirplaneDTO plane = await service.GetById(id);
            if (plane == null)
            {
                return NotFound();
            }
            return Ok(plane);

        }

        // POST: api/Airplanes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AirplaneDTO modelDTO)
        {
            if (modelDTO == null)
            {
                ModelState.AddModelError("", "Plane structure is wrong!!!");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Create(modelDTO);

            return Created("api/Airplanes", modelDTO);
        }

        // PUT: api/Airplanes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AirplaneDTO modelDTO)
        {
            if (modelDTO == null)
            {
                ModelState.AddModelError("", "Plane structure is wrong!!!");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Update(id, modelDTO);

            return Ok(modelDTO);

        }



        // DELETE: api/Airplanes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await service.Delete(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }
    }
}
