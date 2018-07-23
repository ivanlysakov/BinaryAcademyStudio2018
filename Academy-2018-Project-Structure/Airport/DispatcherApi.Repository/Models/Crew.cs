using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Models
{
    public class Crew
    {
        public int Id { get; set; }

        public Pilot Pilot { get; set; }

        public List<Hostess> Hostesses { get; set; }

    }
}
