﻿using DAL.Repository.DataSourсes;
using DAL.Repository.EF;
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

        private readonly AirportContext airport;

        public AirplaneTypeRepository(AirportContext context)
        {
            this.airport = context;
        }

        public List<AirplaneType> GetAll()
        {
            return airport.AirplaneTypes.ToList();
        }

        public AirplaneType Get(int? id)
        {
            return airport.AirplaneTypes.Where(a => a.Id == id).SingleOrDefault();
        }

        public void Create(AirplaneType plane)
        {
            airport.AirplaneTypes.Add(plane);
        }

        public void Update(AirplaneType dest)
        {
            airport.AirplaneTypes.Update(dest);
            
        }

        public void Delete(AirplaneType model)
        {
            airport.AirplaneTypes.Remove(model);
        }

       
    }
}
