using MiConsorcio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiConsorcio.Application.Interfaces
{
    public interface IProveedorRepository
    {
        Task<bool> ExisteCuitAsync(string cuit);
        Task AddAsync(Proveedor proveedor);

        Task<List<Proveedor>> GetAllAsync();

    }

}
