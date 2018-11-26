using BLL.Interface.Services;
using BLL.Services;
using DAL.Fake.Repositories;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverModule
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IBankService>().To<BankService>();
            kernel.Bind<IAccountNumberGenerator>().To<AccountNumberGenerator>();
            kernel.Bind<IHolderNumberGenerator>().To<HolderNumberGenerator>();
            kernel.Bind<IRepository<DalHolder>>().To<HolderRepository>();
            kernel.Bind<IRepository<DalAccount>>().To<AccountRepository>();
        }
    }
}
