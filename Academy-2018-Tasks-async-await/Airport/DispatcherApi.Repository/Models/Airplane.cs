using DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Repository.Models
{
    public class Airplane : IModel
    {
        [Key]
        public int Id { get; set;}

        [MaxLength(10), MinLength(4)]
        public string Name { get; set;}

        public AirplaneType Type { get; set; }

        public DateTime CreationDate { get; set;}

        public int Lifetime { get; set; }

        public int DepartureID { get; set; }
        public Departure Departure { get; set; }



    }
}
