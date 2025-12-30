using MiConsorcio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiConsorcio.Infrastructure.Persistence.Configurations
{
    public class ExpensaDetalleConfiguration : IEntityTypeConfiguration<ExpensaDetalle>
    {
        public void Configure(EntityTypeBuilder<ExpensaDetalle> builder)
        {
            builder.ToTable("ExpensaDetalles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Monto)
                   .IsRequired()
                   .HasPrecision(18, 2);

            builder.HasOne(x => x.Expensa)
                   .WithMany(x => x.Detalles)
                   .HasForeignKey(x => x.ExpensaId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
