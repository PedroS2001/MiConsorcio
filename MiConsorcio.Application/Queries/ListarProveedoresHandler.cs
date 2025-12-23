using MediatR;
using MiConsorcio.Application.DTOs;
using MiConsorcio.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiConsorcio.Application.Queries
{
    public class ListarProveedoresHandler : IRequestHandler<ListarProveedoresQuery, List<ProveedorDto>>
    {
        private readonly IProveedorRepository _proveedorRepository;

        public ListarProveedoresHandler(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public async Task<List<ProveedorDto>> Handle(
            ListarProveedoresQuery request,
            CancellationToken cancellationToken)
        {
            var proveedores = await _proveedorRepository.GetAllAsync();

            return proveedores.Select(p => new ProveedorDto
            {
                Id = p.Id,
                RazonSocial = p.RazonSocial,
                Cuit = p.Cuil,
                Email = p.Email,
                Telefono = p.Telefono
            }).ToList();
        }
    }

}
