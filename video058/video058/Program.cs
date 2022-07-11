/*
    Fuente: video58, video59
    // TODO: Estamos al comienzo del video

    TIPO ENUMERADO (enum)

        Un tipo Enum es un cjto de constantes con nombre. Se usan para representar
        y manejar valores fijos o constantes. Otra opcion seria declarar tantas 
        constantes como fuera necesario, pero es poco practico. Su sintaxis es:

                     enum nombreDeEnumeracion {nom1, nom2, nom3, ...};

        ej) representar dias de la semana, meses del anyo, estaciones ...

        NOTA: una variable enum puede tener el ambito que queramos, pero lo habitual
              es que se cree en el namespace, para que la puedan usar todas las
              clases (presentes y futuras)

    METODO DESTRUCTOR 

        Para hablar de destructor hay que saber que es un Garbage Collector (recolector de basura).
        Cuando declaramos variables, objetos ... se van almacenando en la mem. stack o en la mem. heap
        segun corresponda. Y aunque las memorias actuales son extensas llegarian a saturase.

        Por eso, el recolector de basura detecta cuando un recurso ya no se va a usar y lo elimina de
        las memoria. En los lenguajes antiguos el GC no era automatico y era el programador el que
        tenia que llamarlo. Los lenguajes modernos tienen un GC automatico.

        Un metodo destructor ejecuta su bloque de instrucciones cuando el GC destruya un recurso
        de la memoria. Ejemplos de uso: Conexiones de BBDD, cierre de ficheros, 
        eliminacion de objetos ...

        La sintaxis de un destructor es:

                ~NombreClase()   // Metodo destructor
                { 
                    // codigo que se ejecuta cuando el GC elimine el recurso en memoria
                    .....
                }

        NOTAS:
          * Los metodos destructores se usan solo en Clases
          * Cada Clase solo puede tener un metodo destructor ( no se sobrecargan)
          * los metodos destructores no se heredan
          * los metodos destructores se invocan automaticamente
          * los metodos destructores no tienen modificadores de acceso, ni devuelven nada, ni parametros
        
        RECOMENDACION: Lo normal es que NO IMPLEMENTEMOS EL DESTRUCTOR y dejemos trabajar al GC

 */

using System;
using System.IO;

namespace video058
{ 
    enum Estaciones {Primavera, Verano, Otono, Invierno};  // cada constante recibe un valor por defecto 0, 1, 2, 3
    enum Bonus {bajo=500, normal=1000, bueno=1500, extra=3000};  // cambiamos los valores por defecto de las constantes

    class Empleado
    {
        // CAMPOS O PROPIEDADES DE CLASE
        private double salario, bonus;

        // METODOS DE CLASE

        public Empleado(Bonus bonusEmpleado, double SalarioBase)   // metodo constructor
        {
            this.bonus = (double) bonusEmpleado;
            this.salario = SalarioBase;
        }

        // metodos setter y getter

        public double getSalarioTotal()
        {
            return salario+bonus;
        }
    }

    class ManejoFicheros
    {
        // CAMPOS DE CLASE O PROPIEDADES

        StreamReader fichero = null;  //  creamos un flujo de datos
        int contador = 0;
        string linea;

        // METODOS DE CLASE
        public ManejoFicheros()     // Metodo destructor
        {
            // abrimos el flujo de datos apuntando hacia el fichero.txt
            fichero = new StreamReader(@"D:\Cursos\.NET\Tutorial PildorasInformaticas\ejercicios\video058\video058\fichero.txt");
            
            // leemos linea y comprobamos si hemos llegado al final del fichero
            while((linea = fichero.ReadLine()) != null)
            {
                Console.WriteLine(linea);
                contador++;
            }
        }
        ~ManejoFicheros()   // Metodo destructor
        { 
            // codigo que se ejecuta cuando el GC elimine el recurso en memoria
            fichero.Close();
        }

        public void mensaje()
        {
            Console.WriteLine($"El fichero tiene {contador} lineas");
        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            // Representa las estaciones del anyo
            Estaciones est = Estaciones.Primavera;
            Console.WriteLine(est);

            Console.WriteLine(Estaciones.Invierno);

            // conversion de tipo enumerado a tipo string

            string estacion = Estaciones.Verano.ToString();
            Console.WriteLine($"Mi estacion preferida es {estacion}");

            // conversion de tipo enumerado a tipo entero

            int estacion2 = (int) Estaciones.Otono;
            Console.WriteLine($"Mi estacion preferida es {estacion2}");

            // almacenar el valor null en un tipo enumerado

            Estaciones? e = null;
            //Console.WriteLine(e);

            // dar bonus a los empleados

            Bonus bonusAntonio = Bonus.extra;
            double salarioBase = 950.40;
            Console.WriteLine($"El bonus de Antonio es {bonusAntonio} = {(double) bonusAntonio} " +
                              $"y su salario es {salarioBase + (double)bonusAntonio}");

            // uso de la clase empleado
            Empleado emp1 = new Empleado(Bonus.extra, 1950.50);
            Console.WriteLine($"El salario total es {emp1.getSalarioTotal()}");

            // uso de metodo destructor con ficheros

            ManejoFicheros miFichero = new ManejoFicheros();
            miFichero.mensaje();
            


        }
    }

}
