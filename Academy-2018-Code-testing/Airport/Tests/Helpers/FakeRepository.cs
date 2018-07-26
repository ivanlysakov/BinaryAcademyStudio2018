using DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.Helpers
{
    public class FakeRepository<Entity> : IRepository<Entity> where Entity : class, IModel
    {
        public readonly List<Entity> DataSet;

        public FakeRepository(params Entity[] data)
        {
            DataSet = new List<Entity>(data);
        }
        
        public IEnumerable<Entity> GetAll()
        {
            return DataSet;
        }

        public Entity Get(int id)
        {
            return DataSet.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Entity entity)
        {
            DataSet.Add(entity);
        }
        
        public void Update(Entity _entity)
        {
            Entity entity = DataSet.FirstOrDefault(x => x.Id == _entity.Id);
            entity = _entity;
        }
        
        public void Delete(Entity entity)
        {
            DataSet.Remove(entity);
        }
          
        public IEnumerable<Entity> Get(Func<Entity, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
