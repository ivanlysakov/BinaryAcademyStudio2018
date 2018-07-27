using DAL.Repository.Abstractions;
using DAL.Repository.EF;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repository.Repositories
{
    public class TicketRepository : Repository<Ticket>, IRepository<Ticket>
    {
        public TicketRepository(AirportContext context) : base(context)
        {
        }
        public override async Task Create(Ticket item)
        {
            item.FlightId = context.Tickets.Where(x=>x.FlightNumber==item.FlightNumber).FirstOrDefault().FlightId;
            await context.Tickets.AddAsync(item);
        }
    }
}
