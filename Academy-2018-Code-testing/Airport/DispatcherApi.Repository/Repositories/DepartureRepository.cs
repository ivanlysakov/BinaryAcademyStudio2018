using DAL.Repository.EF;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repository.Repositories
{
    public class DepartureRepository : IRepository<Departure>
    {
        private readonly AirportContext airport;

        public DepartureRepository(AirportContext context)
        {
            this.airport = context;
        }

        public IEnumerable<Departure> GetAll()
        {
            return airport.Departures
                 .Include(d => d.Airplane)
                .Include(d => d.Airplane.Type)
                .Include(d => d.Crew)
                .Include(d => d.Crew.Pilot)
                .Include(d => d.Crew.Hostesses);
        }

        public Departure Get(int id)
        {
            return GetAll().Where(a => a.Id == id).SingleOrDefault();
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

        public IEnumerable<Departure> Get(Expression<Func<Departure, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Departure> Get(Func<Departure, bool> where)
        {
            throw new NotImplementedException();
        }
    }
}
