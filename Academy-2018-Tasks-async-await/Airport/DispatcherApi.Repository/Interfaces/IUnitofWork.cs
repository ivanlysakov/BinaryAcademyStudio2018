using System;
using System.Threading.Tasks;
using DAL.Repository.Models;

namespace DAL.Repository.Interfaces
{
    public interface IUnitOfWork 
    {
        IRepository<Airplane> Airplanes { get; }
        IRepository<AirplaneType> AirplaneTypes { get; }
        IRepository<Flight> Flights { get; }
        IRepository<Departure> Departures { get; }
        IRepository<Pilot> Pilots { get; }
        IRepository<Hostess> AirHostesses { get; }
        IRepository<Ticket> Tickets { get; }
        IRepository<Crew> Crews { get; }

        void Save();

        Task SaveAsync();
    }
}
