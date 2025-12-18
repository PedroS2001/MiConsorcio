using MiConsorcio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiConsorcio.Infrastructure.Persistence.Configurations
{
    public class ExpensaConfig : IEntityTypeConfiguration<Expensa>
    {
        public void Configure(EntityTypeBuilder<Expensa> builder)
        {
            builder.OwnsOne(e => e.Periodo, p =>
            {
                p.Property(x => x.Anio).HasColumnName("PeriodoAnio");
                p.Property(x => x.Mes).HasColumnName("PeriodoMes");

                p.HasIndex(x => new { x.Anio, x.Mes }).IsUnique();
            });

        }
    }
}
