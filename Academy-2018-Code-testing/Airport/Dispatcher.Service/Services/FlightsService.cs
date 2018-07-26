using System.Collections.Generic;
using Shared.DTO;
using AutoMapper;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using System;
using BL.Service.Services;
using System.Linq;
using FluentValidation;

namespace BL.Service.Services
{
    public class FlightsService : IService<FlightDTO>
    {
        IUnitOfWorkFactory UoWFactory { get; set; }

        private readonly IMapper mymapper;
        private readonly AbstractValidator<Flight> validator;
        private IUnitOfWork DataStore;

        public FlightsService(IMapper mapper, IUnitOfWorkFactory unit, AbstractValidator<Flight> validator)
        {
            UoWFactory = unit;
            mymapper = mapper;
            this.validator = validator;
            DataStore = UoWFactory.Create();

        }


        public IEnumerable<FlightDTO> Get()
        {
            return mymapper.Map<IEnumerable<Flight>, IEnumerable<FlightDTO>>(
               DataStore.Repository<Flight>().GetAll());
        }

        public FlightDTO GetById(int id)
        {
            return mymapper.Map<FlightDTO>(DataStore.Repository<Flight>().Get(id));
        }

        public void Create(string flightNumber, string departure, DateTime departureTime, string destination, DateTime arrivalTime, int[] tickets)
        {

            var ticks = new List<TicketDTO>();
            foreach (var item in tickets)
            {
                ticks.Add(mymapper.Map<TicketDTO>(DataStore.Repository<Ticket>().Get(item)));
            }


            var modelDTO = new FlightDTO
            {
                
                Number = flightNumber,
                Departure = departure,
                DepartureTime = departureTime,
                Destination = destination,
                ArrivalTime = arrivalTime,
                Tickets = ticks
            };

            DataStore.Repository<Flight>().Create(mymapper.Map<FlightDTO, Flight>(modelDTO));
            DataStore.Save();
        }

        public void Update(string flightNumber, string departure, DateTime departureTime, string destination, DateTime arrivalTime, int[] tickets, int id)
        {
            var ticks = new List<TicketDTO>();
            foreach (var item in tickets)
            {
                ticks.Add(mymapper.Map<TicketDTO>(DataStore.Repository<Ticket>().Get(item)));
            }

            var modelDTO = new FlightDTO
            {
                Id = id,
                Number = flightNumber,
                Departure = departure,
                DepartureTime = departureTime,
                Destination = destination,
                ArrivalTime = arrivalTime,
                Tickets = ticks
            };

            var dest = mymapper.Map<FlightDTO, Flight>(modelDTO);
            DataStore.Repository<Flight>().Update(dest);
            DataStore.Save();
        }

        public void Update(int id, DateTime departureTime)
        {
            var modelDTO = mymapper.Map<FlightDTO>(DataStore.Repository<Flight>().Get(id));
            modelDTO.DepartureTime = departureTime;
            var dest = mymapper.Map<FlightDTO, Flight>(modelDTO);
            DataStore.Repository<Flight>().Update(dest);
            DataStore.Save();
        }

        public void Delete(int id)
        {
            var model = DataStore.Repository<Flight>().Get(id);
            DataStore.Repository<Flight>().Delete(model);
            DataStore.Save();
        }

    }
}
