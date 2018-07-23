using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Repository.DataSourсes;
using DAL.Repository.EF;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using DAL.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Repositories
{
    class AirplaneRepository : IRepository<Airplane>
    {
        private readonly AirportContext airport;

        public AirplaneRepository(AirportContext context)
        {
            this.airport = context;
        }

        public List<Airplane> GetAll()
        {
            return airport.Airplanes.ToList();
        }

        public Airplane Get(int? id)
        {
            return airport.Airplanes.Where(a => a.Id == id).SingleOrDefault();
        }

        public void Create(Airplane plane)
        {
           airport.Airplanes.Add(plane);
        }
        
        public void Update(Airplane dest)
        {

            airport.Airplanes.Update(dest);
        }

        public void Delete(Airplane model)
        {
           airport.Airplanes.Remove(model);

        }

    }
}

