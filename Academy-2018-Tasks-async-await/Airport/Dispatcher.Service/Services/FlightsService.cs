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
using System.Timers;

namespace BL.Service.Services
{
    public class FlightsService : IFlightService
    {
        private readonly IMapper mapper;
        private readonly AbstractValidator<Flight> validator;
        private IUnitOfWork uow;

        public FlightsService(IMapper mapper, AbstractValidator<Flight> validator, IUnitOfWork uow)
        {

            this.mapper = mapper;
            this.validator = validator;
            this.uow = uow;

        }

        public async Task<List<FlightDTO>> GetWithDelay()
        {
            var completionSource = new TaskCompletionSource<List<FlightDTO>>();
            Timer delay = new Timer(7777);
            var flights = mapper.Map<List<Flight>, List<FlightDTO>>(await uow.Flights.GetAll());
            delay.Elapsed += delegate { delay.Dispose(); completionSource.SetResult(flights); };
            delay.Start();
            return await completionSource.Task;
        }

      

        public async Task<List<FlightDTO>> Get()
        {
            return mapper.Map<List<Flight>, List<FlightDTO>>(await uow.Flights.GetAll());
        }

        public async Task<FlightDTO> GetById(int id)
        {
            return mapper.Map<FlightDTO>(await uow.Flights.Get(id));
        }

        public async Task Create(FlightDTO item)
        {

            var model = mapper.Map<FlightDTO, Flight>(item);
            var validationResult = validator.Validate(model);

            if (validationResult.IsValid)
            {
                await uow.Flights.Create(model);
                await uow.SaveAsync();
            }

            throw new ValidationException(validationResult.Errors);

        }

        public async Task Update(int id, FlightDTO modelDTO)
        {
            var source = uow.Flights.Get(id);
            var dest = mapper.Map<FlightDTO, Flight>(modelDTO);
            await uow.Flights.Update(dest);
            await uow.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await uow.Flights.Delete(id);
            await uow.SaveAsync();
        }

        public async Task Update(FlightDTO modelDTO)
        {
            var dest = mapper.Map<FlightDTO, Flight>(modelDTO);
            await uow.Flights.Update(dest);
        }

        }
}
