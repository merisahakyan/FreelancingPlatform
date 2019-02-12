using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.RepositoryInterfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll();
        T GetSingle(int id);
        T GetSingleWithInclude<TProp>(int id, params Expression<Func<T, TProp>>[] exp);
        void Update(T entity);
        void Add(T entity);
        void Delete(int id);
        void SaveChanges();
    }
}
