using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.Models.Repository
{
    public abstract class GenericRepository<C, T> : IGenericRepository<T> where T : class where C : DbContext, new()
    {
        private C _context = new C();
        public C Context
        {
            get { return _context; }
            set { _context = value; }
        }
        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = _context.Set<T>();
            return query;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
