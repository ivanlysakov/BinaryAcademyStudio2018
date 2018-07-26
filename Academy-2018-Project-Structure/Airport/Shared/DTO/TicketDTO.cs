using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
    public class TicketDTO
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public string FlightNumber { get; set; }
    }
}
