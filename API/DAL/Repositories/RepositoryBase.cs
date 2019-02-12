using Core.Database;
using Core.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public T GetSingle(int id)
        {
            return Context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public T GetSingleWithInclude<TProp>(int id, params Expression<Func<T, TProp>>[] exp)
        {
            var set = Context.Set<T>();
            IIncludableQueryable<T, TProp> resultSet = set.Include(exp[0]);
            for (int i = 1; i < exp.Length; i++)
            {
                set.Include(exp[i]);
            };

            return resultSet.FirstOrDefault(e => e.Id == id);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
