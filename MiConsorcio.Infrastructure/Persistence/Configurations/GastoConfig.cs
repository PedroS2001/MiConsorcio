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

            builder.OwnsOne(g => g.PeriodoContable, pc =>
            {
                pc.Property(p => p.Anio).HasColumnName("PeriodoAno");
                pc.Property(p => p.Mes).HasColumnName("PeriodoMes");
            });


            // Otras configuraciones de la entidad
        }


    }
}
