using MiConsorcio.Domain.Enums;

namespace MiConsorcio.Domain.Models
{
    public class Consorcio
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        public string Cuit { get; private set; }
        public Direccion Direccion { get; private set; }
        public string? Codigo { get; private set; } //que es?
        public EEstadoUnidad Estado { get; private set; }


        private readonly List<UnidadFuncional> _unidades;
        public IReadOnlyCollection<UnidadFuncional> Unidades => _unidades;
    }

}
