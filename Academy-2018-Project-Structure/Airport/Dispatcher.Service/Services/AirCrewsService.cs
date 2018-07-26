using AutoMapper;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Service.Services
{
    public class AirCrewsService : IService<CrewDTO>
    {
        IUnitOfWork DataStore { get; set; }

        private readonly IMapper mymapper;

        public AirCrewsService(IMapper mapper, IUnitOfWork unit)
        {
            DataStore = unit;
            mymapper = mapper;
        }

        public List<CrewDTO> Get()
        {
            return mymapper.Map<List<CrewDTO>>(DataStore.Crews.GetAll());
        }

        public CrewDTO GetById(int? id)
        {
            return mymapper.Map<CrewDTO>(DataStore.Crews.Get(id));
        }

        public void Create(int pilotId, int[] hostessId)
        {

            var hostess = new List<HostessDTO>();
            foreach (var item in hostessId)
            {
                hostess.Add(mymapper.Map<HostessDTO>(DataStore.AirHostesses.Get(item)));
            }
            
            
            var modelDTO = new CrewDTO
            {
                Id = DataStore.AirHostesses.GetAll().Max(s => s.Id) + 1,
                Pilot = mymapper.Map<PilotDTO>(DataStore.Pilots.Get(pilotId)),
                Hostesses = hostess
            };

            DataStore.Crews.Create(mymapper.Map<CrewDTO, Crew>(modelDTO));
        }

        public void Update(int pilotId, int[] hostessId, int id)
        {
            var hostess = new List<HostessDTO>();
            foreach (var item in hostessId)
            {
                hostess.Add(mymapper.Map<HostessDTO>(DataStore.AirHostesses.Get(item)));
            }
            
            var modelDTO = new CrewDTO
            {
                Id = id,
                Pilot = mymapper.Map<PilotDTO>(DataStore.Pilots.Get(pilotId)),
                Hostesses = hostess
            };

            var dest = mymapper.Map<CrewDTO, Crew>(modelDTO);
            DataStore.Crews.Update(dest, id);
        }
        
        public void Update(int? id, CrewDTO modelDTO)
        {
            var source = DataStore.Crews.Get(id);
            var dest = mymapper.Map<CrewDTO, Crew>(modelDTO);
            DataStore.Crews.Update(dest, id);
        }

        public void Delete(int? id)
        {
            var model = DataStore.Crews.Get(id);
            DataStore.Crews.Delete(model);
        }
    }
}
