using DAL.Repository.Abstractions;
using DAL.Repository.EF;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repository.Repositories
{
    public class DepartureRepository : Repository<Departure>, IRepository<Departure>
    {
        public DepartureRepository(AirportContext context) : base(context)
        {
        }
        
        public override async Task<List<Departure>> GetAll()
        {
            return await context.Departures
                .Include(d => d.Airplane)
                .Include(t=> t.Airplane.Type)
                .Include(d => d.Crew)
                .Include(p=> p.Crew.Pilot)
                .Include(h=> h.Crew.Hostesses).ToListAsync();
        }
    }

}
