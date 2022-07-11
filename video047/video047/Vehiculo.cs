using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace video047
{
    internal class Vehiculo
    {
        // PROPIEDADES DE CLASE  (PROP.COMUNES A LAS SUBCLASES)

        private string matricula;

        // METODOS DE CLASE  (MET.COMUNES A LAS SUBCLASES)

        public Vehiculo(string matricula)  // Metodo constructor
        {
            this.matricula = matricula;
        }

        // Metodos setter y getter

        public string getInfo()
        {
            return $"Matricula: {matricula}";
        }

        // Otros metodos

        public void arrancarMotor(string sonidoArranque)
        {
            Console.WriteLine($"{sonidoArranque}... Motor arrancado");
        }

        public void pararMotor(string sonidoParada)
        {
            Console.WriteLine($"Motor parado ... {sonidoParada}");
        }

        public virtual void conducir()
        {
            Console.WriteLine("conduciendo vehiculo");
        }
    }
}
