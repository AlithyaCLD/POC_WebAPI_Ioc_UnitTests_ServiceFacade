using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using TR.DataLayer.Interfaces.Generic;

namespace TRDataLayer.Implementations.Generic
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IDataContext dataContext)
        {
            Context = dataContext;
        }

        public IDataContext Context { get; set; }

        #region Implementation of IUnitOfWork

        public void Dispose()
        {
            Context.Dispose();
        }

        public void Commit()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException dbe)
            {
                Debug.Write(dbe.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage).Aggregate((curent, next) => curent + "\r\n" + next));
                throw new Exception(dbe.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage).Aggregate((curent, next) => curent + "\r\n" + next));
            }
        }

        #endregion
    }
}
