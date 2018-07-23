using System.Collections.Generic;
using Shared.DTO;
using AutoMapper;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using System;
using System.Linq;
using FluentValidation;

namespace BL.Service.Services
{
    public class AirplanesService : IService<AirplaneDTO>
    {
        IUnitOfWorkFactory UoWFactory { get; set; }

        private readonly IMapper mymapper;
        private readonly AbstractValidator<Airplane> validator;
        private IUnitOfWork DataStore;

        public AirplanesService(IMapper mapper, IUnitOfWorkFactory unit, AbstractValidator<Airplane> validator)
        {
            UoWFactory = unit;
            mymapper = mapper;
            this.validator = validator;
            DataStore = UoWFactory.Create();

        }

        public IEnumerable<AirplaneDTO> Get()
        {
            return mymapper.Map<IEnumerable<Airplane>, IEnumerable<AirplaneDTO>>(
                DataStore.Repository<Airplane>().GetAll());
        }

        public AirplaneDTO GetById(int id)
        {
            return mymapper.Map<AirplaneDTO>(DataStore.Repository<Airplane>().Get(id));
        }

        public void Create(string name, DateTime creationDate, int lifetime, int type)
        {
           var modelDTO = new AirplaneDTO { 
              
                CreationDate = creationDate,
                Lifetime =lifetime,
               Type = mymapper.Map<AirplaneTypeDTO>(DataStore.Repository<AirplaneType>().Get(type)),
               Name = name
            };
           
            DataStore.Repository<Airplane>().Create(mymapper.Map<AirplaneDTO, Airplane>(modelDTO));
            DataStore.Save();
        }

        public void Update(string name, DateTime creationDate, int lifetime, int type, int id)
        {
            var modelDTO = new AirplaneDTO
            {
                Id = id,
                CreationDate = creationDate,
                Lifetime = lifetime,
                Type = mymapper.Map<AirplaneTypeDTO>(DataStore.Repository<AirplaneType>().Get(type)),
                Name = name
            };

            var dest = mymapper.Map<AirplaneDTO, Airplane>(modelDTO);
            DataStore.Repository<Airplane>().Update(dest);
            DataStore.Save();
        }
        
        public void Update(int id, int lifetime)
        {
            var modelDTO = mymapper.Map<AirplaneDTO>(DataStore.Repository<Airplane>().Get(id));
            modelDTO.Lifetime = lifetime;
            var dest = mymapper.Map<AirplaneDTO, Airplane>(modelDTO);
            DataStore.Repository<Airplane>().Update(dest);
            DataStore.Save();
        }
        
        public void Delete(int id)
        {
            var model = DataStore.Repository<Airplane>().Get(id);
            DataStore.Repository<Airplane>().Delete(model);
            DataStore.Save();
        }

    
    }
}
