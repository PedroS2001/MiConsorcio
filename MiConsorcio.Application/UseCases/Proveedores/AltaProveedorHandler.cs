using MediatR;
using MiConsorcio.Application.Interfaces;
using MiConsorcio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiConsorcio.Application.UseCases.Proveedores
{
    public class AltaProveedorHandler : IRequestHandler<AltaProveedorCommand, int>
    {
        private readonly IProveedorRepository _proveedorRepository;

        public AltaProveedorHandler(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public async Task<int> Handle(AltaProveedorCommand request,CancellationToken cancellationToken)
        {
            if (await _proveedorRepository.ExisteCuitAsync(request.Cuit))
                throw new Exception("Ya existe un proveedor con ese CUIT");

            var proveedor = new Proveedor(
                request.ConsorcioId,
                request.RazonSocial,
                request.Cuit,
                request.Actividad,
                request.Email,
                request.Telefono,
                Domain.Enums.EEstadoPersona.Activa
            );

            await _proveedorRepository.AddAsync(proveedor);

            return proveedor.Id;
        }
    }

}
