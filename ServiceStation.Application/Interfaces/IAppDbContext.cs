using Microsoft.EntityFrameworkCore;
using ServiceStation.Domain;

namespace ServiceStation.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<VehicleEntity> Vehicles { get; }
        DbSet<CarEntity> Cars { get; set; }
        DbSet<BusEntity> Buses { get; set; }
        DbSet<TruckEntity> Trucks { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
