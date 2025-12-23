using System;
using System.Collections.Generic;
using System.Text;

namespace MiConsorcio.Application.DTOs
{
    public class DashboardConsorcioDto
    {
        public Guid ConsorcioId { get; set; }
        public string Nombre { get; set; }
        public IEnumerable<ExpensaDto> UltimasExpensas { get; set; } = new List<ExpensaDto>();
        public IEnumerable<UFSaldoDto> SaldosUF { get; set; } = new List<UFSaldoDto>();
        public IEnumerable<GastoDto> UltimosGastos { get; set; } = new List<GastoDto>();
        public decimal TotalGastos { get; set; }
        public decimal TotalPagos { get; set; }
    }

}
