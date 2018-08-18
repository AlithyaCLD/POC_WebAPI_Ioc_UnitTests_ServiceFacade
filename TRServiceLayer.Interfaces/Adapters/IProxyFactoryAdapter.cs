
namespace TR.ServiceLayer.Interfaces.Adapters
{
    public interface IProxyFactoryAdapter
    {
        T GetInstance<T>() where T : class;
    }
}
