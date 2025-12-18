using MiConsorcio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiConsorcio.Application.Interfaces
{
    public interface IConsorcioRepository
    {
        Task Add(Consorcio consorcio);
        Task<Consorcio> GetById(Guid id);
        Task Save(Consorcio consorcio);
    }

}
