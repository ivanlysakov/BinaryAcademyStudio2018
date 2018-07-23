using DAL.Repository.EF;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository.Repositories
{
    internal class Repository<T> : IRepository<T> where T : class, IModel
    {
        protected readonly DbContext DataContext;
        protected readonly DbSet<T> DataSet;
        
        public Repository(AirportContext dataContext)
        {
            DataContext = dataContext;
            DataSet = dataContext.Set<T>();
        }

        public IQueryable<T> Query()
        {
            return DataSet;
        }

        public IEnumerable<T> GetAll()
        {
            return DataSet.ToList();
        }

        public T Get(int id)
        {
            return DataSet.FirstOrDefault(x => x.Id == id);
        }

        
        public void Create(T entity)
        {
            DataSet.Add(entity);
        }

        public void Update(T entity)
        {
            DataSet.Attach(entity);
        }

        public void Delete(T entity)
        {
            DataSet.Remove(entity);
        }

        public void SaveChanges()
        {
            DataContext.SaveChanges();
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            yield return DataSet.FirstOrDefault(predicate);
        }
    }
}