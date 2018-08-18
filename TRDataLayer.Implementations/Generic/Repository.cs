using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using TR.BusinessLayer.Domain.Common;
using TR.DataLayer.Implementations.Common;
using TR.DataLayer.Implementations.LinqKit;
using TR.DataLayer.Interfaces.Generic;

namespace TRDataLayer.Implementations.Generic
{
    public class Repository<T> : IRepository<T>
         where T : class
    {
        #region Constructor

        private readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            _unitOfWork = unitOfWork;
        }

        #endregion


        #region Implementation of IRepository<T>

        public T Attach(T entity)
        {
            try
            {
                return _unitOfWork.Context.Set<T>().Attach(entity);
            }
            catch (Exception) { }

            var objectContext = ((IObjectContextAdapter)_unitOfWork.Context).ObjectContext;
            var set = objectContext.CreateObjectSet<T>();
            var keyNames = set.EntitySet.ElementType.KeyMembers.Select(k => k.Name);

            IList<object> keys = keyNames.Select(keyName => entity.GetType().GetProperty(keyName).GetValue(entity)).ToList();

            return _unitOfWork.Context.Set<T>().Find(keys.ToArray());
        }

        public IDbSet<T> Set
        {
            get { return _unitOfWork.Context.Set<T>(); }
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return Set.Where(expression);
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }

        public IQueryable<T> Query(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Set;
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return query;
        }

        public IQueryable<T> Query(bool enableCache, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Set;
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (!enableCache)
            {
                query = query.AsNoTracking();
            }

            return query;
        }



        public virtual T Find(object id)
        {
            return _unitOfWork.Context.Set<T>().Find(id);
        }

        public virtual T Find(object id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> result = _unitOfWork.Context.Set<T>();
            result = includeProperties.Aggregate(result, (current, property) => current.Include(property));
            var query = result.Where(BuildPrimaryKeyWhere(id));

            return query.FirstOrDefault();
        }

        public virtual T Find(object id, params string[] includeProperties)
        {
            IQueryable<T> result = _unitOfWork.Context.Set<T>();
            result = includeProperties.Aggregate(result, (current, property) => current.Include(property));

            return result.FirstOrDefault(BuildPrimaryKeyWhere(id));
        }

        public void Insert(T entity)
        {
            _unitOfWork.Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            ObjectContext objectContext = ((IObjectContextAdapter)_unitOfWork.Context).ObjectContext;
            ObjectSet<T> set = objectContext.CreateObjectSet<T>();
            IEnumerable<string> keyNames = set.EntitySet.ElementType
                                                        .KeyMembers
                                                        .Select(k => k.Name);

            IList<object> keyValues = keyNames.Select(keyName => entity.GetType().GetProperty(keyName).GetValue(entity, null)).ToList();

            var originalEntity = (T)((DbContext)_unitOfWork.Context).Set(entity.GetType()).Find(keyValues.First());

            if (originalEntity != null)
            {
                _unitOfWork.Context.Entry(originalEntity).CurrentValues.SetValues(entity);

            }
            else
            {
                _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            _unitOfWork.Context.Set<T>().Remove(_unitOfWork.Context.Set<T>().Find(id));
        }

        public void Delete(T entity)
        {
            if (_unitOfWork.Context.Entry(entity).State == EntityState.Detached)
            {
                Set.Attach(entity);
            }

            Set.Remove(entity);
        }
        public PagedList<T> PagedList(int skip, int numberOfRows, params Expression<Func<T, object>>[] includeProperties)
        {
            ObjectContext objectContext = ((IObjectContextAdapter)_unitOfWork.Context).ObjectContext;
            ObjectSet<T> set = objectContext.CreateObjectSet<T>();
            IEnumerable<string> keyNames = set.EntitySet.ElementType
                                                        .KeyMembers
                                                        .Select(k => k.Name);

            return new PagedList<T>
            {
                List = Query(includeProperties).OrderBy(keyNames.First()).Skip(skip).Take(numberOfRows).ToList(),
                ItemCount = Query(includeProperties).Count()
            };
        }

        public PagedList<T> PagedList(int skip, int numberOfRows, string orderByExpression, params Expression<Func<T, object>>[] includeProperties)
        {
            ObjectContext objectContext = ((IObjectContextAdapter)_unitOfWork.Context).ObjectContext;
            ObjectSet<T> set = objectContext.CreateObjectSet<T>();
            IEnumerable<string> keyNames = set.EntitySet.ElementType
                                                        .KeyMembers
                                                        .Select(k => k.Name);

            return new PagedList<T>
            {
                List = Query(includeProperties).OrderBy(orderByExpression).Skip(skip).Take(numberOfRows).ToList(),
                ItemCount = Query(includeProperties).Count()
            };
        }

        public PagedList<T> FilteredPagedList(int skip, int numberOfRows, Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>>[] includeProperties)
        {
            ObjectContext objectContext = ((IObjectContextAdapter)_unitOfWork.Context).ObjectContext;
            ObjectSet<T> set = objectContext.CreateObjectSet<T>();
            IEnumerable<string> keyNames = set.EntitySet.ElementType
                                                        .KeyMembers
                                                        .Select(k => k.Name);

            return new PagedList<T>
            {
                List =
                    Query(includeProperties).AsExpandable().Where(whereExpression).OrderBy(keyNames.First()).Skip(skip).Take(
                        numberOfRows).ToList(),
                ItemCount = Query(includeProperties).AsExpandable().Where(whereExpression).Count()
            };
        }

        public PagedList<T> FilteredPagedList(int skip, int numberOfRows, Expression<Func<T, bool>> whereExpression, string orderBy, Expression<Func<T, object>>[] includeProperties)
        {
            ObjectContext objectContext = ((IObjectContextAdapter)_unitOfWork.Context).ObjectContext;
            ObjectSet<T> set = objectContext.CreateObjectSet<T>();
            IEnumerable<string> keyNames = set.EntitySet.ElementType
                                                        .KeyMembers
                                                        .Select(k => k.Name);

            return new PagedList<T>
            {
                List =
                    Query(includeProperties).AsExpandable().Where(whereExpression).OrderBy(orderBy).Skip(skip).Take(
                        numberOfRows).ToList(),
                ItemCount = Query(includeProperties).AsExpandable().Where(whereExpression).Count()
            };
        }

        public PagedList<T> FilteredPagedList(int skip, int numberOfRows, string whereExpression, params Expression<Func<T, object>>[] includeProperties)
        {
            ObjectContext objectContext = ((IObjectContextAdapter)_unitOfWork.Context).ObjectContext;
            ObjectSet<T> set = objectContext.CreateObjectSet<T>();
            IEnumerable<string> keyNames = set.EntitySet.ElementType
                                                        .KeyMembers
                                                        .Select(k => k.Name);

            return new PagedList<T>
            {
                List =
                    Query(includeProperties).Where(whereExpression).OrderBy(keyNames.First()).Skip(skip).Take(numberOfRows).ToList(),
                ItemCount = Query(includeProperties).Where(whereExpression).Count()
            };
        }

        public PagedList<T> FilteredPagedList(int skip, int numberOfRows, string whereExpression, string orderByExpression, Expression<Func<T, object>>[] includeProperties)
        {
            ObjectContext objectContext = ((IObjectContextAdapter)_unitOfWork.Context).ObjectContext;
            ObjectSet<T> set = objectContext.CreateObjectSet<T>();
            IEnumerable<string> keyNames = set.EntitySet.ElementType
                                                        .KeyMembers
                                                        .Select(k => k.Name);

            return new PagedList<T>
            {
                List =
                    Query(includeProperties).Where(whereExpression).OrderBy(orderByExpression).Skip(skip).Take(numberOfRows).ToList(),
                ItemCount = Query(includeProperties).Where(whereExpression).Count()
            };
        }

        public DbConnection ExecuteSql(string sql)
        {
            var connection = _unitOfWork.Context.UnderlyingContext.Database.Connection;
            connection.Open();
            _unitOfWork.Context.UnderlyingContext.Database.ExecuteSqlCommand(sql);

            return connection;
        }

        public DbConnection Connection()
        {
            return _unitOfWork.Context.UnderlyingContext.Database.Connection;
        }

        #endregion


        private Expression<Func<T, bool>> BuildPrimaryKeyWhere(object id)
        {
            ObjectContext objectContext = ((IObjectContextAdapter)_unitOfWork.Context).ObjectContext;
            ObjectSet<T> set = objectContext.CreateObjectSet<T>();
            IEnumerable<string> keyNames = set.EntitySet.ElementType
                                                        .KeyMembers
                                                        .Select(k => k.Name);

            var baseTypeParams = new[] { Expression.Parameter(typeof(T), "") };

            var whereExpression = (Expression<Func<T, bool>>)Expression.Lambda(
                    Expression.Call(
                        Expression.Property(baseTypeParams.First(), keyNames.First()),
                        id.GetType().GetMethod("Equals", new[] { id.GetType() }),
                        Expression.Constant(id)),
                    baseTypeParams
                );

            return whereExpression;
        }
        public DbPropertyValues GetDatabaseValues(T entity)
        {
            return _unitOfWork.Context.Entry(entity).GetDatabaseValues();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
