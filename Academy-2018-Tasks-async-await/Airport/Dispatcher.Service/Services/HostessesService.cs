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
    public class HostessesService : IHostessesService
    {
        private readonly IMapper mapper;
        private readonly AbstractValidator<Hostess> validator;
        private IUnitOfWork uow;

        public HostessesService(IMapper mapper, AbstractValidator<Hostess> validator, IUnitOfWork uow)
        {

            this.mapper = mapper;
            this.validator = validator;
            this.uow = uow;

        }

        public async Task<List<HostessDTO>> Get()
        {
            return mapper.Map<List<Hostess>, List<HostessDTO>>(await uow.AirHostesses.GetAll());
        }

        public async Task<HostessDTO> GetById(int id)
        {
            return mapper.Map<HostessDTO>(await uow.AirHostesses.Get(id));
        }

        public async Task Create(HostessDTO item)
        {

            var model = mapper.Map<HostessDTO, Hostess>(item);
            var validationResult = validator.Validate(model);

            if (validationResult.IsValid)
            {
                await uow.AirHostesses.Create(model);
                await uow.SaveAsync();
            }

            throw new ValidationException(validationResult.Errors);

        }

        public async Task Update(int id, HostessDTO modelDTO)
        {
            var source = uow.AirHostesses.Get(id);
            var dest = mapper.Map<HostessDTO, Hostess>(modelDTO);
            await uow.AirHostesses.Update(dest);
            await uow.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await uow.AirHostesses.Delete(id);
            await uow.SaveAsync();
        }

        public async Task Update(HostessDTO modelDTO)
        {
            var dest = mapper.Map<HostessDTO, Hostess>(modelDTO);
            await uow.AirHostesses.Update(dest);
        }

    }
}
