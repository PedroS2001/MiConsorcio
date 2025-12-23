using System;
using System.Collections.Generic;
using System.Text;

namespace MiConsorcio.Application.DTOs
{
    public record GastoDto(
        Guid Id,
        DateTime Fecha,
        decimal Importe,
        string Categoria,
        string? Proveedor,
        string? MedioPago,
        string Descripcion
    );

}
