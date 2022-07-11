/*
    Fuente: video52, video53, video54
    // TODO: Estamos comenzando el video

    CLASES ABSTRACTAS Y METODOS ABSTRACTOS

        Imagina que tenemos un nuevo animal de clase Lagartija. Es un Mamifero?. No, luego no puede
        heredar de Mamifero?. Que hacemos? Introducir una nueva clase abstracta Animales de la
        que heredaran el resto. Nuestra jerarquia quedara asi:

            IMamiferoTrerrestre (IM)
            IAnimalesYDeportes (IA)
            ISaltoConPatas (IS)

                            Animal    (clase abstracta)     
                     respirar()  getNombre()
                       
                                Mamiferos                                      Lagartija
                          pensar()  cuidarCrias() 
                       
                 Ballena        Caballo         Humano        Gorila
                 nadar()       galopar()       pensar()       trepar()
                             numeroPatas()    numeroPatas()   numeroPatas()
                            (IM) (IA) (IS)     (IM) (IA)        (IM)

            getNombre() sera un metodo abstracto, es decir, solo lo declaramos en Animal y
                        despues ya lo implementamos en aquellos animales que hereden. Cuando una clase
                        hereda de otra Clase abstracta esta obligada a implementar los metodos
                        abstractos.

        Pq se llama clase abstracta?? Pq al menos tiene un metodo abstracto. Veamos el siguiente
        ejemplo. Cual es la clase mas especializada (la que mas cosas hace)?. Es la 
        mas baja en la cuspide, es decir Director. A medida que subimos en la jerarquia, las 
        clases hacen menos cosas. Son mas abstractas. Asi pues una Clase abstracta es la que
        menos cosas hace.

                                                Persona         (A) 
                                            getDescripcion()    (A)

                               -  Empleado                        Alumno
                              |  
              getNombre()    - -  Jefe
              setSubeSueldo() |             
                               -  Director

         SINTAXIS DE UNA CLASE ABSTRACTA
        
                            abstract class miClaseAbs
                            {
                                 public abstract tipoDevuelto metodoAbstracto();  // declaramos un metodo abstracto
                            }

                            class miClase : miClaseAbs
                            {
                                 public override tipoDevuelto metodoAbstracto()  // definimos o implementamos el metodo abstracto
                                 {
                                    ....
                                 }
                            }                

                Ver ejemplo de la lLagartija

         CLASE ABSTRACTA VS INTERFACE

                Si Animales fuera una interface la tendria que implementar en la clase Lagartija.
                Ademas el metodo respirar() habria que implementarlo en todas la clases herederas.
                Con lo cual con la clase abstracta nos ahorramos trabajo

    CLASES SELLADAS (SEALED)
    
        Cuando en una app participan varios desarrolladores, a veces, el jefe de proyecto
        tiene claro el disenio a priori y otras lo improvisa sobre la marcha. Pej)

        - caso 1: No sabemos si en un futuro Ballena, Caballo, Humano, Gorila o Lagartija puedan
                  tener clases hijas.

             Ej) Vamos a crear una clase Chimpace que herede de Gorila

                        class Chimpance : Gorila 
                        {
                            // METODOS

                            // llama al constructor de clase padre
                            public Chimpance(string nombreChimpance) : base(nombreChimpance)
                            {
                                // El metodo constructor Chimpance() recibe nombreChimpance que se le pasa
                                // a su vez al metodo constructor de la clase padre Gorila()
                            }

                            // otros Metodos
                        }

        - caso 2: Tenemos muy claro que las clases anteriores no tendran hijas. Por tanto
                  las sellariamos para que no puedan tener descendientes

              Ej) No queremos que Gorila tenga descendencia

                        sealed class Gorila : Mamifero, IMamiferoTrerrestre
                        {
                            ....
                        }

                   Con un metodo sellado pasa lo mismo. Hace que futuras clases que hereden un metodo
                   sellado impide que lo puedan sobreescribir
        Resumen: 

            - una clase sellada no se puede tener hijas
            - un metodo sellado no puede ser sobreescrito en las clases hijas

    METODOS SELLADOS (SEALED)

        Imaginemos que creamos Adolescente que herede de Humano. Y queremos que el metodo
        pensar() de Humano funcione distinto al que heredara Adolescente. Que hacemos?

                    class Humano : Mamifero, IAnimalesYDeportes   
                    {
                        .....
                        public override void pensar()
                        {
                            Console.WriteLine("Pensamiento de humano");
                        }
                        ....
                    }

                    class Adolescente : Humano
                    {
                        ......
                        public override void pensar()
                        {
                            Console.WriteLine("Mis hormonas de adolescente me nublan el pensamiento");
                        }
                        .....
                    }

        Y si queremos impedir lo anterior?. Es decir, no queremos que pensar() se pueda sobreescribir en clases
        hijas de Humano. Que todos piensen igual

                    class Humano : Mamifero, IAnimalesYDeportes   
                    {
                        .....
                        public sealed override void pensar()
                        {
                            Console.WriteLine("Pensamiento de humano");
                        }
                        ....
                    }

                    class Adolescente : Humano
                    {
                        ......
                        public override void pensar() // marcara el error "no se puede invalidar el miembro heredado 'Humano.pensar()' porque está sellado"
                        {
                            Console.WriteLine("Mis hormonas de adolescente me nublan el pensamiento");
                        }
                        .....
                    }



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

    abstract class Animal
    {
        // PROPIEDADES O CAMPOS DE CLASE

        // METODOS

        // metodo constructor

        // otros metodos

        public void respirar()
        {
            Console.WriteLine("Estoy respirando");
        }

        public abstract void getNombre();  // metodo abstracto. Obliga a que las herederas lo implementen
        
    }

    class Mamifero: Animal
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
        public override void getNombre()  // definicion mediante sobreescritura del metodo abstracto
        {
            Console.WriteLine($"El nombre del mamifero es: {nombre}");
        }

        // otros metodos
       
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

    class Adolescente : Humano
    {
        // Propiedades o campos de clase

        // METODOS

        // llama al constructor de clase padre
        public Adolescente(string nombreHumano, string dni) : base(nombreHumano, dni)
        { 
           
        }

        // otros metodos
        public override void pensar()
        {
            Console.WriteLine("Mis hormonas de adolescente me nublan el pensamiento");
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

    class Chimpance : Gorila 
    {
        // METODOS

        // llama al constructor de clase padre
        public Chimpance(string nombreChimpance) : base(nombreChimpance)
        {
            // El metodo constructor Chimpance() recibe nombreChimpance que se le pasa
            // a su vez al metodo constructor de la clase padre Gorila()
        }

        // otros Metodos
    }

    class Ballena : Mamifero
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

    class Lagartija : Animal
    {
        // PROPIEDADES O CAMPOS DE CLASE
        private string nombre;
        
        // METODOS DE LA CLASE
        public Lagartija(string nombre)   // metodo constructor
        {
            this.nombre = nombre;
        }

        // otros metodos

        public override void getNombre()  // definicion mediante sobreescritura del metodo abstracto
        {
            Console.WriteLine($"El nombre del reptil es: {nombre}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Clases abstractas

            Lagartija l = new Lagartija("Juancho");
            l.respirar();
            l.getNombre();

            Humano h = new Humano("Pedro","23456456T");
            h.respirar();
            h.getNombre(); 
        }
    }
}