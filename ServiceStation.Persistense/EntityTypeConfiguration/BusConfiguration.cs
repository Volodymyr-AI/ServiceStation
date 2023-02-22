using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStation.Domain;

namespace ServiceStation.Persistense.EntityTypeConfiguration
{
    public class BusConfiguration : VehicleConfiguration<Bus>
    {
        public override void Configure(EntityTypeBuilder<Bus> builder)
        {
            base.Configure(builder);
        }
    }
}
