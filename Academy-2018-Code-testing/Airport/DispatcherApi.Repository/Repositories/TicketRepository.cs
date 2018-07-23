using DAL.Repository.DataSourсes;
using DAL.Repository.EF;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repository.Repositories
{
    public class TicketRepository : IRepository<Ticket>
    {
        private readonly AirportContext airport;

        public TicketRepository(AirportContext context)
        {
            this.airport = context;
        }
        public IEnumerable<Ticket> GetAll()
        {
            return airport.Tickets;
        }

        public Ticket Get(int id)
        {
            return airport.Tickets.Where(a => a.Id == id).SingleOrDefault();
        }

        public void Create(Ticket model)
        {
            airport.Tickets.Add(model);
        }
        
        public void Update(Ticket dest)
        {
            airport.Tickets.Update(dest);
        }

        public void Delete(Ticket model)
        {
            airport.Tickets.Remove(model);
        }

        public IEnumerable<Ticket> Get(Expression<Func<Ticket, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> Get(Func<Ticket, bool> where)
        {
            throw new NotImplementedException();
        }
    }
}
