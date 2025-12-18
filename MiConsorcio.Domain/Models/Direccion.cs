namespace MiConsorcio.Domain.Models
{
    public class Direccion
    {
        public string Calle { get; private set; }
        public string Ciudad { get; private set; }
        public string CodigoPostal { get; private set; }

        protected Direccion() { } // EF

        public Direccion(string calle, string ciudad, string codigoPostal)
        {
            Calle = calle;
            Ciudad = ciudad;
            CodigoPostal = codigoPostal;
        }
    }

}
