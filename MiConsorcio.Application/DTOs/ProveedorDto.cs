using System;
using System.Collections.Generic;
using System.Text;

namespace MiConsorcio.Application.DTOs
{
    public class ProveedorDto
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }

}
