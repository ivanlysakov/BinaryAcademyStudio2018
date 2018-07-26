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
using System.Threading.Tasks;

namespace BL.Service.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly IMapper mapper;
        private readonly AbstractValidator<Ticket> validator;
        private IUnitOfWork uow;

        public TicketsService(IMapper mapper, AbstractValidator<Ticket> validator, IUnitOfWork uow)
        {

            this.mapper = mapper;
            this.validator = validator;
            this.uow = uow;
        }

        public async Task<List<TicketDTO>> Get()
        {
            return mapper.Map<List<Ticket>, List<TicketDTO>>(await uow.Tickets.GetAll());
        }

        public async Task<TicketDTO> GetById(int id)
        {
            return mapper.Map<TicketDTO>(await uow.Tickets.Get(id));
        }

        public async Task Create(TicketDTO modelDTO)
        {
            await uow.Tickets.Create(mapper.Map<TicketDTO, Ticket>(modelDTO));
            uow.Save();
        }

        public async Task Update(TicketDTO modelDTO)
        {
            var dest = mapper.Map<TicketDTO, Ticket>(modelDTO);
            await uow.Tickets.Update(dest);
        }
        public async Task Update(int id, TicketDTO modelDTO)

        {
            var source = uow.Tickets.Get(id);
            var dest = mapper.Map<TicketDTO, Ticket>(modelDTO);
            await uow.Tickets.Update(dest);
            await uow.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await uow.Tickets.Delete(id);
            await uow.SaveAsync();
        }


    }
}
