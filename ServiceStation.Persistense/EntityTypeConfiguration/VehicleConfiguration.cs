using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceStation.Domain;

namespace ServiceStation.Persistense.EntityTypeConfiguration
{
    public class VehicleConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Vehicle
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(v => v.Id);
            builder.HasIndex(v => v.Id).IsUnique();
        }
    }
}
