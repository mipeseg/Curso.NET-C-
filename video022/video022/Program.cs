/*
    Fuente: video22, video23, video24, video25, Video26

    EXCEPCIONES

        Una excepcion es un error en tiempo de ejecucion que hace que se pierda el control
        del programa y se cierre. Ej: acciones inesperadas del usuario, memoria corrupta, 
        desbordamiento de pila, acceso a fichero inexistente, conexion a BBDD interrumpida, etc...

        * Captura y manejo de excepciones

            Manejar las excepciones es indicar en el codigo que hara el programa en caso de que ocurran.

                    try {
                      .... // codigo susceptible de provocar excepciones
                    }
                    catch(Exception ex) {
                      ... // codigo que se ejecuta cuando se produce cualquier excepcion
                    }
                    finally {
                      ... // Este bloque es opcional. Su codigo se ejecuta siempre
                    }


                    try {
                      .... // codigo susceptible de provocar excepciones
                    }
                    catch(ExceptionClase1 ex) {
                      ... // cuando se produce una excepcion ExceptionClase1
                    }
                    ..
                    catch(ExceptionClaseN ex) {
                      ... // cuando se produce una excepcion ExceptionClaseN
                    }
                    finally {
                      ... // Este bloque es opcional. Su codigo se ejecuta siempre
                    }

        * Conflictos en el uso de varios catch

            Si capturamos todas las excepciones con Exception, podemos capturar
            otrras excepciones especificas pero de la siguiente manera. El siguiente
            ejemplo no es correcto y marca error en el compilador:

            try
            {
               ....
            }
            catch (Exception ex) { 
                ...
            }
            catch (OverflowException ex)
            {
                ....
            }

            Este codigo es el correcto:

            try
            {
               ....
            }
            catch (OverflowException ex)
            {
                ....
            }
            catch (Exception ex) { 
                ...
            }

        * Captura de excepciones con filtros

        Si queremos hacer una captura generica con Exception, pero a una de las excepciones
        queremos darle un tratamiento especifico, usamos la captura con filtros

            try
            {
               ....
            }
            catch (Exception ex) when (ex.GetType() != typeof(FormatException)) { 
               // captura todas las excepciones cuando la clase sean distintas a FormatException
                ...
            }
            catch(FormatException)
            {
              // solo entra en este bloque cuando se produzca la FormatException
            }

        * Expresiones checked y unchecked (por defecto)

          - checked permite que el programaa caiga en operaciones artimeticas desbordadas

                checked{ ... instrucciones a checkear ... }
                checked ( operacion aritmetica a checkear )

          - Se puede activar desde propiedades del proyecto/compilacion/opciones avanzadas/comprobar el desbordamiento aritmetico
          - solo funcionan con los tipos int y long  

            NOTA: En "Depurar/Ventanas/Configuracion de Excepciones/Common LAnguage Runtime Exceptions" encontramos
                  todas las excepciones. Le decimos a Vstudio con que interrupciones debe deterner el programa
                  cuando iniciemos en modo depuracion.

        * Lanzamiento de Excepciones con throw
           - Podemos obligar al sistema a que lance una excepcion, para luego manejarla
           - Biblioteca de clases en .NET -> podemos ver las clases de excepciones que hay
             https://docs.microsoft.com/es-es/previous-versions/gg145045(v=vs.110)?redirectedfrom=MSDN
           - buscar la excepcion que mas se adecua a la operativa que buscamos

                    throw new nombreExcepcion();   // creamos un objeto de esa clase de excepcion. Despues lanzamos la excepcion

 */

// controlar TODAS las excepciones del programa de adivinar un numero

// genera un numero aleatorio entre 0 y 10. Debes adivinarlo acotando y el programa dira los intentos
// que has tardado

// creamos un objeto de clase Random y llamamos al metodo que genera enteros aleatorio entre inicio y fin
int numAleatorio = new Random().Next(0, 10);
int resp=-1, intentos = 0;

do
{
    intentos++;
    Console.Write("Introduce el numero a adivinar: ");

    // si el usuario no introduce una cadena con formato de entero se produce
    // la excepcion System.FormatException: 'Input string was not in a correct format.'
    try
    {
        resp = int.Parse(Console.ReadLine());
        if (resp < numAleatorio)
            Console.WriteLine("El numero que buscas es mayor");
        if (resp > numAleatorio)
            Console.WriteLine("El numero que buscas es menor");
    }
    catch(Exception ex)
    {
        //Console.WriteLine("El numero introducido no es un entero");
        Console.WriteLine(ex.Message); // describimos la excepcion ocurrida
    }
} while (resp != numAleatorio);

Console.WriteLine($"Has acertado en {intentos} intentos. El numero era: {numAleatorio}");

// capturar excepciones especificas

Console.Write("Introduce el radio (solo enteros): ");

try
{
    int r = int.Parse(Console.ReadLine());
    Console.WriteLine($"El area de la circunferencia es: {Math.PI * Math.Pow(r,2)}");
}
catch (FormatException ex) { 
    Console.WriteLine("El numero introducido no es un entero");
}
catch (OverflowException ex)
{
    Console.WriteLine("Desbordamiento de pila. Ha introducido un entero demasiado largo");
}

// capturar excepciones con filtros

Console.Write("Introduce la masa del cuerpo en Kg: ");

try
{
    float masa = float.Parse(Console.ReadLine());
    Console.WriteLine($"El peso del cuerpo es: {masa*9.8} N");
}
catch (Exception ex) when (ex.GetType() != typeof(OverflowException))
{
    // captura todas las excepciones cuando sean distintas a OverflowException
    Console.WriteLine("Se ha producido una excepcion generica");
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.GetType() + " - " + typeof(OverflowException));
}
catch (OverflowException ex)
{
    Console.WriteLine("Se ha producido un desbordamiento de pila");
}

// Expresiones checked y unchecked

int max = int.MaxValue; // valor maximo representable con el tipo entero
Console.WriteLine($"El maximo entero representable es {max}"); // 2147483647
Console.WriteLine($"El maximo entero representable es {max+20}"); // deberia dar un error de desbordamiento pero muestra una respuesta erronea -2147483629. Lo hace para que el programa no caiga con operaciones aritmeticas desbordadas.
                                                                  // es un comportamiento unchecked
checked // deja caer al programa ante cualquier desbordamiento en operaciones aritmeticas
{
    try
    {
        Console.WriteLine($"El maximo entero representable es {max + 20}"); // ahora si cae
    }
    catch(Exception ex) 
    {
        Console.WriteLine(ex.Message);
    }
    
}

// uso de checked( ) con enteros. Con float no ha funcionado

int x=-1;

Console.Write("Introduce un numero entero: ");
try
{
    x = checked(int.Parse(Console.ReadLine()));
    Console.WriteLine($"Numero entero introducido: {x}");
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

// introducir el numero de mes y que muestre su nombre. Lanza una excepcion 
// si el num de mes esta fuera de rango

string nombreDelMes(byte mes)
{
    switch(mes) 
    {
        case 1: return "Enero";
        case 2: return "Febrero";
        case 3: return "Marzo";
        case 4: return "Abril";
        case 5: return "Mayo";
        case 6: return "Junio";
        case 7: return "Julio";
        case 8: return "Agosto";
        case 9: return "Septiembre";
        case 10: return "Octubre";
        case 11: return "Noviembre";
        case 12: return "Diciembre";
        default:
            // return "Num de mes erroneo";
            // creamos un objeto de la clase ArgumentOutOfRangeException
            throw new ArgumentOutOfRangeException(); 
    }
}

try
{
    Console.Write("Introduce el numero de mes: ");
    byte numMes = byte.Parse(Console.ReadLine());
    Console.WriteLine($"El mes {numMes} corresponde a '{nombreDelMes(numMes)}'");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}

// acceso al contenido de un fichero de texto
System.IO.StreamReader fichero = null; // Creamos un flujo de lectura de informacion desde un fichero

try
{
    string linea;
    int cont = 0;
    string ruta = @"D:\Cursos\.NET\Tutorial PildorasInformaticas\ejercicios\video022\nombres.txt";

    fichero = new System.IO.StreamReader(ruta); // apuntamos a nombres.txt y lo abrimos

    Console.WriteLine("Contenido de nombres.txt: ");
    while ((linea = fichero.ReadLine()) != null)  // leemos lineas del fichero hasta llegar al final, que sera null
    {
        Console.WriteLine(linea);
        cont++;
    }
}
catch(Exception e)
{
    Console.WriteLine(e.Message); // mostramos la excepcion
}
finally
{
    if (fichero != null) fichero.Close();   // si el fichero esta abierto, lo cerramos
    Console.WriteLine("Conexion cerrada con el fichero");
}