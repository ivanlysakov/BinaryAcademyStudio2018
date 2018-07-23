using DAL.Repository.DataSourсes;
using DAL.Repository.EF;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public IEnumerable<Flight> GetAll()
        {
            return airport.Flights.Include(f => f.Tickets);
        }

        public Flight Get(int id)
        {
            return GetAll().Where(a => a.Id == id).SingleOrDefault();
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

        public IEnumerable<Flight> Get(Expression<Func<Flight, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> Get(Func<Flight, bool> where)
        {
            throw new NotImplementedException();
        }
    }
}
