using System.Collections.Generic;
using Shared.DTO;
using AutoMapper;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using System;
using BL.Service.Services;
using System.Linq;
using BL.Service.Interfaces;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace BL.Service.Services
{
    public class TicketsService : ITicketsService
    {
        IUnitOfWorkFactory UoWFactory { get; set; }

        private readonly IMapper mymapper;
        private readonly AbstractValidator<Ticket> validator;
        private IUnitOfWork DataStore;

        public TicketsService(IMapper mapper, IUnitOfWorkFactory unit, AbstractValidator<Ticket> validator)
        {
            UoWFactory = unit;
            mymapper = mapper;
            this.validator = validator;
            DataStore = UoWFactory.Create();

        }

        public IEnumerable<TicketDTO> Get()
        {
            return mymapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDTO>>(
               DataStore.Repository<Ticket>().GetAll());
        }

        public TicketDTO GetById(int id)
        {
            return mymapper.Map<TicketDTO>(DataStore.Repository<Ticket>().Get(id));
        }
               
        public void Create(TicketDTO modelDTO)
        {
            DataStore.Repository<Ticket>().Create(mymapper.Map<TicketDTO, Ticket>(modelDTO));
            DataStore.Save();
        }

        public void Update(TicketDTO modelDTO, int id)
        {
            var ticket = DataStore.Repository<Ticket>().Get(id);

            if (ticket == null)
                throw new System.ComponentModel.DataAnnotations.ValidationException($"Ticket with this id {modelDTO.Id} not found");
            if (modelDTO.Price > 0)
                ticket.Price = modelDTO.Price;
            if (modelDTO.FlightNumber != null)
                ticket.FlightNumber = modelDTO.FlightNumber;
            if (modelDTO.FlightId > 0)
                ticket.FlightId = modelDTO.FlightId;



            var dest = mymapper.Map<TicketDTO, Ticket>(modelDTO);
            DataStore.Repository<Ticket>().Update(dest);
        }

        public void Update(int id, int price)
        {
            var modelDTO = mymapper.Map<TicketDTO>(DataStore.Repository<Ticket>().Get(id));
            modelDTO.Price = price;
            var dest = mymapper.Map<TicketDTO, Ticket>(modelDTO);
            DataStore.Repository<Ticket>().Update(dest);
            DataStore.Save();
        }

        public void Delete(int id)
        {
            var model = DataStore.Repository<Ticket>().Get(id);
            DataStore.Repository<Ticket>().Delete(model);
            DataStore.Save();
        }
    }
}
