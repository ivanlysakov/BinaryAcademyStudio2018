using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO.RemoteAPI
{
    public class RemoteCrewDTO
    {
        public string Id { get; set; }
        public List<RemotePilotDTO> pilot { get; set; }
        public List<RemoteHostessDTO> stewardess { get; set; }
    }
}
