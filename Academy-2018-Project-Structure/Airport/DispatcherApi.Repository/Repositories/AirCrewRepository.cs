using DAL.Repository.DataSourсes;
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
        private AirportDataSource airport;

        public AirCrewRepository(DataSourсes.AirportDataSource source)
        {
            this.airport = source;
        }

        public List<Crew> GetAll()
        {
            return airport.Crews;
        }

        public Crew Get(int? id)
        {
            return airport.Crews.Where(a => a.Id == id).SingleOrDefault();
        }

        public void Create(Crew model)
        {
             airport.Crews.Add(model);
        }
      
        public void Update(Crew dest, int? id)
        {
            var index = airport.Crews.IndexOf(Get(id));
            airport.Crews[index] = dest;
        }
        
        public void Delete(Crew model)
        {
            airport.Crews.Remove(model);
        }
             
    }
}
