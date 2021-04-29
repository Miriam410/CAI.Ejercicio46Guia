using System;

namespace CAI.Ejercicio46Guia
{
    internal class Precio
    {
        private Precio(string codigoProducto, decimal monto)
        {
            CodigoProducto = codigoProducto;
            Monto = monto;
        }

        public string CodigoProducto { get; }
        public decimal Monto { get; }


        internal static Precio IngresarNuevo()
        {
            var codigoProducto = Ingresos.IngresarCodigoProducto();

            decimal monto = 0M;
            while (true)
            {
                Console.WriteLine("Ingrese el precio del producto.");
                var ingreso = Console.ReadLine();
                if (!decimal.TryParse(ingreso, out monto))
                {
                    Console.WriteLine("No ha ingresado un valor numérico válido.");
                    continue;
                }

                if (monto <= 0)
                {
                    Console.WriteLine("El precio debe ser mayor a 0.");
                    continue;
                }

                break;
            }

            return new Precio(codigoProducto, monto);
        }
    }
}