using MiConsorcio.Application.Interfaces;
using MiConsorcio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiConsorcio.Infrastructure.Persistence.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly AppDbContext _context;

        public ProveedorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExisteCuitAsync(string cuit)
        {
            return await _context.Proveedores
                .AnyAsync(p => p.Cuil == cuit);
        }

        public async Task AddAsync(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Proveedor>> GetAllAsync()
        {
            return await _context.Proveedores
                .OrderBy(p => p.RazonSocial)
                .AsNoTracking()
                .ToListAsync();
        }

    }

}
