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
        public Expensa Expensa { get; private set; } = null!;

        public Guid UnidadFuncionalId { get; private set; }

        public decimal Monto { get; private set; }

        protected ExpensaDetalle() { }

        public ExpensaDetalle(Guid expensaId, Guid unidadFuncionalId, decimal monto)
        {
            Id = Guid.NewGuid();
            ExpensaId = expensaId;
            UnidadFuncionalId = unidadFuncionalId;
            Monto = monto;
        }

    }

}
