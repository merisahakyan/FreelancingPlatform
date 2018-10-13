using Core.Database;
using Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        public ApplicationDbContext Context { get; private set; }
        public RepositoryBase(ApplicationDbContext context)
        {
            Context = context;
        }
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            var entity = Context.Set<T>().FirstOrDefault(e => e.Id == id);
            Context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public T GetSingle(int id)
        {
            return Context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
    }
}
