using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI.Ejercicio46Guia
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cargando lista de productos....");
            var productos = new Dictionary<string, Producto>(); //productos x codigo.
            var precios = new Dictionary<string, Precio>(); //precios x codigo de producto.
            bool salir = false;
            while (!salir)
            {
                var producto = Producto.IngresarNuevo();
                if (productos.ContainsKey(producto.Codigo))
                {
                    Console.WriteLine("El producto ingresado ya existe.");
                    continue;
                }

                Console.WriteLine("Presione S para ingresar otro o cualquier tecla para continuar.");
                var tecla = Console.ReadKey(intercept: true);
                salir = tecla.Key != ConsoleKey.S;

                productos.Add(producto.Codigo, producto);
            }

            if (productos.Count == 0)
            {
                Console.WriteLine("No ha ingresado productos. Presione cualquier tecla para finalizar.");
                Console.ReadKey(intercept: true);
            }

            Console.WriteLine("Ingresando lista de precios...");
            salir = false;
            while (!salir)
            {
                var precio = Precio.IngresarNuevo();

                if (!productos.ContainsKey(precio.CodigoProducto))
                {
                    Console.WriteLine("No se encuentra el producto indicaado.");
                    continue;
                }

                if (precios.ContainsKey(precio.CodigoProducto))
                {
                    Console.WriteLine("Ya ha ingresado un precio para ese producto.");
                    continue;
                }

                Console.WriteLine("Presione S para ingresar otro o cualquier tecla para continuar.");
                var tecla = Console.ReadKey(intercept: true);
                salir = tecla.Key != ConsoleKey.S;

                precios.Add(precio.CodigoProducto, precio);
            }

            if (precios.Count == 0)
            {
                Console.WriteLine("No ha ingresado precios. Presione cualquier tecla para finalizar.");
                Console.ReadKey(intercept: true);
            }

            Console.WriteLine("--------------------");
            decimal total = 0M;
            while (true)
            {
                Console.WriteLine("Ingrese código de producto o '0' para salir:");
                var ingreso = Console.ReadLine().ToUpperInvariant();
                if (ingreso == "0")
                {
                    break;
                }

                if (!productos.ContainsKey(ingreso))
                {
                    Console.WriteLine("No existe ese código de producto.");
                    continue;
                }

                if (!precios.ContainsKey(ingreso))
                {
                    Console.WriteLine($"No hay precio para el producto {productos[ingreso].Nombre}");
                    continue;
                }

                total += precios[ingreso].Monto;
            }

            Console.WriteLine($"El total de los productos ingresados es: {total}");
            Console.ReadKey(intercept: true);
        }
    }
}
