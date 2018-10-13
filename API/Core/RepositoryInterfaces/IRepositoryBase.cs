using System;
using System.Collections.Generic;
using System.Text;

namespace Core.RepositoryInterfaces
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAll();
        T GetSingle(int id);
        void Update(T entity);
        void Add(T entity);
        void Delete(int id);
    }
}
