using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Models
{
    public class Pilot
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public DateTime BirthDay { get; set; }

        public TimeSpan Experience { get; set; }
    }
}
