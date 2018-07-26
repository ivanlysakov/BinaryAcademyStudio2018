using DAL.Repository.Repositories;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private DataSourсes.AirportDataSource datasource;
        private AirplaneRepository airplaneRepository;
        private AirplaneTypeRepository airplaneTypesRepository;
        private AirCrewRepository crewRepository;
        private HostessRepository hostessRepository;
        private PilotRepository pilotRepository;
        private DepartureRepository departureRepository;
        private FlightRepository flightRepository;
        private TicketRepository ticketRepository;

        public UnitOfWork(DataSourсes.AirportDataSource source)
        {
            datasource = source;
        }

        public IRepository<Airplane> Airplanes
        {
            get
            {
                if (airplaneRepository == null)
                    airplaneRepository = new AirplaneRepository(datasource);
                return airplaneRepository;
            }
        }
        public IRepository<AirplaneType> AirplaneTypes
        {
            get
            {
                if (airplaneTypesRepository == null)
                    airplaneTypesRepository = new AirplaneTypeRepository(datasource);
                return airplaneTypesRepository;
            }
        }
        public IRepository<Hostess> AirHostesses
        {
            get
            {
                if (hostessRepository == null)
                    hostessRepository = new HostessRepository(datasource);
                return hostessRepository;
            }
        }
        public IRepository<Pilot> Pilots
        {
            get
            {
                if (pilotRepository == null)
                    pilotRepository = new PilotRepository(datasource);
                return pilotRepository;
            }
        }
        public IRepository<Crew> Crews
        {
            get
            {
                if (crewRepository == null)
                    crewRepository = new AirCrewRepository(datasource);
                return crewRepository;
            }
        }
        public IRepository<Departure> Departures
        {
            get
            {
                if (departureRepository == null)
                    departureRepository = new DepartureRepository(datasource);
                return departureRepository;
            }
        }
        public IRepository<Flight> Flights
        {
            get
            {
                if (flightRepository == null)
                    flightRepository = new FlightRepository(datasource);
                return flightRepository;
            }
        }
        public IRepository<Ticket> Tickets
        {
            get
            {
                if (ticketRepository == null)
                    ticketRepository = new TicketRepository(datasource);
                return ticketRepository;
            }
        }
        public void Save()
        {
            throw new NotImplementedException();
        }







    }
}
