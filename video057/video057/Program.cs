/*  Fuente: video57
    // TODO: Comenzamos con el video

    ESTRUCTURAS (STRUCTS) vs CLASES: Similitudes y diferencias

        - similitudes


        - diferencias

            - las clases se almacenan en la memoria heap (referencia) y las estrucutras en 
              la mem. stack (valor). Ej: Para los tipos primitivos se reserva espacio en la
              zona de memoria stack. Cuando definimos un array, se crea una referencia
              en la mem. stack que apunta al contenido del array en la mem. Heap . 
              Si instanciamos una clase, se crea una referencia en la mem. stack que 
              apunta al objeto que se se almacena en la memoria heap. Las estructuras, al igual
              que los tipos primitivos se almacenar en la memoria stack

                                                         STACK              HEAP
                 int z = 5;                                5                          
                 double[] nums = new double[4];           nums  ----------> [0,0,0,0]
                 Empleado emp1 = new Empleado("Juan");    emp1  ----------> objeto empleado <---  
                 Empleado emp2 = new Empleado("Lola");    emp2  ----------> objeto empleado     |
                 Empleado emp3 = emp1;                    emp3  --------------------------------
                 
                 struct Prueba { ... }                   estructura Prueba
                 Prueba pru1 = new Prueba();             pru1 (copia de Prueba)
                 Prueba pru2 = new Prueba();             pru2 (copia de Prueba)


            - la mem. stack es de acceso rapido. La mem. heap es mas lenta

            - la mem. stack almacena datos mas temporales. La mem. heap almacena datos mas duraderos
                ej) variables locales (con ambito de un metodo, de un bloque) se almacenan en el Stack, ya que se destruiran antes de acabar el programa
                    variables globales, clases, etc se almacenan en el Heap pq tienen que durar hasta q acabe la ejecucion del programa
            
            - la info en el stack se almacena en forma de pila LIFO (Last in First out)

            - Las estructuras no permite la declaracion del metodo constructor

            - En las estructuras el compilador no inicia los campos. Debe hacerlo el constructor

            - En la estructuras no hay sobrecarga de constructores

            - Las estructuras no heredan de clases pero si de interfaces

            - Las estructuras son selladas (sealed)

    USO DE LAS ESTRUCTURAS

       - Se usan cuando se necesita trabajar con una cantidad grande de datos en memoria.
        Ej) con gran cantidad de primitivos, con nums complejos, puntos 3D, com arrays ... 

       - Cuando las instancias no cambien (Sean inmutables)

       - Cuando la instancia tenga un tamano < 16 bytes

       - Cuando no necesite convertir a objeto (lo que llamamos boxed)

       - Cualquier otra razon de rendimiento

 */

using System;

namespace video055
{
    class Empleado
    {
        // CAMPOS O PROPIEDADES DE CLASE

        private double salarioBase;
        private double comision;

        // METODOS

        public Empleado(double salario, double comision)  // Metodo constructor
        {
            this.salarioBase = salario;
            this.comision = comision;
        }

        // Metodos setter y getter

        // Otros metodos
        public override string ToString() // estamos sobrescribiendo el metodo ToString heredado de la clase Object
        {
            return String.Format($"Salario y comision del empleado: {salarioBase} - {comision}");
        }

        public void cambiaSalario(Empleado emp, double incremento) // modifica salario y comision
        {
            emp.salarioBase += incremento;
            emp.comision += incremento;
        }

    }

    struct Empleado2
    {
        // CAMPOS O PROPIEDADES DE CLASE

        private double salarioBase;
        private double comision;

        // METODOS

        public Empleado2(double salario, double comision)  // Metodo constructor
        {
            this.salarioBase = salario;
            this.comision = comision;
        }

        // Metodos setter y getter

        // Otros metodos
        public override string ToString() // estamos sobrescribiendo el metodo ToString heredado de la clase Object
        {
            return String.Format($"Salario y comision del empleado: {salarioBase} - {comision}");
        }
        public void cambiaSalario(Empleado2 emp, double incremento) // modifica salario y comision
        {
            emp.salarioBase += incremento;
            emp.comision += incremento;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            // uso de una clase

            Empleado emp1 = new Empleado(1200,250);
            Console.WriteLine(emp1.ToString());  // idem con Console.WriteLine(emp1);
            emp1.cambiaSalario(emp1, 100);  //  la referencia emp1 esta en el stack y apunta el objeto Empleado en la mem. heap. Por tanto los cambios se guardan
            Console.WriteLine(emp1.ToString());

            // uso de una estructura

            Empleado2 emp2 = new Empleado2(950, 150);
            Console.WriteLine(emp2.ToString());  // idem con Console.WriteLine(emp1);
            emp2.cambiaSalario(emp2, 100);  //  pq muestra "950 - 150"?. pq no cambian los valores?. Pq emp2 es una copia de la estructura original Empleado2 q permanece inalterada. 
            Console.WriteLine(emp2.ToString());
        }
    }
}

