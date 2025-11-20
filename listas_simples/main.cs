namespace BancoListasSimples
{
    public class principal
    {
        public static void Main()
        {
            ListaCuentas banco = new ListaCuentas();

            // *** CUENTAS PRECARGADAS ***
            banco.AgregarCuenta("1001", "Juan Pérez", 150000);
            banco.AgregarCuenta("1002", "María Gómez", 250000);
            banco.AgregarCuenta("1003", "Carlos Ramírez", 500000);
            banco.AgregarCuenta("1004", "Laura Castaño", 80000);

            int opcion = -1;

            do
            {
                Console.WriteLine("\n=== MENÚ BANCO SIMPLE ===");
                Console.WriteLine("1. Agregar cuenta");
                Console.WriteLine("2. Mostrar todas las cuentas");
                Console.WriteLine("3. Buscar cuenta por número");
                Console.WriteLine("4. Eliminar cuenta");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                string entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out opcion))
                {
                    Console.WriteLine("Debe ingresar un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese número de cuenta: ");
                        string numero = Console.ReadLine();
                        Console.Write("Ingrese nombre del titular: ");
                        string titular = Console.ReadLine();
                        Console.Write("Ingrese saldo inicial: ");
                        double saldo;

                        while (!double.TryParse(Console.ReadLine(), out saldo))
                        {
                            Console.Write("Por favor ingrese un valor numérico para el saldo: ");
                        }

                        banco.AgregarCuenta(numero, titular, saldo);
                        break;

                    case 2:
                        banco.MostrarCuentas();
                        break;

                    case 3:
                        Console.Write("Ingrese número de cuenta a buscar: ");
                        string numBuscar = Console.ReadLine();
                        banco.BuscarCuenta(numBuscar);
                        break;

                    case 4:
                        Console.Write("Ingrese número de cuenta a eliminar: ");
                        string numEliminar = Console.ReadLine();
                        banco.EliminarCuenta(numEliminar);
                        break;

                    case 0:
                        Console.WriteLine("Saliendo del sistema bancario...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

            } while (opcion != 0);
        }
    }
}