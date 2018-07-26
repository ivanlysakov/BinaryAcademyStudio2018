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

namespace BL.Service.Services
{
    public class DeparturesService : IDepartureService
    {
        private readonly IMapper mapper;
        private readonly AbstractValidator<Departure> validator;
        private IUnitOfWork uow;

        public DeparturesService(IMapper mapper, AbstractValidator<Departure> validator, IUnitOfWork uow)
        {

            this.mapper = mapper;
            this.validator = validator;
            this.uow = uow;

        }
        
        public async Task<List<DepartureDTO>> Get()
        {
            return mapper.Map<List<Departure>, List<DepartureDTO>>(await uow.Departures.GetAll());
        }

        public async Task<DepartureDTO> GetById(int id)
        {
            return mapper.Map<DepartureDTO>(await uow.Departures.Get(id));
        }

        public async Task Create(DepartureDTO item)
        {

            var model = mapper.Map<DepartureDTO, Departure>(item);
            var validationResult = validator.Validate(model);

            if (validationResult.IsValid)
            {
                await uow.Departures.Create(model);
                await uow.SaveAsync();
            }

            throw new ValidationException(validationResult.Errors);

        }

        public async Task Update(int id, DepartureDTO modelDTO)
        {
            var source = uow.Departures.Get(id);
            var dest = mapper.Map<DepartureDTO, Departure>(modelDTO);
            await uow.Departures.Update(dest);
            await uow.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await uow.Departures.Delete(id);
            await uow.SaveAsync();
        }

        public async Task Update(DepartureDTO modelDTO)
        {
            var dest = mapper.Map<DepartureDTO, Departure>(modelDTO);
            await uow.Departures.Update(dest);
        }


    }
}
