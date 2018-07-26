using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
    public class FlightDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string Departure { get; set; }

        public DateTime DepartureTime { get; set; }
        
        [Required]
        public string Destination { get; set; }

        public DateTime ArrivalTime { get; set; }

        public ICollection<TicketDTO> Tickets { get; set; }
       
        public int FlightId { get; set; }

    }
}
