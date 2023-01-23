using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceSolution.Domain.VehicleEntities;

namespace ServiceStation.Persistence.EntityTypeConfiguration
{
    public class VehicleConfigurationc:IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(vehicle => vehicle.Id);
            builder.HasIndex(vehicle => vehicle.Id).IsUnique();
        }
    }
}
