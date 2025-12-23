using MiConsorcio.Domain.Enums;

namespace MiConsorcio.Domain.Models
{
    public class CategoriaGasto
    {
        public int Id { get; private set; }

        public string Nombre { get; private set; }
        public string? Descripcion { get; private set; }

        public EEstadoCategoriaGasto Estado { get; private set; }

        protected CategoriaGasto() { } // EF

        private CategoriaGasto(string nombre, string? descripcion)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("El nombre de la categoría es obligatorio");

            Nombre = nombre.Trim();
            Descripcion = descripcion;
            Estado = EEstadoCategoriaGasto.Activa;
        }

        public static CategoriaGasto Crear(string nombre, string? descripcion)
        {
            return new CategoriaGasto(nombre, descripcion);
        }

        public void Desactivar()
        {
            Estado = EEstadoCategoriaGasto.Inactiva;
        }

    }

}
