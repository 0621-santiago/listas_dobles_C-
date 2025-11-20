namespace BancoListasSimples
{
    // Class que representa una lista simple de cuentas bancarias
    public class ListaCuentas
    {
        // Clase interna: Nodo (cada nodo representa una cuenta bancaria)
        private class Nodo
        {
            public string NumeroCuenta;
            public string Titular;
            public double Saldo;
            public Nodo Siguiente;

            public Nodo(string numeroCuenta, string titular, double saldo)
            {
                NumeroCuenta = numeroCuenta;
                Titular = titular;
                Saldo = saldo;
                Siguiente = null;
            }
        }

        private Nodo cabeza;

        public ListaCuentas()
        {
            cabeza = null;
        }

        public void AgregarCuenta(string numeroCuenta, string titular, double saldoInicial)
        {
            Nodo nuevaCuenta = new Nodo(numeroCuenta, titular, saldoInicial);

            if (cabeza == null)
            {
                cabeza = nuevaCuenta;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevaCuenta;
            }

            Console.WriteLine($"Cuenta {numeroCuenta} registrada para {titular} con saldo inicial ${saldoInicial}.");
        }

        public void MostrarCuentas()
        {
            if (cabeza == null)
            {
                Console.WriteLine("No hay cuentas registradas.");
                return;
            }

            Console.WriteLine("\nLISTADO DE CUENTAS BANCARIAS:");
            Nodo actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine($"Cuenta: {actual.NumeroCuenta} | Titular: {actual.Titular} | Saldo: ${actual.Saldo}");
                actual = actual.Siguiente;
            }
        }

        public bool BuscarCuenta(string numeroCuenta)
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                if (actual.NumeroCuenta.Equals(numeroCuenta))
                {
                    Console.WriteLine($"Cuenta encontrada: {actual.NumeroCuenta} - Titular: {actual.Titular} - Saldo: ${actual.Saldo}");
                    return true;
                }
                actual = actual.Siguiente;
            }
            Console.WriteLine($"La cuenta {numeroCuenta} no se encontró.");
            return false;
        }

        public void EliminarCuenta(string numeroCuenta)
        {
            if (cabeza == null)
            {
                Console.WriteLine("No hay cuentas para eliminar.");
                return;
            }

            if (cabeza.NumeroCuenta.Equals(numeroCuenta))
            {
                Console.WriteLine($"Cuenta {cabeza.NumeroCuenta} eliminada correctamente.");
                cabeza = cabeza.Siguiente;
                return;
            }

            Nodo actual = cabeza;
            while (actual.Siguiente != null && !actual.Siguiente.NumeroCuenta.Equals(numeroCuenta))
            {
                actual = actual.Siguiente;
            }

            if (actual.Siguiente != null)
            {
                Console.WriteLine($"Cuenta {actual.Siguiente.NumeroCuenta} eliminada correctamente.");
                actual.Siguiente = actual.Siguiente.Siguiente;
            }
            else
            {
                Console.WriteLine($"No se encontró la cuenta {numeroCuenta}.");
            }
        }
    }
}