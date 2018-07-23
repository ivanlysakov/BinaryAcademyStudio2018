using DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Helpers
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public void SetRepository<T>(IRepository<T> repository) where T : class, IModel
        {
            _repositories[typeof(T)] = repository;
        }

        public IRepository<T> Repository<T>() where T : class, IModel
        {
            object repository;
            return _repositories.TryGetValue(typeof(T), out repository)
                       ? (IRepository<T>)repository
                       : new FakeRepository<T>();
        }

        public void Save()
        {
        }

       
    }
}
