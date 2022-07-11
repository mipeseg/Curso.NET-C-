using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace video047
{
    internal class Coche : Vehiculo
    {
        // PROPIEDADES DE CLASE

        // METODOS DE CLASE 

        public Coche(string mat) : base(mat)  // Metodo constructor
        {

        }

        // Metodos setter y getter

        // Otros metodos
        public override void conducir()
        {
            Console.WriteLine("conduciendo coche");
        }
        public void acelerar()
        {
            Console.WriteLine("acelerando");
        }
        public void frenar()
        {
            Console.WriteLine("frenando");
        }

    }
}
