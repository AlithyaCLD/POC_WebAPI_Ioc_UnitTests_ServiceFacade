using System;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using TR.BusinessLayer.Domain.Common;

namespace TR.DataLayer.Interfaces.Generic
{
    public interface IRepository<T> : IDisposable
         where T : class
    {
        void Commit();
        IQueryable<T> Query(params Expression<Func<T, object>>[] includeProperties);
        T Attach(T entity);
        T Find(object id);
        T Find(object id, params Expression<Func<T, object>>[] includeProperties);
        T Find(object id, params string[] includeProperties);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);
        PagedList<T> FilteredPagedList(int skip, int numberOfRows, Expression<Func<T, bool>> whereExpression, params Expression<Func<T, object>>[] includeProperties);
        PagedList<T> FilteredPagedList(int skip, int numberOfRows, Expression<Func<T, bool>> whereExpression, string orderBy, params Expression<Func<T, object>>[] includeProperties);
        PagedList<T> FilteredPagedList(int skip, int numberOfRows, string whereExpression, params Expression<Func<T, object>>[] includeProperties);
        PagedList<T> FilteredPagedList(int skip, int numberOfRows, string whereExpression, string orderByExpression, Expression<Func<T, object>>[] includeProperties);
        DbConnection ExecuteSql(string sql);
        DbConnection Connection();
        DbPropertyValues GetDatabaseValues(T entity);
    }
}
