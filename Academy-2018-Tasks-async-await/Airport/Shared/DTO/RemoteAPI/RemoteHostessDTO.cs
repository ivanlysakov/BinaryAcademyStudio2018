using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO.RemoteAPI
{
    public class RemoteHostessDTO
    {
        public string Id { get; set; }
        public string CrewId { get; set; }
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
