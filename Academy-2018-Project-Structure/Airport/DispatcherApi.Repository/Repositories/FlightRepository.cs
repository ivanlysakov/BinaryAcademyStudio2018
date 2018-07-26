using DAL.Repository.DataSourсes;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository.Repositories
{
    public class FlightRepository : IRepository<Flight>
    {
        private AirportDataSource airport;

        public FlightRepository(DataSourсes.AirportDataSource source)
        {
            this.airport = source;
        }

        public List<Flight> GetAll()
        {
            return airport.Flights;
        }

        public Flight Get(int? id)
        {
            return airport.Flights.Where(a => a.Id == id).SingleOrDefault();
        }

        public void Create(Flight model)
        {
            airport.Flights.Add(model);
        }

        public void Update(Flight dest, int? id)
        {
            var index = airport.Flights.IndexOf(Get(id));
            airport.Flights[index] = dest;
        }

        public void Delete(Flight model)
        {
            airport.Flights.Remove(model);
        }

    }
}
