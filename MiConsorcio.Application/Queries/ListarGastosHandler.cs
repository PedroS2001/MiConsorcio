using MediatR;
using MiConsorcio.Application.DTOs;
using MiConsorcio.Application.Interfaces;
using MiConsorcio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiConsorcio.Application.Queries
{
    public class ListarGastosHandler : IRequestHandler<ListarGastosQuery, List<GastoDto>>
    {
        private readonly IConsorcioRepository _consorcios;
        private readonly IGastoRepository _gastos;


        public ListarGastosHandler(IConsorcioRepository consorcio, IGastoRepository gasto)
        {
            _consorcios = consorcio;
            _gastos = gasto;
        }

        public async Task<List<GastoDto>> Handle(ListarGastosQuery request, CancellationToken cancellationToken)
        {
            var query = await _consorcios.GetById(request.ConsorcioId);

            var gastos = await _gastos.ListarGastosAsync(request.ConsorcioId, request.Desde, request.Hasta);

            List<GastoDto> gastosDto = new List<GastoDto>();
            return gastos.Select(g => new GastoDto
            (
                g.Id,
                g.Fecha,
                g.Monto,
                g.CategoriaGastoId.ToString(),
                g.ProveedorId?.ToString(),
                g.Tipo.ToString(),
                g.Descripcion
            )).ToList();



            //foreach (Gasto item in gastos)
            //{
            //    GastoDto gastoDto = new GastoDto
            //    (
            //        Id: item.Id,
            //        Fecha: item.Fecha,
            //        Importe: item.Monto,
            //        Categoria: item.CategoriaGastoId.ToString(), // Assuming CategoriaGastoId is a string representation
            //        Proveedor: item.ProveedorId?.ToString(), // Assuming ProveedorId is a string representation
            //        MedioPago: item.Tipo.ToString(), // Assuming Tipo represents MedioPago
            //        Descripcion: item.Descripcion
            //    );
            //    gastosDto.Add(gastoDto);
            //}
            //return gastosDto;
        }

    }
}
