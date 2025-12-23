using MediatR;
using MiConsorcio.Domain.Enums;
using MiConsorcio.Domain.Models;


namespace MiConsorcio.Application.UseCases.Gastos
{
    public record RegistrarGastoCommand(
        Guid ConsorcioId,
        DateTime Fecha,
        decimal Importe,
        ETipoGasto tipo,
        int CategoriaId,
        Guid? ProveedorId,
        string Descripcion,
        int PeriodoAnio,
        int PeriodoMes,
        string? MedioPago
    ) : IRequest<Guid>;

}
