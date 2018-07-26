using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.DTO
{
    public class AirplaneDTO
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public AirplaneTypeDTO Type { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public TimeSpan Lifetime { get; set; }
    }
}
