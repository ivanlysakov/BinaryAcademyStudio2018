using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
    public class CrewDTO
    {
        [Required]
        public int Id { get; set; }

        public int CrewNumber { get; set; }

        public PilotDTO Pilot { get; set; }

        public ICollection<HostessDTO> Hostesses { get; set; }

       
    }
}
