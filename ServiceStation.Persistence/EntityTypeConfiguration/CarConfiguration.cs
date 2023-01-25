using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Persistence.EntityTypeConfiguration
{
    public class CarConfiguration : VehicleConfiguration<Car>
    {
        public override void Configure(EntityTypeBuilder<Car> builder)
        {
            base.Configure(builder);
            builder.Property(car => car.WheelBalancing).HasDefaultValue(false);
        }
    }
}
