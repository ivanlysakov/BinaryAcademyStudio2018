using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Service.Services
{
    public interface IService <T>  where T : class
{
        T GetById(int id);
        IEnumerable<T> Get();
        void Delete(int id);
    }
}
