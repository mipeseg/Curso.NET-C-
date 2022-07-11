using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace video047
{
    internal class Avion : Vehiculo
    {
        // PROPIEDADES DE CLASE

        // METODOS DE CLASE 

        public Avion(string mat) : base(mat)  // Metodo constructor
        {

        }

        // Metodos setter y getter

        // Otros metodos
        public override void conducir()
        {
            // base.conducir(); // si necesitamos llamar al metodo conduncir() de Vehiculo
            Console.WriteLine("conduciendo avion");
        }

        public void aterrizar()
        {
            Console.WriteLine("aterrizando");
        }

        public void despegar()
        {
            Console.WriteLine("despegando");
        }
    }
}
