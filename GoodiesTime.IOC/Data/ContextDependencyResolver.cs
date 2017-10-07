using GoodiesTime.Domain.Context;
using GoodiesTime.Domain.UnityOfWork;
using GoodiesTime.Infrastructure.Context;
using GoodiesTime.Infrastructure.UnityOfWork;
using Microsoft.Practices.Unity;

namespace GoodiesTime.IOC.Data
{
    public class ContextDependencyResolver
    {
        public static void RegisterDependencies(UnityContainer container)
        {
            container.RegisterType<IUnitiOfWork, UnitiOfWork>(new HierarchicalLifetimeManager());

            container.RegisterType<IDataContext, DataContext>(new HierarchicalLifetimeManager());
        }
    }
}
