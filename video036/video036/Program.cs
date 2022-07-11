/*  Fuente: video36, video37, video38, video39, video40
    // TODO: 

    ARRAYS = MATRICES = ARREGLOS

       Un array es una estructura finita y homegenea de datos (del mismo tipo). Su sintaxis es:

          tipoDatos[] nombreArray;  // declaracion del array
          nombreArray = new tipoDatos[4];  // inicializacion: new lo crea en memoria, e indicamos el num y tipo de datos que contiene
          tipoDatos[] nombreArray = new tipoDatos[4];  // todo a la vez

          Ej:
                int[] edades;               // declaracion del array
                edades = new int[4];        // inicializacion: tendra 4 datos de tipo entero y se crea en memoria. Por defecto al ser enteros se almacena [0,0,0,0]
                int[] edades = new int[4];  // declaracion e inicializacion del array

                int[] enteros = {12,45,-3,7};  // creacion y asignacion de valores 

           NOTA: un array de enteros por defecto almacena 0. Un array de strings almacena por defevcto ""
                 un array de objetos por defecto almecena null.
      
    ARRAYS IMPLICITOS

        Es un array que almacena datos, pero no sabemos ni cuantos ni de que tipo.

                 var nombres = new[] {"Juan","Anna","Sole"};
                 var valores1 = new[] {"Juan","Anna",15};  // error pq los datos son de distinto tipo
                 var valores2 = new[] {2.5,10,15};  // aqui no da error aunq los tipo sean distintos

    ARRAYS DE OBJETOS

       ver el ejemplo

    ARRAYS DE CLASES ANONIMAS

        ver ejemplo

    RECORRIDO Y ACCESO DE ARRAYS (bucles for y foreach)

        for(iniciacion;condicion;incremento) { }
        foreach(tipoDelIterador interador in array) { } --> se usa para recorrer arrays de objetos, arrays implicitos, arrays dinamicos, o cuando no sabemos el numero de elementos del array

        ver ejemplo

    ARRAYS EN METODOS: COMO PARAMETROS Y COMO DEVOLUCION (RETURN)

        Los arrays se puede pasar como parametros a un metodo. Y hay metonos que pueden
        devolver arrays

        Ver los metodos: ProcesaDatos, ProcesaDatos2, ProcesaDatos3 y leerDatos

 */

using System;

namespace Video036
{
    class Empleados
    {
        // CAMPOS DE CLASE
        private string nombre;
        private int edad;


        // METODO CONSTRUCTOR
        public Empleados(string nombre, int edad)
        {
            this.nombre = nombre;
            this.edad = edad;   
        }

        // METODOS SETTER Y GETTER

        public string getInfo()
        {
            return "Empleado: " + nombre + " - " + edad + " anos";
        }
    }

    class Program
    {
        static void ProcesaDatos(int[] datos) // visualiza los datos de un array
        {
            foreach(int i in datos)
            {
                Console.Write($"{i}, ");
            }

            Console.WriteLine();
        }

        static int[] ProcesaDatos2(int[] datos)  // modifica los datos de un array y devuelve otro array
        {
            for (int i=0;i<datos.Length;i++)
            {
                datos[i] += 10;   // como el paso es por referencia, los cambios se almacenan en el array numeros
            }

            return datos;  // no seria necesario pq el paso de arrays a un metodo es por referencis
        }

        static void ProcesaDatos3(int[] datos)  // modifica los datos de un array y devuelve otro array
        {
            for (int i = 0; i < datos.Length; i++)
            {
                datos[i] += 10; 
            }
        }

        static int[] leerDatos()  
        {
            Console.Write("Numero de elementos del array: ");
            byte numElementos = byte.Parse(Console.ReadLine());

            int[] enteros = new int[numElementos]; // creamos un array de esas dimensiones

            for(int i = 0; i < enteros.Length; i++)
            {
                Console.Write($"Introduce el elemento {i}: ");
                enteros[i] = int.Parse(Console.ReadLine());
            }  

            return enteros;
        }


        static void Main(string[] args)
        {
            int[] edades = new int[4];  // declaracion e inicializacion del array 
            edades[0] = 23; edades[1] = -12; edades[3] = 167;   // asignacion de valores
            Console.WriteLine($"[{edades[0]},{edades[1]},{edades[2]},{edades[3]}]");

            string[] nombres = {"Pedro","Ana","Luis"}; // declaracion y asignacion de valores
            Console.WriteLine($"[{nombres[0]},{nombres[1]},{nombres[2]}]");

            // Excepcion System.IndexOutOfRangeException (RangeExceptionIndex was outside the bounds of the array)
            // Indice fuera de rango. Intentamos acceder a una posicion del array que no existe
            //Console.WriteLine($"{nombres[8]}");

            // double[] temps = new double[5];
            double[] temps = new double[5] {1.45, 34.6, 12.1, 23.4, 7.6};
            Console.WriteLine($"{temps[1]}");

            // Arrays implicitos

            var nombres2 = new[] { "Juan", "Anna", "Sole" };
            //var valores1 = new[] { "Juan", "Anna", 15 };  // error pq los datos son de distinto tipo
            var valores2 = new[] { 2.5, 10, 15 };  // aqui no da error aunq los tipo sean distintos

            // Arrays de objetos

            Empleados[] arrayEmpleados = new Empleados[3];
            Empleados ana = new Empleados("Ana",57);

            arrayEmpleados[0] = new Empleados("Sara", 37);
            arrayEmpleados[1] = ana;
            arrayEmpleados[2] = new Empleados("Tom", 17);

            Console.WriteLine($"{arrayEmpleados[0].getInfo()}");
            Console.WriteLine($"{arrayEmpleados[1].getInfo()}");
            // Console.WriteLine($"{arrayEmpleados[2].getInfo()}"); // System.NullReferenceException: 'Object reference not set to an instance of an object.'

            // Arrays de clases anonimas

            // Recordemos que una clase anonima se declara asi:
            // var miobjeto = new { p1 = valor, p2 = valor, ... };

            var persons = new[]
            {
                new {nombre = "Juan", edad=19},
                new {nombre = "Elena", edad=15},
                new {nombre = "Felipe", edad=25}
            };

            Console.WriteLine(persons[1]);
            Console.WriteLine(persons[0].nombre);

            //recorrido de arrays

            for(int i=0; i < persons.Length; i++)  // recorrido de principio a fin
            {
                Console.WriteLine(persons[i]);
            }

            for (int i = persons.Length-1; i >= 0; i--)  // recorrido de fin a principio
            {
                if (i==0)
                    Console.Write(valores2[i]);
                else
                    Console.Write(valores2[i] + ", ");
            }

            Console.WriteLine("");
            
            for (int i = 0; i < arrayEmpleados.Length; i++) 
            {
                Console.WriteLine(arrayEmpleados[i].getInfo());
            }

            foreach(Empleados emp in arrayEmpleados)
            {
                Console.WriteLine(emp.getInfo());
            }

            foreach (Double valor in valores2)
            {
                Console.Write(valor + ", ");
            }

            Console.WriteLine();

            foreach(var persona in persons)
            {
                Console.WriteLine(persona);
            }

            // trabajando con arrays y metodos

            int[] numeros = new int[4] {7,15,34,4};
            int[] numeros2;
            
            ProcesaDatos(numeros);

            numeros2 = ProcesaDatos2(numeros); // incremento cada valor de numeros en +10. El array devuelto se almacenar en numeros2

            for (int i = 0; i < numeros2.Length; i++)  // mostramos numeros2
            {
                Console.Write($"{numeros2[i]}, ");
            }

            Console.WriteLine();

            ProcesaDatos3(numeros);

            for (int i = 0; i < numeros.Length; i++)  // mostramos numeros2
            {
                Console.Write($"{numeros[i]}, ");
            }

            Console.WriteLine();

            // metodo que devuelve un array

            int[] misEnteros = leerDatos();

            for (int i = 0; i < misEnteros.Length; i++)  // mostramos numeros2
            {
                Console.Write($"{misEnteros[i]}, ");
            }


        }
    }
}