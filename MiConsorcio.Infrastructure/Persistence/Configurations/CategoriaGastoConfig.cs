using MiConsorcio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiConsorcio.Infrastructure.Persistence.Configurations
{
    public class CategoriaGastoConfig : IEntityTypeConfiguration<CategoriaGasto>
    {
        public void Configure(EntityTypeBuilder<CategoriaGasto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(x => x.Nombre)
                .IsUnique();

        }
    }
}
