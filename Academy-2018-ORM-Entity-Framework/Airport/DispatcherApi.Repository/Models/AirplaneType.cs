using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Repository.Models
{
    public class AirplaneType
    {
        [Key]
        public int Id { get; set; }
        
        public string Model { get; set; }

        [Range(minimum: 1, maximum: 500)]
        public int Capacity { get; set; }

        [Range(minimum: 1, maximum: 4000)]
        public int Cargo { get; set; }
        
        //public int AirplaneRef { get; set; }

        //public Airplane Airplane { get; set; }
      
    }
}
