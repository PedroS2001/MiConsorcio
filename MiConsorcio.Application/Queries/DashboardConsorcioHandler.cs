using MediatR;
using MiConsorcio.Application.DTOs;
using MiConsorcio.Application.Interfaces;

namespace MiConsorcio.Application.Queries
{
    public class DashboardConsorcioHandler : IRequestHandler<DashboardConsorcioQuery, DashboardConsorcioDto>
    {
        private readonly IConsorcioRepository _repo;

        public DashboardConsorcioHandler(IConsorcioRepository repo)
        {
            _repo = repo;
        }

        public async Task<DashboardConsorcioDto> Handle(DashboardConsorcioQuery query, CancellationToken cancellationToken)
        {
            var consorcio = await _repo.GetById(query.ConsorcioId);

            return new DashboardConsorcioDto
            {
                ConsorcioId = consorcio.Id,
                Nombre = consorcio.Nombre,
                UltimasExpensas = consorcio.Expensas
                                    .OrderByDescending(e => e.Periodo)
                                    .Take(5)
                                    .Select(e => new ExpensaDto
                                    {
                                        Anio = e.Periodo.Anio,
                                        Mes = e.Periodo.Mes,
                                        Monto = e.Detalles.Sum(e => e.Monto),
                                        Estado = e.Estado.ToString()
                                    }),
                SaldosUF = consorcio.Unidades
                            .Select(u => new UFSaldoDto
                            {
                                UFId = u.Id,
                                Nombre = u.Codigo,
                                Saldo = u.Saldo.Monto
                            }),
                UltimosGastos = consorcio.Gastos
                                    .OrderByDescending(g => g.Fecha)
                                    .Take(5)
                                    .Select(g => new GastoDto(
                                        g.Id,
                                        g.Fecha,
                                        g.Monto,
                                        g.CategoriaGastoId.ToString(),
                                        g.ProveedorId?.ToString(),
                                        g.Tipo.ToString(),
                                        g.Descripcion
                                    )),
                TotalGastos = consorcio.Expensas.Sum(e => e.Detalles.Sum(g => g.Monto)),
                TotalPagos = consorcio.Pagos.Sum(p => p.Monto)
            };
        }
    }

}
