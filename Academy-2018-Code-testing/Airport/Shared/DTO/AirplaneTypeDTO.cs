using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.DTO
{
    public class AirplaneTypeDTO
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Model { get; set; }
        
        [Required]
        public int Capacity { get; set; }
        
        [Required]
        public int Cargo { get; set; }

      
    }
}
