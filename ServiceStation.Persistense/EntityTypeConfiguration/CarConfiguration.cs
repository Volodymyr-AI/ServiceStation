using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStation.Domain;

namespace ServiceStation.Persistense.EntityTypeConfiguration
{
    public class CarConfiguration : VehicleConfiguration<Car>
    {
        public override void Configure(EntityTypeBuilder<Car> builder)
        {
            base.Configure(builder);
        }
    }
}
