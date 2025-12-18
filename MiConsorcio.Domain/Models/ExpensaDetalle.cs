using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiConsorcio.Domain.Models
{
    public class ExpensaDetalle
    {
        public Guid Id { get; private set; }

        public Guid ExpensaId { get; private set; }
        public Guid UnidadFuncionalId { get; private set; }

        public decimal Monto { get; private set; }

        protected ExpensaDetalle() { }

        public ExpensaDetalle(Guid unidadFuncionalId, decimal monto)
        {
            UnidadFuncionalId = unidadFuncionalId;
            Monto = monto;
        }

    }

}
