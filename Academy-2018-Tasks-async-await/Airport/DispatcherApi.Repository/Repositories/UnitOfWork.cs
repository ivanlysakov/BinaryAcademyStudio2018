
using DAL.Repository.Interfaces;
using DAL.Repository.EF;
using DAL.Repository.Models;
using System.Threading.Tasks;

namespace DAL.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AirportContext context;

        private AirplaneRepository airplaneRepository;
        private AirplaneTypeRepository airplaneTypesRepository;
        private AirCrewRepository crewRepository;
        private HostessRepository hostessRepository;
        private PilotRepository pilotRepository;
        private DepartureRepository departureRepository;
        private FlightRepository flightRepository;
        private TicketRepository ticketRepository;

        public UnitOfWork(AirportContext context)
        {
            this.context = context;
        }

        public IRepository<Airplane> Airplanes
        {
            get
            {
                if (airplaneRepository == null)
                    airplaneRepository = new AirplaneRepository(context);
                return airplaneRepository;
            }
        }
        public IRepository<AirplaneType> AirplaneTypes
        {
            get
            {
                if (airplaneTypesRepository == null)
                    airplaneTypesRepository = new AirplaneTypeRepository(context);
                return airplaneTypesRepository;
            }
        }
        public IRepository<Hostess> AirHostesses
        {
            get
            {
                if (hostessRepository == null)
                    hostessRepository = new HostessRepository(context);
                return hostessRepository;
            }
        }
        public IRepository<Pilot> Pilots
        {
            get
            {
                if (pilotRepository == null)
                    pilotRepository = new PilotRepository(context);
                return pilotRepository;
            }
        }
        public IRepository<Crew> Crews
        {
            get
            {
                if (crewRepository == null)
                    crewRepository = new AirCrewRepository(context);
                return crewRepository;
            }
        }
        public IRepository<Departure> Departures
        {
            get
            {
                if (departureRepository == null)
                    departureRepository = new DepartureRepository(context);
                return departureRepository;
            }
        }
        public IRepository<Flight> Flights
        {
            get
            {
                if (flightRepository == null)
                    flightRepository = new FlightRepository(context);
                return flightRepository;
            }
        }
        public IRepository<Ticket> Tickets
        {
            get
            {
                if (ticketRepository == null)
                    ticketRepository = new TicketRepository(context);
                return ticketRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
