using MiConsorcio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiConsorcio.Domain.Models
{
    public class Expensa
    {
        public Guid Id { get; private set; }

        public Guid ConsorcioId { get; private set; }
        public Periodo Periodo { get; private set; }

        public EEstadoExpensa Estado { get; private set; }

        public DateTime FechaCreacion { get; private set; }
    }

}
