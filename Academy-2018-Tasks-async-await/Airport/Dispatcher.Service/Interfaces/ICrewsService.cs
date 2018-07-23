using BL.Service.Services;
using Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Service.Interfaces
{
    public interface ICrewsService 
    {
        Task<CrewDTO> GetById(int id);
        Task<List<CrewDTO>> Get();
        Task Delete(int id);
        Task Create(CrewDTO modelDTO);
        Task Update(int id,CrewDTO modelDTO);
        Task<string> GetRemoteApi();
 
    }
}
