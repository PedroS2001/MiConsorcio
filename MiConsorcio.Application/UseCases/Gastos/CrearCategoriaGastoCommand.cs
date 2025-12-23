using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiConsorcio.Application.UseCases.Gastos
{
    public record CrearCategoriaGastoCommand(string Nombre, string? Descripcion) : IRequest<int>;

}
