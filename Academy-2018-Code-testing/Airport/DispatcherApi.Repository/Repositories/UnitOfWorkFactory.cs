using DAL.Repository.EF;
using DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Repositories
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        
        private readonly AirportContext context;

        public UnitOfWorkFactory(AirportContext context)

        {

            this.context = context;

        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(context);
        }
    }
}
