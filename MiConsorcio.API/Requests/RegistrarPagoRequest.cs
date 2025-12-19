using MiConsorcio.Domain.Enums;

namespace MiConsorcio.API.Requests
{
    public class RegistrarPagoRequest
    {
        public Guid UnidadFuncionalId { get; set; }
        public decimal Monto { get; set; }
        public EMedioDePago MedioPago { get; set; }
        public DateTime Fecha { get; set; }
    }

}
