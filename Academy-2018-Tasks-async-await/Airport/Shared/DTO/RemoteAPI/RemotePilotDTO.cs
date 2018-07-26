using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO
{
    public class RemotePilotDTO
    {
        public string Id { get; set; }
        public string CrewId { get; set; }
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Exp { get; set; }
    }
}
