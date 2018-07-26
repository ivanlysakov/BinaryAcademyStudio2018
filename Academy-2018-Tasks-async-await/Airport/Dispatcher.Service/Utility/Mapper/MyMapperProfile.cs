using DAL.Repository.Models;
using Shared.DTO;
using AutoMapper;
using Shared.DTO.RemoteAPI;
using System;

namespace BL.Service.Utility.Mapper
{
    class mapperProfile : Profile
    {

        public mapperProfile()

        {
            CreateMap<Airplane, AirplaneDTO>();
            CreateMap<AirplaneDTO, Airplane>();

            CreateMap<AirplaneType, AirplaneTypeDTO>();
            CreateMap<AirplaneTypeDTO, AirplaneType>();

            CreateMap<Crew, CrewDTO>();
            CreateMap<CrewDTO, Crew>();

            CreateMap<Flight, FlightDTO>();
            CreateMap<FlightDTO, Flight>();

            CreateMap<Pilot, PilotDTO>();
            CreateMap<PilotDTO, Pilot>();

            CreateMap<Hostess, HostessDTO>();
            CreateMap<HostessDTO, Hostess>();

            CreateMap<Ticket, TicketDTO>();
            CreateMap<TicketDTO, Ticket>();

            CreateMap<Departure, DepartureDTO>();
            CreateMap<DepartureDTO, Departure>();


            CreateMap<RemotePilotDTO, PilotDTO>()
                .ForMember(p => p.Id, opt => opt.UseValue(0))
                .ForMember(p => p.Experience, opt => opt.MapFrom(p => p.Exp))
                .ForMember(p => p.BirthDay,
                    opt => opt.ResolveUsing(s => s.BirthDate.ToString("g")));

            
            CreateMap<RemoteHostessDTO, HostessDTO>()
                .ForMember(h => h.Id, opt => opt.UseValue(0))
                .ForMember(p => p.BirthDay,
                opt => opt.ResolveUsing(s => s.BirthDate.ToString("g")));

            CreateMap<RemoteCrewDTO, CrewDTO>().
            ForMember(c => c.Id, opt => opt.UseValue(0));

        }
    }
}
