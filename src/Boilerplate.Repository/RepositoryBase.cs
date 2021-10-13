using System;
using System.Linq;
using System.Linq.Expressions;
using Boilerplate.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Repository {
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class {
        private DbContext DbContext { get; }

        protected RepositoryBase(DbContext dbContext) => DbContext = dbContext;

        public void Update(T entity) => DbContext.Set<T>().Update(entity);
        public void Insert(T entity) => DbContext.Set<T>().Add(entity);
        public void Delete(T entity) => DbContext.Set<T>().Remove(entity);
        
        public IQueryable<T> GetAll() => DbContext.Set<T>().AsNoTracking();
        public IQueryable<T> GetWithPredicate(
            Expression<Func<T, bool>> expression) => DbContext.Set<T>().Where(expression).AsNoTracking();
    }
}