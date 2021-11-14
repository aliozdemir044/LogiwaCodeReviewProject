using Autofac;
using Logiwa.Service.Shop.Product;
using System.Reflection;
using Module = Autofac.Module;


namespace Logiwa.IoC.Modules
{

    /// <summary>
    /// Service katmanıyla ilgili tüm TypeRegistration'lar buradan yapılır.
    /// Author : Ali Özdemir
    /// </summary>
    public class ServiceModule : Module
    {
        /// <summary>
        /// Service katmanındaki registrationlar yapılıyor.
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            var authenticationService = Assembly.GetAssembly(typeof(ProductService));

            #region Services

            builder.RegisterAssemblyTypes(authenticationService)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            #endregion
        }
    }
}
