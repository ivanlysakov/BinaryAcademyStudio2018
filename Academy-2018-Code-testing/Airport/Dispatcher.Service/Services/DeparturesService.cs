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
    public class DeparturesService : IService<DepartureDTO>
    {
        IUnitOfWorkFactory UoWFactory { get; set; }

        private readonly IMapper mymapper;
        private readonly AbstractValidator<Departure> validator;
        private IUnitOfWork DataStore;

        public DeparturesService(IMapper mapper, IUnitOfWorkFactory unit, AbstractValidator<Departure> validator)
        {
            UoWFactory = unit;
            mymapper = mapper;
            this.validator = validator;
            DataStore = UoWFactory.Create();

        }


        public IEnumerable<DepartureDTO> Get()
        {
            return mymapper.Map<IEnumerable<Departure>, IEnumerable<DepartureDTO>>(
                DataStore.Repository<Departure>().GetAll());
        }

        public DepartureDTO GetById(int id)
        {
            return mymapper.Map<DepartureDTO>(DataStore.Repository<Departure>().Get(id));
        }

        public void Create(string flightnumber, DateTime time, int crewid, int airplaneId)
        {
            var modelDTO = new DepartureDTO
            {
               
                FlightNumber = flightnumber,
                Time = time,
                Crew = mymapper.Map<CrewDTO>(DataStore.Repository<Crew>().Get(crewid)),
                Airplane = mymapper.Map<AirplaneDTO>(DataStore.Repository<Airplane>().Get(airplaneId))
            };
            DataStore.Repository<Departure>().Create(mymapper.Map<DepartureDTO, Departure>(modelDTO));
            DataStore.Save();
        }

        public void Update(string flightnumber, DateTime time, int crewid, int airplaneId, int id)
        {
            var modelDTO = new DepartureDTO
            {
                Id = id,
                FlightNumber = flightnumber,
                Time = time,
                Crew = mymapper.Map<CrewDTO>(DataStore.Repository<Crew>().Get(crewid)),
                Airplane = mymapper.Map<AirplaneDTO>(DataStore.Repository<Airplane>().Get(airplaneId))
            };

            var dest = mymapper.Map<DepartureDTO, Departure>(modelDTO);
            DataStore.Repository<Departure>().Update(dest);
            DataStore.Save();
        }

        public void Update(int id, DateTime time)
        {
            var modelDTO = mymapper.Map<DepartureDTO>(DataStore.Repository<Departure>().Get(id));
            modelDTO.Time = time;
            var dest = mymapper.Map<DepartureDTO, Departure>(modelDTO);
            DataStore.Repository<Departure>().Update(dest);
            DataStore.Save(); ;
        }

        public void Delete(int id)
        {
            var model = DataStore.Repository<Departure>().Get(id);
            DataStore.Repository<Departure>().Delete(model);
            DataStore.Save();
        }


    }
}
