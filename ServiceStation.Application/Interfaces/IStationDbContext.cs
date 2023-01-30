using Microsoft.EntityFrameworkCore;
using ServiceStation.Domain;
using ServiceStation.Domain.DTO;

namespace ServiceStation.Application.Interfaces
{
    public interface IStationDbContext
    {
        DbSet<CarDTO> Cars { get; set; }
        DbSet<BusDTO> Buses { get; set; }
        DbSet<TruckDTO> Trucks { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
