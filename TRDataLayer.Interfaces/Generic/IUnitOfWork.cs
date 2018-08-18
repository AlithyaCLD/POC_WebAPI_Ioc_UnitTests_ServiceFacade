
namespace TR.DataLayer.Interfaces.Generic
{
    public interface IUnitOfWork
    {
        IDataContext Context { get; set; }
        void Commit();
        void Dispose();
    }
}
