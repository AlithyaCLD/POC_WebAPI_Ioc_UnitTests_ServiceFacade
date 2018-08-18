using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace TR.DataLayer.Interfaces.Generic
{
    public interface IDataContext
    {
        IDbSet<T> Set<T>() where T : class;
        int SaveChanges();

        DbEntityEntry Entry(object o);
        void Dispose();
        DbContext UnderlyingContext { get; }
    }
}
