using MiConsorcio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MiConsorcio.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Consorcio> Consorcios => Set<Consorcio>();
        public DbSet<UnidadFuncional> UnidadesFuncionales => Set<UnidadFuncional>();
        public DbSet<UnidadFuncionalPersona> UFPersonas => Set<UnidadFuncionalPersona>();
        public DbSet<Persona> Personas => Set<Persona>();
        public DbSet<Expensa> Expensas => Set<Expensa>();
        public DbSet<Gasto> Gastos => Set<Gasto>();
        public DbSet<Pago> Pagos => Set<Pago>();
        public DbSet<Proveedor> Proveedores => Set<Proveedor>();
        public DbSet<CategoriaGasto> CategoriasGasto => Set<CategoriaGasto>();


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }


}
