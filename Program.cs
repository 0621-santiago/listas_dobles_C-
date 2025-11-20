using System; // Importa el namespace System, necesario para usar la clase Console.


// Inicia la ejecución del programa.
Console.WriteLine("main de la lista doble:");

// Crea una instancia de la lista. Aquí se llama al constructor listas_dobles().
listas_dobles listasDobles = new listas_dobles();

listasDobles.agregar(10);
listasDobles.agregar(20);
listasDobles.agregar(30);
listasDobles.agregar(40);
listasDobles.agregar(50);
listasDobles.agregar(60);

// Muestra la lista .
listasDobles.MostrarLista();

listasDobles.eliminar(30); // Elimina un nodo del medio.
listasDobles.eliminar(45); // Intenta eliminar un nodo que no existe.

// Muestra la lista .
listasDobles.MostrarLista();
listasDobles.agregar(70);
listasDobles.eliminar(35);
listasDobles.MostrarLista();
listasDobles.agregar(30);
listasDobles.eliminar(70);
listasDobles.eliminar(60);
listasDobles.eliminar(50);
listasDobles.eliminar(40);
listasDobles.MostrarLista();
listasDobles.agregar(40);
listasDobles.agregar(50);
listasDobles.agregar(60);
listasDobles.agregar(70);
listasDobles.agregar(80);
listasDobles.agregar(90);
listasDobles.agregar(100);
listasDobles.MostrarLista();
// Muestra la lista al reves.
listasDobles.MostrarInverso();


// PARTE 2: DEFINICIÓN DE LA CLASE LISTAS_DOBLES 

public class listas_dobles 
{
    // Clase interna Nodo: Define la estructura de cada elemento de la lista.
    private class Nodo
    {
        public int dato;       // Campo para almacenar el valor (dato útil).
        public Nodo anterior;  // Puntero al nodo previo (enlace backward).
        public Nodo siguiente; // Puntero al nodo siguiente (enlace forward).

        // Constructor del nodo.
        public Nodo(int dato)
        {
            this.dato = dato;
            this.anterior = null; // Inicialmente, no tiene enlaces.
            this.siguiente = null;
        }
    }

    // Propiedades de control de la lista (punteros de inicio y fin).
    private Nodo cabeza; // Puntero al primer nodo.
    private Nodo cola;   // Puntero al último nodo.
    
    // Constructor de la lista.
    public listas_dobles()
    {
        cabeza = null; // Inicializa la lista como vacía.
        cola = null;
    }


    // MÉTODO AGREGAR (Insertar al final)
    
    public void agregar(int dato)
    {
        Nodo nuevo = new Nodo(dato); // Crea el nuevo nodo.

        // CASO 1: Si la lista está vacía.
        if (cabeza == null)
        {
            cabeza = nuevo; // El nuevo nodo es la cabeza.
            cola = nuevo;   // Y también es la cola.
        }
        // CASO 2: Si la lista ya tiene nodos.
        else
        {
            cola.siguiente = nuevo; // 1. Enlaza la cola existente al nuevo nodo (Forward).
            nuevo.anterior = cola;  // 2. Enlaza el nuevo nodo a la cola existente (Backward).
            cola = nuevo;           // 3. El nuevo nodo se convierte en la nueva cola.
        }
    }

    // =============================================================
    // MÉTODO MOSTRAR LISTA (Recorrido Forward)
    // =============================================================
    public void MostrarLista()
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo actual = cabeza; // Comienza el recorrido desde la cabeza.
        Console.Write("Lista lista en orden: ");

        while (actual != null) // Mientras no lleguemos al final de la lista.
        {
            Console.Write(actual.dato);

            if (actual.siguiente != null)
            {
                Console.Write(", ");
            }

            actual = actual.siguiente; // Avanza al siguiente nodo.
        }
        Console.WriteLine(); // Salto de línea al finalizar la impresión.
    }

    // MÉTODO ELIMINAR (Maneja 3 casos: Cabeza, Cola, Medio)

    public void eliminar(int dato)
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía, no se puede eliminar.");
            return;
        }

        // 1. Encontrar el nodo:
        Nodo actual = cabeza;
        // Recorre hasta encontrar el dato O hasta llegar al final.
        while (actual != null && actual.dato != dato)
        {
            actual = actual.siguiente;
        }

        // 2. Caso No Encontrado (Si el ciclo terminó porque actual es null).
        if (actual == null)
        {
            Console.WriteLine("El número " + dato + " no se encontró.");
            return;
        }

        // 3. Caso 1: Eliminar la CABEZA.
        if (actual == cabeza)
        {
            cabeza = cabeza.siguiente; // Mueve el puntero cabeza al siguiente nodo.
            if (cabeza != null)
            {
                cabeza.anterior = null; // Rompe el enlace backward de la nueva cabeza.
            }
            else
            {
                cola = null; // Si la lista se vació.
            }
        }
        // 4. Caso 2: Eliminar la COLA.
        else if (actual == cola)
        {
            cola = actual.anterior;      // Mueve 'cola' al nodo anterior (la nueva cola).
            cola.siguiente = null;       // Rompe el enlace forward de la nueva cola.
        }
        // 5. Caso 3: Eliminar un nodo del MEDIO.
        else
        {
            // Reconexión Forward: El nodo anterior salta a apuntar al nodo siguiente.
            actual.anterior.siguiente = actual.siguiente;
            // Reconexión Backward: El nodo siguiente salta a apuntar al nodo anterior.
            actual.siguiente.anterior = actual.anterior;
        }

        Console.WriteLine("Número " + dato + " eliminado.");
    }
    
    // =============================================================
    // MÉTODO MOSTRAR INVERSO (Recorrido Backward)
    // =============================================================
    public void MostrarInverso()
    {
        if (cola== null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo actual = cola; // Comienza el recorrido desde el final (cola).
        Console.Write("Lista al reves : ");

        while (actual != null) // Mientras no lleguemos al inicio de la lista (cabeza).
        {
            Console.Write(actual.dato);

            // Agrega flechas si hay un nodo anterior.
            if (actual.anterior != null)
            {
                Console.Write(", ");
            }

            actual = actual.anterior; // Avanza al nodo anterior (movimiento inverso).
        }
        Console.WriteLine();
    }
}