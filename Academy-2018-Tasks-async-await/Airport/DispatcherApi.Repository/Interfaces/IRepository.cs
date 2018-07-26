using DAL.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IRepository <T> where T : class
    {
       
        Task <List<T>> GetAll();
        Task<T> Get(int id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
        Task<bool> IsExist(int id);
        Task CreateListAsync(List<T> TEntity);
        int GetRowsCount();
    }
}
