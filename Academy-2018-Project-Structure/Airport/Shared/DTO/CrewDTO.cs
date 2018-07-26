using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
    public class CrewDTO
    {
        [Required]
        public int? Id { get; set; }

        public PilotDTO Pilot { get; set; }

        public List<HostessDTO> Hostesses { get; set; }
    }
}
