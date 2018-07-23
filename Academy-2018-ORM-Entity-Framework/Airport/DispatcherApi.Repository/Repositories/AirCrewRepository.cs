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
    public class AirCrewRepository : IRepository<Crew>
    {

        private readonly AirportContext airport;

        public AirCrewRepository(AirportContext context)
        {
            this.airport = context;
        }

        public List<Crew> GetAll()
        {
            return airport.Crews.ToList();
        }

        public Crew Get(int? id)
        {
            return airport.Crews.Where(a => a.Id == id).SingleOrDefault();
        }

        public void Create(Crew model)
        {
            airport.Crews.Add(model);
        }
      
        public void Update(Crew dest)
        {
            airport.Crews.Update(dest);
            
        }
        
        public void Delete(Crew model)
        {
            airport.Crews.Remove(model);
        }
             
    }
}
