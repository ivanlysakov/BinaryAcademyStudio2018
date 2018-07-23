using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Repository.Models
{
    public class Pilot
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MinLength(2), MaxLength(30)]
        public string FirstName { get; set; }
        [MinLength(2), MaxLength(30)]
        public string Lastname { get; set; }

        public DateTime BirthDay { get; set; }

        public long Experience { get; set; }
    }
}
