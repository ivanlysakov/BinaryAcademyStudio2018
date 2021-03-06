﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Interfaces
{
    public interface IRepository <T> where T : class
    {
        List<T> GetAll();
        T Get(int? id);
        void Create(T item);
        void Update(T item, int? id);
        void Delete(T item);

    }
}
