using System;
using System.Collections.Generic;
using System.Text;

namespace MiConsorcio.Application.DTOs
{
    public class UFSaldoDto
    {
        public Guid UFId { get; set; }
        public string Nombre { get; set; }
        public decimal Saldo { get; set; }
    }

}
