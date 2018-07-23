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
    public class TicketsService : IService<TicketDTO>
    {
        IUnitOfWork DataStore { get; set; }

        private readonly IMapper mymapper;

        public TicketsService(IMapper mapper, IUnitOfWork unit)
        {
            DataStore = unit;
            mymapper = mapper;
        }

        public List<TicketDTO> Get()
        {
            return mymapper.Map<List<TicketDTO>>(DataStore.Tickets.GetAll());
        }

        public TicketDTO GetById(int? id)
        {
            return mymapper.Map<TicketDTO>(DataStore.Tickets.Get(id));
        }
               
        public void Create(string flightnumber, int price)
        {
            var modelDTO = new TicketDTO
            {
                Id = DataStore.Tickets.GetAll().Max(s => s.Id) + 1,
                FlightNumber = flightnumber,
                Price = price

            };
            DataStore.Tickets.Create(mymapper.Map<TicketDTO, Ticket>(modelDTO));
        }

        public void Update(string flightnumber, int price, int id)
        {
            var modelDTO = new TicketDTO
            {
                Id = id,
                FlightNumber = flightnumber,
                Price = price
            };

            var dest = mymapper.Map<TicketDTO, Ticket>(modelDTO);
            DataStore.Tickets.Update(dest, id);
        }

        public void Update(int id, int price)
        {
            var modelDTO = mymapper.Map<TicketDTO>(DataStore.Tickets.Get(id));
            modelDTO.Price = price;
            var dest = mymapper.Map<TicketDTO, Ticket>(modelDTO);
            DataStore.Tickets.Update(dest, id);
        }

        public void Delete(int? id)
        {
            var model = DataStore.Tickets.Get(id);
            DataStore.Tickets.Delete(model);
        }
    }
}
