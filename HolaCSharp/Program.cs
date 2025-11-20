using System;

namespace ListaDobleCircular
{

    // Clase que representa un nodo de la lista doble circular

    class Nodo
    {
        public int Valor;         // Dato almacenado en el nodo
        public Nodo Siguiente;    // Referencia al siguiente nodo
        public Nodo Anterior;     // Referencia al nodo anterior

        // Constructor que inicializa el valor del nodo
        public Nodo(int valor)
        {
            Valor = valor;
            Siguiente = null;
            Anterior = null;
        }
    }

    // Clase que representa una Lista Doble Enlazada Circular
    class ListaDobleCircular
    {
        private Nodo cabeza;  // Primer nodo de la lista
        public int Cantidad { get; private set; } = 0; // Contador de nodos

    
        // MÉTODO: AgregarAlFinal
        // Agrega un nodo con un valor al final de la lista

        public void AgregarAlFinal(int valor)
        {
            Nodo nuevo = new Nodo(valor); // Crear el nuevo nodo

            if (cabeza == null)
            {
                // Si la lista está vacía, el nuevo nodo se enlaza consigo mismo
                cabeza = nuevo;
                nuevo.Siguiente = nuevo;
                nuevo.Anterior = nuevo;
            }
            else
            {
                // Si la lista no está vacía, se inserta entre la "cola" y la "cabeza"
                Nodo cola = cabeza.Anterior;  // Último nodo actual
                cola.Siguiente = nuevo;       // La cola apunta al nuevo nodo
                nuevo.Anterior = cola;        // El nuevo nodo apunta hacia atrás a la cola
                nuevo.Siguiente = cabeza;     // Y apunta hacia adelante a la cabeza
                cabeza.Anterior = nuevo;      // La cabeza apunta hacia atrás al nuevo nodo
            }

            Cantidad++; // Aumentamos el conteo de nodos
        }

        // -------------------------------------------------------
        // MÉTODO: AgregarAlInicio
        // Agrega un nodo al inicio de la lista
        // -------------------------------------------------------
        public void AgregarAlInicio(int valor)
        {
            AgregarAlFinal(valor);   // Se agrega al final
            cabeza = cabeza.Anterior; // El último nodo agregado se convierte en la nueva cabeza
        }

        // -------------------------------------------------------
        // MÉTODO: BuscarNodo
        // Busca un nodo que contenga un valor específico
        // -------------------------------------------------------
        private Nodo BuscarNodo(int valor)
        {
            if (cabeza == null) return null; // Si la lista está vacía, no hay nada que buscar

            Nodo actual = cabeza;
            do
            {
                if (actual.Valor == valor)
                    return actual; // Si encontramos el valor, devolvemos el nodo

                actual = actual.Siguiente;
            } while (actual != cabeza); // Recorremos hasta volver a la cabeza

            return null; // No se encontró el valor
        }

        // -------------------------------------------------------
        // MÉTODO: Eliminar
        // Elimina el primer nodo que contenga un valor específico
        // -------------------------------------------------------
        public bool Eliminar(int valor)
        {
            Nodo nodo = BuscarNodo(valor); // Buscar el nodo a eliminar
            if (nodo == null) return false; // Si no existe, no se elimina nada

            if (nodo.Siguiente == nodo)
            {
                // Si solo hay un nodo, la lista queda vacía
                cabeza = null;
            }
            else
            {
                // Se enlazan los nodos anterior y siguiente, "saltando" el nodo eliminado
                nodo.Anterior.Siguiente = nodo.Siguiente;
                nodo.Siguiente.Anterior = nodo.Anterior;

                // Si el nodo eliminado era la cabeza, actualizamos la referencia
                if (nodo == cabeza)
                    cabeza = nodo.Siguiente;
            }

            Cantidad--; // Reducimos el contador
            return true; // Eliminación exitosa
        }


        // MÉTODO: RecorrerAdelante
        // Recorre la lista desde la cabeza hacia adelante
        public void RecorrerAdelante(Action<int> accion)
        {
            if (cabeza == null) return; // Si la lista está vacía, no hay nada que recorrer

            Nodo actual = cabeza;
            do
            {
                accion(actual.Valor); // Ejecuta la acción para cada valor (por ejemplo, imprimir)
                actual = actual.Siguiente; // Avanza al siguiente nodo
            } while (actual != cabeza);
        }


        // MÉTODO: RecorrerAtras
        // Recorre la lista desde la cola hacia atrás
    
        public void RecorrerAtras(Action<int> accion)
        {
            if (cabeza == null) return; // Lista vacía

            Nodo actual = cabeza.Anterior; // Comenzamos desde la cola
            Nodo cola = actual;            // Guardamos la referencia de inicio

            do
            {
                accion(actual.Valor); // Ejecuta la acción
                actual = actual.Anterior; // Retrocede al nodo anterior
            } while (actual != cola);
        }

        
        // MÉTODO: EstaVacia
        // Retorna true si la lista no tiene elementos
        public bool EstaVacia()
        {
            return cabeza == null;
        }
    }


    // PROGRAMA PRINCIPAL

    class Programa
    {
        static void Main()
        {
            var lista = new ListaDobleCircular();

            // Agregamos algunos valores a la lista
            lista.AgregarAlFinal(10);
            lista.AgregarAlFinal(20);
            lista.AgregarAlInicio(5);  // Lista: 5, 10, 20
            lista.AgregarAlFinal(30);  // Lista: 5, 10, 20, 30

            Console.WriteLine("Recorrido hacia adelante:");
            lista.RecorrerAdelante(valor => Console.Write(valor + " "));
            Console.WriteLine();

            Console.WriteLine("Recorrido hacia atrás:");
            lista.RecorrerAtras(valor => Console.Write(valor + " "));
            Console.WriteLine();

            Console.WriteLine($"Cantidad de elementos: {lista.Cantidad}");

            Console.WriteLine("\nEliminamos el número 10:");
            lista.Eliminar(10);

            Console.WriteLine("Lista después de eliminar 10:");
            lista.RecorrerAdelante(valor => Console.Write(valor + " "));
            Console.WriteLine();

            Console.WriteLine("\nEliminamos el primer elemento (5):");
            lista.Eliminar(5);

            Console.WriteLine("Lista final:");
            lista.RecorrerAdelante(valor => Console.Write(valor + " "));
            Console.WriteLine();

            Console.WriteLine($"¿La lista está vacía? {lista.EstaVacia()}");
        }
    }
}