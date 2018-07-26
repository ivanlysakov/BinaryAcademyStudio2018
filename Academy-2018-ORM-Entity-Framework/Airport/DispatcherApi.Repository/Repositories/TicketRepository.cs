using DAL.Repository.DataSourсes;
using DAL.Repository.EF;
using DAL.Repository.Interfaces;
using DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<Ticket> GetAll()
        {
            return airport.Tickets.ToList();
        }

        public Ticket Get(int? id)
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


    }
}
