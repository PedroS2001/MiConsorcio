using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiConsorcio.Domain.Models
{
    public class SaldoUF
    {
        public decimal Monto { get; private set; }

        public SaldoUF(decimal monto)
        {
            Monto = monto;
        }

        public void Debitar(decimal monto)
        {
            Monto -= monto;
        }

        public void Acreditar(decimal monto)
        {
            Monto += monto;
        }
    }

}
