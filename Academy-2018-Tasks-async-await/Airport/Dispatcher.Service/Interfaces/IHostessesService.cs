using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Service.Interfaces
{
    public interface IHostessesService
    {
        Task<List<HostessDTO>> Get();
        Task<HostessDTO> GetById(int id);
        Task Create(HostessDTO entity);
        Task Update(int id, HostessDTO entity);
        Task Delete(int id);
    }
}
