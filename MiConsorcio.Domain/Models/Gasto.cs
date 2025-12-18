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
        public Guid CategoriaGastoId { get; private set; }
        public ETipoGasto Tipo { get; private set; }


        protected Gasto() { }

        public Gasto(Guid consorcioId,DateTime fecha,Periodo periodoContable,decimal monto,ETipoGasto tipo, string descripcion, Guid categoriaGastoId,Guid? proveedorId = null)
        {
            ConsorcioId = consorcioId;
            Fecha = fecha;
            PeriodoContable = periodoContable;
            Monto = monto;
            Tipo = tipo;
            Descripcion = descripcion;
            CategoriaGastoId = categoriaGastoId;
            ProveedorId = proveedorId;
        }


    }

}
