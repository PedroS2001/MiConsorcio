using MiConsorcio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiConsorcio.Domain.Models
{
    public class Pago
    {
        public Guid Id { get; private set; }

        public Guid ConsorcioId { get; private set; }
        public Guid UnidadFuncionalId { get; private set; }

        public DateTime Fecha { get; private set; }
        public decimal Monto { get; private set; }

        public EMedioDePago MedioPago { get; private set; }
        public string? Observacion { get; private set; }

        public EEstadoPago Estado { get; private set; }

        public Pago(Guid consorcioId,Guid unidadFuncionalId,DateTime fecha,decimal monto,EMedioDePago medioDePago)
        {
            if (monto <= 0)
                throw new Exception("El monto del pago debe ser mayor a cero");

            Id = Guid.NewGuid();
            ConsorcioId = consorcioId;
            UnidadFuncionalId = unidadFuncionalId;
            Fecha = fecha;
            Monto = monto;
            MedioPago = medioDePago;
        }

    }

}
