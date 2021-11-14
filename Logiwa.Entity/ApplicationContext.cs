using Logiwa.Entity.Shop;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Logiwa.Entity
{
    /// <summary>
    /// EntityFramework için bağlantı nesnesidir.
    /// </summary>
    public class ApplicationContext : DbContext
    {
        private readonly IConfigurationRoot _configuration;

        public ApplicationContext(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        //public ApplicationContext()
        //{
        //}

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("LogiwaMemoryDB");
        }

    }
}