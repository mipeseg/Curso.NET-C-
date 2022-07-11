using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace video063
{
    internal class ListaEnlazada
    {
        public void ejerciciosConLinkedList()
        {
            // Creacion de una lista enlazada

            LinkedList<int> listaNumeros = new LinkedList<int>();  // creamos una lista enlazada de enteros

            listaNumeros.AddFirst(7);      // agregamos un valor entero al inicio de la lista enlazada

            foreach( int i in new int[] {10,8,6,42,0})    // agregamos a la LinkedList todos los valores de un array
            {
                listaNumeros.AddFirst(i);  
            }

            Console.Write("La lista de numeros es: ");
            foreach (int i in listaNumeros)    // agregamos a la LinkedList todos los valores de un array
            {
                Console.Write($"{i}, ");   // La lista de numeros es: 0, 42, 6, 8, 10, 7,
            }

            /*   ERROR
            Console.Write("La lista de numeros es: ");
            for (int i = 0; i < listaNumeros.Count; i++)
            {
                Console.Write($"{listaNumeros[i]}, ");  La indexacion con listas enlazadas no se permite
            }*/

            Console.WriteLine();

            listaNumeros.AddLast(-34);      // agregamos un valor entero al final de la lista enlazada

            Console.Write("La lista de numeros es: ");
            foreach (int i in listaNumeros)    // visualizamos la LinkedList 
            {
                Console.Write($"{i}, ");   // La lista de numeros es: 0, 42, 6, 8, 10, 7, -34,
            }

            Console.WriteLine();

            // otra forma de trabajar con nodos

            Console.Write("La lista de numeros es: ");
            for (LinkedListNode<int> nodo = listaNumeros.First ; nodo!=null ; nodo = nodo.Next)
            {
                int numero = nodo.Value;
                Console.Write($"{numero}, ");
            }

            Console.WriteLine();

            // buscamos un nodo con un valor introducido por teclado y anadimos un nodo con valor 111 antes y otro 
            // con valor 222 despues

            Console.Write("Introduce un numero a buscar en la lista: ");
            int n = int.Parse(Console.ReadLine());

            LinkedListNode<int> nodoEncontrado = listaNumeros.Find(n);   // busca el primer nodo que contenga n que encuentre en la lista enlaza. Devuelve null si no encuentra nada
            if( nodoEncontrado != null )
            {
                listaNumeros.AddBefore(nodoEncontrado, 111);   // anade un nodo q contiene 111 antes del nodoEncontrado
                listaNumeros.AddAfter(nodoEncontrado, 222);   // anade un nodo q contiene 222 despues del nodoEncontrado
                Console.Write("La lista de numeros es: ");
                foreach (int i in listaNumeros)    // visualizamos los cambios realizados en la LinkedList
                {
                    Console.Write($"{i}, ");   
                }
            }
            else
                Console.WriteLine($"No se ha encontrado el nodo con valor {n}");

            Console.WriteLine();

            // borramos un nodo de la lista

            Console.Write("Introduce un numero a borrar en la lista: ");
            n = int.Parse(Console.ReadLine());

            if(listaNumeros.Remove(n))   // borra el nodo con valor n. Si lo borra devuelve true. Si no lo encuentra false
            {
                Console.Write("La lista de numeros es: ");
                foreach (int i in listaNumeros)    // visualizamos los cambios realizados en la LinkedList
                    Console.Write($"{i}, ");
            }
            else
                Console.WriteLine($"No se ha encontrado el nodo con valor {n}");

            Console.WriteLine();

            // Dos formas de agregar datos a la lista enlazada
            // 1: crea un nodo con el valor 15 e insertalo al principio de la lista enlazada
            // 2: anade directamente el valor 30 al final de la lista enlazada
            
            LinkedListNode<int> miNodo = new LinkedListNode<int>(15);
            listaNumeros.AddFirst(miNodo);
            listaNumeros.AddLast(30);

            Console.Write("La lista de numeros es: ");
            foreach (int i in listaNumeros)    // visualizamos los cambios realizados en la LinkedList
                Console.Write($"{i}, ");



        }
    }
}
