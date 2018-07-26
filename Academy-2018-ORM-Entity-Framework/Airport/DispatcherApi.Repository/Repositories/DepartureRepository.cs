using DAL.Repository.EF;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository.Repositories
{
    public class DepartureRepository : IRepository<Departure>
    {
        private readonly AirportContext airport;

        public DepartureRepository(AirportContext context)
        {
            this.airport = context;
        }

        public List<Departure> GetAll()
        {
            return airport.Departures.ToList();
        }

        public Departure Get(int? id)
        {
            return airport.Departures.Where(a => a.Id == id).SingleOrDefault();
        }

        public void Create(Departure model)
        {
            airport.Departures.Add(model);
        }

        public void Update(Departure dest)
        {
             airport.Departures.Update(dest);
            
        }

        public void Delete(Departure model)
        {
            airport.Departures.Remove(model);
        }

        
    }
}
