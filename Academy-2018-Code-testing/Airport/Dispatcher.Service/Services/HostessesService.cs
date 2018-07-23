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
    public class HostessesService : IService<HostessDTO>
    {
        IUnitOfWorkFactory UoWFactory { get; set; }

        private readonly IMapper mymapper;
        private readonly AbstractValidator<Hostess> validator;
        private IUnitOfWork DataStore;

        public HostessesService(IMapper mapper, IUnitOfWorkFactory unit, AbstractValidator<Hostess> validator)
        {
            UoWFactory = unit;
            mymapper = mapper;
            this.validator = validator;
            DataStore = UoWFactory.Create();

        }

        public IEnumerable<HostessDTO> Get()
        {
            return mymapper.Map<IEnumerable<Hostess>, IEnumerable<HostessDTO>>(
               DataStore.Repository<Hostess>().GetAll());
        }

        public HostessDTO GetById(int id)
        {
            return mymapper.Map<HostessDTO>(DataStore.Repository<Hostess>().Get(id));
        }
        
        public void Create(string firstname, string lastname, DateTime birthday, int crew)
        {
            var modelDTO = new HostessDTO
            {
               CrewID = crew,
                FirstName = firstname,
                Lastname = lastname,
                BirthDay = birthday,
                
            };

            DataStore.Repository<Hostess>().Create(mymapper.Map<HostessDTO, Hostess>(modelDTO));
            DataStore.Save();
        }
        
        public void Update(string firstname, string lastname, DateTime birthday, int id, int crew)
        {
            var modelDTO = new HostessDTO
            {
                CrewID = crew,
                Id = id,
                FirstName = firstname,
                Lastname = lastname,
                BirthDay = birthday,
            };

            var dest = mymapper.Map<HostessDTO, Hostess>(modelDTO);
            DataStore.Repository<Hostess>().Update(dest);
            DataStore.Save();
        }

        public void Delete(int id)
        {
            var model = DataStore.Repository<Hostess>().Get(id);
            DataStore.Repository<Hostess>().Delete(model);
            DataStore.Save();
        }

       
    }
}
