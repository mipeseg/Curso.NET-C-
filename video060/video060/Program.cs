/*
    Fuente: video60, video61, video62
    // TODO: estamos al comiendo del video

    PROGRAMACION GENERICA (GENERICOS)

        La PG consiste en crear clases que permiten manejar cualquier clase
        de objeto. Esto se consigue indicando la clase de objeto que vamos a manejar (mediante
        el parametro de tipo). La sintaxis es:

                ClaseEjemplo obj1 = new ClaseEjemplo();  // lo visto hasta ahora
                ClaseEjemplo <String> obj1 = new ClaseEjemplo<String>();  // String es el parametro de tipo. La clase manejara un objeto String
                ClaseEjemplo <File> fichero = new ClaseEjemplo<File>();  // La clase manejara un objeto File
                

        Ventajas:

          - mayor sencillez del codigo
          - permite reutilizar el codigo (al igual que haciamos con la herencia de clases)
          - se pueden comprobar errores en tiempo de compilacion

        Inconvenientes:

          - uso continuo del casting, lo cual, complica el codigo
          - no hay posibilidad de comprobacion de errores

        Ejemplo: Veamos la clase AlmacenObjetos. Es una clase capaz de almacenar cualquier objeto
                 En lugar de usar PG lo haremos con herencia de clases. Las desventajas es que hemos
                 de hacer constantemente casting y que no vemos los errores en tiempo de compilacion

    CREACION DE UNA CLASE GENERICA

        Vamos a crear una clase generica AlmacenObjetos2 partiendo de AlmacenObjetos. Sintaxis

                class AlmacenObjetos2<T>  // Usaremos T como el tipo generico donde nos convenga
                {
                      // CAMPOS DE CLASE O PROPIEDADES

                      private T[] elementos; 
                    
                      ....
                    
                      // METODO CONSTRUCTOR

                      public AlmacenObjetos2(int z)  // z = num de objetos que contendra el array
                      {
                        elementos = new T[z];  //  creamos el array de tipo generico de z elementos
                      }

                      ...
                }

    CREACION DE UNA CLASE GENERICA CON RESTRICCIONES

        Las restricciones se utilizan para evitar que una clase generica use alguna clase
        que le indiquemos. Veamos el ejemplo de la clase AlmacenObjetos3

                class AlmacenObjetos3<T> where T: IParaEmpleados
                {
                    // el resto del codigo es igual que en la clase AlmacenObjetos2
                }
        
 */

using System;
using System.IO;

namespace video060
{
    class AlmacenObjetos 
    {
        // PROPIEDADES O CAMPOS DE CLASE

        private Object[] elementos;  // array donde almacenar los objetos
        private int i = 0;  // contador

        // METODOS DE CLASE

        // metodo constructor
        public AlmacenObjetos(int z)  // z = num de objetos que se pueden almacenar
        {
            elementos = new Object[z];
        }

        // setter y getter

        public Object getElemento(int i)
        {
            return elementos[i];
        }

        // otros metodos
        public void agregar(Object obj)
        {
            elementos[i] = obj;
            i++;
        }
    }
    class AlmacenObjetos2<T>      // CLASE GENERICA  <tipo generico>  La letra T es por convencion
    {
        // PROPIEDADES O CAMPOS DE CLASE

        private T[] elementos;  // declaramos un array generico donde almacenar objetos de cualquier clase
        private int i = 0;  // contador

        // METODOS DE CLASE

        // metodo constructor
        public AlmacenObjetos2(int z)  // z = num de objetos que contendra el array
        {
            elementos = new T[z];  //  creamos el array de tipo generico de z elementos
        }

        // setter y getter

        public T getElemento(int i)    // recibe el indice del objeto generico que queremos devolver
        {
            return elementos[i];
        }

        // otros metodos
        public void agregar(T obj)    // recibe un objeto generico y lo almacena en el array elementos
        {
            elementos[i] = obj;
            i++;
        }
    }
    class AlmacenObjetos3<T> where T: IParaEmpleados   // CLASE GENERICA que solo admite empleados con salario
    {
        // PROPIEDADES O CAMPOS DE CLASE

        private T[] elementos;  // declaramos un array generico donde almacenar objetos de cualquier clase
        private int i = 0;  // contador

        // METODOS DE CLASE

        // metodo constructor
        public AlmacenObjetos3(int z)  // z = num de objetos que contendra el array
        {
            elementos = new T[z];  //  creamos el array de tipo generico de z elementos
        }

        // setter y getter

        public T getElemento(int i)    // recibe el indice del objeto generico que queremos devolver
        {
            return elementos[i];
        }

        // otros metodos
        public void agregar(T obj)    // recibe un objeto generico y lo almacena en el array elementos
        {
            elementos[i] = obj;
            i++;
        }
    }

    class Empleado
    {
        // CAMPOS DE CLASE O PROPIEDADES
        private double salario;

        // METODOS DE CLASE

        public Empleado(double salario)  // metodo constructor
        {
            this.salario = salario;
        }

        // setter y getter
        public double getSalario()
        {
            return salario;
        }
    }

    interface IParaEmpleados
    {
        // metodos a implementar en las clases herederas
        double getSalario();
    }

    class Director : IParaEmpleados
    {
        // CAMPOS DE CLASE O PROPIEDADES
        private double salario;

        // METODOS DE CLASE
        public Director(double salario)   // metodo constructor
        {
            this.salario=salario;
        }

        // OTROS METODOS
        public double getSalario()   // metodo a implementar de IParaEmpleados
        {
            return salario;
        }
    }

    class Secretaria : IParaEmpleados
    {
        // CAMPOS DE CLASE O PROPIEDADES
        private double salario;

        // METODOS DE CLASE
        public Secretaria(double salario)   // metodo constructor
        {
            this.salario = salario;
        }

        // OTROS METODOS
        public double getSalario()   // metodo a implementar de IParaEmpleados
        {
            return salario;
        }
    }

    class Electricista : IParaEmpleados
    {
        // CAMPOS DE CLASE O PROPIEDADES
        private double salario;

        // METODOS DE CLASE
        public Electricista(double salario)   // metodo constructor
        {
            this.salario = salario;
        }

        // OTROS METODOS
        public double getSalario()   // metodo a implementar de IParaEmpleados
        {
            return salario;
        }
    }

    class Estudiante
    {

        // CAMPOS DE CLASE O PROPIEDADES
        private int edad;

        // METODOS DE CLASE
        public Estudiante (int edad)   // metodo constructor
        {
            this.edad = edad;
        }

        // OTROS METODOS
        public int getEdad()   // metodo getter
        {
            return edad;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int i = 125;
            StreamReader fichero = null;

            AlmacenObjetos miAlmacen = new AlmacenObjetos(4);   // creamos un array de Object de 4 elementos
            miAlmacen.agregar("Juan");
            miAlmacen.agregar(i);
            miAlmacen.agregar(fichero);
            miAlmacen.agregar(new Empleado(1500.45));

            string nombrePersona = (string) miAlmacen.getElemento(0);
            Console.WriteLine(nombrePersona);
            Console.WriteLine(miAlmacen.getElemento(1)); // no hace falta casting porque es un objeto int
            Console.WriteLine((string)miAlmacen.getElemento(2)); // el valor null no se imprime

            Empleado emp = (Empleado) miAlmacen.getElemento(3); // casting de Object a Empleado
            Console.WriteLine($"El salario del empleado es {emp.getSalario()} euros");

            // uso de la clase generica AlmacenObjetos2

            AlmacenObjetos2<Empleado> miAlm = new AlmacenObjetos2<Empleado>(4);   // creamos objeto que contendra un array de 4 objetos Empleado
            miAlm.agregar(new Empleado(1500));
            miAlm.agregar(new Empleado(2500));
            miAlm.agregar(new Empleado(3500.60));
            miAlm.agregar(new Empleado(4500));
            Empleado emp2 = miAlm.getElemento(2);
            Console.WriteLine($"El salario del empleado es {emp2.getSalario()} euros");

            AlmacenObjetos2<DateTime> misFechas = new AlmacenObjetos2<DateTime>(3);   // creamos objeto que contendra un array de 3 objetos DateTime
            misFechas.agregar(new DateTime());             // 01/01/0001 0:00:00
            misFechas.agregar(new DateTime(2022,09,14));   // 14/09/2022 0:00:00
            misFechas.agregar(new DateTime(1978,11,22));   // 22/11/1978 0:00:00
            DateTime fecha = misFechas.getElemento(1);
            Console.WriteLine($"La fecha es {fecha}");

            // uso de la clase generica con restricciones AlmacenObjetos3 para manejar Secretaria
            // lo mismo podria manejar ibjetos de la clase Director y Electricista

            AlmacenObjetos3<Secretaria> empleadosConSalario = new AlmacenObjetos3<Secretaria>(3);   // creamos un objeto que contendra un array de 3 objetos Secretaria
            empleadosConSalario.agregar(new Secretaria(4500));
            empleadosConSalario.agregar(new Secretaria(3500));
            empleadosConSalario.agregar(new Secretaria(2500));
            Secretaria sec = empleadosConSalario.getElemento(2);
            Console.WriteLine($"El sueldo de secretaria es {sec.getSalario()} euros");

            // el siguiente codigo da error pq la clase Estudiante no se admite como parametro de tipo T
            // debido a la restriccion que tiene la clase generica AlmacenObjetos3

            /*AlmacenObjetos3<Estudiante> misEstudiantes = new AlmacenObjetos3<Estudiante>(3);   // creamos un objeto que contendra un array de 3 objetos Estudiante
            misEstudiantes.agregar(new Estudiante(23));
            misEstudiantes.agregar(new Estudiante(34));
            misEstudiantes.agregar(new Estudiante(17));
            Estudiante e = misEstudiantes.getElemento(2);
            Console.WriteLine($"El sueldo de secretaria es {e.} euros");*/


        }
    }
}
