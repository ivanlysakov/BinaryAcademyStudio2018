using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Service.Services
{
    public interface IService <T>  where T : class
{
        Task<T> GetById(int id);
        Task<List<T>> GetAsync();
        Task Delete(int id);
        Task<T> Update(T item, int id);
        Task Create (T item);
    }
}
