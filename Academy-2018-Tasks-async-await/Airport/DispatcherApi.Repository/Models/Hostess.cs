using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Repository.Interfaces;

namespace DAL.Repository.Models
{
    public class Hostess : IModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MinLength(2), MaxLength(30)]
        public string FirstName { get; set; }
        [MinLength(2), MaxLength(30)]
        public string Lastname { get; set; }

        public int CrewID { get; set; }
        public Crew Crew { get; set; }
       
        public DateTime BirthDay { get; set; }
        
    }
}
