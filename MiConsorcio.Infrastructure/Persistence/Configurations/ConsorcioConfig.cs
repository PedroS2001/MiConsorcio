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
                   .HasForeignKey("ConsorcioId")
                   .OnDelete(DeleteBehavior.Restrict);


            //builder.HasMany(c => c.Expensas)
            //       .WithOne(e => e.Consorcio)
            //       .HasForeignKey(e => e.ConsorcioId)
            //       .OnDelete(DeleteBehavior.Restrict);
            //builder.Navigation(c => c.Expensas)
            //    .UsePropertyAccessMode(PropertyAccessMode.Field);


            builder.HasMany(c => c.Pagos)
                   .WithOne()
                   .HasForeignKey("ConsorcioId")
                   .OnDelete(DeleteBehavior.Restrict);
            //builder.Navigation(c => c.Pagos)
            //    .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(c => c.Gastos)
                .WithOne()
                .HasForeignKey("ConsorcioId")
                .OnDelete(DeleteBehavior.Restrict);
            builder.Navigation(c => c.Gastos)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.OwnsOne(p => p.Direccion, dir =>
            {
                dir.Property(d => d.Calle).HasColumnName("Calle");
                dir.Property(d => d.Ciudad).HasColumnName("Ciudad");
                dir.Property(d => d.CodigoPostal).HasColumnName("CodigoPostal");
            });
        }
    }

}
