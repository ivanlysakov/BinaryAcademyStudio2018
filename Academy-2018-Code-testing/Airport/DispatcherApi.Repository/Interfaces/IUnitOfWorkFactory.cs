using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
