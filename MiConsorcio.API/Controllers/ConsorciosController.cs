using MiConsorcio.API.Requests;
using MiConsorcio.Application.UseCases.Consorcio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiConsorcio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsorciosController : ControllerBase
    {
        private readonly CrearConsorcioHandler _handler;

        public ConsorciosController(CrearConsorcioHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearConsorcioRequest request)
        {
            var command = new CrearConsorcioCommand(request.Nombre);

            var consorcioId = await _handler.Handle(command);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = consorcioId },
                null
            );
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(Guid id)
        {
            // lo hacemos después (Query)
            return Ok();
        }
    }

}
