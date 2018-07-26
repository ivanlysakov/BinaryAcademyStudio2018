using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Shared.DTO
{
    public class HostessDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }
        
              
        public int CrewID { get; set; }

    }
}
