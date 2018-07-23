using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Repository.Interfaces;

namespace DAL.Repository.Models
{
    public class Departure : IModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(7)]
        public string FlightNumber { get; set; }

        public DateTime Time { get; set; }

        public Crew Crew { get; set; }

       public Airplane Airplane { get; set; }
           
    }
}
