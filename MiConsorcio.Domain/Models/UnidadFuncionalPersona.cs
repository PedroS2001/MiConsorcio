using MiConsorcio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiConsorcio.Domain.Models
{
    public class UnidadFuncionalPersona
    {
        public Guid Id { get; private set; }

        public Guid UnidadFuncionalId { get; private set; }
        public Guid PersonaId { get; private set; }

        public ERolEnUnidadFuncional Rol { get; private set; }
        public EEstadoRelacionUFPersona Estado { get; private set; }
    }

}
