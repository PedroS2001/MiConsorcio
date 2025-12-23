using MiConsorcio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiConsorcio.Application.Interfaces
{
    public interface IGastoRepository
    {
        Task AddAsync(Gasto gasto);
        Task<List<Gasto>> ListarGastosAsync(Guid consorcioId, DateTime? desde, DateTime? hasta);
    }
}
