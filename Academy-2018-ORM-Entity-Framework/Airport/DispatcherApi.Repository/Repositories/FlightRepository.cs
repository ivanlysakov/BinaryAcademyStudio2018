using DAL.Repository.DataSourсes;
using DAL.Repository.EF;
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
        private readonly AirportContext airport;

        public FlightRepository(AirportContext context)
        {
            this.airport = context;
        }

        public List<Flight> GetAll()
        {
            return airport.Flights.ToList();
        }

        public Flight Get(int? id)
        {
            return airport.Flights.Where(a => a.Id == id).SingleOrDefault();
        }

        public void Create(Flight model)
        {
            airport.Flights.Add(model);
        }

        public void Update(Flight dest)
        {
            airport.Flights.Update(dest);
        }

        public void Delete(Flight model)
        {
            airport.Flights.Remove(model);
        }

    }
}
