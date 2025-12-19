using MiConsorcio.API.Requests;
using MiConsorcio.Application.UseCases.Pagos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiConsorcio.API.Controllers
{
    [Route("api/consorcios/{consorcioId}/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly RegistrarPagoHandler _handler;

        public PagosController(RegistrarPagoHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(Guid consorcioId, [FromBody] RegistrarPagoRequest request)
        {
            var command = new RegistrarPagoCommand(
                consorcioId,
                request.UnidadFuncionalId,
                request.Monto,
                request.MedioPago,
                request.Fecha
            );

            await _handler.Handle(command);

            return NoContent();
        }

    }
}
