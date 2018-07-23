using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Models
{
    public class AirplaneType
    {
        public int Id { get; set; }
        
        public string Model { get; set; }
        
        public int Capacity { get; set; }

        public int Cargo { get; set; }

        public int Speed { get; set; }

        public int FlightRange { get; set; }

    }
}
