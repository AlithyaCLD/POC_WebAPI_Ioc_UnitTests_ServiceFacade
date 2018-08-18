using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TR.DataLayer.Interfaces.Generic;
using TR.ServiceLayer.Interfaces.Generic;

namespace TR.ServiceLayer.Implementation.Generic
{
    public class Service<T> : IService<T>
         where T : class
    {
        private readonly IRepository<T> _repository;
        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }
        #region Implementation of IService<T>

        public T Attach(T entity)
        {
            return _repository.Attach(entity);
        }

        public T Find(object id)
        {
            return _repository.Find(id);
        }

        public T Find(object id, params Expression<Func<T, object>>[] includeProperties)
        {
            return _repository.Find(id, includeProperties);
        }

        public void Insert(T entity)
        {
            _repository.Insert(entity);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public int Count
        {
            get { return _repository.Query().Count(); }
        }

        public IList<T> List(params Expression<Func<T, object>>[] includeProperties)
        {
            if (includeProperties != null)
                return _repository.Query(includeProperties).ToList();

            return _repository.Query().ToList();
        }

        public IList<T> ListDescending(IList<Expression<Func<T, object>>> orderByDescendings, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = includeProperties != null ? _repository.Query(includeProperties) : _repository.Query();

            for (var i = 0; i < orderByDescendings.Count; i++)
            {
                query = i == 0 ? query.OrderByDescending(orderByDescendings[i]) : ((IOrderedQueryable<T>)query).ThenByDescending(orderByDescendings[i]);
            }

            return query.ToList();
        }

        public IList<T> ListAscending(IList<Expression<Func<T, object>>> orderByAscendings, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = includeProperties != null ? _repository.Query(includeProperties) : _repository.Query();

            for (var i = 0; i < orderByAscendings.Count; i++)
            {
                query = i == 0 ? query.OrderBy(orderByAscendings[i]) : ((IOrderedQueryable<T>)query).ThenBy(orderByAscendings[i]);
            }

            return query.ToList();
        }

        #endregion

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
