using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiConsorcio.Application.UseCases.Gastos
{
    public record RegistrarGastoCommand(
        Guid ConsorcioId,
        decimal Monto,
        DateTime Fecha,
        Guid CategoriaId,
        Guid ProveedorId
    );

}
