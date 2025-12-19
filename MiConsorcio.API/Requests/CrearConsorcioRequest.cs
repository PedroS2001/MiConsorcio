using MiConsorcio.Domain.Enums;
using MiConsorcio.Domain.Models;

namespace MiConsorcio.API.Requests
{
    public class CrearConsorcioRequest
    {
        public string Nombre { get; set; } = null!;
        public string Cuit { get; set; } = null!;
        public Direccion Direccion { get; set; }
        public EEstadoUnidad Estado { get; set; }

    }

}
