/*
    Fuente: video27, video28, video29, video30, video31, video32, video33, video34, video35
    // TODO: 

    PROGRAMACION ORIENTADA A OBJETOS (POO)
        
        INTRODUCCION

        Hoy dia existen dos tipos de paradigmas de programacion:

        a) programacion orientada a procedimientos (antiguis lenguajes)
           Desventajas: muchas lineas de codigo, codigo poco reutilizable, codigo complejo de leer, dificil depuracion,
                        ante una excepcion el programa caia, uso de goto
           Ej: Fortran, Cobol, Basic. 

        b) poo (lenguajes mas modernos)
           Vino a solucionar la vida a los programadores. Se basa en los objetos de la vida real.
           Los objetos tienen : 
             - estado (como se encuentra)
             - propiedades (caracteristicas)
             - comportamiento (que es capaz de hacer)

           Ventajas: El codigo se puede dividir en clases (modulos). Reutilizable (herencia).
                     Tratamiento de excepciones, encapsulamiento, etc...

        MODIFICADORES DE ACCESO PARA CLASES

        Controlan el acceso a una clase desde distintas partes. Veamoslos:

          - public (accesible desde cualquier parte)
          - private (accesible desde la propia clase. Encapsulamiento)
          - protected (accesible desde clase derivada)
          - internal (accesible desde el mismo ensamblado)
          - protected internal (accesible desde el mismo ensamblado o clase derivada de otro ensambaldo)
          - private protected (accesible desde la clase o clase derivada del mismo ensamblado)
          - default (accesible desde el mismo paquete. En C# es equivalente a private)

        VOCABULARIO DE LA POO

          1. Clase = Modulo = grupo
             Es un patron, plantilla, modelo o descripcion de como debe ser un objeto de esa clase

          2. Objeto = ejemplar de clase = instancia de clase = instancia
             Ejemplar perteneciente a una clase. En el codigo de un objeto encontramos:
             - propiedades = atributos = caracteristicas (ej: un objeto coche:  color, peso, altura ...)
             - metodos (como se comporta. Lo que puede hacer) ej: un objeto perro: andar, ladrar, comer ...

             Para acceder a las propiedades y metodos de un objeto se usa el punto. Ej:
             coche1.color = "rojo"; coche1.peso = 1200; coche1.arrancar();

          3. Modularizacion
             Dividir un programa complejo en modulos o clases. Hasta ahora estamos trabajando
             con un solo modulo (Program.cs)

          4. Encapsulamiento = encapsulacion
             Mecanismo de aislamiento de atributos y métodos de una clase. Se usa para evitar modificaciones no autorizadas en los datos de un objeto.

          5. Herencia
             Las clases pueden tener hijas o no. Toda clase tiene un padre, un abuelo ...

          6. Polimorfismo
             Capacidad de invocar al mismo metodo de distintos objetos y que cada objeto responda de una forma distinta

        DECLARACION DE CLASES Y OBJETOS
          ver la clase Circulo y el objeto circ1

                 Clase nomObjeto = new Clase();   // new llama al metodo creador de la clase
           
        ENCAPSULACION Y CONVENCIONES DE PROGRAMACION

            La Encapsulacion es el mecanismo de aislamiento de atributos y métodos de una clase. 
            Se usa para evitar modificaciones no autorizadas en los datos de un objeto. Por tanto
            para encapsular un elemento y evitar que se vea desde el exterior de su clase hacemos:

                            private const tipo CONSTANTE = valor;
                            private tipo variable;
                            private tipoDevuelto metodo (tipo p1, tipo p2, tipo p3 ...) { }
            
            Convenciones de buenas practicas: 

              - las variables y constantes se encapsulan. Y si necesitamos modificarla/verla desde 
                el exterior?. Lo hacemos a traves de METODOS DE ACCESO

              - los identificadores que lleven public deben comenzar con mayuscula. (notacion PascalCase)
                Ej: public double Radio = 4.35;     public double CalculoArea() { }

              - Para el resto de modificadores se usa la notacion camelCase

        METODO CONSTRUCTOR

            Un metodo constructor sirve para construir un objeto y darle un estado inicial.
            No devuelve nada (ni ningun tipo nisiquiera void). Por defecto no es necesario
            declararlo si no vamos a pasarle parametros. Los parametros tb son opcionales

                    public mismoNombreQueLaClase(p1,p2,...pn)
                    {
                       .....
                    }

            Sobrecarga de constructores -> Podemos crear objetos con estados iniciales diferentes.
                                           Podemos crear infinitos constructores siempre y cuando sus parametros sean distintos

        METODOS GETTER Y METODOS SETTER

            Los metodos getter nos permiten visualizar propiedades. Los metodos setter nos permiten
            cambiar el valor de propiedades. Por convencion se nombran anteponiedo set o get
            al identificador

        LA PALABRA RESERVADA THIS

            this hace referencia al objeto que llama a un metodo

        DIVIDIR CLASES LARGAS (clases parciales)

            En C# las clases se pueden dividir en trozos cuando sean bastante complejas

                     partial class nombreDeLaClase
                       {
                       }

        COMENTARIOS TODO (PARAHACER)

            Se usan para indicar tareas que hemos de hacer. Ej: // TODO: Continuar x aqui
            En el menu "ver/lista de tareas" podemos ver todos los comentarios TODO

        DIVIDIR LA APLICACION EN VARIOS FICHEROS FUENTES (MODULARIZACION)

            En C# por defecto una aplicacion de consola tiene un unico fichero fuenyte (program.cs)
            Como podemos crear mas ficheros fuente?.

            Ej: Boton derecho en "video27/agregar/nuevo elemento/Clase" o bien "Proyecto/agregar clase"
                Le damos el nombre "Punto.cs" y se crea el fichero con esta estructura:

                        using System;
                        using System.Collections.Generic;
                        using System.Linq;
                        using System.Text;
                        using System.Threading.Tasks;

                        namespace video027
                        {
                            internal class Punto
                            {
                            }
                        }

                 Despues a podemos utilizar la clase Punto desde program.cs

         LA CLASE MATH (es nativa)
            
                Math.sqrt()  raiz cuadrada         Pow(a,b)   potencia

         (CONSTANTES, VARIABLES Y METODOS) STATIC = (CONSTANTES, VARIABLES Y METODOS) DE CLASE

            Imaginemos la clase "Ganso" con la propiedad "contador". Si creamos 3 objetos
            inicialmente cada uno tiene la propiedad iniciada a 7. Pero mas tarde pueden cambiar
            su valor porque son objetos distintos. Lo mismo pasaria con CTEs y con metodos

                    Ganso ... int contador = 7;

                    ganso1  ... contador = 7               ganso1  ... ganso1.contador = 10 
                    ganso2  ... contador = 7               ganso2  ... ganso2.contador = 2 
                    ganso3  ... contador = 7               ganso3  ... ganso3.contador = -5 
             
            si usamos static con una variable/constante, esta es compartida por todos los objetos de la clase
            que se creen. Por eso a lo "static" se le suele llamar "de clase"

                    Ganso ... static int contador = 7;

                    ganso1  ...                            ganso1  ... 
                    ganso2  ... contador = 7               ganso2  ... Ganso.contador = 923
                    ganso3  ...                            ganso3  ...  
            

            Lo mismo ocurre con los metodos que se llaman desde una instancia y los metodos estaticos
            Ej:

                    double distancia = origen.DistanciaHasta(destino);  // el metodo DistanciaHasta() se llama desde un objeto
                    Console.WriteLine("....");   // El metodo WriteLine() se llama desde la clase Console
                    Math.Pow(...); // el metodo Pow() se llama desde la clase Math


             Por tanto para acceder a un elemento static siempre lo haremos a traves de su propietaria
             que es la Clase. Nunca a traves de los objetos pq dara error. Y viceversa.

                Ej: La clase Math pide a gritos que sus metodos, constantes y variables sean estaticas. 
                    No tendria sentido tener que crear instancias para realizar las operaciones 
                    matematicas deseadas.
                            
                           Math.Pow()   metodo estatico      Math.PI  constante estatica
        
         IMPORTAR METODOS STATIC
            Podemos usar todos los metodos estaticos de una clase sin necesidad de usar luego Clase.metodo()

                    using static System.Math;  // usar los metodos estaticos de Math
                    using static System.Console;  // usar los metodos estaticos de Console
                           ....
                    double raiz = Math.Sqrt(9);
                    double potencia = Pow(3,4);  // observa que no ha sido necesario poner Math.Pow(3,4);  
                    
                    Console.WriteLine($"raiz = {raiz} / potencia = {potencia}");
                    WriteLine($"raiz = {raiz} / potencia = {potencia}");

            A mi no me gusta. No recomiendo su uso.

         CLASES ANONIMAS
            son clases sin nombre. Ahorran lineas de codigo. Se suele usar con la Querys o consultas SQL

                     var miobjeto = new { p1 = valor, p2 = valor, ... };
                     Console.WriteLine($"p1 = {miobjeto.p1}");

            NOTAS: - las clases anonimas no tienen identificador
                   - No hace falta indicar el tipo de los atributos. Los asigna el compilador en funcion del valor que almacenan
                   - si dos objetos de clase anomnima tiene los mismos parametros, se consideran de la misma clase
                   - limitaciones
                      - todos los campos seran public (no hace falta poner public)
                      - todos los campos deben iniciarse
                      - los campos no pueden ser static
                      - no pueden definirse metodos

 */

using System; // usar la clase System
using static System.Math; // Usar los metodos estaticos de la clase Math sin estar usando todo el rato Math.

namespace video027 // definimos nuestro espacio de nombres
{
    partial class Circulo
    {
        // esta clase permite definir circulos

        // Propiedades de clase = campos de clase
        // const double PI = 3.1416; // (encapsulamiento)
        private const double PI = 3.1416; // (encapsulamiento)
        public string color = "blanco";
    }

    partial class Circulo 
    { 
        //Metodos de clase
        public double area(int radio)
        {
            return PI * radio * radio;
        }
    }

    class ConversorEuroDolar
    {
        // Esta clase convierte dolares a euros

        // Propiedades o campos de clase
        private double euro = 1.253;  // 1E son 1.253$

        //Metodos de acceso
        public void cambiaValorEuro(double nuevoValor)
        {
            if(nuevoValor <= 0) 
                euro = 1.253;
            else 
                euro = nuevoValor;
        }

        //Metodos de clase
        public double convierte(double cantidad)
        {
            return cantidad * euro;
        }
    }

    class Coche
    {
        // Propiedades o campos de clase

        private int ruedas;
        private double largo, ancho;
        private bool climatizador; //valor por defecto es false
        private string tapiceria; // valor por defecto es ""

        // Metodos de clase
        public Coche()   // constructor de clase. Indica el estado inicial de los objetos
        {
            ruedas = 4; largo = 2.300; ancho = 0.800;
            climatizador = false; tapiceria = "tela";
        }

        public Coche(double largoCoche, double anchoCoche, bool cli=false, string tap="tela")   // sobrecarga de constructor
        {
            ruedas = 4; 
            largo = largoCoche; 
            ancho = anchoCoche;
            climatizador = cli; tapiceria = tap;
        }

        public string getInfoCoche() //metodo getter
        {
            return $"Informacion: {ruedas} ruedas {largo}m {ancho}m climatizador-{climatizador} tapiceria-{tapiceria}";
        }

        public string getExtras() // metodo getter
        {
            return $"Extras: climatizador-{climatizador} tapiceria-{tapiceria}";
        }

        public void setExtras(bool climatizador, string tapiceria) // metodo setter
        {
            this.climatizador = climatizador;
            this.tapiceria = tapiceria;
        }

    }

    class Program // clase principal
    {
        static void realizarTarea()
        {
            // TODO: continuar por aqui el proximo dia 1
            // TODO: continuar por aqui el proximo dia 2

            Punto origen = new Punto();   // es como pasarle (0,0)
            Punto destino = new Punto(128, 80); // le pasamos (128,80)
            double distancia = origen.distanciaHasta(destino); // calculamos la distancia entre dos puntos

            Punto punto3 = new Punto();  // es como pasarle (0,0)

            Console.WriteLine($"La distancia entre ({origen.getX()},{origen.getY()}) e ({destino.getX()},{destino.getY()}) es {distancia}");
            Console.WriteLine($"Numero de objetos creados: {Punto.getContadorDeObjetos()}");
            Console.WriteLine($"el valor de PRUEBA es: {Punto.PRUEBA}");  // PRUEBA es una const estatica o de clase. Por tanto se accede desde la clase
            //Console.WriteLine($"el valor de PRUEBA es: {origen.PRUEBA}"); // error pq PRUEBA es una const estatica y no se puede acceder desde un objeto

        }

        static void Main(string[] args)
        {
            // declaramos e inicializamos objetos de clase Circulo
            Circulo circ1 = new Circulo();
            Circulo circ2 = new Circulo();

            circ2.color = "rojo"; 

            //Console.WriteLine($"El numero pi es {circ1.PI}"); // no es accesible debido a su nivel de proteccion. La encapsulacion protege que desde una clase se acceda a otra
            Console.WriteLine($"El area del circulo {circ1.color} de radio = 5 m es {circ1.area(5)} m2 "); // podemos acceder porque el metodo area es publico
            Console.WriteLine($"El area del circulo {circ2.color} de radio = 9 m es {circ2.area(9)} m2 "); // podemos acceder porque el metodo area es publico

            // Vamos a convertir dolares a euros
            ConversorEuroDolar obj1 = new ConversorEuroDolar();
            Console.WriteLine($"50$ son {obj1.convierte(50)} Euros");

            // y si cambia el valor del $ ???
            obj1.cambiaValorEuro(1.45);
            Console.WriteLine($"50$ son {obj1.convierte(50)} Euros");

            // creamos dos objetos Coche. Inicialmente los dos tienen el mismo estado
            Coche coche1 = new Coche(); // llamamos al constructor para crear e inicializar un onjeto
            Coche coche2 = new Coche();
            Coche coche3 = new Coche(4.5, 1.200, true);
            Coche coche4 = new Coche(4, 1.0, false,"cuero");

            Console.WriteLine($"Coche1 --- {coche1.getInfoCoche()}");
            Console.WriteLine($"Coche2 --- {coche2.getInfoCoche()}");
            Console.WriteLine($"Coche3 --- {coche3.getInfoCoche()}");
            Console.WriteLine($"Coche4 --- {coche4.getInfoCoche()}");
            Console.WriteLine($"Coche4 --- {coche4.getExtras()}");

            coche3.setExtras(false, "skie");
            Console.WriteLine($"Coche3 --- {coche3.getExtras()}");

            realizarTarea();

            // vamos a usar metodos estaticos 
            // para evitar estar todo el rato usando Math. podemos escribir "using static System.Math;"
            double raiz = Math.Sqrt(9);
            double potencia = Pow(3,4);  // observa que no ha sido necesario Math.Pow(3,4);
            Console.WriteLine($"raiz = {raiz} / potencia = {potencia}");

            // declaracion de dos objeto de la misma clase anonima

            var miObjeto = new { nombre = "Juan", edad = 19};
            Console.WriteLine($"nombre = {miObjeto.nombre} / edad = {miObjeto.edad}");

            var obj2 = new { nombre = "Tania", edad = 40};
            // var obj2 = new { nombre = "Tania", edad = "40" }; // esto provocaria que no fueran de la misma clase anonima
            Console.WriteLine($"nombre = {obj2.nombre} / edad = {obj2.edad}");

            miObjeto = obj2; // como son objetos de la misma clase no da error esta instruccion
            Console.WriteLine($"nombre = {miObjeto.nombre} / edad = {miObjeto.edad}");

        }
    }
}