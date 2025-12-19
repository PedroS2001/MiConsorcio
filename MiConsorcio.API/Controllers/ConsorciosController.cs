using MediatR;
using MiConsorcio.API.Requests;
using MiConsorcio.Application.Queries;
using MiConsorcio.Application.UseCases.Consorcio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiConsorcio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsorciosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsorciosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearConsorcioRequest request)
        {
            var command = new CrearConsorcioCommand(request.Nombre, request.Cuit, request.Direccion, request.Estado);

            var consorcioId = await _mediator.Send(command);

            return CreatedAtAction(nameof(ObtenerPorId), new { id = consorcioId }, null);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(Guid id)
        {
            // lo hacemos después (Query)
            return Ok();
        }

        [HttpGet("{consorcioId}/dashboard")]
        public async Task<IActionResult> Dashboard(Guid consorcioId)
        {
            var query = new DashboardConsorcioQuery(consorcioId);
            var dto = await _mediator.Send(query); // usando MediatR
            return Ok(dto);
        }

    }

}
