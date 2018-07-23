using BL.Service.Services;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Service.Interfaces
{
    public interface ITicketsService 
    {
        TicketDTO GetById(int id);
        IEnumerable<TicketDTO> Get();
        void Delete(int id);
        void Create(TicketDTO modelDTO);
        void Update(TicketDTO modelDTO, int id);
    }
}
