using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStation.Domain;

namespace ServiceStation.Persistense.EntityTypeConfiguration
{
    public class TruckConfiguration : VehicleConfiguration<Truck>
    {
        public override void Configure(EntityTypeBuilder<Truck> builder)
        {
            base.Configure(builder);
            builder.Property(t => t.Hydraulics).HasMaxLength(100);
        }
    }
}
