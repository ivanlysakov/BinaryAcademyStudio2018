using System.Collections.Generic;
using Shared.DTO;
using AutoMapper;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using System;
using System.Linq;

namespace BL.Service.Services
{
    public class AirplanesService : IService<AirplaneDTO>
    {
        IUnitOfWork DataStore { get; set; }

        private readonly IMapper mymapper;

        public AirplanesService(IMapper mapper, IUnitOfWork unit)
        {
            DataStore = unit;
            mymapper = mapper;
        }

        public List<AirplaneDTO> Get()
        {
            return mymapper.Map<List<AirplaneDTO>>(DataStore.Airplanes.GetAll());
        }

        public AirplaneDTO GetById(int? id)
        {
            return mymapper.Map<AirplaneDTO>(DataStore.Airplanes.Get(id));
        }

        public void Create(string name, DateTime creationDate, long lifetime, int type)
        {
           var modelDTO = new AirplaneDTO { 
                Id = DataStore.Airplanes.GetAll().Max(s => s.Id) + 1, 
                CreationDate = creationDate,
                Lifetime =lifetime,
                Type = type,
                Name = name
            };
           
            DataStore.Airplanes.Create(mymapper.Map<AirplaneDTO, Airplane>(modelDTO));
            DataStore.Save();
        }

        public void Update(string name, DateTime creationDate, long lifetime, int type, int id)
        {
            var modelDTO = new AirplaneDTO
            {
                Id = id,
                CreationDate = creationDate,
                Lifetime = lifetime,
                Type = type,
                Name = name
            };

            var dest = mymapper.Map<AirplaneDTO, Airplane>(modelDTO);
            DataStore.Airplanes.Update(dest);
            DataStore.Save();
        }
        
        public void Update(int id, long lifetime)
        {
            var modelDTO = mymapper.Map<AirplaneDTO>(DataStore.Airplanes.Get(id));
            modelDTO.Lifetime = lifetime;
            var dest = mymapper.Map<AirplaneDTO, Airplane>(modelDTO);
            DataStore.Airplanes.Update(dest);
            DataStore.Save();
        }
        
        public void Delete(int? id)
        {
            var model = DataStore.Airplanes.Get(id);
            DataStore.Airplanes.Delete(model);
            DataStore.Save();
        }

        
    }
}
