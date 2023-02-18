using Microsoft.EntityFrameworkCore;
using ServiceStation.Domain;

namespace ServiceStation.Persistense
{
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Bus> Buses { get; set; }
    }
}
