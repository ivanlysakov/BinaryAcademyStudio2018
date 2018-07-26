using System.Collections.Generic;
using Shared.DTO;
using AutoMapper;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using System;
using BL.Service.Services;
using System.Linq;
using FluentValidation;
using BL.Service.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BL.Service.Services
{
    public class PilotsService : IPilotService
    {
        private readonly IMapper mapper;
        private readonly AbstractValidator<Pilot> validator;
        private IUnitOfWork uow;

        public PilotsService(IMapper mapper, AbstractValidator<Pilot> validator, IUnitOfWork uow)
        {

            this.mapper = mapper;
            this.validator = validator;
            this.uow = uow;

        }

        public async Task<List<PilotDTO>> Get()
        {
            return mapper.Map<List<Pilot>, List<PilotDTO>>(await uow.Pilots.GetAll());
        }

        public async Task<PilotDTO> GetById(int id)
        {
            return mapper.Map<PilotDTO>(await uow.Pilots.Get(id));
        }

        public async Task Create(PilotDTO item)
        {

            var model = mapper.Map<PilotDTO, Pilot>(item);
            var validationResult = validator.Validate(model);

            if (validationResult.IsValid)
            {
                await uow.Pilots.Create(model);
                await uow.SaveAsync();
            }

            throw new ValidationException(validationResult.Errors);

        }

        public async Task Update(int id, PilotDTO modelDTO)
        {
            var source = uow.Pilots.Get(id);
            var dest = mapper.Map<PilotDTO, Pilot>(modelDTO);
            await uow.Pilots.Update(dest);
            await uow.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await uow.Pilots.Delete(id);
            await uow.SaveAsync();
        }

        public async Task Update(PilotDTO modelDTO)
        {
            var dest = mapper.Map<PilotDTO, Pilot>(modelDTO);
            await uow.Pilots.Update(dest);
        }

             
    }

}
