using MediatR;
using MiConsorcio.Application.Interfaces;
using MiConsorcio.Domain.Models;

namespace MiConsorcio.Application.UseCases.Gastos
{
    public class CrearCategoriaGastoHandler : IRequestHandler<CrearCategoriaGastoCommand, int>
    {
        private readonly ICategoriaGastoRepository _repository;

        public CrearCategoriaGastoHandler(ICategoriaGastoRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(
            CrearCategoriaGastoCommand request,
            CancellationToken cancellationToken)
        {
            var existe = await _repository.ExisteConNombre(request.Nombre);

            if (existe)
                throw new ApplicationException("Ya existe una categoría con ese nombre");

            var categoria = CategoriaGasto.Crear(
                request.Nombre,
                request.Descripcion);

            await _repository.AddAsync(categoria);

            return categoria.Id;
        }
    }

}
