using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Repository.Models
{
    public class Airplane
    {
        [Key]
        public int Id { get; set;}

        [MaxLength(10), MinLength(4)]
        public string Name { get; set;}

        public AirplaneType Type { get; set; }

        public DateTime CreationDate { get; set;}

        public long Lifetime { get; set; }

      

    }
}
