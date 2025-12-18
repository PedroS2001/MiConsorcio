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
        public Guid Id { get; private set; }

        public Guid ConsorcioId { get; private set; }

        public string RazonSocial { get; private set; }
        public string Cuil { get; private set; }
        public string Actividad { get; private set; }

        public string? Email { get; private set; }
        public string? Telefono { get; private set; }

        public EEstadoPersona Estado { get; private set; }
    }

}
