using DAL.Repository.DataSourсes;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository.Repositories
{
    public class PilotRepository : IRepository<Pilot>
    {
        private AirportDataSource airport;

        public PilotRepository(DataSourсes.AirportDataSource source)
        {
            this.airport = source;
        }

        public List<Pilot> GetAll()
        {
            return airport.Pilots;
        }

        public Pilot Get(int? id)
        {
            return airport.Pilots.Where(a => a.Id == id).SingleOrDefault();
        }

        public void Create(Pilot model)
        {
            airport.Pilots.Add(model);
        }

        public void Update(Pilot dest, int? id)
        {
            var index = airport.Pilots.IndexOf(Get(id));
            airport.Pilots[index] = dest;
        }

        public void Delete(Pilot model)
        {
            airport.Pilots.Remove(model);
        }

    }
}
