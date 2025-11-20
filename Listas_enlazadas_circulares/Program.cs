using System;

class Nodo
{
    public int dato;           // Guarda el valor del nodo
    public Nodo siguiente;     // Enlace al siguiente nodo

    public Nodo(int valor)
    {
        dato = valor;          // Inicializa el dato
        siguiente = null;      // Por defecto no apunta a nadie
    }
}

class ListaEnlazadaCircular
{
    private Nodo inicio;

    public ListaEnlazadaCircular()
    {
        inicio = null; // Lista vacía al crearla
    }

    // Insertar al final
    public void Insertar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor);

        if (inicio == null)
        {
            inicio = nuevoNodo;
            inicio.siguiente = inicio; // Un solo nodo apunta a sí mismo
        }
        else
        {
            Nodo actual = inicio;
            while (actual.siguiente != inicio)
            {
                actual = actual.siguiente;
            }
            // Enlaza el nuevo nodo al final y cierra el círculo
            actual.siguiente = nuevoNodo;
            nuevoNodo.siguiente = inicio; // Apunta al inicio
        }
    }

    // Eliminar un nodo
    public void Eliminar(int valor)
    {
        if (inicio == null)
        {
            Console.WriteLine("La lista está vacía");
            return;
        }

        if (inicio.dato == valor)
        {
            if (inicio.siguiente == inicio)
            {
                inicio = null; // Era el único nodo: ahora lista vacía
            }
            else
            {
                Nodo actual = inicio;
                while (actual.siguiente != inicio)
                {
                    actual = actual.siguiente;
                }
                // El último nodo ahora apuntará al segundo nodo
                actual.siguiente = inicio.siguiente;
                // Mover inicio al segundo nodo (nuevo inicio)
                inicio = inicio.siguiente;
            }
        }
        else
        {
            Nodo anterior = inicio;
            Nodo actual = inicio.siguiente;

            while (actual != inicio && actual.dato != valor)
            {
                anterior = actual;
                actual = actual.siguiente;
            }

            if (actual.dato == valor)
            {
                // Saltamos el nodo encontrado: lo desconectamos
                anterior.siguiente = actual.siguiente;
            }
            else
            {
                Console.WriteLine("Valor no encontrado");
            }
        }
    }

    // Buscar un valor
    
    public bool Buscar(int valor)
    {
        // Si la lista está vacía no hay nada que buscar
        if (inicio == null)
            return false;

        // Empezamos en el primer nodo
        Nodo actual = inicio;

        // Usamos do-while para garantizar que comprobamos `inicio` al menos una vez
        do
        {
            // 1) MIRAR: ¿el dato del nodo actual es el que buscamos?
            if (actual.dato == valor)
                return true; // Sí: devolvemos true

            // 2) AVANZAR: pasar al siguiente nodo
            actual = actual.siguiente;

            // Repetir hasta que volvamos al inicio
        } while (actual != inicio);

        // Si salimos del bucle, dimos la vuelta completa y no lo encontramos
        return false;
    }

    // Mostrar la lista
    public void Mostrar()
    {
        if (inicio == null)
        {
            Console.WriteLine("La lista está vacía");
            return;
        }

        Nodo actual = inicio;
        Console.Write("Lista: ");
        do
        {
            Console.Write(actual.dato + " -> "); // Imprime el dato y la flecha
            actual = actual.siguiente;            // Avanza al siguiente nodo
        } while (actual != inicio);
        Console.WriteLine("(vuelve al inicio)");
    }
}

class Program
{
    static void Main()
    {
        ListaEnlazadaCircular lista = new ListaEnlazadaCircular();

        // INSERTAR: añadimos varios valores de ejemplo
        lista.Insertar(10);
        lista.Insertar(20);
        lista.Insertar(30);
        lista.Insertar(40);
        lista.Insertar(50);

        // MOSTRAR: imprimimos la lista completa
        lista.Mostrar();

        // BUSCAR: comprobamos si existen valores
        Console.WriteLine("\nBuscando 30: " + lista.Buscar(30)); // true
        Console.WriteLine("Buscando 99: " + lista.Buscar(99)); // false

        // ELIMINAR: quitamos algunos nodos y mostramos resultados
        Console.WriteLine("\nEliminando 30...");
        lista.Eliminar(30);
        lista.Mostrar();

        // Eliminar el inicio
        Console.WriteLine("\nEliminando 10...");
        lista.Eliminar(10);
        lista.Mostrar();
    }
}


