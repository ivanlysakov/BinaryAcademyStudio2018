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
using System.Threading.Tasks;

namespace DAL.Repository.Repositories
{
    public class AirCrewRepository : IRepository<Crew>
    {

        private readonly AirportContext airport;

        public AirCrewRepository(AirportContext context)
        {
            this.airport = context;
        }

        public AirCrewRepository()
        {
        }

        public IEnumerable<Crew> GetAll()
        {
            return airport.Crews
                    .Include(c => c.Pilot)
                    .Include(c => c.Hostesses).ToList();
        }

        public Crew Get(int id)
        {
            return GetAll().Where(a => a.Id == id).SingleOrDefault();
        }

        public void Create(Crew model)
        {
          
            airport.Set<Crew>().Add(model);
          
        }
      
        public void Update(Crew dest)
        {
            airport.Crews.Update(dest);
            
        }
        
        public void Delete(Crew model)
        {
            airport.Crews.Remove(model);
        }

        public IEnumerable<Crew> Get(Expression<Func<Crew, int>> Contains) => Get(Contains);

        public IEnumerable<Crew> Get(Func<Crew, bool> where)
        {
            throw new NotImplementedException();
        }

        //IEnumerable<Crew> IRepository<Crew>.Get(Expression<Func<Crew, bool>> where)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
