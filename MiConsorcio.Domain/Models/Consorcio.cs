using MiConsorcio.Domain.Enums;

namespace MiConsorcio.Domain.Models
{
    public class Consorcio
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        public string Cuit { get; private set; }
        public Direccion Direccion { get; private set; }
        public string? Codigo { get; private set; } //que es?
        public EEstadoUnidad Estado { get; private set; }


        private readonly List<UnidadFuncional> _unidades;
        public IReadOnlyCollection<UnidadFuncional> Unidades => _unidades;

        private readonly List<Expensa> _expensas = new();
        public IReadOnlyCollection<Expensa> Expensas => _expensas;

        private readonly List<Gasto> _gastos = new();
        public IReadOnlyCollection<Gasto> Gastos => _gastos;

        private readonly List<Pago> _pagos = new();
        public IReadOnlyCollection<Pago> Pagos => _pagos;

        protected Consorcio() { } // Para ORM

        public Consorcio(string nombre, string cuit, Direccion direccion, EEstadoUnidad estado)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("Nombre requerido");
            if (string.IsNullOrWhiteSpace(cuit))
                throw new ArgumentException("Cuit requerido");


            Nombre = nombre;
            Cuit = cuit;
            Direccion = direccion;
            Estado = estado;
        }
        public Expensa CalcularExpensa(Periodo periodo)
        {
            if (_expensas.Any(e => e.Periodo == periodo))
                throw new Exception("Ya existe una expensa para ese período");

            var expensa = new Expensa(periodo);

            var unidadesActivas = _unidades.Where(u => u.Estado == EEstadoUnidad.Activo).ToList();
            if (!unidadesActivas.Any())
                throw new Exception("No hay unidades funcionales activas");

            var gastosDelPeriodo = _gastos
                .Where(g => g.PeriodoContable == periodo)
                .ToList();

            var totalGastos = gastosDelPeriodo.Sum(g => g.Monto);
            if (totalGastos <= 0)
                throw new Exception("No hay gastos para calcular la expensa");

            var totalCoeficientes = unidadesActivas.Sum(u => u.Coeficiente);

            var acumulado = new Dictionary<Guid, decimal>();
            foreach (var uf in unidadesActivas)
            {
                var monto = totalGastos * (uf.Coeficiente / totalCoeficientes);
                monto = Math.Round(monto, 2);

                acumulado[uf.Id] = monto;
            }

            //foreach (var gasto in gastosDelPeriodo)
            //{
            //    foreach (var uf in unidadesActivas)
            //    {
            //        var monto = gasto.Monto * (uf.Coeficiente / totalCoeficientes);
            //        monto = Math.Round(monto, 2);

            //        acumuladoPorUf[uf.Id] += monto;
            //    }
            //}

            // Ajuste por redondeo
            var totalDistribuido = acumulado.Values.Sum();
            var diferencia = totalGastos - totalDistribuido;

            if (diferencia != 0)
            {
                var ufMayorCoef = unidadesActivas
                    .OrderByDescending(u => u.Coeficiente)
                    .First();

                acumulado[ufMayorCoef.Id] += diferencia;
            }

            foreach (var item in acumulado)
            {
                expensa.AgregarDetalle(item.Key, item.Value);
            }

            _expensas.Add(expensa);

            return expensa;
        }


        public void CerrarExpensa(Periodo periodo)
        {
            var expensa = _expensas.SingleOrDefault(e => e.Periodo == periodo)
                ?? throw new Exception("No existe expensa para ese período");

            expensa.Cerrar();
        }

        public void ImpactarExpensa(Periodo periodo)
        {
            var expensa = _expensas.Single(e => e.Periodo == periodo);

            if (expensa.Estado != EEstadoExpensa.Cerrada)
                throw new Exception("La expensa debe estar cerrada");

            foreach (var detalle in expensa.Detalles)
            {
                var uf = _unidades.Single(u => u.Id == detalle.UnidadFuncionalId);
                uf.Debitar(detalle.Monto);
            }
        }

        public void RegistrarGasto(DateTime fecha,decimal monto,string descripcion,Periodo periodoContable, ETipoGasto tipoGasto, Guid categoriaId, Guid proveedorId )
        {
            if (monto <= 0)
                throw new InvalidOperationException("Monto inválido");

            var gasto = new Gasto(
                this.Id,
                fecha,
                periodoContable,
                monto,
                tipoGasto,
                descripcion,
                categoriaId,
                proveedorId
            );

            _gastos.Add(gasto);
        }


        public void RegistrarPago(Guid ufId, decimal monto, EMedioDePago medioPago, DateTime fecha)
        {
            if (monto <= 0)
                throw new Exception("El monto del pago debe ser mayor a cero");

            var uf = _unidades.Single(u => u.Id == ufId);

            var pago = new Pago(this.Id, ufId, fecha, monto, medioPago);

            _pagos.Add(pago);

            uf.Acreditar(monto);
        }





    }

}
