using DAL.Repository.Abstractions;
using DAL.Repository.DataSourсes;
using DAL.Repository.EF;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Repositories
{
    class AirplaneTypeRepository : Repository<AirplaneType>, IRepository<AirplaneType> 
    {
        public AirplaneTypeRepository(AirportContext context) : base(context)
        {
            
        }
    }

    
}

