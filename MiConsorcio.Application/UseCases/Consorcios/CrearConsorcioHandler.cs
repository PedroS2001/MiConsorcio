using MediatR;
using MiConsorcio.Application.Interfaces;

namespace MiConsorcio.Application.UseCases.Consorcio
{
    public class CrearConsorcioHandler : IRequestHandler<CrearConsorcioCommand, Guid>
    {
        private readonly IConsorcioRepository _repo;

        public CrearConsorcioHandler(IConsorcioRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(CrearConsorcioCommand request, CancellationToken cancellationToken)
        {
            var consorcio = new MiConsorcio.Domain.Models.Consorcio(request.Nombre, request.cuit, request.direccion, request.estado);

            await _repo.Add(consorcio);

            return consorcio.Id;
        }
    }

}
