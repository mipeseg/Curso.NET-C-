/*
    Fuente: video
    // TODO: Estamos al principio del video80

    LA INTERFAZ INotifyPropertyChanged (https://docs.microsoft.com/es-es/dotnet/api/system.componentmodel.inotifypropertychanged?view=net-6.0)
    https://docs.microsoft.com/es-es/dotnet/api/system.componentmodel.inotifypropertychanged?view=net-6.0
      
        Hasta ahora si queriamos controlar cambios en una propiedad de un objeto 
        creabamos un evento que hacia una tarea cuando cambiara la propiedad. 
        Y asi por cada propiedad a controlar.

        Gracias a la interfaz INotifyPropertyChanged podemos detectar cambios 
        en cualquier propiedad de un objeto y crear un solo evento que lo gestione.
        
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfVideo080
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            JuntaNombre miObj = new JuntaNombre {Nombre = "Juan", Apellido = "Diaz" };
            this.DataContext = miObj; // Indicamos que origen de los bidings esta en this (MainWindow)
        }
    }
}
