using MiConsorcio.Application.Interfaces;
using MiConsorcio.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MiConsorcio.Infrastructure.Persistence.Repositories
{
    public class ConsorcioRepositoryEF : IConsorcioRepository
    {
        private readonly AppDbContext _context;

        public ConsorcioRepositoryEF(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Consorcio> GetById(Guid id)
        {
            return await _context.Consorcios
                .Include(c => c.Unidades)
                .Include(c => c.Expensas)
                .Include(c => c.Pagos)
                .FirstAsync(c => c.Id == id);
        }

        public async Task Add(Consorcio consorcio)
        {
            _context.Consorcios.Add(consorcio);
            await _context.SaveChangesAsync();
        }

        public async Task Save(Consorcio consorcio)
        {
            await _context.SaveChangesAsync();
        }
    }

}
