using MiConsorcio.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiConsorcio.Application.UseCases.Expensas
{
    public class CerrarExpensaHandler
    {
        private readonly IConsorcioRepository _repo;

        public CerrarExpensaHandler(IConsorcioRepository repo)
        {
            _repo = repo;
        }

        public async Task Handle(CerrarExpensaCommand cmd)
        {
            var consorcio = await _repo.GetById(cmd.ConsorcioId);

            consorcio.CalcularExpensa(cmd.Periodo);
            consorcio.CerrarExpensa(cmd.Periodo);
            consorcio.ImpactarExpensa(cmd.Periodo);

            await _repo.Save(consorcio);
        }
    }

}
