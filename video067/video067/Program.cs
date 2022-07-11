/*
    Fuente: video67, video68, video69
    //TODO: estamos al comienzo del video

    METODO-OBJETO DELEGADO vs METODO APUNTADO

        Un metodo-objeto delegado es una referencia a otro metodo. Es muy similar a los punteros de C++. 
        Sus utilidades son:

            - llamar a eventos (lo veremos en entornos graficos)
            - llamar a cualquier metodo de cualquier clase del proyecto (siempre que sean accesibles)
            - se reduce significativamente el codigo 
            - hacen que el codigo sea reutilizable

        Sintaxis:       

            class Prueba
            {
               public static void mensaje (string nombre);    // metodo apuntado. static para que sea invocado por la clase
               {
                  ....
               }
            }

            class Program
            {
                delegate void MetodoDelegado(string nombre);  // declaracion del metodo delegado
                
                static void Main(string[] args)
                {
                    // creamos el delagado y lo apuntamos al metodo mensajeBienvenida

                    MetodoDelegado delegado = new MetodoDelegado(Prueba.mensaje); 
                    delegado("Juan");   // el delegado invoca al metodo mensaje
                }
            }

            NOTA: el metodo delegado debera devolver el mismo tipo y tendra los mismos argumentos que
                  el metodo apuntado

        Veamos el ejemplo

    DELEGADOS PREDICADOS

        Son metodos delegados que devuelven true o false. Se usan en muchas tareas pero son muy
        utilizados para filtrar listas de valores (comprobando si los valores cumple ciertas
        condiciones). Su sintaxis:

                static bool damePares(int num)  // metodo apuntado
                {
                    if(num%2 == 0) return true;
                    else return false;
                }

                Predicate<int> delegadoPred = new Predicate<int>(damePares);  // el predicado apunta al metodo damePares
                List<int> numPares = listaNumeros.FindAll(delegadoPred);  // FindAll recorre la lista haciendo la tarea 'comprobar si es par'. Finalmente devuelve una lista de numeros pares

    EXPRESIONES LAMBDA

        Las expresiones lambda son como metodos sin nombres, anonimos. Se usan para: simplificar
        codigo, crear delegados sencillos, en expresiones LINQ query (ya las veremos), etc..

        Sintaxis:        parametros => expresion o bloque de instrucciones

*/

using System;
using System.IO;
using System.Collections.Generic;

namespace video067
{
    class Bienvenida
    {
        public static void mensajeBienvenida(string nombre)   // este metodo lleva static para poderlo llamar sin una instancia
        {
            Console.WriteLine($"Hola {nombre}. Que tal?");
        }
    }

    class Despedida
    {
        public static void mensajeDespedida(string nombre)   // este metodo lleva static para poderlo llamar sin una instancia
        {
            Console.WriteLine($"Hasta luego {nombre}. Que vaya bien");
        }
    }

    class Persona
    {
        // PROPIEDADES O CAMPOS CLAVE
        private string nombre;
        private int edad;

        // METODOS
        public Persona(string nombre, int edad)  // metodo constructor
        {
            this.nombre = nombre;
            this.edad = edad;
        }

        // setter y getter

        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }
    }

    class Program
    {

        // Definicion de un metodo delegado que puede llamar a cualquier metodo de cualquier clase
        delegate void MetodoDelegado(string nombre);

        // comprueba si un numero es par o impar
        static bool damePares(int num)
        {
            if(num%2 == 0) return true;
            else return false;
        }

        // Creamos un metodo que comprueba si existe una persona

        static string nombreBuscado;

        static bool existePersona(Persona persona)
        {
            if (persona.Nombre == nombreBuscado) return true;
            else return false;
        }

        public static int cuadrado (int num)
        {
            return num * num;
        }

        public delegate int delegadoMats(int num);  // declaramos un delegado

        public static int suma (int n1, int n2)
        {
            return n1 + n2;
        }

        public delegate int delegadoSuma(int num1, int num2);  // declaramos un delegado

        public delegate bool delegadoComparaEdadPersonas(int edad1, int edad2); // declaramos un delegado
        public delegate bool delegadoComparaNombrePersonas(string nom1, string nom2); // declaramos un delegado

        static void Main(string[] args)
        {
            // el metodo delagado se comporta como un objeto que apunta a otro metodo

            MetodoDelegado delegado = new MetodoDelegado(Bienvenida.mensajeBienvenida); // creamos el delagado y lo apuntamos al metodo mensajeBienvenida
            delegado("Juan");   // el delegado invoca al metodo mensajeBienvenida

            delegado = new MetodoDelegado(Despedida.mensajeDespedida); //  el delagado se apunta al metodo mensajeDespedida
            delegado("Juan");   // el delegado invoca al metodo mensajeDespedida

            // Creamos un delegado predicado que nos filtra los numeros pares de una lista

            List<int> listaNumeros = new List<int>() {1,2,3,4,5,6};  // creamos e inicializamos una lista
            listaNumeros.AddRange(new int[] {7,8,9});  // anade a la lista los elementos de una coleccion o de un array

            Console.Write("La lista de numeros es: ");
            foreach (int num in listaNumeros)
            {
                Console.Write($"{num}, ");  // La lista de numeros es: 1, 2, 3, 4, 5, 6, 7, 8, 9,
            }

            Console.WriteLine();

            Predicate<int> delegadoPred = new Predicate<int>(damePares);  // el predicado apunta al metodo damePares
            List<int> numPares = listaNumeros.FindAll(delegadoPred);  // FindAll recorre la lista haciendo la tarea 'comprobar si es par'. Finalmente devuelve una lista de numeros pares

            Console.Write("La lista de numeros pares es: ");
            foreach(int num in numPares)
            {
                Console.Write($"{num}, ");
            }

            Console.WriteLine();

            // Creamos un delegado predicado que comprueba si existe la persona de nombre "Juan"

            List<Persona> listaPersonas = new List<Persona>();  // creamos la lista de personas
            listaPersonas.Add(new Persona("Juan",18));  // anadimos personas
            listaPersonas.Add(new Persona("Maria", 28));  // anadimos personas
            listaPersonas.Add(new Persona("Maca", 45));  // anadimos personas

            Console.WriteLine("La lista de personas es:");
            foreach (Persona p in listaPersonas)
            {
                Console.WriteLine($"Nombre: {p.Nombre} Edad: {p.Edad}");
            }

            Predicate<Persona> delegadoPredicado = new Predicate<Persona>(existePersona);  // creamos el delegado predicado que apunta al metodo existePersona 
            
            Console.Write("Introduce el nombre a buscar: ");
            nombreBuscado = Console.ReadLine();

            if (listaPersonas.Exists(delegadoPredicado))
                Console.WriteLine($"{nombreBuscado} existe");
            else
                Console.WriteLine($"{nombreBuscado} no existe");

            // Expresiones Lambda

            delegadoMats operacion = new delegadoMats(cuadrado);  // el delegado operacion apunta al metodo cuadrado 
            Console.WriteLine($"4 al cuadrado es {operacion(4)}");

            delegadoMats operacion2 = new delegadoMats(num => num*num);  // otra forma usando expresiones lambda
            Console.WriteLine($"4 al cuadrado es {operacion(4)}");

            // expresion lamba con 2 parametros

            delegadoSuma operacionSuma = new delegadoSuma(suma);
            Console.WriteLine($"4 + 7 es {operacionSuma(4,7)}");

            delegadoSuma operacionSuma2 = new delegadoSuma((num1, num2) => num1 + num2);
            Console.WriteLine($"4 + 7 es {operacionSuma(4, 7)}");

            // lista de valores numericos. Mostar cuales son los numeros pares
            List<int>  listaNums = new List<int>() {1,2,3,4,5,6,7,8,9};

            List<int> numPars = listaNums.FindAll(i => i%2 == 0);

            Console.Write("La lista de numeros pares es: ");
            foreach (int num in numPars)
            {
                Console.Write($"{num}, ");  // La lista de numeros primo es: 2,4,6,8, 
            }

            Console.WriteLine();

            Console.Write("La lista de numeros pares es: ");
            numPares.ForEach(n => Console.Write($"{n}, "));

            Console.WriteLine();

            /*
            numPares.ForEach(n => { Console.Write("La lista de numeros pares es: ");
                                    Console.Write($"{n}, ");
                                  }); */

            // Comparar el nombre y la edad de dos personas

            Persona p1 = new Persona("Juana", 7);
            Persona p2 = new Persona("Juana", 9);

            delegadoComparaEdadPersonas comparaEdad = (persona1,persona2) => persona1 == persona2;
            Console.WriteLine($"p1 y p2 tienen la misma edad? {comparaEdad(p1.Edad, p2.Edad)}");

            delegadoComparaNombrePersonas comparaNombre = (persona1, persona2) => persona1 == persona2;
            Console.WriteLine($"p1 y p2 tienen el mismo nombre? {comparaNombre(p1.Nombre, p2.Nombre)}");

        }
    }
}
