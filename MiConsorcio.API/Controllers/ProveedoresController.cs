using MediatR;
using MiConsorcio.Application.Queries;
using MiConsorcio.Application.UseCases.Proveedores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiConsorcio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProveedoresController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AltaProveedor([FromBody] AltaProveedorCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(AltaProveedor), new { id }, null);
        }

        [HttpGet]
        public async Task<IActionResult> ListarProveedores()
        {
            var proveedores = await _mediator.Send(new ListarProveedoresQuery());
            return Ok(proveedores);
        }


    }
}
