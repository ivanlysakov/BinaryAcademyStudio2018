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
    public class DeparturesService : IService<DepartureDTO>
    {
        IUnitOfWork DataStore { get; set; }

        private readonly IMapper mymapper;

        public DeparturesService(IMapper mapper, IUnitOfWork unit)
        {
            DataStore = unit;
            mymapper = mapper;
        }

        public List<DepartureDTO> Get()
        {
            return mymapper.Map<List<DepartureDTO>>(DataStore.Departures.GetAll());
        }

        public DepartureDTO GetById(int? id)
        {
            return mymapper.Map<DepartureDTO>(DataStore.Departures.Get(id));
        }

        public void Create(string flightnumber, DateTime time, int crewid, int airplaneId)
        {
            var modelDTO = new DepartureDTO
            {
                Id = DataStore.Departures.GetAll().Max(s => s.Id) + 1,
                FlightNumber = flightnumber,
                Time = time,
                Crew = mymapper.Map<CrewDTO>(DataStore.Crews.Get(crewid)),
                Airplane = mymapper.Map<AirplaneDTO>(DataStore.Airplanes.Get(airplaneId))
            };
            DataStore.Departures.Create(mymapper.Map<DepartureDTO, Departure>(modelDTO));
            DataStore.Save();
        }

        public void Update(string flightnumber, DateTime time, int crewid, int airplaneId,int id)
        {
            var modelDTO = new DepartureDTO
            {
                Id = id,
                FlightNumber = flightnumber,
                Time = time,
                Crew = mymapper.Map<CrewDTO>(DataStore.Crews.Get(crewid)),
                Airplane = mymapper.Map<AirplaneDTO>(DataStore.Airplanes.Get(airplaneId))
            };

            var dest = mymapper.Map<DepartureDTO, Departure>(modelDTO);
            DataStore.Departures.Update(dest);
            DataStore.Save();
        }

        public void Update(int id, DateTime time)
        {
            var modelDTO = mymapper.Map<DepartureDTO>(DataStore.Departures.Get(id));
            modelDTO.Time = time;
            var dest = mymapper.Map<DepartureDTO, Departure>(modelDTO);
            DataStore.Departures.Update(dest);
            DataStore.Save(); ;
        }
        
        public void Delete(int? id)
        {
            var model = DataStore.Departures.Get(id);
            DataStore.Departures.Delete(model);
            DataStore.Save();
        }

        
    }
}
