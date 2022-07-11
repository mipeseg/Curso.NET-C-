/*
    Fuente: video63, video64, video65, video66
    // TODO: Empezamos con el video

    COLECCIONES (https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic?view=net-6.0)

        * Son clases genericas que pertenecen al namespace System.Collection.Generic
        * Estas clases permiten almacenar cualquier tipo de elementos
        * No tienen las limitaciones de los arrays (pero consumen mas recursos). Permiten:
          ordenar, anadir elementos en tiempo de ejecucion, eliminar elementos, buscar, etc...

    TIPOS DE COLECCIONES MAS USADAS

            List<T>        lista: parecida a los arrays pero con metodos para agregar, eliminar, ordenar, buscar ...
            Queue<T>       cola: estructura FIFO (First input First output)
            Stack<T>       pila: estructura FILO (First input Last output)
            LinkedList<T>  lista enlazada: Se comporta como Queue o Stack pero con acceso aleatorio
            HastSet<T>     lista de valores sin ordenar
            Dictionary<TKey,Tvalue>  diccionario: almacena pares clave-valor
            SortedList<Tkey,Tvalue> Como el diccionario pero almacenar pares ordenados

    COLECCIONES DE CLASE LIST (LISTA)  https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.list-1?view=net-6.0

        Un objeto List<T> se trata de una coleccion de objetos de la clase <T>

        - funcionamiento interno de una List

            Conforme anadimos elementos, se van anadiendo en posiciones contiguas de la memoria.
            Esto significa que si elimamos un elemento, queda vacia esa posicion de memoria, y 
            para evitar esto se mueven los restantes datos una posicion hacia atras. Esto consume
            recursos y es menos eficiente

            Ej:  List<T>               obj1,obj2,obj3,obj4...objN
                 eliminamos obj2       obj1,    ,obj3,obj4...objN  -->  obj1,obj3,obj4...objN

            Ver los ejemplos con la List<int> listaNumeros

    COLECCIONES DE CLASE LINKEDLIST (LISTA ENLAZADA)  https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.linkedlist-1?view=net-6.0

        El funcionamiento de una List y de una Linkedlist es muy parecido, ya que comparten
        los mismos metodos (agregar, eliminar, buscar ...). La diferencia fundamental es la
        eficiencia. Veamos el funcionamiento interno de ambas

        - funcionamiento interno de una Linkedlist

            Un objeto Linkedlist<T> es una coleccion de objetos (NODOS) de la clase LinkedListNode<T>. 
            La estructura de un nodo es:

             NODO:             Enlace al nodo anterior     obj1    Enlace al nodo siguiente
        
            Por tanto en una Linkedlist<T> los NODOS no necesitan estar en posiciones contiguas. En el
            primer NODO de la LinkedList<T> el valor de su enlace inicial es null (no apunta a nadie)
            y en el ultimo NODO ocurre lo mismo. Ej:


                0x0000            Link(null)     obj1       Link(0x020A)
                .....
                0x020A            Link(0x0000)     obj2       Link(0xE300)
                .....
                0xE300            Link(0x020A)     objN       Link(null)

            Por tanto anadir o eliminar NODOS, es mas eficiente, ya que no es necesario desplazar
            los NODOS de posicion de memoria, sino que basta con actualizar los links.

            Cuando usar una Linkedlist<T>? Cuando vayamos a hacer muchas operaciones de adicion o eliminacion
 
    COLECCIONES DE CLASE QUEUE (COLAS)  https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.queue-1?view=net-6.0

        Un objeto de clase Queue<T> (cola) es una coleccion de objetos de clase T. El funcionamiento
        interno es FIFO (First In First Out). El primero en entrar es el primero en salir, es decir,
        que su funcionamiento es SECUENCIAL

        el metodo Enqueue() -> anade un elemento despues del ultimo elemento de la cola
        el metodo Dequeue() -> elimina elementos en el orden que entraron

        Cuando se usan las colas? En apps donde tengamos que realizar tareas de forma SECUENCIAL

    COLECCIONES DE CLASE STACK (PILAS)  https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.stack-1?view=net-6.0
 
        Un objeto de clase Stack<T> (pila) es una coleccion de objetos de clase T. Son la antitesis
        de las colas, es decir, una pila se comporta de forma LIFO (Last In First Out). El ultimo en
        entrar es el primero en salir.

        el metodo Push() -> anade un elemento antes del ultimo elemento de la pila
        el metodo Pop() -> elimina el ultimo elemento que entro

    COLECCIONES DE CLASE DICTIONARY (DICCIONARIOS)   https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0

        Un objeto de clase Dictionary<TKey,Tvalue> es una coleccion de objetos 
        KeyValuePair<Tkey,TValue> que almacenan pares clave-valor. Son como los arrays 
        asociativos de php. Consumen mas recursos pero son muy utiles con BBDD

        - el metodo Add(TKey,TValue) -> anade un objeto KeyValuePair<Tkey,TValue> al final del diccionario
                                      Tkey y TValue son genericos. Cada Tvalue esta identificado univocamente
                                      por su Tkey
            

        - el metodo Remove (Tkey) -> borra el objeto KeyValuePair<Tkey,TValue> asociado a Tkey y devuelve true. En cualquier 
                                     otro caso devuelve false
        
        - Para recorrer un Dictionary<TKey,Tvalue> usamos el bucle foreach
          OJO: El valor que devuelve foreach es de clase KeyValuePair<Tkey,TValue>
          Ej)
                    Dictionary<string,string> miDicc = new Dictionary<string,string>();
                    miDicc.Add("txt", "notepad.exe");
                    miDicc.Add("bmp", "paint.exe");
                    miDicc.Add("rtf", "wordpad.exe");

                    foreach( KeyValuePair<string,string> kvp in miDicc)
                    {
                        Console.WriteLine($"Key = {kvp.Key}, Value = {kvp.Value}");
                    }

 */

using System;
using System.IO;
using System.Collections.Generic;

namespace video063
{
    class Program
    {
        static void Main(string[] args)
        {

            // USO DE LAS COLECCIONES DE CLASE List<T>

            // Lista ejemplo1 = new Lista();
            // ejemplo1.ejerciciosConList();

            // USO DE LAS COLECCIONES DE CLASE Linkedlist<T>

            // ListaEnlazada ejemplo2 = new ListaEnlazada();
            // ejemplo2.ejerciciosConLinkedList();

            // USO DE LAS COLECCIONES DE CLASE Queue<T>

            // Cola.ejerciciosConColas();

            // USO DE LAS COLECCIONES DE CLASE Stack<T>

            // Pila.ejerciciosConPilas();

            // USO DE LAS COLECCIONES DE CLASE Dictionary<TKey,Tvalue>

            Diccionario.ejerciciosConDiccionarios();

        }
    }
}
