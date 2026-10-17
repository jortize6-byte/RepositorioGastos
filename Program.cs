using System;
using System.Collections.Generic;

namespace RepositorioGastos
{
    public  class Program
    {
       public static void Main(string[] args)
        {
            GastoRepositorio repo = new GastoRepositorio();
            int opcion;
            do
            {
                Console.WriteLine();
                Console.WriteLine("===REPOSITORIO DE GASTOS===");
                Console.WriteLine("1. Registrar gasto");
                Console.WriteLine("2. Listar gastos");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una de las 3 opciones: ");
                string entrada = Console.ReadLine() ?? "";
                if (!int.TryParse(entrada, out opcion))
                {
                    opcion = -1;
                }
                switch (opcion)
                {
                    case 1:
                        RegistrarGasto(repo);
                        break;
                        case 2:
                        ListarGastos(repo);
                        break;
                    case 3:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break; 
                }
          } while (opcion != 3);
        }
        private static void RegistrarGasto(GastoRepositorio repo)
        {
            Console.Write("Descripcion:");
            string descripcion = Console.ReadLine() ?? "";
            Console.Write("Monto:");
            string montoTexto = Console.ReadLine() ?? "";
            Console.Write("Categoria:");
            string categoria = Console.ReadLine() ?? "";
           
            if (string.IsNullOrWhiteSpace(descripcion) || 
                string.IsNullOrWhiteSpace(categoria) || 
                !decimal.TryParse(montoTexto, out decimal monto) ||
                monto <= 0)
            {
                Console.WriteLine("No hay gastos registrados");
                return;
            }
            Gasto nuevo = new Gasto
            {
                Descripcion = descripcion.Trim(),
                Monto = monto,
                Categoria = categoria.Trim()
            };
            repo.Insertar(nuevo);
        }
        private static void ListarGastos(GastoRepositorio repo)
        {
            List<Gasto> gastos = repo.ListarTodos();
            if (gastos.Count == 0)
            {
                Console.WriteLine("No hay gastos registrados");
                return;
            }
            decimal total = 0;
            foreach (Gasto g in gastos)
            {
                Console.WriteLine(g.ToString());
                total += g.Monto;
            }
            Console.WriteLine($"TOTAL GASTADO:Q {total:N2}");
        }
    }
}
