using MiConsorcio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiConsorcio.Domain.Models
{
    public class Gasto
    {
        public Guid Id { get; private set; }
        public Guid ConsorcioId { get; private set; }

        public Periodo PeriodoContable { get; private set; }
        public EEstadoGasto Estado { get; private set; }


        public DateTime Fecha { get; private set; }
        public decimal Monto { get; private set; }
        public string Descripcion { get; private set; }

        public Guid? ProveedorId { get; private set; }
        public int CategoriaGastoId { get; private set; }
        public ETipoGasto Tipo { get; private set; }


        protected Gasto() { }

        private Gasto(Guid consorcioId,DateTime fecha,Periodo periodoContable,decimal monto,ETipoGasto tipo,EEstadoGasto estado, string descripcion, int categoriaGastoId,Guid? proveedorId = null)
        {
            if (monto <= 0)
                throw new Exception("El importe del gasto debe ser mayor a cero");

            ConsorcioId = consorcioId;
            Fecha = fecha;
            PeriodoContable = periodoContable;
            Monto = monto;
            Estado = estado;
            Descripcion = descripcion;
            ProveedorId = proveedorId;
            CategoriaGastoId = categoriaGastoId;
            Tipo = tipo;
        }

        public static Gasto Crear(Guid consorcioId, DateTime fecha, Periodo periodoContable, decimal monto, ETipoGasto tipo, string descripcion, int categoriaGastoId, Guid? proveedorId = null)
        {
            return new Gasto(consorcioId, fecha, periodoContable, monto, tipo, EEstadoGasto.Registrado, descripcion, categoriaGastoId, proveedorId);
        }

    }

}
