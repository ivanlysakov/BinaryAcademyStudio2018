using Microsoft.AspNetCore.Mvc;
using BL.Service.Services;
using Shared.DTO;
using System.Collections.Generic;
using BL.Service.Interfaces;
using System.Threading.Tasks;
using FluentValidation;

namespace DAL.Controllers
{
    [Produces("application/json")]
    [Route("api/AirplaneTypes")]
    public class AirplaneTypesController : Controller
    {
        IAirplaneTypesService service;

        public AirplaneTypesController(IAirplaneTypesService serv)
        {
            service = serv;
        }

        // GET: api/AirplaneTypes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.Get());
        }

        // GET: api/AirplaneTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            AirplaneTypeDTO plane = await service.GetById(id);
            if (plane == null)
            {
                return NotFound();
            }
            return Ok(plane);

        }

        // POST: api/AirplaneTypes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AirplaneTypeDTO modelDTO)
        {
            if (modelDTO == null)
            {
                ModelState.AddModelError("", "Type structure is wrong!!!");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Create(modelDTO);

            return Created("api/AirplaneTypes", modelDTO);
        }

        // PUT: api/AirplaneTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AirplaneTypeDTO modelDTO)
        {
            if (modelDTO == null)
            {
                ModelState.AddModelError("", "Type structure is wrong!!!");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Update(id, modelDTO);

            return Ok(modelDTO);

        }

        // DELETE: api/AirplaneTypes/5
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
