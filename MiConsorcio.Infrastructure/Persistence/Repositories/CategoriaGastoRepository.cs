using MiConsorcio.Application.Interfaces;
using MiConsorcio.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MiConsorcio.Infrastructure.Persistence.Repositories
{
    public class CategoriaGastoRepository : ICategoriaGastoRepository
    {
        private readonly AppDbContext _context;

        public CategoriaGastoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CategoriaGasto categoria)
        {
            await _context.CategoriasGasto.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExisteConNombre(string nombre)
        {
            return await _context.CategoriasGasto
                .AnyAsync(c => c.Nombre == nombre);
        }
    }

}
