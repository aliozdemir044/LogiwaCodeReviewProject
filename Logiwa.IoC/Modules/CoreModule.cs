using Autofac;
using Logiwa.Core.Interfaces;
using Logiwa.Core.Logging;
using System.Net.Http;
using Module = Autofac.Module;

namespace Logiwa.IoC.Modules
{
    /// <summary>
    /// Core katmanıyla ilgili tüm TypeRegistration'lar buradan yapılır.
    /// Author : Ali Özdemir
    /// </summary>
    public class CoreModule : Module
    {
        /// <summary>
        /// Core katmanındaki registrationlar yapılıyor.
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NLogManager>().As<ILogManager>().SingleInstance();
        }
    }
}