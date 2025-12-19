using MiConsorcio.Application.Interfaces;
using MiConsorcio.Domain.Enums;

namespace MiConsorcio.Application.UseCases.Pagos
{
    public class RegistrarPagoHandler
    {
        private readonly IConsorcioRepository _repo;

        public async Task Handle(RegistrarPagoCommand cmd)
        {
            var consorcio = await _repo.GetById(cmd.ConsorcioId);

            consorcio.RegistrarPago(cmd.UnidadFuncionalID, cmd.Monto, cmd.medioDePago, cmd.Fecha);

            await _repo.Save(consorcio);
        }
    }
}
