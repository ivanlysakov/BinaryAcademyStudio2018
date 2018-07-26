using DAL.Repository.DataSourсes;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository.Repositories
{
    public class DepartureRepository : IRepository<Departure>
    {
        private AirportDataSource airport;

        public DepartureRepository(DataSourсes.AirportDataSource source)
        {
            this.airport = source;
        }

        public List<Departure> GetAll()
        {
            return airport.Departures;
        }

        public Departure Get(int? id)
        {
            return airport.Departures.Where(a => a.Id == id).SingleOrDefault();
        }

        public void Create(Departure model)
        {
            airport.Departures.Add(model);
        }

        public void Update(Departure dest, int? id)
        {
            var index = airport.Departures.IndexOf(Get(id));
            airport.Departures[index] = dest;
        }

        public void Delete(Departure model)
        {
            airport.Departures.Remove(model);
        }

        
    }
}
