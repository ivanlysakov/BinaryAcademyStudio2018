using System.Collections.Generic;
using Shared.DTO;
using AutoMapper;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using System;
using BL.Service.Services;
using System.Linq;

namespace BL.Service.Services
{
    public class FlightsService : IService<FlightDTO>
    {
        IUnitOfWork DataStore { get; set; }

        private readonly IMapper mymapper;

        public FlightsService(IMapper mapper, IUnitOfWork unit)
        {
            DataStore = unit;
            mymapper = mapper;
        }

        public List<FlightDTO> Get()
        {
            return mymapper.Map<List<FlightDTO>>(DataStore.Flights.GetAll());
        }

        public FlightDTO GetById(int? id)
        {
            return mymapper.Map<FlightDTO>(DataStore.Flights.Get(id));
        }

        public void Create(string flightNumber, string departure, DateTime departureTime, string destination, DateTime arrivalTime, int[] tickets)
        {

            var ticks = new List<TicketDTO>();
            foreach (var item in tickets)
            {
                ticks.Add(mymapper.Map<TicketDTO>(DataStore.Tickets.Get(item)));
            }


            var modelDTO = new FlightDTO
            {
                Id = DataStore.Pilots.GetAll().Max(s => s.Id) + 1,
                Number = flightNumber,
                Departure = departure,
                DepartureTime = departureTime,
                Destination = destination,
                ArrivalTime = arrivalTime,
                Tickets = ticks
            };

            DataStore.Flights.Create(mymapper.Map<FlightDTO, Flight>(modelDTO));
            DataStore.Save();
        }

        public void Update(string flightNumber, string departure, DateTime departureTime, string destination, DateTime arrivalTime, int[] tickets, int id)
        {
            var ticks = new List<TicketDTO>();
            foreach (var item in tickets)
            {
                ticks.Add(mymapper.Map<TicketDTO>(DataStore.Tickets.Get(item)));
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
            DataStore.Flights.Update(dest);
            DataStore.Save();
        }

        public void Update(int id, DateTime departureTime)
        {
            var modelDTO = mymapper.Map<FlightDTO>(DataStore.Flights.Get(id));
            modelDTO.DepartureTime = departureTime;
            var dest = mymapper.Map<FlightDTO, Flight>(modelDTO);
            DataStore.Flights.Update(dest);
            DataStore.Save();
        }

        public void Delete(int? id)
        {
            var model = DataStore.Flights.Get(id);
            DataStore.Flights.Delete(model);
            DataStore.Save();
        }

    }
}
