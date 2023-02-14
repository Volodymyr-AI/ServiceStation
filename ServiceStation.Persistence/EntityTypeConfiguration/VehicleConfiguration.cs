using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStation.Domain;

namespace ServiceStation.Persistence.EntityTypeConfiguration
{
    public class VehicleConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Vehicle
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(v => v.VehicleId).IsRequired();
        }
    }
}
