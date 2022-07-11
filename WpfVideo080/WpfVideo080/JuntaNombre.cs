/*
    Fuente: video80
    // TODO: comenzamos el video
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;  // necesario para usar la interfaz INotifyPropertyChanged

namespace WpfVideo080
{
    public class JuntaNombre : INotifyPropertyChanged
    {
        // PROPIEDADES O CAMPOS DE CLASE

        private string nombre, apellido, nombreCompleto;

        // METODOS 

        // implementamos el metodo obligatorio de la interfaz
        // Este metodo es un controlador de eventos que se desencadena
        // cuando cambie cualquier propiedad
        public event PropertyChangedEventHandler? PropertyChanged;

        // este metodo se invoca cada vez que cambie cualquier propiedad
        // en alguno de los controles WPF
        private void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null) // si cambia el valor de alguna propiedad
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        // IMPLEMETAMOS LAS PROPERTIES WPF
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value;
                  OnPropertyChanged("NombreCompleto"); // si Nombre cambia, NombreCompleto tambien
                }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value;
                  OnPropertyChanged("NombreCompleto"); // si Apellido cambia, NombreCompleto tambien                                    
                }
            }

        public string NombreCompleto
        {
            get { nombreCompleto = Nombre + " " + Apellido;
                  return nombreCompleto;
                }
            set
            {
              
            }
        }
    }
    
}
