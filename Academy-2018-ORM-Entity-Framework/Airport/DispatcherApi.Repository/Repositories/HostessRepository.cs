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
    public class HostessRepository : IRepository<Hostess>
    {
        private readonly AirportContext airport;

        public HostessRepository(AirportContext context)
        {
            this.airport = context;
        }

        public List<Hostess> GetAll()
        {
            return airport.Hostesses.ToList();
        }

        public Hostess Get(int? id)
        {
            return airport.Hostesses.Where(a => a.Id == id).SingleOrDefault();
        }

        public void Create(Hostess model)
        {
            airport.Hostesses.Add(model);
        }

        public void Update(Hostess dest)
        {
            airport.Hostesses.Update(dest);
        }

        public void Delete(Hostess model)
        {
            airport.Hostesses.Remove(model);
        }
        
    }
}
