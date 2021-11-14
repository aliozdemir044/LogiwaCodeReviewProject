using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NLog.Web;
using System.IO;

namespace Logiwa.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                 .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                 .ConfigureWebHostDefaults(webHostBuilder =>
                 {
                     webHostBuilder
                         .UseContentRoot(Directory.GetCurrentDirectory())
                         .UseIISIntegration()
                         .UseStartup<Startup>();
                 }).UseNLog()
                 .Build();

            host.Run();
        }

       
    }
}
