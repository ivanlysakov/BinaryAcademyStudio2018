using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
    public class DepartureDTO
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string FlightNumber { get; set; }
        
        [Required]
        public DateTime Time { get; set; }

        public CrewDTO Crew { get; set; }

        public AirplaneDTO Airplane { get; set; }

        

    }
}
