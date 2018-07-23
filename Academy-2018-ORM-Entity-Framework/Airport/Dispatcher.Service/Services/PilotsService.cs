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
    public class PilotsService : IService<PilotDTO>
    {
        IUnitOfWork DataStore { get; set; }

        private readonly IMapper mymapper;

        public PilotsService(IMapper mapper, IUnitOfWork unit)
        {
            DataStore = unit;
            mymapper = mapper;
        }

        public List<PilotDTO> Get()
        {
            return mymapper.Map<List<PilotDTO>>(DataStore.Pilots.GetAll());
        }

        public PilotDTO GetById(int? id)
        {
            return mymapper.Map<PilotDTO>(DataStore.Pilots.Get(id));
        }

        public void Create(string firstname, string lastname, DateTime birthday, int experience)
        {
            var modelDTO = new PilotDTO
            {
                Id = DataStore.Pilots.GetAll().Max(s => s.Id) + 1,
                FirstName = firstname,
                Lastname = lastname,
                BirthDay = birthday,
                Experience = experience
            };

            DataStore.Pilots.Create(mymapper.Map<PilotDTO, Pilot>(modelDTO));
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
            DataStore.Pilots.Update(dest);
            DataStore.Save();
        }

        public void Update(int id, int experience)
        {
            var modelDTO = mymapper.Map<PilotDTO>(DataStore.Pilots.Get(id));
            modelDTO.Experience = experience;
            var dest = mymapper.Map<PilotDTO, Pilot>(modelDTO);
            DataStore.Pilots.Update(dest);
            DataStore.Save();
        }
                  
        public void Delete(int? id)
        {
            var model = DataStore.Pilots.Get(id);
            DataStore.Pilots.Delete(model);
            DataStore.Save();
        }
    }

}
