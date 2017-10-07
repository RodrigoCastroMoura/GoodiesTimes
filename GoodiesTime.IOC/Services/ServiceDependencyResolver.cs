using GoodiesTime.Domain.Interfaces.Services;
using GoodiesTime.Service.Service;
using Microsoft.Practices.Unity;

namespace GoodiesTime.IOC.Services
{
    public class ServiceDependencyResolver
    {
        public static void RegisterDependencies(UnityContainer container)
        {
            container.RegisterType<Itb_partnersServices, PartnersAppService>(new HierarchicalLifetimeManager());
        }
    }
}
