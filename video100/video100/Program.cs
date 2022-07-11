/*
    Fuente: video100, video101, video102
    // TODO: Estamos al comienzo de video

    LINQ (Language Integrated Query) https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/concepts/linq/basic-linq-query-operations

        - Es un lenguaje integrado de consultas. Esta integrado tanto en la plataforma .NET (desde la
          version 3.5) como en el lenguaje C# (desde la version 3.0)

        - se usa para acceder a datos de distintos origenes de datos:
            colecciones de objetos, XML, BBDD, entidades, recordset, otras estructuras, etc...
        
        - ventajas de utilizar link

              A pesar de que podemos acceder a los origenes de datos anteriores sin LINKQ (ej, a BBDD
              accediamos con SQL) conviene usarlo por:

              1) uniformidad en el lenguaje de consulta de datos
              2) reduccion de codigo
              3) el codigo se hace mas legible
              4) integracion con C# (intellisense disponible)

        - La API de LINQ esta formada por dos clases: Enumerable y Queryable

            Estas clases nos ofrecen una serie de metodos para acceder y manipular datos. Estos
            datos seran tambien accesibles desde aquellas clases que implementen las interfaces
            IEnumerable y IQueryable
             
            clase Enumarable -> https://docs.microsoft.com/es-es/dotnet/api/system.linq.enumerable?view=net-6.0
                                using System.Linq;
            clase Queryable -> https://docs.microsoft.com/es-es/dotnet/api/system.linq.queryable?view=net-6.0
                                using System.Linq;
 
        Ejemplo: Creamos un array de enteros. Obtener los numeros pares y guardarlos en una lista de enteros.
                 Lo haremos de la forma 1 (clasica) y de la forma 2 (usando LINQ)

    LINQ Y OBJETOS

        Ej) tenemos dos clases: Empresa y Empleado. Cada una tendra sus propiedades. Cada empleado
            pertenece a una sola empresa.

                // la consulta LINQ obtiene aquellos empleados de listaEmpleados con cargo "ceo"

                IEnumerable<Empleado> ceos = from empleado in listaEmpleados where empleado.Cargo == "Ceo"
                                         select empleado;

    INSTRUCCIONES LINK DE ORDENACION

        - ordenacion segun algun criterio

            a) ascendente (default)
     
                // la consulta LINQ obtiene todos los empleados de listaEmpleados ordenados por nombre

                    IEnumerable<Empleado> empleados = from empleado in listaEmpleados
                                             orderby empleado.NombreEmpleado select empleado;
            b) descendente
      

               // la consulta LINQ obtiene todos los empleados de listaEmpleados ordenados por salario descendente
             
                    IEnumerable<Empleado> empleados = from empleado in listaEmpleados
                                                      orderby empleado.Salario descending
                                                      select empleado;
        - consulta de datos relacionados entre si

            Recordemos que Empleado y Empresa estan relacionados por la clave foranea Empleado.idEmpresa
            Veamos el metodo getEmpleadosByEmpresa(string nombre)

             // obtener los empleados que trabajan en google
             IEnumerable<Empleado> empleados = from empleado in listaEmpleados    // de la lista empleados
                                               join empresa in listaEmpresas      // relacionada con la lista empresas
                                               on empleado.IdEmpresa equals empresa.getId()  // en empleado.IdEmpresa == empresa.getId() 
                                               where empresa.getNombre()==nombre  // criterio de seleccion
                                               select empleado;
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace video100
{
    public class Empresa
    {
        // CAMPOS DE CLASE O PROPIEDADES

        private int idEmpresa;          // seria como la PRIMARY KEY
        private string nombreEmpresa;

        // METODO(S) CONSTRUCTOR(ES)

        public Empresa(int id, string nom)
        {
            this.idEmpresa = id;
            this.nombreEmpresa = nom;
        }

        // METODOS SETTER Y GETTER

        public int getId() { return idEmpresa; }
        public void setId(int idEmpresa) { this.idEmpresa = idEmpresa; }
        public string getNombre() { return nombreEmpresa; }
        public void setNombre(string nom) { this.nombreEmpresa = nom; }

        // OTROS METODOS
        public void infoEmpresa()
        {
            Console.WriteLine($"Info empresa => Id: {idEmpresa} nombre: {nombreEmpresa}");
        }
    }

    public class Empleado
    {
        // PROPIERTIES
       
        public int IdEmpleado { get; set; }   // seria como la PRIMARY KEY
        public int IdEmpresa { get; set; }    // seria como la FOREIGN KEY
        public string NombreEmpleado { get; set; }
        public string Cargo{ get; set; }
        public double Salario { get; set; }

        // OTROS METODOS

        public void infoEmpleado()
        {
            Console.WriteLine($"Info empleado => IdEmpleado: {IdEmpleado} nombre: {NombreEmpleado} " +
                              $"cargo: {Cargo} salario: {Salario} IdEmpresa: {IdEmpresa}");
        }

    }

    public class ControlEmpresasEmpleados
    {
        // CAMPOS DE CLASE O PROPIEDADES

        private List<Empresa> listaEmpresas;   // definimos una lista de objetos Empresa
        private List<Empleado> listaEmpleados; // definimos una lista de objetos Empleado

        // METODO(S) CONSTRUCTOR(ES)
        
        public ControlEmpresasEmpleados()
        {
            // creamos las listas 
            listaEmpresas = new List<Empresa>();
            listaEmpleados = new List<Empleado>();

            // Rellenamos las listas
            listaEmpresas.Add(new Empresa(1,"google"));
            listaEmpresas.Add(new Empresa(2, "apple inc"));
            listaEmpresas.Add(new Empresa(3, "amazon"));
            listaEmpleados.Add(new Empleado {IdEmpleado = 1, IdEmpresa = 1, NombreEmpleado = "Sergei Flint", 
                                              Cargo = "Ceo", Salario = 15000});
            listaEmpleados.Add(new Empleado {IdEmpleado = 2, IdEmpresa = 2, NombreEmpleado = "Juan Diaz", 
                                              Cargo = "Peon", Salario = 25000});
            listaEmpleados.Add(new Empleado {IdEmpleado = 3, IdEmpresa = 1, NombreEmpleado = "Laura Perez", 
                                              Cargo = "Ceo", Salario = 17325.50});
            listaEmpleados.Add(new Empleado {IdEmpleado = 4, IdEmpresa = 1, NombreEmpleado = "Ramon Melendi", 
                                              Cargo = "Ingeniero", Salario = 19245});
        }

        // OTROS METODOS
        public void getInfoEmpresa(int idEmp)
        {
            IEnumerable<Empresa> empresas = from empresa in listaEmpresas
                                         where empresa.getId() == idEmp
                                         select empresa;

            if (empresas.Count() > 0)
            {
                foreach (Empresa empr in empresas)
                {
                    empr.infoEmpresa();
                }
            }
            else
                Console.WriteLine("No se ha encontrado la empresa.");
        }

        public void getCeo()  // obtiene todos los empleados con cargo "ceo" usando LINQ
        {
            IEnumerable<Empleado> ceos = from empleado in listaEmpleados where empleado.Cargo == "Ceo"
                                         select empleado;

            if (ceos.Count() > 0)
            {
                foreach (Empleado emp in ceos)
                {
                    emp.infoEmpleado();
                }
            }
            else
                Console.WriteLine("No se han encontrado empleados");
        }

        public void getSalarioMayorA(double salario)  // obtiene todos Empleado.Salario>salario usando LINQ
        {
            IEnumerable<Empleado> empleados = from empleado in listaEmpleados
                                         where empleado.Salario > salario
                                         select empleado;

            if (empleados.Count() > 0)
            {
                foreach (Empleado emp in empleados)
                {
                    emp.infoEmpleado();
                }
            }
            else
                Console.WriteLine("No se han encontrado empleados");
        }

        public void getEmpresa(int idEmpresa)  // obtiene todos los empleados de una empresa usando LINQ
        {
            IEnumerable<Empleado> empleados = from empleado in listaEmpleados
                                              where empleado.IdEmpresa == idEmpresa
                                              select empleado;

            if (empleados.Count() > 0)
            {
                foreach (Empleado emp in empleados)
                {
                    emp.infoEmpleado();
                }
            }
            else
                Console.WriteLine("No se han encontrado empleados");  
        }

        public void getEmpleadosByName()
        {
            // ordena alfabeticamente por el nombre del empleado
            IEnumerable<Empleado> empleados = from empleado in listaEmpleados
                                         orderby empleado.NombreEmpleado select empleado;

            if (empleados.Count() > 0)
            {
                foreach (Empleado emp in empleados)
                {
                    emp.infoEmpleado();
                }
            }
            else
                Console.WriteLine("No se han encontrado empleados");
        }

        public void getEmpleadosByEmpresa()
        {
            // ordena los empleados por empresa
            IEnumerable<Empleado> empleados = from empleado in listaEmpleados
                                              orderby empleado.IdEmpresa
                                              select empleado;

            if (empleados.Count() > 0)
            {
                foreach (Empleado emp in empleados)
                {
                    emp.infoEmpleado();
                }
            }
            else
                Console.WriteLine("No se han encontrado empleados");
        }

        public void getEmpleadosBySalario()
        {
            // ordena los empleados por salario de mayor a menor
            IEnumerable<Empleado> empleados = from empleado in listaEmpleados
                                              orderby empleado.Salario descending
                                              select empleado;

            if (empleados.Count() > 0)
            {
                foreach (Empleado emp in empleados)
                {
                    emp.infoEmpleado();
                }
            }
            else
                Console.WriteLine("No se han encontrado empleados");
        }

        public void getEmpleadosByEmpresa(string nombre)
        {
            // obtener los empleados que trabajan en google
            IEnumerable<Empleado> empleados = from empleado in listaEmpleados    // de la lista empleados
                                              join empresa in listaEmpresas      // relacionada con la lista empresas
                                              on empleado.IdEmpresa equals empresa.getId()  // en empleado.IdEmpresa == empresa.getId() 
                                              where empresa.getNombre()==nombre  // criterio de seleccion
                                              select empleado;

            if (empleados.Count() > 0)
            {
                foreach (Empleado emp in empleados)
                {
                    emp.infoEmpleado();
                }
            }
            else
                Console.WriteLine("No se han encontrado empleados");
        }
    }

    public class Program
    {

        static void numerosParesClasico()
        {
            int[] numeros = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };  // origen de datos

            List<int> numerosPares = new List<int>();  // Target de datos

            foreach (int i in numeros)
            {
                if (i % 2 == 0)
                    numerosPares.Add(i);
            }

            Console.Write($"Numeros pares (clasico): ");
            for (int i = 0; i < numerosPares.Count; i++)
            {
                Console.Write($"{numerosPares[i]}, ");
            }
        }

        static void numerosParesLinq()
        {
            int[] numeros = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };  // origen de datos

            IEnumerable<int> numerosPares = from num in numeros where num % 2 == 0 select num; // target de datos (relleno con lenguaje linq)

            Console.Write($"Numeros pares (linq): ");
            foreach (int i in numerosPares)
            {
               Console.Write($"{i}, ");
            }
        }

        static void Main(string[] args)
        {

            // NUMEROS PARES
            numerosParesClasico();  // forma 1 (acceso clasico)
            Console.WriteLine();
            numerosParesLinq();   // forma 2 (acceso usando LINQ)

            Console.WriteLine();

            // EMPRESAS Y EMPLEADOS

            ControlEmpresasEmpleados cee = new ControlEmpresasEmpleados();
            cee.getCeo();  // muestra todos los empleados con cargo "Ceo"
            Console.WriteLine();
            cee.getSalarioMayorA(15000); // muestra todos los empleados con salario > 15000
            Console.WriteLine();
            cee.getEmpresa(1);   // muestra todos los empleados de la empresa con idEmpresa = 1
            Console.WriteLine();
            cee.getInfoEmpresa(3);  // muestra toda la info de la empresa idEmpresa = 3
            Console.WriteLine();
            cee.getEmpleadosByName();  // muestra todos los empleados pero ordenados alfabeticamente
            Console.WriteLine();
            cee.getEmpleadosByEmpresa();  // muestra todos los empleados pero ordenados por idEmpresa
            Console.WriteLine();
            cee.getEmpleadosBySalario();  // muestra todos los empleados pero ordenados por salario descendente
            Console.WriteLine();

            // muestra todos los empleados de la empresa que el usuario introduzca por teclado
            Console.Write("Introduce el nombre de una empresa: ");
            string nom = Console.ReadLine();
            cee.getEmpleadosByEmpresa(nom); 
        }
    }
}