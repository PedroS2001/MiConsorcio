using MediatR;
using MiConsorcio.Application.UseCases.Gastos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiConsorcio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasGastoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriasGastoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Crear(
            [FromBody] CrearCategoriaGastoCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Crear), new { id }, null);
        }

    }
}
