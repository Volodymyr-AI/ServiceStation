using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ServiceStation.Application.Interfaces;
using ServiceStation.Domain;
using ServiceStation.Persistense.EntityTypeConfiguration;

namespace ServiceStation.Persistense
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<BusEntity> Buses { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
