using System;
using System.Linq;

namespace CAI.Ejercicio46Guia
{
    internal class Producto //RECORD 
    {
        private Producto(string codigo, string nombre)
        {
            Codigo = codigo;
            Nombre = nombre;
        }

        public string Nombre { get; }
        public string Codigo { get; }

        internal static Producto IngresarNuevo()
        {
            string codigo = Ingresos.IngresarCodigoProducto();
            string nombre = Ingresos.IngresarCadena("Ingrese el nombre del producto.", 1, 30);

            return new Producto(codigo, nombre);
        }
    }
}