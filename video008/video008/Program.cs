/*
 *   Fuente: Video8, video 9, video 10, video 11, video12, video13
 *   
     DECLARACION DE CONSTANTES (su valor nunca varia en toda la ejecucion de la app)

         const tipo NOMBRE_CONSTANTE = valor;

         NOTAS: Una const se tiene que declaran e inicializar a la vez. 
                Por recomendacion el nombre en mayusculas.

       Ej)  const float B = 3.5F;

     METODOS O FUNCIONES

     Un metodo es un grupo de sentencias o instrucciones referenciados con un identificador
     y que hace una tarea concreta. 
     NOTAS: 
       - La tarea se realiza cuando el metodo sea invocado
       - todos los metodos deben codificarse dentro de una Clase
       - se puede llamar a un metodo infinitas veces
       - Para declarar metodos usamos dos sintaxis:

                    TipoDevuelto nombreMetodo (p1, p2, ...){
                        ....   // cuerpo del metodo
                        ....
                        return valor; // lo que devuelve el metodo. Es opcional
                    }

                    TipoDevuelto nombreMetodo (p1, p2, ...) => instruccion // usamos la notacion lambda si hay una sola instruccion en el cuerpo

           NOTAS: un metodo puede no devolver nada (void). Los p son tb opcionales

      MODULARIZACION (Divide y venceras)

      C# es un lenguaje modular, es decir, permite que el codigo se divida en modulos o metodos.
      Si para ver la cantidad de lineas dentro de un modulo hay que scrollear, no suele
      estar bien disenado

      AMBITO (ALCANCE O CONTEXTO)
        Se aplica tanto a variables como a metodos. Dos tipos;
        - una variable puede ser de ambito local a un metodo 
           solo se puede usar dentro de ese metodo
        - una variable puede ser de ambito global a una clase (class Program)
          se define fuera de todos los modulos, para que puedan usarla todos
          NOTA: A una variable con ambito de clase se le llama CAMPO DE CLASE 

      SOBRECARGA DE METODOS
        Ocurre cuando en una clase hay dos o mas metodos con el mismo nombre pero
        su lista de parametros es distinta en numero, tipo de datos, etc
        Ej: el metodo WriteLine tiene 17 sobrecargas dentro de la clase Console

      AYUDAS DE VISUAL STUDIO A LA HORA DE TRABAJAR CON METODOS
        Podemos declarar un metodo pero no implementar su contenido hasta mas tarde

        Ej:
            bool suma (int v1, double v2)
            {
                throw new NotImplementedException();    
            }
        Depuracion
            - Seleccionamos una linea de codigo y pulsamos CTRL+F10 (ejecutar el programa hasta el cursor)
            - F11 (ejecutar la instruccion actual y saltar a la siguiente)
            - SHIFT + F11 (salir del modo depuracion y continuar con la ejecucion normal)
            
      METODOS CON PARAMETROS OPCIONALES

           TipoDevuelto nombreMetodo (p1, p2, p3 = 15){    // p3 es opcional. Si no recibe valor su valor por default sera 15
                        ....   // cuerpo del metodo
                        ....
                        return valor; // lo que devuelve el metodo. Es opcional
                    }

            NOTA: Los parametros opcionales siempre deben ir al final de la lista de parametros,
                  a continuacion de los obligatorios

      AMBIGUEDADES EN LA LLAMADAS A METODOS
 */

// declaracion de constantes y variables

const int VALOR1 = 1;
const float VALOR2 = 3.14F;
int a = 5; 

Console.WriteLine("Valores: {0} - {1} - {2}", VALOR1, VALOR2, a); // entre llaves la posicion del parametro
Console.WriteLine($"Valores: {VALOR1} - {VALOR2}");
Console.WriteLine("Valores: " + VALOR1 + " - " + VALOR2);

// introduce un radio y calcula el area de un circulo
const double PI = 3.1416;
double radio;

Console.Write("Introduce el radio: ");
radio = double.Parse(Console.ReadLine());
// double.TryParse(Console.ReadLine(), out radio);  // controlando excepciones
// Console.WriteLine($"El area de la circunferencia es {PI*radio*radio}");
Console.WriteLine($"El area de la circunferencia es {Math.PI * Math.Pow(radio,2)}");

// utiliza un metodo para sumar dos numeros
int num1 = 15, num2 = -3;

int suma1(int a, int b)
{
    return a + b;
}

int suma2(int a, int b) => a + b;


void limpiarPantalla() => Console.Clear();


Console.WriteLine($"Las sumas son {suma1(num1,num2)} - {suma2(3, 33)} ");
limpiarPantalla(); //borra la pantalla

// utiliza un metodo para dividir dos numeros enteros o reales

double division(double a, int b)
{
    // cualquier operacion aritmetica entre real y entero da un resultado real
    return a / b;
}

Console.WriteLine($"La division es {division(15, 3)}"); // La division es 5
Console.WriteLine($"La division es {division(18, 7)}"); // La division es 2,5714285714285716

// Ambito
int f = 3; // variable local a main() pero como si fuera global a segundoMetodo() y primerMetodo()

void primeroMetodo()  // este metodo tiene un ambito local a void main(void) que es dentro de donde estamos
{
    f++;
    Console.WriteLine(f);
}

void segundoMetodo()  // este metodo tiene un ambito local a void main(void) que es dentro de donde estamos
{
    int num = 5; //esta variable tiene un ambito local a segundoMetodo(). Solo 
                 //se puede usar dentro de su cuerpo
}

primeroMetodo(); // escribe el valor de f que sera 4

// sobrecarga
/* No funciona en .NET 6
 
int sum1(int a, int b) => a + b;
double sum1(int op1, double op2, int op3) => op1 + op2 + op3;
Console.WriteLine($"Las sumas son: {sum1(2,9)} - {sum1(12, -11,9)}");

Si funciona en .NET framework 4.8 // Podemos hacer proyectos .NET 6 usando
la antigua codificacion que ha estado vigente hasta .NET 5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace video008
{
    internal class Program
    {
        static int sum1(int a, int b) => a + b;
        static double sum1(int op1, double op2, int op3) => op1 + op2 + op3;

        static void Main(string[] args)
        {
            Console.WriteLine($"Las sumas son: {sum1(2,9)} - {sum1(12, -11, 9)}");
        }
    }
}

*/

// declarar un metodo sin contenido, para mas tarde implementarlo
bool sumaO(int v1, double v2)
{
    throw new NotImplementedException(); // lanzamiento de excepcion 
}

// Parametros opcionales

int sumaOp(int a, int b, int c=0)
{
    return a + b + c;
}

Console.WriteLine($"La suma es: {sumaOp(5, 6)} - {sumaOp(1, 2, 4)}");