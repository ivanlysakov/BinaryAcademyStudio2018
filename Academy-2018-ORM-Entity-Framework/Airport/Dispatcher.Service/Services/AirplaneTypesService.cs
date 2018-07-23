using AutoMapper;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using BL.Service.Services;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BL.Service.Services
{
    public class AirplaneTypesService : IService<AirplaneTypeDTO>
    {
        IUnitOfWork DataStore { get; set; }

        private readonly IMapper mymapper;

        public AirplaneTypesService(IMapper mapper, IUnitOfWork unit)
        {
            DataStore = unit;
            mymapper = mapper;
        }

        public List<AirplaneTypeDTO> Get()
        {
            return mymapper.Map<List<AirplaneTypeDTO>>(DataStore.AirplaneTypes.GetAll());
        }

        public AirplaneTypeDTO GetById(int? id)
        {
            return mymapper.Map<AirplaneTypeDTO>(DataStore.AirplaneTypes.Get(id));
        }
                
        public void Create(string model, int capacity, int cargo)
        {
            var modelDTO = new AirplaneTypeDTO
            {
                Id = DataStore.AirplaneTypes.GetAll().Max(s => s.Id) + 1,
                Model =model,
                Capacity =capacity,
                Cargo=cargo
            };

            DataStore.AirplaneTypes.Create(mymapper.Map<AirplaneTypeDTO, AirplaneType>(modelDTO));
            DataStore.Save();
        }
        
        public void Update(string model, int capacity, int cargo, int id)
        {
            var modelDTO = new AirplaneTypeDTO
            {
                Id = id,
                Model = model,
                Capacity = capacity,
                Cargo = cargo
            };

            var dest = mymapper.Map<AirplaneTypeDTO, AirplaneType>(modelDTO);
            DataStore.AirplaneTypes.Update(dest);
            DataStore.Save();
        }
        
        public void Delete(int? id)
        {
            var model = DataStore.AirplaneTypes.Get(id);
            DataStore.AirplaneTypes.Delete(model);
            DataStore.Save();
        }


    }
}

