using MiConsorcio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiConsorcio.Domain.Models
{
    public class Persona
    {
        public Guid Id { get; private set; }

        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Documento { get; private set; }
        public ETipoPersona TipoPersona { get; private set; }
        public Direccion Direccion { get; private set; }

        public string? Email { get; private set; }
        public string? Telefono { get; private set; }

        public EEstadoPersona Estado { get; private set; }
    }

}
