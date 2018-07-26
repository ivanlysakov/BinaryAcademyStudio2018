using DAL.Repository.DataSourсes;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository.Repositories
{
    class AirplaneTypeRepository : IRepository<AirplaneType>
    {
        private AirportDataSource airport;

        public AirplaneTypeRepository(DataSourсes.AirportDataSource source)
        {
            this.airport = source;
        }

        public List<AirplaneType> GetAll()
        {
            return airport.AirplaneTypes;
        }

        public AirplaneType Get(int? id)
        {
            return airport.AirplaneTypes.Where(a => a.Id == id).SingleOrDefault();
        }

        public void Create(AirplaneType plane)
        {
            airport.AirplaneTypes.Add(plane);
        }

        public void Update(AirplaneType dest, int id)
        {
            var index = airport.AirplaneTypes.IndexOf(Get(id));
            airport.AirplaneTypes[index] = dest;
        }

        public void Delete(AirplaneType model)
        {
            airport.AirplaneTypes.Remove(model);
        }

        public void Update(AirplaneType item, int? id)
        {
            var index = airport.AirplaneTypes.IndexOf(Get(id));
            
        }
    }
}
