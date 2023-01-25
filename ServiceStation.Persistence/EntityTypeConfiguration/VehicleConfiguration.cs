using FluentValidation;
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
    public class VehicleConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Vehicle
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(v => v.VehicleId).IsRequired();
        }
    }
}
