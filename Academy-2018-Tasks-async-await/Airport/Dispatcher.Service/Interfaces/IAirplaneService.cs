using Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Service.Interfaces
{
    public interface IAirplaneService
    {
        Task<List<AirplaneDTO>> Get();
        Task<AirplaneDTO> GetById(int id);
        Task Create(AirplaneDTO entity);
        Task Update(int id, AirplaneDTO entity);
        Task Delete(int id);
    }
}
