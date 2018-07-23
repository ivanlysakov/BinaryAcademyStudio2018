using DAL.Repository.DataSourсes;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository.Repositories
{
    public class HostessRepository : IRepository<Hostess>
    {
        private AirportDataSource airport;

        public HostessRepository(DataSourсes.AirportDataSource source)
        {
            this.airport = source;
        }

        public List<Hostess> GetAll()
        {
            return airport.Hostesses;
        }

        public Hostess Get(int? id)
        {
            return airport.Hostesses.Where(a => a.Id == id).SingleOrDefault();
        }

        public void Create(Hostess model)
        {
            airport.Hostesses.Add(model);
        }

        public void Update(Hostess dest, int? id)
        {
            var index = airport.Hostesses.IndexOf(Get(id));
            airport.Hostesses[index] = dest;
        }

        public void Delete(Hostess model)
        {
            airport.Hostesses.Remove(model);
        }

      
    }
}
