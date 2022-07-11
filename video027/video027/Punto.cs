using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace video027
{
    internal class Punto
    {
        //CAMPOS DE CLASE

        private int x, y;
        private static int contadorDeObjetos = 0;  // variable estatica o variable de clase
        public const int PRUEBA = 7; // C# hace que las constantes sean estaticas por defecto

        // METODO CONSTRUCTOR Y SOBRECARGAS

        public Punto() 
        {
            this.x = 0;
            this.y = 0;
            contadorDeObjetos++;  // por cada instancia creada se incrementa
        }

        public Punto(int x, int y)   // por cada instancia creada se incrementa
        {
            this.x = x;
            this.y = y;
            contadorDeObjetos++;
        }

        // METODOS SETTER Y GETTER
        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public static int getContadorDeObjetos() => contadorDeObjetos;  // metodo estatico o metodo de clase

        // METODOS
        public double distanciaHasta(Punto otroPunto) // distancia entre dos puntos
        {
            // calcula la distancia entre este objeto Punto y otro que le pasamos
            int xDif = this.x - otroPunto.x;  // this.x haria referencia a origen.x
            int yDif = this.y - otroPunto.y;  // this.y haria referencia a origen.y
            double distanciaPuntos = Math.Sqrt(Math.Pow(xDif,2) + Math.Pow(yDif, 2)); //pitagoras a2 = b2 + c2

            return distanciaPuntos; // devuelve la hipotenusa del Trect que es la distancia entre los puntos
            // https://docs.microsoft.com/es-es/dotnet/api/  Podemos buscar toda la documentacion de las clases
        }
    }
}
