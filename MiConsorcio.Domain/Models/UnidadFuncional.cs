using MiConsorcio.Domain.Enums;

namespace MiConsorcio.Domain.Models
{
    public class UnidadFuncional
    {
        public Guid Id { get; private set; }

        public string Codigo { get; private set; }
        public ETipoUnidadFuncional Tipo { get; private set; }
        public decimal Coeficiente { get; private set; }

        public int? Piso { get; private set; }
        public string? Departamento { get; private set; }

        public EEstadoUnidad Estado { get; private set; }
    }

}
