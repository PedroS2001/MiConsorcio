using MediatR;
using MiConsorcio.Domain.Enums;
using MiConsorcio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiConsorcio.Application.UseCases.Consorcio
{
    public record CrearConsorcioCommand(string Nombre, string cuit, Direccion direccion, EEstadoUnidad estado) : IRequest<Guid>;

}
