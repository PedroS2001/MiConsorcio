using MiConsorcio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiConsorcio.Infrastructure.Persistence.Configurations
{
    public class UnidadFuncionalConfig : IEntityTypeConfiguration<UnidadFuncional>
    {
        public void Configure(EntityTypeBuilder<UnidadFuncional> builder)
        {
            builder.HasKey(u => u.Id);

            builder.OwnsOne(u => u.Saldo, saldo =>
            {
                saldo.Property(s => s.Monto)
                     .HasColumnName("Saldo");
            });
        }
    }

}
