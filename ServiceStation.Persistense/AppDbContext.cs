using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ServiceStation.Domain;
using ServiceStation.Persistense.EntityTypeConfiguration;

namespace ServiceStation.Persistense
{
    public class AppDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Bus> Buses { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new CarConfiguration());
        //    modelBuilder.ApplyConfiguration(new TruckConfiguration());  
        //    modelBuilder.ApplyConfiguration(new BusConfiguration());
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
