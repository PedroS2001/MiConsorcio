using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiConsorcio.Domain.Models
{
    public sealed class Periodo
    {
        public int Anio { get; private set; }
        public int Mes { get; private set; }

        public Periodo() { }

        public Periodo(int anio, int mes)
        {
            Anio = anio;
            Mes = mes;
        }

        public static bool operator ==(Periodo a, Periodo b)
        {
            if (a is null || b is null)
                return false;
            return a.Anio == b.Anio && a.Mes == b.Mes;
        }

        public static bool operator !=(Periodo a, Periodo b)
        {
            return !(a == b);

        }
    }


}
