using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStation.Domain;

namespace ServiceStation.Persistence.EntityTypeConfiguration
{
    public class BusConfiguration : VehicleConfiguration<Bus>
    {
        public override void Configure(EntityTypeBuilder<Bus> builder)
        {
            base.Configure(builder);
            builder.Property(bus => bus.replacementOfInteriorSeatUpholstery).HasDefaultValue(false);
        }
    }
}
