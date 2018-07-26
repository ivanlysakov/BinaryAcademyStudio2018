using BL.Service.Services;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Service.Interfaces
{
    public interface ITicketsService 
    {
        Task<TicketDTO> GetById(int id);
        Task<List<TicketDTO>> Get();
        Task Delete(int id);
        Task Create(TicketDTO modelDTO);
        Task Update(int id,TicketDTO modelDTO);
    }
}
