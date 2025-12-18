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

        public Periodo(){        }

        public Periodo(int anio, int mes)
        {
            Anio = anio;
            Mes = mes;
        }
    }

}
