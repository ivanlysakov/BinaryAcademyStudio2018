﻿using DAL.Repository.EF;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Abstractions
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IModel
    {
        public readonly AirportContext context;

        protected Repository()
        {
        }

        protected Repository(AirportContext context) : this()
        {
            this.context = context;
        }
        
        public virtual async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

       public virtual async Task<TEntity> Get(int id)
        {
           var item = context.Set<TEntity>().FindAsync(id);

            return await item;
        }

        public virtual async Task Create(TEntity item)
        {
            await context.Set<TEntity>().AddAsync(item);
        }

        public async Task Delete(int id)
        {
            var model = await context.Set<TEntity>().FindAsync(id);
            if (model == null)
                throw new InvalidOperationException("No instance found matching id " + id);

            context.Set<TEntity>().Remove(model);
        }

        public async Task<bool> IsExist(int id)
        {
            return await context.Set<TEntity>().FindAsync(id) != null;
        }

        public async Task<TEntity> Update(TEntity item, int id)
        {
            if (item == null)
                return null;
            TEntity exist = await context.Set<TEntity>().FindAsync(id);
            if (exist != null)
            {
                context.Entry(exist).CurrentValues.SetValues(item);
                await context.SaveChangesAsync();
            }
            return exist;

        }

        public async Task CreateListAsync(List<TEntity> list)
        {
            await context.Set<TEntity>().AddRangeAsync(list);
        }

        public int GetRowsCount()
        {
            return  context.Set<TEntity>().Count();
        }

       
    }
}

