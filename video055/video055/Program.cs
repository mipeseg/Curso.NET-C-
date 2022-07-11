/*  Fuente: video55, video56
    // TODO: Comenzamos con el video

    PROPERTIES (O PROPIEDADES) vs ENCAPSULACION (private)

        Que son?. Utilidad. Las properties son una alternativa mas "comoda" que 
        usar los metodos getter y setter. No siempre se podran utilizar

        Sintaxis:

            private double evaluaSalario(double salario)    // Metodo de control de la propertie
            {
                if (salario < 0)
                    return 0;
                else
                    return salario;
            }

            public double SALARIO    // creacion de la propertie
            {
                get { return salario; }
                set { this.salario = evaluaSalario(value); }
            }

    EXPRESSION BODIES

        Simplifica bastante la sintaxis para crear properties.  Ej:

                 public double SALARIO
                 {
                        // expression bodies

                        get => this.salario;
                        set => this.salario = evaluaSalario(value);
                 }

    READONLY PROPERTIES vs WRITEONLY PROPERTIES

        - WRITEONLY PROPERTIES 

          ej) Una constrasenia no interesa que tenga lectura para obtenerla

                    private string evaluaPassword(string pass)    // Metodo de control de la propertie
                    {
                        if (pass == "")
                            return "";
                        else
                            return "";
                    }

                    public double PASSWORD    // creacion de la propertie
                    {
                        set { this.password = evaluaPassword(value); }
                    }

        - READONLY PROPERTIES 

            Idem pero prescindimos del set

    CONVENCIONES EN EL USO DE PROPERTIES

        - cuando usemos PROPERTIES los campos de clase a los que hacen referencia deberian
          nombrase con un prefijo _  Ej)  private double _salario;

 */

using System;

namespace video055 
{
    class Empleado
    {
        // CAMPOS O PROPIEDADES DE CLASE

        private string nombre;
        private double salario;

        // METODOS

        public Empleado(string nombre)  // Metodo constructor
        {
            this.nombre = nombre;
        }

        // Metodos setter y getter

        public string getNombre()
        {
            return nombre;
        }

        public double getSalario() 
        { 
            return salario;
        }

        public void setSalario(double salario) 
        {
            if(salario<0)
            {
                Console.WriteLine("El salario es negativo. Se asignara 0");
                this.salario = 0;
            }
            else
                this.salario = salario;
        }

        // CREACION DE PROPERTIES

        private double evaluaSalario(double salario)    // Metodo de control de la propertie
        {
            if (salario < 0)
                return 0;
            else
                return salario;
        }

        private string evaluaNombre(string nombre)    // Metodo de control de la propertie
        {
            return nombre;
        }

        public double SALARIO
        {
            /*get { return salario; }
            set { this.salario = evaluaSalario(value); }*/

            // expression bodies

            get => this.salario;
            set => this.salario = evaluaSalario(value);
        }

        public string NOMBRE
        {
            get { return nombre; }
            set { this.nombre = evaluaNombre(value); }
        }
    }

    class Program 
    { 
        static void Main(string[] args) 
        {
            Empleado emp1 = new Empleado("Juan");

            Console.WriteLine($"El salario de {emp1.getNombre()} es {emp1.getSalario()} euros");
            emp1.setSalario(-15);
            Console.WriteLine($"El salario de {emp1.getNombre()} es {emp1.getSalario()} euros");
            emp1.setSalario(1500);
            Console.WriteLine($"El salario de {emp1.getNombre()} es {emp1.getSalario()} euros");

            // incrementamos el sueldo a emp1 en 200 euros

            emp1.setSalario(emp1.getSalario() + 200);
            Console.WriteLine($"El salario de {emp1.getNombre()} es {emp1.getSalario()} euros");

            // uso de properties

            Console.WriteLine($"El salario de {emp1.NOMBRE} es {emp1.SALARIO} euros");
            emp1.NOMBRE = "Juan Manuel";
            emp1.SALARIO += 500;
            Console.WriteLine($"El salario de {emp1.NOMBRE} es {emp1.SALARIO} euros");
        }    
    }
}
