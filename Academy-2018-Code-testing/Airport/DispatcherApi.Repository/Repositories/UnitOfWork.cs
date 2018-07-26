
using DAL.Repository.Interfaces;
using DAL.Repository.EF;

namespace DAL.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AirportContext context;

        public UnitOfWork(AirportContext context)

        {

            this.context = context;

        }
        public IRepository<T> Repository<T>() where T : class, IModel
        {
            return new Repository<T>(context);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
