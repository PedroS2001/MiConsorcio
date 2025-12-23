using MediatR;
using MiConsorcio.Application.Interfaces;
using MiConsorcio.Domain.Enums;
using MiConsorcio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiConsorcio.Application.UseCases.Gastos
{
    public class RegistrarGastoHandler : IRequestHandler<RegistrarGastoCommand, Guid>
    {
        private readonly IGastoRepository _gastoRepository;
        private readonly IConsorcioRepository _consorcioRepository;

        public RegistrarGastoHandler(
            IGastoRepository gastoRepository,
            IConsorcioRepository consorcioRepository)
        {
            _gastoRepository = gastoRepository;
            _consorcioRepository = consorcioRepository;
        }

        public async Task<Guid> Handle(RegistrarGastoCommand request, CancellationToken cancellationToken)
        {
            var consorcio = await _consorcioRepository.GetById(request.ConsorcioId);
            if (consorcio is null)
                throw new Exception("Consorcio inexistente");

            Periodo periodo = new Periodo(request.PeriodoAnio, request.PeriodoMes);
            var gasto = Gasto.Crear(request.ConsorcioId, request.Fecha, periodo, request.Importe, request.tipo, request.Descripcion, request.CategoriaId, request.ProveedorId);

            await _gastoRepository.AddAsync(gasto);

            return gasto.Id;
        }
    }


}
