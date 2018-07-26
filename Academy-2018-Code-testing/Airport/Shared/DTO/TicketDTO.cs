using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
    public class TicketDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string FlightNumber { get; set; }

        public int FlightId { get; set; }
    }
}
