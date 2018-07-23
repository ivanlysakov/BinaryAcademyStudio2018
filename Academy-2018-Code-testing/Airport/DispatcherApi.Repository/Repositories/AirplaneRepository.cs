using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public IEnumerable<Airplane> GetAll()
        {
           return airport.Airplanes.Include(a => a.Type);
        }

        public Airplane Get(int id)
        {
            return GetAll().Where(a => a.Id == id).SingleOrDefault();
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

        public IEnumerable<Airplane> Get(Expression<Func<Airplane, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Airplane> Get(Func<Airplane, bool> where)
        {
            throw new NotImplementedException();
        }
    }
}

