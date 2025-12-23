using MediatR;
using MiConsorcio.Application.Queries;
using MiConsorcio.Application.UseCases.Gastos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiConsorcio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GastosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CrearGasto([FromBody] RegistrarGastoCommand command)
        {
            var gastoId = await _mediator.Send(command);
            return CreatedAtAction(nameof(CrearGasto), new { id = gastoId }, null);
        }

        [HttpGet("consorcio/{consorcioId}")]
        public async Task<IActionResult> ListarPorConsorcio(Guid consorcioId,[FromQuery] DateTime? desde,[FromQuery] DateTime? hasta)
        {
            var result = await _mediator.Send(new  ListarGastosQuery(consorcioId, desde, hasta));

            return Ok(result);
        }

    }
}
