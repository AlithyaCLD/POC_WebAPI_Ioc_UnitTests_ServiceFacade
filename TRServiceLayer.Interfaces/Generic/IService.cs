using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TR.ServiceLayer.Interfaces.Generic
{
    public interface IService<T> : IDisposable
       where T : class
    {
        T Find(object id);
        T Find(object id, params Expression<Func<T, object>>[] includeProperties);
        IList<T> List(params Expression<Func<T, object>>[] includeProperties);

        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);
        int Count { get; }

        IList<T> ListDescending(IList<Expression<Func<T, object>>> orderByDescendings, params Expression<Func<T, object>>[] includeProperties);
        IList<T> ListAscending(IList<Expression<Func<T, object>>> orderByAscendings, params Expression<Func<T, object>>[] includeProperties);
    }
}
