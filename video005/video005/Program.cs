/*   Fuente: Video5, Video6, Video7
 
     TIPOS DE DATOS

        •	Por valor (se almacena el valor en la variable)
            •	Simples o Primitivos
                •	Enteros (byte,sbyte,short,ushort,int,uint,long,ulong)
                •	Reales (float, double, decimal)
                •	bool
                •	char
            •	Estructuras
            •	Enumerados
        •	Por referencia (se almacena la dirección de otra variable)
            •	string

       NOTA:  instancia.getType() -> muestra el tipo de una instancia

    OPERADORES ARITMETICOS   

           binarios   +   -   *  /   %         unarios  -  --  +  ++  

     OPERADORES DE ASIGNACION       

           =     +=     -=      *=      /=       %=

     OPERADOR DE CONCATENACION DE CADENAS

          +    Ej:  Console.WriteLine("Tienes una edad de " + edad + " anyos");

     OPERADOR DE INTERPOLACION DE CADENAS    

          $   Console.WriteLine($"Tienes una edad de {edad} anyos");


     DECLARACION DE VARIABLES CON TIPO IMPLICITO
     var nomVariable = valor ;  -> Le decimos al compilador en tiempo de ejecucion
                                   que la variable se convierta al tipo de datos del valor que le asignemos
     OJO: - las variables con tipo implicito siempre se deben inicializar en su declaracion
          - una vez asignado el valor, siempre debera contener valores de ese tipo

     CONVERSION DE DATOS
         - conversion entre tipos de datos compatibles

             - conversion implicita de variables
               La hace el compilador automaticamente.

             - conversion explicita de variables (casting)
               La forzamos los programadores.

             NOTAS:  Tablas de conversiones implicitas y explicitas
              https://docs.microsoft.com/es-es/dotnet/csharp/language-reference/builtin-types/numeric-conversions
   
         - conversion entre tipos de datos incompatibles
           La forzamos los programadores. ej: uso del metodo Parse() para convertir texto a entero
*/

Console.WriteLine(6 * 2);
Console.WriteLine(5 / 2);
Console.WriteLine(5.0 / 2);
Console.WriteLine(9 % 3);
Console.WriteLine(10 % 3);

int edad = 5;

Console.WriteLine("Tienes una edad de " + edad + " anyos");  // concatenacion de cadenas
Console.WriteLine($"Tienes una edad de {++edad} anyos");  // interpolacion de cadenas

// asignacion multiple

int edad1, edad2, edad3, edad4;

edad1 = edad2 = edad3 = edad4 = 25;  // asi inicializamos todas las var con el mismo valor
Console.WriteLine($"Las edades son: {edad1}, {edad2}, {edad3}, {edad4}");

//declaracion implicita de variables

var variable = 5;
Console.WriteLine($"La variable implicita vale: {variable}");
/*variable = 3.5;  // En c# no se permite esto. variable debe ser siempre de tipo entero
                   // En Visual Basic se permitiria
Console.WriteLine($"La variable implicita vale: {variable}");*/

// conversiones de datos

double temperatura = 35.5;
int temperaturaParteEntera;
byte numTrabajadores = 78;
int numTrabajadores2022;
float masa = 5.78F; // si no ponemos F, 5.78 seria double y daria error  (float)5.78
double masaPrec;

temperaturaParteEntera = (int)temperatura; // conversion explicita de double a int
Console.WriteLine($"La temperatura es: {temperatura} - {temperaturaParteEntera}");

numTrabajadores2022 = numTrabajadores; // conversion implicita de byte a int
Console.WriteLine($"Numero de trabajadores en 2022: {numTrabajadores2022}");

masaPrec = masa; // conversion implicita de float a double
Console.WriteLine($"Masa: {masa}  -  Masa de precision: {masaPrec}");

// mostramos los tipos de las variables anteriores
Console.WriteLine($"{temperatura.GetType().Name} - {temperaturaParteEntera.GetType()} - " +
                  $"{numTrabajadores.GetType()} - {numTrabajadores2022.GetType().Name} - " +
                  $"{masa.GetType()} - {masaPrec.GetType()}");

// conversion de tipos incompatibles
int a, b;
string cad;

Console.Write("Introduce a: ");
a = int.Parse(Console.ReadLine());  // conversion de texto a entero
Console.Write("Introduce b: ");
int.TryParse(Console.ReadLine(), out b);  // conversion de texto a entero con control de excepciones
Console.WriteLine($"La suma es {a+b}");

/*Console.Write("Introduce cad: ");
cad = Console.ReadLine(); 
Console.WriteLine($"tipo {cad.GetType()}");*/
