using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public float Price { get; set; }

        public string FlightNumber { get; set; }
    }
}
