using MiConsorcio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiConsorcio.Infrastructure.Persistence.Configurations
{
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("Proveedores");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.RazonSocial)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.Cuil)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.HasIndex(p => p.Cuil)
                   .IsUnique();
        }
    }

}
