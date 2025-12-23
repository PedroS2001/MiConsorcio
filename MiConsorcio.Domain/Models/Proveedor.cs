using MiConsorcio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiConsorcio.Domain.Models
{
    public class Proveedor
    {
        public int Id { get; private set; }

        public Guid ConsorcioId { get; private set; }

        public string RazonSocial { get; private set; }
        public string Cuil { get; private set; }
        public string Actividad { get; private set; }

        public string? Email { get; private set; }
        public string? Telefono { get; private set; }

        public EEstadoPersona Estado { get; private set; }

        private Proveedor() { } // EF

        public Proveedor(
            Guid consorcioId,
            string razonSocial,
            string cuit,
            string actividad,
            string email,
            string telefono,
            EEstadoPersona estado
            )
        {
            ConsorcioId = consorcioId;
            RazonSocial = razonSocial;
            Cuil = cuit;
            Actividad = actividad;
            Email = email;
            Telefono = telefono;
            Estado = estado;
        }

    }

}
