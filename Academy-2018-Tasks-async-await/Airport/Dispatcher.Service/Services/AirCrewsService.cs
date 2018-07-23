using AutoMapper;
using BL.Service.Interfaces;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using Shared.DTO;
using Shared.DTO.RemoteAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BL.Service.Services
{
    public class AirCrewsService : ICrewsService
    {

        private readonly IMapper mapper;
        private readonly AbstractValidator<Crew> validator;
        private IUnitOfWork uow;

        public AirCrewsService(IMapper mapper, AbstractValidator<Crew> validator, IUnitOfWork uow)
        {

            this.mapper = mapper;
            this.validator = validator;
            this.uow = uow;

        }

        public async Task<List<CrewDTO>> Get()
        {
            return mapper.Map<List<Crew>, List<CrewDTO>>(await uow.Crews.GetAll());
        }
        
        public async Task<string> GetRemoteApi()
        {

            var sourcsList = new List<RemoteCrewDTO>();

            var initCount = uow.Crews.GetRowsCount();

            using (var client = new HttpClient())
            {
                string url = "http://5b128555d50a5c0014ef1204.mockapi.io/crew";
                using (var r = await client.GetAsync(new Uri(url)))
                {
                    string result = await r.Content.ReadAsStringAsync();

                    sourcsList =  JsonConvert.DeserializeObject<List<RemoteCrewDTO>>(result).Take(10).ToList(); 

                }
}
            
            List<CrewDTO> listCrewDTO = new List<CrewDTO>();
            
            StringBuilder writeIntofile = new StringBuilder("");
            writeIntofile.Append(" What a beautiful day.");

            PilotDTO pilotDTO;
            List<HostessDTO> hostessDTOs;
            foreach (var c in sourcsList)
            {
                pilotDTO = mapper.Map<RemotePilotDTO, PilotDTO>(c.pilot.FirstOrDefault());
                hostessDTOs = mapper.Map<List<RemoteHostessDTO>, List<HostessDTO>>(c.stewardess);
                listCrewDTO.Add(new CrewDTO() { Pilot = pilotDTO, Hostesses = hostessDTOs });
                writeIntofile.Append($"\n Crew: {c.Id}");
                writeIntofile.Append($" \n\t Pilot: ");
                writeIntofile.Append($"  {pilotDTO.FirstName}");
                writeIntofile.Append($"  {pilotDTO.Lastname}");
                writeIntofile.Append($"  Exp:{pilotDTO.Experience};");
                writeIntofile.Append($" \n\t Hostesses: ");
                foreach (var hostess in hostessDTOs)
                {
                    writeIntofile.Append($"  {hostess.FirstName} {hostess.Lastname} {hostess.BirthDay.Year};");
                }
                c.Id = null;
            }
            Task task1 = WriteToFileAsync(writeIntofile.ToString());
            //проблема з записом в БД ....так і не переміг її((( прийшлося городити костиль в мапері
            Task task2 = uow.Crews.CreateListAsync(mapper.Map<List<CrewDTO>, List<Crew>>(listCrewDTO));
            Task task3 = uow.SaveAsync();

            await Task.WhenAll(new[] { task1,task2,task3 });


            var addedCount = uow.Crews.GetRowsCount();


            if (addedCount - initCount == 10)
            {
                return "Data added successfully!";
            }

            return "Something went wrong!";

        }

        public async Task WriteToFileAsync(string str)
        {

            foreach (string sFile in Directory.GetFiles(Directory.GetCurrentDirectory(),"*.csv"))
            {
                File.Delete(sFile);
            }

            byte[] array = Encoding.Default.GetBytes("" + str);
            string path = "file_" + DateTime.UtcNow.ToString("yyyy-dd-M--HH-mm") + ".csv";
            using (var fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                fstream.Seek(0, SeekOrigin.End);
                await fstream.WriteAsync(array, 0, array.Length);
            }
        }
        

        public async Task<CrewDTO> GetById(int id)
        {
            return mapper.Map<CrewDTO>(await uow.Crews.Get(id));
        }

        public async Task Create(CrewDTO crewDTO)
        {

            var model = mapper.Map<CrewDTO, Crew>(crewDTO);
            var validationResult = validator.Validate(model);

            if (validationResult.IsValid)
            {
                await uow.Crews.Create(model);
                await uow.SaveAsync();
            }

            throw new ValidationException(validationResult.Errors);

        }

        public async Task Update(int id, CrewDTO modelDTO)
        {
            var source = uow.Crews.Get(id);
            var dest = mapper.Map<CrewDTO, Crew>(modelDTO);
            await uow.Crews.Update(dest);
            await uow.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await uow.Crews.Delete(id);
            await uow.SaveAsync();
        }

        public async Task Update(CrewDTO modelDTO)
        {
            var dest = mapper.Map<CrewDTO, Crew>(modelDTO);
            await uow.Crews.Update(dest);
        }

        
    }
}
