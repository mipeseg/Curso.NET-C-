/*
    Fuente: video048, video49, video50, video51 
    // TODO: Estamos comenzando el video

    INTERFACES: INTRODUCCION

        Una interfaz es un cjto de metodos que debe de implementar cualquier clase heredera. Si,
        una clase puede heredar de una o varias interfaces. 

                    Interface1 (solo contiene definiciones de metodos)
                        ClaseEjemplo1

        Ej ) Continuamos trabajando con la clase Mamifero. Implementamos una nueva subclase Ballena
             Imaginemos que en un futuro, cuando se cree otra subclase, se implemete
             obligatoriamente un metodo que indique el numero de patas que tiene 
             un individuo de esa subclase. Como obligamos a esto? 

             Alquien podria pensar ... pues implementas el metodo numPatas() en la clase Mamifero
             y ya esta. Y las ballenas?. No tienen patas. Que pasa si x error un programador
             llama al metodo numPatas() desde un objeto Ballena?. Igual no daba error, pero es una
             concepcion erronea.

             Una solucion es crear una Interface y decidir quien la implementa y quien no

                    interface IMamiferoTrerrestre
                    {
                        // metodos que deben implementar las clases herederas. Solo se definen
                        int numeroPatas();  // no lleva modificador ni tampoco llaves
                        
                    }

    CLASES QUE HEREDAN DE VARIAS INTERFACES

        En C# no se admite herencia multiple en clases, es decir, una clase solo puede tener un
        padre. Sin embargo si que se permite la herencia multiple de interfaces. Ejemplo:

            Queremos especificar que animales de los que tenemos se usan en deportes. Ej: El gorila no.
            El caballo en hipica. El humano en futbol. La ballena no. Quiero obligar al programador
            y para ello implemento la inteface IAnimalesYDeportes

    INTERFACES CON VARIOS METODOS

        En la interfaz IAnimalesYDeportes defino los metodos:

            string tipoDeporte();  // me muestra los deportes
            boolean esOlimpico();  // muestra si es un deporte olimpico
            
    INTERFACES CON METODOS IGUALES
        
        En la interfaces creadas tenemos:

            IMamiferoTrerrestre con el metodo numeroPatas() que indica las patas de ese animal
            ISaltoConPatas con el metodo numeroPatas() que indica con cuantas patas salta el animal
            
        Ej: Que pasa en la clase Caballo()?. Y en la clase Gorila?. Tendremos que implementar dos metodos llamados igual
            Ocurre una ambiguedad.

            Ademas al quitar public ahora esta encapsulado y no es visible desde el exterior. Por 
            tanto desde la clase Program la instruccion miCaballo.numeroPatas() da error

                // En la clase Caballo

                void IMamiferoTrerrestre.numeroPatas()  
                {
                    Console.WriteLine("Los caballos tenemos 4 patas");
                }

                void ISaltoConPatas.numeroPatas()
                {
                    Console.WriteLine("Los caballos saltamos con las 2 patas traseras");
                }

                // En la clase Gorila

                // En la clase Program

    RESTRICCIONES EN EL USO DE INTERFACES

        - No se permite definir const/variables. Una interfaz solo permite la definicion de metodos
        - no se puede definir metodos constructores
        - no se puede definir metodos destructores (LO VEREMOS PROXIMAMENTE)
        - no se puede especificar modificadores de acceso en los metodos (implicitamente son public)
        - no se pueden anidar clases ni otras estructuras dentro de una interfaz

    EJERCICIO FINAL

        Aplicacion que recepciona avisos en nuestro domicilio. Ademas usaremos la modularizacion
        Ver las clase AvisosTrafico.cs y la interfaz IAvisos.cs

 */

using System;

namespace video048
{
    interface IMamiferoTrerrestre
    {
        // metodos que deben implementar las clases herederas. Solo se definen
        void numeroPatas();  // no lleva modificador ni tampoco llaves

    }

    interface IAnimalesYDeportes
    {
        string tipoDeporte();  // me muestra los deportes
        bool esOlimpico();  // muestra si es un deporte olimpico
    }

    interface ISaltoConPatas 
    {
        void numeroPatas();  // Cuantas patas usa el animal para saltar?. Ej: un caballo las 2 traseras
    }

    class Mamifero
    {

        // PROPIEDADES O CAMPOS DE CLASE
        private bool vertebrado, sangreCaliente, cuidadoParental, generanLeche;
        private string nombre;

        // METODOS

        // metodo constructor

        public Mamifero(string nombre) // reemplaza al constructor por defecto Mamifero()
        {
            vertebrado = true; sangreCaliente = true;
            cuidadoParental = true; generanLeche = true;
            this.nombre = nombre;
        }

        // metodos getter y setter
        public string getInformacion()
        {
            return ($"Nombre: {nombre} => Vertebrado: {vertebrado} - Sangre caliente: {sangreCaliente} - " +
                    $"Cuidado parental: {cuidadoParental} - Generan leche: {generanLeche}");

        }
        public string getNombre()
        {
            return nombre;
        }

        // otros metodos
        public void respirar()
        {
            Console.WriteLine("Estoy respirando");
        }

        public void cuidarCrias()
        {
            Console.WriteLine("Cuido de mis crias hasta que son adultas");
        }

        protected void protegido()
        {
            Console.WriteLine("soy un metodo protegido");
        }
        public virtual void pensar()
        {
            Console.WriteLine("Pensamiento basico instintivo");
        }
    }

    // Caballo hereda de clase Mamifero y de la interfaz IMamiferoTrerrestre  
    // en la lista el orden es importante. Siempre se pone clasePadre, Interface1, Interface2 ...
    // OJO: Hay que implementar el metodo numPatas() para que no marque error.
    class Caballo : Mamifero, IMamiferoTrerrestre, IAnimalesYDeportes, ISaltoConPatas
    {

        // METODOS

        // llama al constructor de clase padre
        public Caballo(string nombreCaballo) : base(nombreCaballo)
        {
            // El metodo constructor Caballo() recibe nombreCaballo que se le pasa
            // a su vez al metodo constructor de la clase padre Mamifero()
        }

        // otros Metodos
        public void galopar()
        {
            Console.WriteLine("Estoy galopando");
        }

        // implementacion de metodos de interface
        void IMamiferoTrerrestre.numeroPatas() 
        {
            Console.WriteLine("Los caballos tenemos 4 patas");
        }
        public string tipoDeporte()
        {
            return "Los caballos participamos en hipica";
        }

        public Boolean esOlimpico()
        {
            return true;
        }
        void ISaltoConPatas.numeroPatas()
        {
            Console.WriteLine("Los caballos saltamos con las 2 patas traseras");
        }
    }

    class Humano : Mamifero, IAnimalesYDeportes   // Humano hereda de Mamifero 
    {
        // Propiedades o campos de clase
        private string dni;

        // METODOS

        // llama al constructor de clase padre
        public Humano(string nombreHumano, string dni) : base(nombreHumano)
        {
            // El metodo constructor Humano() recibe nombreHumano que se le pasa
            // a su vez al metodo constructor de la clase padre Mamifero() y dni
            // que se almacena en la propiedad dni de esta clase
            this.dni = dni;
        }

        // metodos getter y setter
        public string getDni()
        {
            return dni;
        }

        // otros Metodos
        public override void pensar()
        {
            Console.WriteLine("Pensamiento de humano");
        }

        // metodos implementado de interfaces
        public string tipoDeporte() 
        {
            return "Los humanos participamos en MMA";
        }
        public Boolean esOlimpico()
        {
            return false;
        }
    }

    // Gorila hereda de clase Mamifero y de la interfaz IMamiferoTrerrestre  
    // en la lista el orden es importante. Siempre se pone clasePadre, Interface1, Interface2 ...
    // OJO: Hay que implementar el metodo numPatas() para que no marque error.
    class Gorila : Mamifero, IMamiferoTrerrestre  // Gorila hereda de Mamifero 
    {

        // METODOS

        // llama al constructor de clase padre
        public Gorila(string nombreGorila) : base(nombreGorila)
        {
            // El metodo constructor Gorila() recibe nombreGorila que se le pasa
            // a su vez al metodo constructor de la clase padre Mamifero()
        }

        // otros Metodos
        public void trepar()
        {
            Console.WriteLine("Estoy trepando");
            Gorila a = new Gorila("Benito");
            a.protegido();
        }
        public override void pensar()
        {
            Console.WriteLine("Pensamiento de gorila");
        }

        // implementacion de metodos de interface
        public void numeroPatas()
        {
            Console.WriteLine("Los gorilas tenemos 2 patas");
        }
    }

    class Ballena: Mamifero 
    {
        // METODOS

        // llama al constructor de clase padre
        public Ballena(string nombreBallena) : base(nombreBallena)
        {
            // El metodo constructor Gorila() recibe nombreGorila que se le pasa
            // a su vez al metodo constructor de la clase padre Mamifero()
        }

        // otros Metodos
        public void nadar()
        {
            Console.WriteLine("Estoy nadando");
        }

        public override void pensar()
        {
            Console.WriteLine("Pensamiento de ballena");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Uso de interfaces

            Ballena b = new Ballena("Wally");
            b.nadar();

            Gorila g = new Gorila("Copito");
            g.numeroPatas();

            // herencia de interface multiples

            Humano h = new Humano("Felipe","12345456K");
            Console.WriteLine(h.tipoDeporte());
            Console.WriteLine($"Es un deporte olimpico? {h.esOlimpico()}");

            Caballo miCaballo = new Caballo("Babieca");
            miCaballo.tipoDeporte();
            Console.WriteLine(miCaballo.tipoDeporte());
            Console.WriteLine($"Es un deporte olimpico? {miCaballo.esOlimpico()}");

            // interfaces con metodos iguales

            Caballo miCaballo2 = new Caballo("Pedrete");
            IMamiferoTrerrestre ImiCaballo = miCaballo2; // esto se puede hace por el principio ES-UN.  Un Caballo es un IMamiferoTrerrestre? SI
            ImiCaballo.numeroPatas(); // ahora si que podemos llamar a numeroPatas() de la interfaz IMamiferoTrerrestre
            ISaltoConPatas ImiCaballo2 = miCaballo2; // esto se puede hace por el principio ES-UN.  Un Caballo es un ISaltoConPatas? SI
            ImiCaballo2.numeroPatas(); // ahora si que podemos llamar a numeroPatas() de la interfaz ISaltoConPatas

            // Avisos

            AvisosTrafico av1 = new AvisosTrafico();  // aviso generico
            av1.mostrarAviso();

            AvisosTrafico av2 = new AvisosTrafico("Jefatura Provincial Madrid","Sancion de velocidad de 200$","20/06/2022");  // aviso personalizado
            av2.mostrarAviso();
            Console.WriteLine(av2.getFecha());
        }
    }
}