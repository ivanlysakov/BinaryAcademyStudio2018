using DAL.Repository.Abstractions;
using DAL.Repository.EF;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;


namespace DAL.Repository.Repositories
{
    public class TicketRepository : Repository<Ticket>, IRepository<Ticket>
    {
        public TicketRepository(AirportContext context) : base(context)
        {
        }
    }
}
