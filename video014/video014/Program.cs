/*
     Fuente: Video14, Video15, Video16, video17, video18, Video19, Video20
             video21
    
     VARIABLES BOOLEANAS
        
            bool a; // declaracion de una variable booleana
            bool b = true; // declaracion e inicalizacion 

     OPERADORES LOGICOS O BOOLENOS ( se usan en operaciones booleanas)
   
        unarios (necesitan un operando)        ! (negacion)
        binarios (necesitan dos operandos)     &   |  ^ (XOR)  cortocircuito ( && y || )
           
     OPERADORES DE COMPARACION O RELACIONALES (se usan en operaciones booleanas)

        binarios (necesitan dos operandos)    ==  !=   >   >=   <   <=
        

     ESTRUCTURAS DE CONTROL DEL FLUJO DE EJECUCION DE UN PROGRAMA
     Por defecto va de arriba hacia abajo. Con las estructuras de control podemos alterarlo

       - CONDICIONALES -> IF ELSE , SWITCH
         En C# todo lo que se puede hacer con switch lo podemos hacer con if, pero no al reves.
         En otros lenguajes como Visual Basic si que serian equivalentes. Por ejemplo:
           - switch solo puede evaluar expresiones cuyo resultado sea int, char o string

                if(condicion)
                {
                    .......
                }
                else if (condicion)
                {
                    .....
                }
                else
                { 
                    .....
                }

                switch(expresion)
                {
                   case valor:
                   case valor:
                        ....
                        break;
                   case valor
                        .....
                        break;
                   ...
                   default:  // es opcional
                        .....
                        break;
                }

       - ITERATIVAS -> WHILE, DO WHILE, FOR
         Los bucles o estructuras de control iterativas pueden ser:

         - bucle indeterminado (no sabemos a priori las iteraciones que dara)

            while(condicion)      do
            {                     {
               .....                 .......
            }                     } while(condicion);

         - bucle determinado (a priori sabemos las iteraciones que dara)

                for (inicializacion ; condicion ; incremento/decremento)
                {
                   .....
                }

                foreach (lo veremos mas adelante)

 */

bool haceFrio = false;

Console.WriteLine($"En Junio hace frio: {haceFrio}");
Console.WriteLine($"En Diciembre hace frio: {!haceFrio}");

//evalua la edad de una persona

byte edad = 67;

if(edad>=0 && edad<=12)
{
    Console.WriteLine("Eres un nino");
}
else if (edad>=13 && edad<=17) 
{
    Console.WriteLine("Eres un adolescente");
}
else
    Console.WriteLine("Eres un adulto");

// evalua si una persona tiene carnet de conducir

bool carnet = true;

if (carnet)
    Console.WriteLine("Puedes conducir vehiculos");
else
    Console.WriteLine("No puedes conducir vehiculos");

// evalua si una persona puede conducir

byte e;

Console.Write("Introduce tu edad: ");
e = byte.Parse(Console.ReadLine());

if (e >= 18)
{
    Console.Write("Tienes carnet de conducir? (S o N): ");
    string c = Console.ReadLine();  // c tiene un ambito local al bloque if

    //if (c=="s" || c == "S")
    if (String.Compare(c,"s",true) == 0)  // compara dos cadenas ignorando minisculas-mayusculas. Devuelve 0 si son iguales
        Console.WriteLine("Puedes conducir vehiculos");
    else
        Console.WriteLine("No puedes conducir vehiculos");
}
else
    Console.WriteLine("No puedes conducir vehiculos");

// calcula la nota media de 3 parciales. NOTA: Tienes que aprobar cada parcial

float nota1, nota2, nota3;

Console.Write("Introduce nota 1: ");
nota1 = float.Parse(Console.ReadLine());

Console.Write("Introduce nota 2: ");
nota2 = float.Parse(Console.ReadLine());

Console.Write("Introduce nota 3: ");
nota3 = float.Parse(Console.ReadLine());

if (nota1 >= 5 && nota2 >= 5 && nota3 >= 5)
    Console.WriteLine($"La nota media es: {(nota1 + nota2 + nota3)/3}");
else
    Console.WriteLine("Tienes suspendido algun parcial");

// Elegir un medio de transporte
string medioTransporte;

Console.Write("Introduce un medio de transporte (coche, tren, avion): ");
medioTransporte = Console.ReadLine();

switch (medioTransporte) 
{
    case "coche":
        Console.WriteLine("La velocidad media es 100Km/h"); break;
    case "tren":
        Console.WriteLine("La velocidad media es 230Km/h"); break;
    case "avion":
        Console.WriteLine("La velocidad media es 550Km/h"); break;
    default:
        Console.WriteLine("Medio de transporte desconocido"); break;
}

// Mostrar la comision de ventas de cada trimestre
byte numTrimestre;

Console.Write("Introduce el n. de trimestre: ");
numTrimestre = byte.Parse(Console.ReadLine());

switch (numTrimestre)
{
    case 1:
        Console.WriteLine("La comision es 5%"); break;
    case 2:
        Console.WriteLine("La comision es 8%"); break;
    case 3:
        Console.WriteLine("La comision es 10%"); break;
    case 4:
        Console.WriteLine("La comision es 7%"); break;
    default:
        Console.WriteLine("El trimestre no es correcto"); break;
}

// Dado en dni, calcula su letra y muestra el nif  (algoritmo 1)
int dni;

Console.Write("Introduce el dni: ");
dni = int.Parse(Console.ReadLine());

switch (dni % 23)
{
    case 0:
        Console.WriteLine($"El NIF es {dni}-T"); break;
    case 1:
        Console.WriteLine($"El NIF es {dni}-R"); break;
    // ......
    case 7:
        Console.WriteLine($"El NIF es {dni}-F"); break;
    // ......
    case 22:
        Console.WriteLine($"El NIF es {dni}-E"); break;
    default:
        Console.WriteLine("El dni no es correcto"); break;
}

// Dado en dni, calcula su letra y muestra el nif  (algoritmo 2)
int numDni;
string letras = "TRWAGMYFPDXBNJZSQVHLCKE";

Console.Write("Introduce el dni: ");
numDni = int.Parse(Console.ReadLine());
Console.WriteLine($"El NIF es {numDni}-{letras[numDni % 23]}");

// genera un numero aleatorio entre 0 y 10. Debes adivinarlo acotando y el programa dira los intentos
// que has tardado

Random numero = new Random();  // creamos el objeto numero de clase Random
int numAleatorio = numero.Next(0,10); // hacemos que el objeto random devuelva un aleatorio entre 0y 10
//int numAleatorio = new Random().Next(0, 10); 
int resp, intentos=0;

do
{
    intentos++;
    Console.Write("Introduce el numero a adivinar: ");
    resp = int.Parse(Console.ReadLine());
    if (resp < numAleatorio)
        Console.WriteLine("El numero que buscas es mayor");
    if (resp > numAleatorio)
        Console.WriteLine("El numero que buscas es menor");
} while (resp != numAleatorio);

Console.WriteLine($"Has acertado en {intentos} intentos. El numero era: {numAleatorio}");

// mostrar los primeros 10 numeros enteros por pantalla

Console.WriteLine("Los 10 primeros numeros enteros son:");
for(int i = 0; i < 10; i++)
    Console.Write($"{i}, ");