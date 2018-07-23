using System;
using System.Threading.Tasks;
using DAL.Repository.Models;

namespace DAL.Repository.Interfaces
{
    public interface IUnitOfWork 
    {
        IRepository<T> Repository<T>() where T : class, IModel;

        void Save();
    }
}
