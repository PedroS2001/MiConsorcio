using MediatR;
using MiConsorcio.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiConsorcio.Application.Queries
{
    public record ListarProveedoresQuery() : IRequest<List<ProveedorDto>>;

}
