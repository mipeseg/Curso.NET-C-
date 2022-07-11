/*
    Fuentes: video41, video42, video43, video44, video45, video46
    // TODO: empezamos por el video

    HERENCIA
    
        Es la caracteristica mas importante de la POO. Consiste en transladar el concepto de 
        familia, en la vida real, a la programacion. Ventajas de la herencia:
        
        - Permite reutilizar codigo, gracias a la jerarquia de la herencia (la clases hijas heredan 
          propiedades y metodos de su clase padre)

                Ej:  Abuelo
                           Padre
                                Hijo1  Hijo2  Hijo3

                Ej: Como se disena esta jerquia de clases?  Clases:  Empleado  Jefe  Director
                    NOTA: Deberiamos hacer un curso Metodologia de programacion y disenyo de aplicaciones

                    1. Como disenyar la jeraquia? Aplicando el principio "es-un"

                        - un empleado es un jefe? NO NECESARIAMENTE. 
                        - un empleado es un director? NO NECESARIAMENTE. 
                        - un jefe es un empleado? SI SIEMPRE
                        - un director es un empleado? SI SIEMPRE

                        Jeraquia 1
        
                              Empleado
                                    Jefe    Director

                        Jeraquia 2    (ELEGIREMOS ESTA)
                        - Un director es un jefe? SI
        
                              Empleado
                                    Jefe    
                                        Director

                    2. Ahora nos preguntamos que propiedades y metodos deberia tener cada clase

                        - Propiedades y metodos comunes que podrian tener un empleado, un jefe y un director
                             nombre, edad, fechaAlta, salario  (propiedades)
                             trabajar, generarInformes (metodos)
                          NOTA: Se programaran en la cuspide (en la clase Empleado) para que los hereden el resto
    
                Ej: Como se disena esta jerquia de clases?  Clases:  Caballo    Humano   Gorila
                   
                    1. Ahora nos preguntamos que propiedades y metodos deberia tener cada clase

                        - Propiedades y metodos comunes
                             vertebrados, sangreCaliente, cuidadoParental, generanLeche  (propiedades)
                             moverse, respirar (metodos)

                          NOTA: Se programaran en la cuspide (nos inventamos la clase Mamiferos) para que los hereden el resto

                    2. Principio "es-un"
        
                              Mamifero
                                    Caballo    Humano   Gorila

          En aplicaciones sencillas NO SIEMPRE ES NECESARIO CREAR UNA HERENCIA DE CLASES
                       
    SINTAXIS DE LA HERENCIA EN C#

        Ver ejemplo mamiferos 

    CLASE Object

        Los objetos o instancias, ademas de las propiedades y metodos heredados de sus clases
        ancestras, tienen los propios de su clase. Ademas todo objeto tb desciende de la clase
        Object, por lo que heredara metodos como:

            Equals()   GetHashCode()    GetType()    ToString()
 
        Ej:
                        Object  (superclase cosmica)  // los objetos siempre heredan de esta clase
                            Mamifero
                                Caballo     Humano      Gorila

        OJO: Solo se heredan los public. Los protected no se heredan. Ej:
             En la clase Object hay definidos estos metodos entre otros:
         
             ...
             public virtual string ToString();  --> este se heredara
             ....
             protected object MembersWiseClone(); --> este no se heredara

    CONSTRUCTORES DE SUPERCLASE Y SUBCLASE

        En el ejemplo anterior la clase Mamifero es superclase de Caballo, Humano y Gorila.
        De igual forma Caballo, Humano y Gorila son subclases de Mamifero.
        
        Recordemos que cada clase que creamos tiene implicito un metodo constructor Clase().
        Despues podemos crear sobrecargas. Cuando hay herencia, el constructor de
        una subclase siempre llama al constructor de su superclase (clase padre). Esto lo hace
        con la instruccion implicita :base(). 

                INSTRUCCION :base() -> llama al constructor de la clase padre

        Cuando definimos el metodo constructor de la superclase, tambien tenemos que definir
        la instruccion :base() de cada subclase

    HERENCIA: PRINCIPIO DE SUSTITUCION ("Es siempre un")

        Este concepto lo introdujo Barbara Liskov en el anyo 1988 mientras trabajaba con un 
        lenguaje llamado SOLID. 

        Consiste en sustituir un objeto de una clase por uno de otra clase, siempre teniendo
        en cuenta la herencia. Nos puede ayudar a crear la jerarquia

        Ej: Un Caballo "es siempre un" Humano? NO
            Un Humano "es siempre un" Caballo? NO
            Un Humano "es siempre un" Gorila? NO
            Un Gorila "es siempre un" Humano? NO
            Un Mamifero "es siempre un" Caballo? NO SIEMPRE
            Un Mamifero "es siempre un" Humano? NO SIEMPRE
            Un Mamifero "es siempre un" Gorila? NO SIEMPRE
            Un Caballo "es siempre un" Mamifero? SI
            Un Humano "es siempre un" Mamifero? SI
            Un Gorila "es siempre un" Mamifero? SI

              Caballo animal = new Mamifero();    // daria error
              Mamifero animal1 = new Caballo();    // ok. Se aplica el principio de sustitucion
              Mamifero animal2 = new Humano();    // ok. Se aplica el principio de sustitucion
              Mamifero animal3 = new Gorila();    // ok. Se aplica el principio de sustitucion
 
         Ej: Disenamos una herencia de clases en base al principio de sustitucion
             clases:  DirectorGeneral, Empleado, Secretaria, JefeSeccion

             Un DirectorGeneral "es siempre un" Empleado? SI
             Un DirectorGeneral "es siempre una" Secretaria? NO
             Un DirectorGeneral "es siempre un" JefeSeccion? NO
   
             Un Empleado "es siempre un" DirectorGeneral? NO
             Un Empleado "es siempre una" Secretaria? NO
             Un Empleado "es siempre un" JefeSeccion? NO

             Una Secretaria "es siempre un" DirectorGeneral? NO
             Una Secretaria "es siempre una" Empleado? SI
             Una Secretaria "es siempre un" JefeSeccion? NO

             Un JefeSeccion "es siempre un" DirectorGeneral? NO
             Un JefeSeccion "es siempre una" Empleado? SI
             Un JefeSeccion "es siempre un" Secretaria? NO

             Despues de las preguntas anteriores debemos llegar a esta conclusion:

                    Empleado
                            DirectorGeneral     Secretaria      JefeSeccion

    METODOS HEREDADOS: OCULTACION vs MODIFICACION 

        Hasta ahora hemos visto que una subclase (o clase hija) hereda las propiedades y metodos de
        su superclase (o clase padre). Vamos a ver tres palabras reservadas:

        - new (ocultacion de metodos heredados)

            Imaginemos que en la clase Mamiferos tenemos el metodo pensar(). Lo heredaran todas
            las subclases. Sin embargo en la clase Humano hay otro metodo pensar() exactamente
            igual (devuelve lo mismo y recibe los mismo parametros). En este caso cuando creemos
            una instancia de Humano, se ocultara el metodo heredado y solo se usa el de la propia
            clase.

                     public void pensar()  // clase Mamifero
                     {
                             Console.WriteLine("Pensamiento basico instintivo");
                     }
                     
                     
                     // este metodo marca el mensaje intelisense "Humano.pensar() oculta
                     // el miembro heredado Mamifero.pensar(). Use la palabra reservada new
                     // para ocultar este mensaje"

                     // public void pensar()  // clase Humano
                     new public void pensar()  // clase Humano
                     {
                             Console.WriteLine("Estoy pensando");
                     }

                     Caballo caballo3 = new Caballo("Sr.POO");
                     caballo3.pensar(); // "Pensamiento basico instintivo"
                     Humano humano3 = new Humano("Mari","23456789O");
                     humano3.pensar();  //"Estoy pensando"
                    
        - virtual & override (modificacion de metodos heredados)

            En lugar de que pensar() de la clase Mamifero se oculte en aquellas subclases donde
            se vuelva a definir, lo que hace virtual es que convierte a pensar() en un metodo
            adicionable, es decir, que en las subclases se pueda modificar el original

            ej)
                 public virtual void pensar()  // clase Mamifero
                     {
                        Console.WriteLine("Pensamiento basico instintivo");
                     }

                 public override void pensar()  // clase Humano
                     {
                        Console.WriteLine("Los humanos pensamos");
                     }

            ej) si nos vamos al mmetodo Object.ToString() y vemos su declaracion

                    public virtual string ToString();


    POLIMORFISMO

        Es la capacidad que tiene un objeto de tener distintas formas o a comportarse de
        forma diferente, dependiendo del contexto. Pej)

            public virtual void pensar()  // clase Mamifero
            {
                Console.WriteLine("Pensamiento basico instintivo");
            }

            public override void pensar()  // clase Humano
            {
                Console.WriteLine("Pensamiento de humano");
            }

            // En la clase Caballo no definimos el metodo pensar()

            public override void pensar()  // clase Gorila
            {
                Console.WriteLine("Pensamiento de gorila");
            }


            Mamifero[] arcaAnimales = new Mamifero[3];  
            arcaAnimales[0] = caballo1; 
            arcaAnimales[1] = humano1;
            arcaAnimales[2] = gorila1;

            foreach(Mamifero mamif in arcaAnimales)
            {
                Console.WriteLine(mamif.pensar());
                // que mostrara?
                // "Pensamiento basico instintivo"
                // "Pensamiento de humano"
                // "Pensamiento de gorila"
            }

    MODIFICADORES DE ACCESO (public VS private VS protected)     REPASO

        - public  = permite que la cte/variable/metodo sea accesible desde el exterior
        - private = permite que la cte/variable/metodo sea accesible solo desde la propia clase

            NOTA: Recomendacion a seguir. Metodos public y variables/constante private

        - protected = es una mezcla de los anteriores. Hace que la cte/variable/metodo
                      sea accesible desde la propia clase y desde aquellas subclases que hereden
               ej)
                     
                        // CLASE MAMIFERO 
                        .....
                        protected void protegido()  
                        {
                            Console.WriteLine("soy un metodo protegido");
                        }
                        ....
                        Mamifero a = new Mamifero("Benito");
                        a.protegido;  // "soy un metodo protegido"   ACCESIBLE


                        // CLASE CABALLO
                        .....
                        public void galopar()
                        {
                            Console.WriteLine("Estoy galopando");
                            Caballo a = new Caballo("Benito");
                            a.protegido(); // "soy un metodo protegido"   ACCESIBLE
                        }
                        ....


                        // CLASE HUMANO
                        .....
                        public void pensar()
                        {
                            Console.WriteLine("Estoy pensando");
                            Humano a = new Humano("Benito");
                            a.protegido(); // "soy un metodo protegido"   ACCESIBLE
                        }
                        ....
                       
                        // CLASE GORILA
                        .....
                        public void trepar()
                        {
                            Console.WriteLine("Estoy trepando");
                            Gorila a = new Gorila("Benito");
                            a.protegido(); // "soy un metodo protegido"    ACCESIBLE
                        }
                        ....

                        // CLASE PROGRAM

                        Mamifero m = new Mamifero("mmmm");
                        Caballo c = new Caballo("cccc");
                        Humano h = new Humano("hhhh");
                        Gorila g = new Gorila("gggg");
 
                        m.protegido();  // Error   NO ACCESIBLE
                        c.protegido();  // Error   NO ACCESIBLE
                        h.protegido();  // Error   NO ACCESIBLE
                        g.protegido();  // Error   NO ACCESIBLE

    EJERCICIO DE REPASO

    a) Crear 3 clases: Avion, Vehiculo y Coche
    b) Crear una jerarquia de clases o herencia
    c) Metodos comunes a las 3 clases: arrancarMotor y pararMotor
    d) Metodo virtual: Conducir

            LO RESOLVEMOS EN EL SIGUIENTE VIDEO47


 */

using System;

namespace Video041
{
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
            cuidadoParental = true; generanLeche=true;
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

    class Caballo : Mamifero  // Caballo hereda de Mamifero 
    {
        
        // METODOS

        // llama al constructor de clase padre
        public Caballo(string nombreCaballo):base(nombreCaballo)
        {
            // El metodo constructor Caballo() recibe nombreCaballo que se le pasa
            // a su vez al metodo constructor de la clase padre Mamifero()
        }
        
        // otros Metodos
        public void galopar()
        {
            Console.WriteLine("Estoy galopando");
        }

       
    }

    class Humano : Mamifero  // Humano hereda de Mamifero 
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
    }

    class Gorila : Mamifero  // Gorila hereda de Mamifero 
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            Caballo caballo1 = new Caballo("Babieca");
            Humano humano1 = new Humano("Juan","12345678A");
            Gorila gorila1 = new Gorila("Copito de nieve");
           
            gorila1.cuidarCrias();
            //babieca.protegido(); // daria error pq Caballo no hereda el metodo protegido() de Mamifero
            Console.WriteLine(caballo1.getInformacion());
            Console.WriteLine(humano1.getInformacion());
            Console.WriteLine(gorila1.getInformacion());
            humano1.pensar();
            Console.WriteLine($"El humano1 se llama {humano1.getNombre()} " + 
                              $"y su dni es {humano1.getDni()}");

            // principio de sustitucion

            Mamifero animal1 = new Caballo("Rocinante");
            Mamifero animal2 = new Gorila("King Kong");
            Mamifero persona = new Humano("Luisa","47189188J");
            Console.WriteLine(animal1.getInformacion());
            Console.WriteLine(animal2.getInformacion());
            Console.WriteLine(persona.getInformacion());

            // otra forma de aplicar el principio de sustitucion

            Mamifero animal3 = new Caballo("Silverado");
            Console.WriteLine(animal3.getInformacion());

            Caballo caballito = new Caballo("Caballito");
            animal3 = caballito; // un Caballo ES SIEMPRE un Mamifero? SI
            //caballito = animal3; // Error. un Mamifero ES SIEMPRE un Caballo?? NO
            Console.WriteLine(animal3.getInformacion());

            // otra forma de aplicar el principio de sustitucion
            Object animal4 = new Gorila("Simba");

            //utilidad practica: array que almacene animales
            Mamifero[] arcaAnimales = new Mamifero[3];
            arcaAnimales[0] = caballo1;
            arcaAnimales[1] = humano1;
            arcaAnimales[2] = gorila1;

            foreach(Mamifero mamif in arcaAnimales)
            {
                Console.WriteLine(mamif.getInformacion());
            }

            // Ocultacion de metodos heredados: new
            Caballo caballo3 = new Caballo("Sr.POO");
            caballo3.pensar(); // "Pensamiento basico instintivo"
            Humano humano3 = new Humano("Mari", "23456789O");
            humano3.pensar();  //"Estoy pensando"

            // Polimorfismo
            foreach (Mamifero mamif in arcaAnimales)
            {
                mamif.pensar();
                // que mostrara?
                // "Pensamiento basico instintivo"
                // "Pensamiento de humano"
                // "Pensamiento de gorila"
            }

            // acceso al metodo protegido() de la clase Mamifero 

            Gorila g = new Gorila("dhskjdhs");
            g.trepar();
        }
    }
}
