using DAL.Repository.Abstractions;
using DAL.Repository.DataSourсes;
using DAL.Repository.EF;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Repositories
{
    public class FlightRepository : Repository<Flight>, IRepository<Flight>
    {
        public FlightRepository(AirportContext context) : base(context)
        {
        }
        public override async Task<List<Flight>> GetAll()
        {
            return await context.Flights.Include(f => f.Tickets).ToListAsync();
        }
    }
}
