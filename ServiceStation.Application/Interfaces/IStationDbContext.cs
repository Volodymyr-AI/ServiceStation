using Microsoft.EntityFrameworkCore;
using ServiceStation.Domain;

namespace ServiceStation.Application.Interfaces
{
    public interface IStationDbContext
    {
        DbSet<Car> Cars { get; set; }
        DbSet<Bus> Buses { get; set; }
        DbSet<Truck> Trucks { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
