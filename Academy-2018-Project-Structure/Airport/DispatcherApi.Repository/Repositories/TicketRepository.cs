using DAL.Repository.DataSourсes;
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
        private AirportDataSource airport;

        public TicketRepository(DataSourсes.AirportDataSource source)
        {
            this.airport = source;
        }

        public List<Ticket> GetAll()
        {
            return airport.Tickets;
        }

        public Ticket Get(int? id)
        {
            return airport.Tickets.Where(a => a.Id == id).SingleOrDefault();
        }

        public void Create(Ticket model)
        {
            airport.Tickets.Add(model);
        }
        
        public void Update(Ticket dest, int? id)
        {
            var index = airport.Tickets.IndexOf(Get(id));
            airport.Tickets[index] = dest;
        }

        public void Delete(Ticket model)
        {
            airport.Tickets.Remove(model);
        }


    }
}
