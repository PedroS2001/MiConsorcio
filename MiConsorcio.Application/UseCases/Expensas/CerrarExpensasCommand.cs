using MiConsorcio.Domain.Models;

namespace MiConsorcio.Application.UseCases.Expensas
{
    public record CerrarExpensaCommand(
        Guid ConsorcioId,
        Periodo Periodo
    );

}
