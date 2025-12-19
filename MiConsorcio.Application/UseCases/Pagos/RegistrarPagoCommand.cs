using MiConsorcio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiConsorcio.Application.UseCases.Pagos
{
    public record RegistrarPagoCommand(Guid ConsorcioId, Guid UnidadFuncionalID, decimal Monto, EMedioDePago medioDePago, DateTime Fecha);
}
