using MiConsorcio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiConsorcio.Domain.Models
{
    public class Expensa
    {
        public Guid Id { get; private set; }

        public Guid ConsorcioId { get; private set; }
        public Periodo Periodo { get; private set; }
        public EEstadoExpensa Estado { get; private set; }
        public DateTime FechaCreacion { get; private set; }

        private readonly List<ExpensaDetalle> _detalles = new();
        public IReadOnlyCollection<ExpensaDetalle> Detalles => _detalles;



        protected Expensa() { }

        public Expensa(Periodo periodo)
        {
            Id = Guid.NewGuid();
            Periodo = periodo;
            Estado = EEstadoExpensa.Borrador;
        }


        public void AgregarDetalle(Guid unidadFuncionalId, decimal monto)
        {
            if (Estado != EEstadoExpensa.Borrador)
                throw new Exception("No se pueden modificar expensas cerradas");

            _detalles.Add(new ExpensaDetalle(unidadFuncionalId, monto));
        }

        public void Cerrar()
        {
            if (this.Estado != EEstadoExpensa.Borrador)
                throw new Exception("La expensa ya está cerrada");

            if (_detalles.Count == 0)
                throw new Exception("No se puede cerrar una expensa sin detalles");

            this.Estado = EEstadoExpensa.Cerrada;
        }


    }

}
