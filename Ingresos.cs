using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI.Ejercicio46Guia
{
    public static class Ingresos
    {
        public static string IngresarCadena(string texto, int largoMin, int largoMax)
        {
            while (true)
            {
                Console.WriteLine(texto);
                string ingreso = Console.ReadLine();

                if (ingreso.Length < largoMin || ingreso.Length > largoMax)
                {
                    Console.WriteLine($"Debe ingresar entre {largoMin} y {largoMax} caracteres.");
                    continue;
                }

                return ingreso;
            }
        }

        public static string IngresarCodigoProducto()
        {
            string codigo = null;
            while (true)
            {
                codigo = Ingresos.IngresarCadena("Ingrese un código de producto.", 6, 6).ToUpperInvariant();
                if (codigo.Any(c => c < 'A' || c > 'Z'))
                {
                    Console.WriteLine("Debe contener 6 letras.");
                    continue;
                }

                break;
            }

            return codigo;
        }

    }
}
