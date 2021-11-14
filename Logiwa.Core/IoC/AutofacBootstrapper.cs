using System;
using Autofac;

namespace Logiwa.Core.IoC
{
    /// <summary>
    /// Autofac Container'ın ayağa kaldırılmasını sağlar.
    /// Author : Ali Özdemir
    /// </summary>
    public static class AutofacBootstrapper
    {
        private static ILifetimeScope _container;

        /// <summary>
        /// Build edilmiş container'ı set eder.
        /// </summary>
        /// <param name="builder"></param>
        public static void SetContainer(ILifetimeScope container)
        {
            _container = container;
        }

        /// <summary>
        /// Container'a ihtiyaç duyulduğunda ayaktaki containerı teslim eder.
        /// </summary>
        /// <returns>IContainer</returns>
        public static ILifetimeScope GetContainer()
        {
            return _container;
        }

        /// <summary>
        /// Uygulamanın ayağa kalktığı esnada containerın oluşturulmasını sağlar.
        /// </summary>
        /// <param name="builder"></param>
        public static void BuildContainer(ContainerBuilder builder)
        {
            _container = builder.Build();
        }

        /// <summary>
        /// Aldığı tipi container üzerinden çözer.
        /// </summary>
        /// <returns>T</returns>
        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        /// <summary>
        /// Aldığı tipi container üzerinden çözer.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}