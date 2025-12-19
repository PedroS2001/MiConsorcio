using MediatR;
using MiConsorcio.Application.DTOs;

namespace MiConsorcio.Application.Queries
{
    public record DashboardConsorcioQuery(Guid ConsorcioId) : IRequest<DashboardConsorcioDto>;

}
