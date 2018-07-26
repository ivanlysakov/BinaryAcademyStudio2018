using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Models
{
    public class Departure
    {
        public int Id { get; set; }

        public string FlightNumber { get; set; }

        public DateTime Time { get; set; }

        public Crew Crew { get; set; }

        public Airplane Airplane { get; set; }
           
    }
}
