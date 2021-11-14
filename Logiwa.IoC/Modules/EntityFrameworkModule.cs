using Autofac;
using Autofac.Core;
using Logiwa.Core.Interfaces;
using Logiwa.Entity;
using System.Collections.Generic;
using Module = Autofac.Module;

namespace Logiwa.IoC.Modules
{
    /// <summary>
    /// Entity Framework'ün Web kullanımlarında tüm TypeRegistration'lar buradan yapılır.
    /// Author : Ali Özdemir
    /// </summary>
    public class EntityFrameworkModule : Module
    {
        /// <summary>
        /// Entity framework ile ilgili registrationlar yapılıyor.
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationContext>().As<ApplicationContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EntityFrameworkRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<EntityFrameworkUnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            var resolvedParametersForUnitOfWork = new List<ResolvedParameter>
            {
                ResolvedParameter.ForNamed<ApplicationContext>("per-lifetime")
            };

            builder.RegisterType<EntityFrameworkUnitOfWork>()
                .Named<IUnitOfWork>("per-lifetime")
                .WithParameters(resolvedParametersForUnitOfWork)
                .InstancePerLifetimeScope();
        }
    }
}