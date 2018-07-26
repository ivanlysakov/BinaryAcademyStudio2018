using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository.Abstractions;
using DAL.Repository.DataSourсes;
using DAL.Repository.EF;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using DAL.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Repositories
{
    class AirplaneRepository : Repository<Airplane>, IRepository<Airplane>
    {
        public AirplaneRepository(AirportContext context) : base(context)
        {

        }

        public override async Task<List<Airplane>> GetAll()
        {
            return await context.Airplanes.Include(a => a.Type).ToListAsync();
        }
    }
}

