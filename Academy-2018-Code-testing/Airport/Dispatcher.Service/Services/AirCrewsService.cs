using AutoMapper;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using FluentValidation;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Service.Services
{
    public class AirCrewsService : IService<CrewDTO>
    {
        IUnitOfWorkFactory UoWFactory { get; set; }

        private readonly IMapper mymapper;
        private readonly AbstractValidator<Crew> validator;
        private IUnitOfWork DataStore; 

        public AirCrewsService(IMapper mapper, IUnitOfWorkFactory unit, AbstractValidator<Crew> validator)
        {
            UoWFactory = unit;
            mymapper = mapper;
            this.validator=validator;
            DataStore = UoWFactory.Create();
            
        }

        

        public IEnumerable<CrewDTO> Get()
        {
            return mymapper.Map<IEnumerable<Crew>, IEnumerable<CrewDTO>>(
               DataStore.Repository<Crew>().GetAll());
        }

        public CrewDTO GetById(int id)
        {
            return mymapper.Map<CrewDTO>(DataStore.Repository<Crew>().Get(id));
        }

        public void Create(int pilotId, int[] hostessId)
        {
            
            var hostess = DataStore.Repository<Hostess>().Get(x => hostessId.Contains(x.Id)).ToList();
                                    
            var modelDTO = new CrewDTO
            {
                Pilot = mymapper.Map<PilotDTO>(DataStore.Repository<Pilot>().Get(pilotId)),
                Hostesses = mymapper.Map<List<HostessDTO>>(hostess)
            };

            var model = mymapper.Map<CrewDTO, Crew>(modelDTO);
            var validationResult = validator.Validate(model);

            if (validationResult.IsValid)
            {
               
                DataStore.Repository<Crew>().Create(model);
                DataStore.Save();
            }

            throw new ValidationException(validationResult.Errors);

        }


        public void Create(CrewDTO crewDTO)
        {

            
            var model = mymapper.Map<CrewDTO, Crew>(crewDTO);
            var validationResult = validator.Validate(model);

            if (validationResult.IsValid)
            {

                DataStore.Repository<Crew>().Create(model);
                DataStore.Save();
            }

            throw new ValidationException(validationResult.Errors);

        }



        public void Update(int pilotId, int[] hostessId, int id)
        {
            var hostess = new List<HostessDTO>();
            foreach (var item in hostessId)
            {
                hostess.Add(mymapper.Map<HostessDTO>(DataStore.Repository<Hostess>().Get(item)));
            }
            
            var modelDTO = new CrewDTO
            {
                Id = id,
                Pilot = mymapper.Map<PilotDTO>(DataStore.Repository<Pilot>().Get(pilotId)),
                Hostesses = hostess
            };

            var dest = mymapper.Map<CrewDTO, Crew>(modelDTO);
            DataStore.Repository<Crew>().Update(dest);
            DataStore.Save();
        }
        
        public void Update(int id, CrewDTO modelDTO)
        {
            var source = DataStore.Repository<Crew>().Get(id);
            var dest = mymapper.Map<CrewDTO, Crew>(modelDTO);
            DataStore.Repository<Crew>().Update(dest);
            DataStore.Save();
        }

        public void Delete(int id)
        {
            var model = DataStore.Repository<Crew>().Get(id);
            DataStore.Repository<Crew>().Delete(model);
            DataStore.Save();
        }
    }
}
