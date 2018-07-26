using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Repository.Interfaces;

namespace DAL.Repository.Models
{
    public class Crew : IModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CrewNumber { get; set; }

        public Pilot Pilot { get; set; }
        
        public ICollection<Hostess> Hostesses { get; set; }

        //public int DepartureID { get; set; }
        //Departure Departure { get; set; }

    }
}
