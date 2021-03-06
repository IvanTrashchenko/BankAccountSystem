﻿using BLL.Interface.Services;
using BLL.Services;
using DAL.Fake.Repositories;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Repositories;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverModule
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IBankService>().To<BankService>();
            kernel.Bind<IAccountLogger>().To<NLogger>();
            kernel.Bind<IAccountNumberGenerator>().To<AccountNumberGenerator>();
            kernel.Bind<IHolderNumberGenerator>().To<HolderNumberGenerator>();
            kernel.Bind<IRepository<DalAccount>>().To<DbAccountRepository>(); //To<AccountRepository>();
        }
    }
}
