using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Service.Interfaces;
using BL.Service.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace DAL.Controllers
{
    [Produces("application/json")]
    [Route("api/Airhostesses")]
    public class AirhostessesController : Controller
    {
        IHostessesService service;

        public AirhostessesController(IHostessesService serv)
        {
            service = serv;
        }

        // GET: api/Airhostesses
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.Get());
        }

        // GET: api/Airhostesses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            HostessDTO hostess = await service.GetById(id);
            if (hostess == null)
            {
                return NotFound();
            }
            return Ok(hostess);

        }

        // POST: api/Airhostesses
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HostessDTO modelDTO)
        {
            if (modelDTO == null)
            {
                ModelState.AddModelError("", "Hostess structure is wrong!!!");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Create(modelDTO);

            return Created("api/Airhostess", modelDTO);
        }

        // PUT: api/Airhostesses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] HostessDTO modelDTO)
        {
            if (modelDTO == null)
            {
                ModelState.AddModelError("", "Hostess structure is wrong!!!");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Update(id, modelDTO);

            return Ok(modelDTO);

        }


        // DELETE: api/Airhostesses/5
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
