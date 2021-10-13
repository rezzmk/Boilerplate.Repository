using System;
using System.Linq;
using System.Linq.Expressions;

namespace Boilerplate.Repository.Contracts {
    public interface IRepositoryBase <T> {
        IQueryable<T> GetAll();
        IQueryable<T> GetWithPredicate(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        void Insert(T entity);
        void Delete(T entity);
    }
}