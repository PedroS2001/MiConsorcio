using MiConsorcio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiConsorcio.Domain.Models
{
    public class CategoriaGasto
    {
        public Guid Id { get; private set; }

        public Guid ConsorcioId { get; private set; }

        public string Nombre { get; private set; }
        public string? Descripcion { get; private set; }

        public EEstadoCategoriaGasto Estado { get; private set; }
    }

}
