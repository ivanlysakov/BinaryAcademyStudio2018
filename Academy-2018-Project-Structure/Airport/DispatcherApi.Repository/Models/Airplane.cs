using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Models
{
    public class Airplane
    {
        public int Id { get; set;}

        public string Name { get; set;}

        public AirplaneType Type { get; set; }

        public DateTime CreationDate { get; set;}

        public TimeSpan Lifetime { get; set; }
      
    }
}
