using MiConsorcio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiConsorcio.Infrastructure.Persistence.Configurations
{
    public class GastoConfig : IEntityTypeConfiguration<Gasto>
    {

        public void Configure(EntityTypeBuilder<Gasto> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Monto)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            builder.Property(x => x.Descripcion)
                .IsRequired()
                .HasMaxLength(500);


            builder.OwnsOne(g => g.PeriodoContable, pc =>
            {
                pc.Property(p => p.Anio).HasColumnName("PeriodoAno");
                pc.Property(p => p.Mes).HasColumnName("PeriodoMes");
            });


            // Otras configuraciones de la entidad
        }


    }
}
