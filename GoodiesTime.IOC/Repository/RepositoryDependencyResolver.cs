using GoodiesTime.Domain.Interfaces.Repository;
using GoodiesTime.Infrastructure.Repository;
using Microsoft.Practices.Unity;

namespace GoodiesTime.IOC.Repository
{
    public static class RepositoryDependencyResolver
    {
        public static void RegisterDependencies(UnityContainer container)
        {
            container.RegisterType<Itb_partnersRepository, tb_partnersRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<Itb_addressRepository, tb_addressRepository>(new HierarchicalLifetimeManager());
        }
    }
}
