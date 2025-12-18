using MiConsorcio.Application.Interfaces;
using MiConsorcio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiConsorcio.Application.UseCases.Gastos
{
    public class RegistrarGastoHandler
    {
        private readonly IConsorcioRepository _repo;

        public async Task Handle(RegistrarGastoCommand cmd)
        {
            var consorcio = await _repo.GetById(cmd.ConsorcioId);

            consorcio.RegistrarGasto(
                cmd.Fecha,
                cmd.Monto,
                "descripcion por defecto",
                new Domain.Models.Periodo(cmd.Fecha.Month, cmd.Fecha.Year),
                ETipoGasto.Ordinario,
                cmd.CategoriaId,
                cmd.ProveedorId
            );

            await _repo.Save(consorcio);
        } 
    }

}
