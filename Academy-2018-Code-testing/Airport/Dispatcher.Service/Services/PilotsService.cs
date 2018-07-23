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
    public class PilotsService : IService<PilotDTO>
    {
        IUnitOfWorkFactory UoWFactory { get; set; }

        private readonly IMapper mymapper;
        private readonly AbstractValidator<Pilot> validator;
        private IUnitOfWork DataStore;

        public PilotsService(IMapper mapper, IUnitOfWorkFactory unit, AbstractValidator<Pilot> validator)
        {
            UoWFactory = unit;
            mymapper = mapper;
            this.validator = validator;
            DataStore = UoWFactory.Create();

        }

        public IEnumerable<PilotDTO> Get()
        {
            return mymapper.Map<IEnumerable<Pilot>, IEnumerable<PilotDTO>>(
               DataStore.Repository<Pilot>().GetAll());
        }

        public PilotDTO GetById(int id)
        {
            return mymapper.Map<PilotDTO>(DataStore.Repository<Pilot>().Get(id));
        }

        public void Create(string firstname, string lastname, DateTime birthday, int experience, int crew)
        {
            var modelDTO = new PilotDTO
            {
              
                FirstName = firstname,
                Lastname = lastname,
                BirthDay = birthday,
                Experience = experience,
                CrewID = crew
                
            };

            DataStore.Repository<Pilot>().Create(mymapper.Map<PilotDTO, Pilot>(modelDTO));
            DataStore.Save();
        }

        public void Update(string firstname, string lastname, DateTime birthday, int experience, int id)
        {
            var modelDTO = new PilotDTO
            {
                Id = id,
                FirstName = firstname,
                Lastname = lastname,
                BirthDay = birthday,
                Experience = experience
            };

            var dest = mymapper.Map<PilotDTO, Pilot>(modelDTO);
            DataStore.Repository<Pilot>().Update(dest);
            DataStore.Save();
        }

        public void Update(int id, int experience)
        {
            var modelDTO = mymapper.Map<PilotDTO>(DataStore.Repository<Pilot>().Get(id));
            modelDTO.Experience = experience;
            var dest = mymapper.Map<PilotDTO, Pilot>(modelDTO);
            DataStore.Repository<Pilot>().Update(dest);
            DataStore.Save();
        }
                  
        public void Delete(int id)
        {
            var model = DataStore.Repository<Pilot>().Get(id);
            DataStore.Repository<Pilot>().Delete(model);
            DataStore.Save();
        }
    }

}
