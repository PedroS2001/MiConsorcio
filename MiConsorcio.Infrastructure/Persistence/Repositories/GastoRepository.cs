using MiConsorcio.Application.Interfaces;
using MiConsorcio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiConsorcio.Infrastructure.Persistence.Repositories
{
    public class GastoRepository : IGastoRepository
    {
        private readonly AppDbContext _context;

        public GastoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Gasto gasto)
        {
            await _context.Gastos.AddAsync(gasto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Gasto>> ListarGastosAsync(Guid consorcioId, DateTime? desde, DateTime? hasta)
        {
            return await _context.Gastos
                .Where(g => g.ConsorcioId == consorcioId)
                .OrderByDescending(g => g.Fecha)
                .ToListAsync();
        }
    }

}
