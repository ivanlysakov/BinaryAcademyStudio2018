using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Repository.Interfaces;

namespace DAL.Repository.Models
{
    public class Pilot : IModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        [MinLength(2), MaxLength(30)]
        public string FirstName { get; set; }
        [MinLength(2), MaxLength(30)]
        public string Lastname { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }
        [Required]
        public int Experience { get; set; }

        public int CrewId { get; set; }
        public Crew Crew { get; set; }
    }
}
