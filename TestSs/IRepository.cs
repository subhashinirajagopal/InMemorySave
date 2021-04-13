using System;
using System.Collections.Generic;

namespace TestSs
{
    public interface IRepository<T> where T : IStoreable
    {
        IEnumerable<T> All();
        void Delete(int id);
        void Save(T item);
        void Update(int id, T item);
        T FindById(int id);
    }
}
