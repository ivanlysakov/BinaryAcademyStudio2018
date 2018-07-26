using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Repository.DataSourсes;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using DAL.Repository.Repositories;


namespace DAL.Repository.Repositories
{
    class AirplaneRepository : IRepository<Airplane>
    {
        private AirportDataSource airport;

        public AirplaneRepository(DataSourсes.AirportDataSource source)
        {
            this.airport = source;
        }

        public List<Airplane> GetAll()
        {
            return airport.Airplanes;
        }

        public Airplane Get(int? id)
        {
            return airport.Airplanes.Where(a => a.Id == id).SingleOrDefault();
        }

        public void Create(Airplane plane)
        {
           airport.Airplanes.Add(plane);
        }
        
        public void Update(Airplane dest, int? id)
        {
            var index = airport.Airplanes.IndexOf(Get(id));
            airport.Airplanes[index] = dest;
        }

        public void Delete(Airplane model)
        {
           airport.Airplanes.Remove(model);
        }

    }
}

