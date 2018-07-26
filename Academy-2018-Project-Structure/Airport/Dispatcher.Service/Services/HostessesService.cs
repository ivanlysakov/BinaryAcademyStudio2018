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
    public class HostessesService : IService<HostessDTO>
    {
        IUnitOfWork DataStore { get; set; }

        private readonly IMapper mymapper;

        public HostessesService(IMapper mapper, IUnitOfWork unit)
        {
            DataStore = unit;
            mymapper = mapper;
        }

        public List<HostessDTO> Get()
        {
            return mymapper.Map<List<HostessDTO>>(DataStore.AirHostesses.GetAll());
        }

        public HostessDTO GetById(int? id)
        {
            return mymapper.Map<HostessDTO>(DataStore.AirHostesses.Get(id));
        }
        
        public void Create(string firstname, string lastname, DateTime birthday)
        {
            var modelDTO = new HostessDTO
            {
                Id = DataStore.AirHostesses.GetAll().Max(s => s.Id) + 1,
                FirstName = firstname,
                Lastname = lastname,
                BirthDay = birthday,
                
            };

            DataStore.AirHostesses.Create(mymapper.Map<HostessDTO, Hostess>(modelDTO));
        }
        
        public void Update(string firstname, string lastname, DateTime birthday, int id)
        {
            var modelDTO = new HostessDTO
            {
                Id = id,
                FirstName = firstname,
                Lastname = lastname,
                BirthDay = birthday,
            };

            var dest = mymapper.Map<HostessDTO, Hostess>(modelDTO);
            DataStore.AirHostesses.Update(dest, id);
        }

        public void Delete(int? id)
        {
            var model = DataStore.AirHostesses.Get(id);
            DataStore.AirHostesses.Delete(model);
        }

       
    }
}
