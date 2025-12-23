using MediatR;
using MiConsorcio.Application.DTOs;

namespace MiConsorcio.Application.Queries
{
    public record ListarGastosQuery(
        Guid ConsorcioId,
        DateTime? Desde,
        DateTime? Hasta
        ) : IRequest<List<GastoDto>>;

}
