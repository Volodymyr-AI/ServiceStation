using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Interfaces;
using ServiceStation.Domain;
using ServiceStation.Persistence.EntityTypeConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Persistence
{
    public sealed class StationDbContext : DbContext, IStationDbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Truck> Trucks { get; set; }

        public StationDbContext(DbContextOptions<StationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new BusConfiguration());
            builder.ApplyConfiguration(new TruckConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
