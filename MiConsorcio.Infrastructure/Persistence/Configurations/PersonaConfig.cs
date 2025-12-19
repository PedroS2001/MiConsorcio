using MiConsorcio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiConsorcio.Infrastructure.Persistence.Configurations
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(p => p.Id);

            // Configurar Direccion como Value Object
            builder.OwnsOne(p => p.Direccion, dir =>
            {
                dir.Property(d => d.Calle).HasColumnName("Calle");
                dir.Property(d => d.Ciudad).HasColumnName("Ciudad");
                dir.Property(d => d.CodigoPostal).HasColumnName("CodigoPostal");
            });
        }
    }

}
