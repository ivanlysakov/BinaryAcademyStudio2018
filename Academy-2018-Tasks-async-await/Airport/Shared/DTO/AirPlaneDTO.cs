using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.DTO
{
    public class AirplaneDTO
    {
       
        public int Id { get; set; }
              
        public string Name { get; set; }

        public AirplaneTypeDTO Type { get; set; }

        public DateTime CreationDate { get; set; }
        
        public int Lifetime { get; set; }

        
    }
}
