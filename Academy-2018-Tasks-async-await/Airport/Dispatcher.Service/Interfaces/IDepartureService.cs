using Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Service.Interfaces
{
    public interface IDepartureService
    {
        Task<List<DepartureDTO>> Get();
        Task<DepartureDTO> GetById(int id);
        Task Create(DepartureDTO entity);
        Task Update(DepartureDTO entity);
        Task Delete(int id);
    }
}
