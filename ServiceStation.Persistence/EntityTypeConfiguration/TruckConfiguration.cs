using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Persistence.EntityTypeConfiguration
{
    public class TruckConfiguration : VehicleConfiguration<Truck>
    {
        public override void Configure(EntityTypeBuilder<Truck> builder)
        {
            base.Configure(builder);
        }
    }
}
