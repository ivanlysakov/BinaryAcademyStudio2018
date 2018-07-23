using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Service.Services
{
    public interface IService <T>  where T : class
{
        T GetById(int? id);
        List<T> Get();
        void Delete(int? id);
    }
}
