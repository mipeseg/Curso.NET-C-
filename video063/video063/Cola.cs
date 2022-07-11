using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace video063
{
    internal class Cola
    {
        public static void ejerciciosConColas()  // static hace que no sean necesario una instancia de Cola para llamarlo
        {
            // creacion de una cola y adicion de elementos

            Queue<int> colaNumeros = new Queue<int>();

            foreach (int i in new int[] { 2, 4, 6, 8, 10 })    // agregamos a la Queue<T> todos los valores de un array
            {
                colaNumeros.Enqueue(i);   // anade el elemento al final de la lista
            }

            Console.Write("La cola de numeros es: ");
            foreach (int i in colaNumeros)    // visualizamos todos los valores de la Queue<T>
            {
                Console.Write($"{i}, ");   // La cola de numeros es: 2, 4, 6, 8, 10,
            }

            /*Console.Write("La cola de numeros es: ");    ERROR
            for(int i = 0; i<colaNumeros.Count; i++)    
            {
                Console.Write($"{colaNumeros[i]}, ");   // No se puede aplicar la indexacion con [] a una expresión del tipo 'Queue<int>'
            }*/

            Console.WriteLine();

            // Elimina un elemento de la cola

            colaNumeros.Dequeue();  // elimina y devuelve el primer elemento de la cola. O sea el 2
            Console.WriteLine($"Se ha eliminado el elemento {colaNumeros.Dequeue()}"); // elimina y devuelve el primer elemento de la cola. O sea el 4

            Console.Write("La cola de numeros es: ");
            foreach (int i in colaNumeros)    // visualizamos todos los valores de la Queue<T>
            {
                Console.Write($"{i}, ");   // La cola de numeros es: 6, 8, 10,
            }

            Console.WriteLine();

            // Visualiza el primer elemento de la cola

            Console.WriteLine($"El primer elemento de la cola es: {colaNumeros.Peek()}");   // devuelve el primer elemento de la cola sin eliminarlo

            // Crea una cola. Traslada sus valores a un array. Manipula los valores. Limpia la cola.
            // guarda los valores en la cola

            Queue<int> colaNumeros2 = new Queue<int>();  // creamos una cola de enteros
            colaNumeros2.Enqueue(2); colaNumeros2.Enqueue(4); colaNumeros2.Enqueue(6);  // anadimos 3 enteros
            int[] vector = new int[colaNumeros2.Count];  // creamos un array de 3 enteros

            Console.Write("La cola de numeros es: ");    // mostramos la cola a la vez que rellenamos el vector
            int j = 0;
            foreach (int i in colaNumeros2)
            {
                Console.Write($"{i}, ");   // La cola de numeros es: 2, 4, 6,
                vector[j] = i + 100;
                j++;
            }

            Console.WriteLine();
            colaNumeros2.Clear();   // borramos todos los elementos de la cola
                
            for(int i = 0; i < vector.Count(); i++)   // rellenamos la cola con los elementos del vector
                colaNumeros2.Enqueue(vector[i]);

            Console.Write("La cola de numeros es: ");    // mostramos la cola
            foreach (int i in colaNumeros2)
                Console.Write($"{i}, ");   // La cola de numeros es: 102, 104, 106,
        }
    }
}
