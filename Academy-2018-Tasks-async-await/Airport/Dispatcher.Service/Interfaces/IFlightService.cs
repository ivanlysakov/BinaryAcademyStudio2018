using DAL.Repository.Models;
using Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Service.Interfaces
{
    public interface IFlightService
    {
        Task<List<FlightDTO>> Get();
        Task<FlightDTO> GetById(int id);
        Task Create(FlightDTO entity);
        Task Update(int id,FlightDTO entity);
        Task Delete(int id);
        Task<List<FlightDTO>> GetWithDelay();
    }
}
