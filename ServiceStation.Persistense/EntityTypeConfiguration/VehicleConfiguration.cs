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
            builder.Property(v => v.Body).HasMaxLength(100);
            builder.Property(v => v.Wheels).HasMaxLength(100);
            builder.Property(v => v.Engine).HasMaxLength(100);
            builder.Property(v => v.Breaks).HasMaxLength(100);
            builder.Property(v => v.Undercarriage).HasMaxLength(100);
        }
    }
}
