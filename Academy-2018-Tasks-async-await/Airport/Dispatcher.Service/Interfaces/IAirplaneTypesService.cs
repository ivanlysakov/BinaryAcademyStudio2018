
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Service.Interfaces
{
    public interface IAirplaneTypesService
    {
        Task<List<AirplaneTypeDTO>> Get();
        Task<AirplaneTypeDTO> GetById(int id);
        Task Create(AirplaneTypeDTO entity);
        Task Update(int id, AirplaneTypeDTO entity);
        Task Delete(int id);
    }
}
