using DAL.Repository.Abstractions;
using DAL.Repository.EF;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository.Repositories
{
    public class AirCrewRepository : Repository<Crew>, IRepository<Crew>
    {
        public AirCrewRepository(AirportContext context) : base(context)
        {
        }
        public override async Task<List<Crew>> GetAll()
        {
            return await context.Crews
                    .Include(c => c.Pilot)
                    .Include(c => c.Hostesses)
                    .ToListAsync();
        }
        public override async Task<Crew> Get(int id)
        {
            return await context.Crews.Include(c => c.Pilot)
                .Include(c => c.Hostesses)
                .FirstOrDefaultAsync(x=>x.Id==id);

        }


        public override async Task Create(Crew item)
        {
            await context.Set<Crew>().AddAsync(item);
        }
    }
}
