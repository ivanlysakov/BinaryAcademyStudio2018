using System.Collections.Generic;
using Shared.DTO;
using AutoMapper;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using System;
using System.Linq;
using FluentValidation;
using System.Threading.Tasks;
using BL.Service.Interfaces;

namespace BL.Service.Services
{
    public class AirplanesService : IAirplaneService
    {
        private readonly IMapper mapper;
        private readonly AbstractValidator<Airplane> validator;
        private IUnitOfWork uow;

        public AirplanesService(IMapper mapper, AbstractValidator<Airplane> validator, IUnitOfWork uow)
        {

            this.mapper = mapper;
            this.validator = validator;
            this.uow = uow;
        }

        public async Task<List<AirplaneDTO>> Get()
        {
            return mapper.Map<List<Airplane>, List<AirplaneDTO>>(await uow.Airplanes.GetAll());
        }

        public async Task<AirplaneDTO> GetById(int id)
        {
            return mapper.Map<AirplaneDTO>(await uow.Airplanes.Get(id));
        }

        public async Task Create(AirplaneDTO item)
        {

            var model = mapper.Map<AirplaneDTO, Airplane>(item);
            var validationResult = validator.Validate(model);

            if (validationResult.IsValid)
            {
                await uow.Airplanes.Create(model);
                await uow.SaveAsync();
            }

            throw new ValidationException(validationResult.Errors);

        }

        public async Task Update(int id, AirplaneDTO modelDTO)
        {
            var source = uow.Airplanes.Get(id);
            var dest = mapper.Map<AirplaneDTO, Airplane>(modelDTO);
            await uow.Airplanes.Update(dest);
            await uow.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await uow.Airplanes.Delete(id);
            await uow.SaveAsync();
        }

        public async Task Update(AirplaneDTO modelDTO)
        {
            var dest = mapper.Map<AirplaneDTO, Airplane>(modelDTO);
            await uow.Airplanes.Update(dest);
        }

        public Task<List<AirplaneDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        
    }
}
