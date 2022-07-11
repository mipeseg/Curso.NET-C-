using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace video048
{
    internal class AvisosTrafico : IAvisos
    {
        // PROPIEDADES O CAMPOS DE LA CLASE
        private string remitente;
        private string mensaje;
        private string fecha;


        // METODOS DE CLASE

        public AvisosTrafico()  // metodo constructor
        {
            // aviso generico

            remitente = "DGT";
            mensaje = "Sancion cometida. Pague en 3 dias y tendra reduccion del 50%";
            fecha = "";
        }

        public AvisosTrafico(string remitente, string mensaje, string fecha)  // metodo constructor sobrecarga +1
        {
            // aviso personalizado

            this.remitente = remitente;
            this.mensaje = mensaje;
            this.fecha = fecha;
        }

        // metodos a implementar de la interfaz
        public void mostrarAviso()
        {
            // Console.WriteLine($"Mensaje {0} ha sido enviado por {1} el dia {2}", mensaje, remitente, fecha);
            Console.WriteLine($"Mensaje '{mensaje}' ha sido enviado por '{remitente}' el dia '{fecha}'");
        }

        public string getFecha()
        {
            return fecha;
        }

        
    }
}
