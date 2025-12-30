using MiConsorcio.Application.UseCases.Expensas;
using MiConsorcio.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiConsorcio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensasController : ControllerBase
    {
        private readonly CerrarExpensaHandler _handler;

        public ExpensasController(CerrarExpensaHandler handler)
        {
            _handler = handler;
        }

        [HttpPost("cerrar")]
        public async Task<IActionResult> Cerrar(Guid consorcioId, int anio, int mes)
        {
            var command = new CerrarExpensaCommand(consorcioId, new Periodo(anio, mes));

            await _handler.Handle(command);

            return NoContent();
        }

    }
}
