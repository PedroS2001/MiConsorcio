using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiConsorcio.Application.UseCases.Proveedores
{
    public class AltaProveedorCommand :IRequest<int>
    {
        public Guid ConsorcioId { get; init; }
        public string RazonSocial { get; init; }
        public string Cuit { get; init; }
        public string Actividad { get; init; }
        public string? Email { get; init; }
        public string? Telefono { get; init; }
        public AltaProveedorCommand(
            Guid consorcioId,
            string razonSocial,
            string cuit,
            string actividad,
            string? email,
            string? telefono
            )
        {
            ConsorcioId = consorcioId;
            RazonSocial = razonSocial;
            Cuit = cuit;
            Actividad = actividad;
            Email = email;
            Telefono = telefono;
        }
    }
}
