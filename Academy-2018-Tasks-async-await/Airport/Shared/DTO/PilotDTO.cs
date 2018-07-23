using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
    public class PilotDTO
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string Lastname { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }
        
        [Required]
        public int Experience { get; set; }

        public int CrewID { get; set; }
    }
}
