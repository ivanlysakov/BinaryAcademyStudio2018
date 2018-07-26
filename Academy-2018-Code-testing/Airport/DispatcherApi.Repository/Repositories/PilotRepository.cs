using DAL.Repository.DataSourсes;
using DAL.Repository.EF;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repository.Repositories
{
    public class PilotRepository : IRepository<Pilot>
    {
        private readonly AirportContext airport;

        public PilotRepository(AirportContext context)
        {
            this.airport = context;
        }

        public IEnumerable<Pilot> GetAll()
        {
            return airport.Pilots;
        }

        public Pilot Get(int id)
        {
            return airport.Pilots.Where(a => a.Id == id).SingleOrDefault();
        }

        public void Create(Pilot model)
        {
            airport.Pilots.Add(model);
        }

        public void Update(Pilot dest)
        {
            airport.Pilots.Update(dest);
        }

        public void Delete(Pilot model)
        {
            airport.Pilots.Remove(model);
        }

        public IEnumerable<Pilot> Get(Expression<Func<Pilot, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pilot> Get(Func<Pilot, bool> where)
        {
            throw new NotImplementedException();
        }
    }
}
