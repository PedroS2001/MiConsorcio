using MiConsorcio.Application.Interfaces;
using MiConsorcio.Domain.Models;

namespace MiConsorcio.Application.UseCases.Consorcio
{
    public class CrearConsorcioHandler
    {
        private readonly IConsorcioRepository _repo;

        public CrearConsorcioHandler(IConsorcioRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(CrearConsorcioCommand cmd)
        {
            var consorcio = new MiConsorcio.Domain.Models.Consorcio(cmd.Nombre);

            await _repo.Add(consorcio);

            return consorcio.Id;
        }
    }

}
