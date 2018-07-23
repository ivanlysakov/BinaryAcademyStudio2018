using AutoMapper;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using BL.Service.Services;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FluentValidation;
using BL.Service.Interfaces;
using System.Threading.Tasks;

namespace BL.Service.Services
{
    public class AirplaneTypesService : IAirplaneTypesService
    {
        private readonly IMapper mapper;
        private readonly AbstractValidator<AirplaneType> validator;
        private IUnitOfWork uow;

        public AirplaneTypesService(IMapper mapper, AbstractValidator<AirplaneType> validator, IUnitOfWork uow)
        {

            this.mapper = mapper;
            this.validator = validator;
            this.uow = uow;

        }
        
        public async Task<List<AirplaneTypeDTO>> Get()
        {
            return mapper.Map<List<AirplaneType>, List<AirplaneTypeDTO>>(await uow.AirplaneTypes.GetAll());
        }

        public async Task<AirplaneTypeDTO> GetById(int id)
        {
            return mapper.Map<AirplaneTypeDTO>(await uow.AirplaneTypes.Get(id));
        }

        public async Task Create(AirplaneTypeDTO item)
        {

            var model = mapper.Map<AirplaneTypeDTO, AirplaneType>(item);
            var validationResult = validator.Validate(model);

            if (validationResult.IsValid)
            {
                await uow.AirplaneTypes.Create(model);
                await uow.SaveAsync();
            }

            throw new ValidationException(validationResult.Errors);

        }

        public async Task Update(int id, AirplaneTypeDTO modelDTO)
        {
            var source = uow.AirplaneTypes.Get(id);
            var dest = mapper.Map<AirplaneTypeDTO, Airplane>(modelDTO);
            await uow.Airplanes.Update(dest);
            await uow.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await uow.Airplanes.Delete(id);
            await uow.SaveAsync();
        }

        public async Task Update(AirplaneTypeDTO modelDTO)
        {
            var dest = mapper.Map<AirplaneTypeDTO, Airplane>(modelDTO);
            await uow.Airplanes.Update(dest);
        }
    }
}

