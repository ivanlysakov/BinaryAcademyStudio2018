using Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Service.Interfaces
{
    public interface IPilotService
    {
        Task<List<PilotDTO>> Get();
        Task<PilotDTO> GetById(int id);
        Task Create(PilotDTO entity);
        Task Update(int id, PilotDTO entity);
        Task Delete(int id);
    }
}
