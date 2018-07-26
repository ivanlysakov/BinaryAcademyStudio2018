using BL.Service.Services;
using Shared.DTO;
using System.Collections.Generic;

namespace BL.Service.Interfaces
{
    public interface ICrewsService 
    {
        CrewDTO GetById(int id);
        IEnumerable<CrewDTO> Get();
        void Delete(int id);

    }
}
