using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.Models.DataModel.Repository
{
    public abstract class GenericRepository<C, T> : IGenericRepository<T> where T : class where C : DbContext, new()
    {
        public C Context { get; set; }
        public GenericRepository()
        {
            Context = new C();
            //Context.Database.EnsureCreated();
        }
        public async Task<T> Add(T entity)
        {
            var result = await Context.AddAsync(entity);
            return result.Entity;
        }

        public void Delete(T entity)
        {
            Context.Attach(entity);
            Context.Remove(entity);
        }

        public void Edit(T entity)
        {
            Context.Update(entity);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = Context.Set<T>().Where(predicate);
            return query;
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = Context.Set<T>();
            return query;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
