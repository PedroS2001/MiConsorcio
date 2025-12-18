using MiConsorcio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiConsorcio.Infrastructure.Persistence.Configurations
{
    public class ConsorcioConfig : IEntityTypeConfiguration<Consorcio>
    {
        public void Configure(EntityTypeBuilder<Consorcio> builder)
        {
            builder.ToTable("Consorcios");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nombre)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasMany(c => c.Unidades)
                   .WithOne()
                   .HasForeignKey("ConsorcioId");

            builder.HasMany(c => c.Expensas)
                   .WithOne()
                   .HasForeignKey("ConsorcioId");

            builder.HasMany(c => c.Pagos)
                   .WithOne()
                   .HasForeignKey("ConsorcioId");
        }
    }

}
