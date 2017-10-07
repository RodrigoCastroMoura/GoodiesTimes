using GoodiesTime.IOC.Data;
using GoodiesTime.IOC.Repository;
using GoodiesTime.IOC.Services;
using Microsoft.Practices.Unity;

namespace GoodiesTime.IOC
{
    public static class IoC
    {
        public static void Resolve(UnityContainer container)
        {
            ServiceDependencyResolver.RegisterDependencies(container);
            RepositoryDependencyResolver.RegisterDependencies(container);
            ContextDependencyResolver.RegisterDependencies(container);
        }
    }
}
