using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace video063
{
    internal class Pila
    {
        public static void ejerciciosConPilas()  // static hace que no sea necesario una instancia de Pila para llamarlo
        {
            // creacion de una pila y adicion de elementos

            Stack<int> pilaNumeros = new Stack<int>();

            foreach (int i in new int[] { 2, 4, 6, 8, 10 })    // agregamos a la Stack<T> todos los valores de un array
            {
                pilaNumeros.Push(i);   // anade el elemento al principio de la pila
            }

            Console.Write("La pila de numeros es: ");
            foreach (int i in pilaNumeros)    // visualizamos todos los valores de la Stack<T>
            {
                Console.Write($"{i}, ");   // La pila de numeros es: 10, 8, 6, 4, 2, 
            }

            /*Console.Write("La pila de numeros es: ");    ERROR
            for(int i = 0; i<pilaNumeros.Count; i++)    
            {
                Console.Write($"{pilaNumeros[i]}, ");   // No se puede aplicar la indexacion con [] a una expresión del tipo 'Stack<int>'
            }*/

            Console.WriteLine();

            // Elimina un elemento de la pila

            pilaNumeros.Pop();  // elimina y devuelve el primer elemento de la pila. O sea el 10
            Console.WriteLine($"Se ha eliminado el elemento {pilaNumeros.Pop()}"); // elimina y devuelve el primer elemento de la cola. O sea el 8

            Console.Write("La pila de numeros es: ");
            foreach (int i in pilaNumeros)    // visualizamos todos los valores de la Stack<T>
            {
                Console.Write($"{i}, ");   // La cola de numeros es: 6, 4, 2,
            }

            Console.WriteLine();

            // Visualiza el primer elemento de la pila

            Console.WriteLine($"El primer elemento de la pila es: {pilaNumeros.Peek()}");   // devuelve el primer elemento de la pila sin eliminarlo

            // Crea una pila. Traslada sus valores a un array. Manipula los valores. Limpia la pila.
            // guarda los valores en la pila

            Stack<int> pilaNumeros2 = new Stack<int>();  // creamos una pila de enteros
            pilaNumeros2.Push(2); pilaNumeros2.Push(4); pilaNumeros2.Push(6);  // anadimos 3 enteros
            int[] vector = new int[pilaNumeros2.Count];  // creamos un array de 3 enteros

            Console.Write("La pila de numeros es: ");    // mostramos la pila a la vez que rellenamos el vector
            int j = 0;
            foreach (int i in pilaNumeros2)
            {
                Console.Write($"{i}, ");   // La pila de numeros es: 6, 4, 2,
                vector[j] = i + 100;
                j++;
            }

            Console.WriteLine();
            pilaNumeros2.Clear();   // borramos todos los elementos de la pila
                
            for(int i = 0; i < vector.Count(); i++)   // rellenamos la pila con los elementos del vector
                pilaNumeros2.Push(vector[i]);        //  OJO:  vector 106,104,102 --> pila 102,104,106

            Console.Write("La pila de numeros es: ");    // mostramos la pila
            foreach (int i in pilaNumeros2)
                Console.Write($"{i}, ");   // La pila de numeros es: 102, 104, 106, 
        }
    }
}
