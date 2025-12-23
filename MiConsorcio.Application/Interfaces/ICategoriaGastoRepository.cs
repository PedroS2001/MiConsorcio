using MiConsorcio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiConsorcio.Application.Interfaces
{
    public interface ICategoriaGastoRepository
    {
        Task AddAsync(CategoriaGasto categoria);
        Task<bool> ExisteConNombre(string nombre);
    }

}
