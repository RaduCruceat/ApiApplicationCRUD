using ApiApplication.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace ApiApplication.Data.Context
{
    public class CarContext : DbContext
    {
        public CarContext() : base()
        {
        }
        public DbSet<Car> Cars { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        }
    }
}
