using DAL.Repository.Abstractions;
using DAL.Repository.EF;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;


namespace DAL.Repository.Repositories
{
    public class PilotRepository : Repository<Pilot>, IRepository<Pilot>
    {
        public PilotRepository(AirportContext context) : base(context)
        {
        }
    }
}
