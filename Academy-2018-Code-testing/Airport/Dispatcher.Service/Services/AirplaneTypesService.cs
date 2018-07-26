using AutoMapper;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using BL.Service.Services;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FluentValidation;

namespace BL.Service.Services
{
    public class AirplaneTypesService : IService<AirplaneTypeDTO>
    {
        IUnitOfWorkFactory UoWFactory { get; set; }

        private readonly IMapper mymapper;
        private readonly AbstractValidator<AirplaneType> validator;
        private IUnitOfWork DataStore;

        public AirplaneTypesService(IMapper mapper, IUnitOfWorkFactory unit, AbstractValidator<AirplaneType> validator)
        {
            UoWFactory = unit;
            mymapper = mapper;
            this.validator = validator;
            DataStore = UoWFactory.Create();

        }

        public IEnumerable<AirplaneTypeDTO> Get()
        {
            return mymapper.Map<IEnumerable<AirplaneType>, IEnumerable<AirplaneTypeDTO>>(
               DataStore.Repository<AirplaneType>().GetAll());
        }

        public AirplaneTypeDTO GetById(int id)
        {
            return mymapper.Map<AirplaneTypeDTO>(DataStore.Repository<AirplaneType>().Get(id));
        }
                
        public void Create(string model, int capacity, int cargo)
        {
            var modelDTO = new AirplaneTypeDTO
            {
              
                Model =model,
                Capacity =capacity,
                Cargo=cargo
            };

            DataStore.Repository<AirplaneType>().Create(mymapper.Map<AirplaneTypeDTO, AirplaneType>(modelDTO));
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
            DataStore.Repository<AirplaneType>().Update(dest);
            DataStore.Save();
        }
        
        public void Delete(int id)
        {
            var model = DataStore.Repository<AirplaneType>().Get(id);
            DataStore.Repository<AirplaneType>().Delete(model);
            DataStore.Save();
        }


    }
}

