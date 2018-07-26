using DAL.Repository.Models;
using Shared.DTO;
using AutoMapper;

namespace BL.Service.Utility.Mapper
{
    class MyMapperProfile : Profile
    {

        public MyMapperProfile()

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

        }
    }
}
