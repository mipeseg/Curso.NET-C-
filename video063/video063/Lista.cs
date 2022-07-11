using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace video063
{
    internal class Lista
    {
        public Lista()
        {

        }

        public void ejerciciosConList()
        {
            // Creacion de una lista

            List<int> listaNumeros = new List<int>();  // creamos una lista de enteros

            listaNumeros.Add(230);  // agregamos un valor entero al final de la lista
            listaNumeros.Add(7);  // agregamos un valor entero al final de la lista
            listaNumeros.Add(29);  // agregamos un valor entero al final de la lista
            listaNumeros[2] = 25;
            //listaNumeros[3] = 125;  // daria error pq el 4. elemento se tiene que crear con Add()

            Console.Write("La lista de numeros es: ");
            for (int i = 0; i < listaNumeros.Count; i++)
            {
                Console.Write($"{listaNumeros[i]}, ");
            }

            Console.WriteLine();

            // trabajando con la lista

            Console.Write("Cuantos elementos quieres anadir a la lista?: ");
            int elem = int.Parse(Console.ReadLine());

            for (int i = 0; i < elem; i++)
            {
                Console.Write($"Introduce el elemento {i}: ");
                listaNumeros.Add(int.Parse(Console.ReadLine()));
            }

            Console.Write("La lista de numeros es: ");
            for (int i = 0; i < listaNumeros.Count; i++)   // Count es una propiedad
            {
                Console.Write($"{listaNumeros[i]}, ");
            }

            Console.WriteLine();

            // anade elementos a la lista mientras no pulsemos cero

            do
            {
                Console.Write("Introduce un valor entero (0 para salir): ");
                elem = int.Parse(Console.ReadLine());
                if (elem != 0) listaNumeros.Add(elem);
            } while (elem != 0);

            //  listaNumeros.RemoveAt(listaNumeros.Count - 1);   // en lugar de usar if (elem != 0), podriamos quitar el ultimo elemento 0

            Console.Write("La lista de numeros es: ");
            foreach (int v in listaNumeros)
            {
                Console.Write($"{v}, ");
            }
        }
    }
}
