﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T t);
        void Delete(int id);
        void Update(T t, int id);
        T FindById(int id);
        List<T> GetAll();
        T Find(T t);
    }
}
