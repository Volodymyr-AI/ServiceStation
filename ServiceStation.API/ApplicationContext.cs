using Microsoft.EntityFrameworkCore;
using ServiceStation.API.Entities;

namespace ServiceStation.API
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<Bus> Buses => Set<Bus>();
        public DbSet<Truck> Trucks => Set<Truck>(); 

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Using Fluent API
            base.OnModelCreating(builder);
        }
    }
}
