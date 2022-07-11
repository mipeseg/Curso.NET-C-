/*
    Fuente: video81, video82, video83
    // TODO: estamos al comienzo de video84

    LISTBOX (https://docs.microsoft.com/es-es/dotnet/api/system.windows.controls.listbox?view=windowsdesktop-6.0)
             https://docs.microsoft.com/es-es/dotnet/api/system.windows.controls.primitives.selector.selectionchanged?view=windowsdesktop-6.0
        Es un control WPF que puede contener una lista de objetos seleccionables.
        Posee el evento SelectionChanged que se lanza cuando se produce un 
        cambio 

        Para detectar que ListBoxItem hemos clickado:

             <Listbox ... SelectionChanged="PrintText" SelectionMode="Single"></ListBox>

             void PrintText(object sender, SelectionChangedEventArgs args)
             {
                 Mensaje();
             }

             private void Mensaje()
             {
                if (listBoxPoblaciones.SelectedItem != null)
                    MessageBox.Show((listBoxPoblaciones.SelectedItem as Poblaciones).Poblacion1 + " " +
                                    (listBoxPoblaciones.SelectedItem as Poblaciones).Temperatura1 + " °C " +
                                    (listBoxPoblaciones.SelectedItem as Poblaciones).Poblacion2 + " " +
                                    (listBoxPoblaciones.SelectedItem as Poblaciones).Temperatura2 + " °C DifTemps " +
                                    (listBoxPoblaciones.SelectedItem as Poblaciones).DifTemps + " °C"
                                   );
                else
                    MessageBox.Show("Selecciona un Item de la lista");
             }


    PROGRESSBAR

        https://docs.microsoft.com/es-ES/dotnet/api/system.windows.controls.progressbar?view=windowsdesktop-6.0

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
using System.Windows.Controls.Primitives;

namespace WpfVideo081
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public class Poblaciones
    {
        // CAMPOS DE CLASE O PROPIEDADES

        
        // PROPERTIES
        // En lugar de definir campos de clase y despues metodo constructor
        // nos ahorramos codigo definicion Properties

        public string Poblacion1 { get; set; }
        public int Temperatura1 { get; set; }
        public string Poblacion2 { get; set; }
        public int Temperatura2 { get; set; }
        public int DifTemps 
        {
            get { return Math.Abs(Temperatura1 - Temperatura2); }
            set { }
        }
    }

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            List<Poblaciones> listaPob = new List<Poblaciones>();

            listaPob.Add(new Poblaciones() {Poblacion1 = "Madrid", Poblacion2 = "Barcelona", Temperatura1 = 20, Temperatura2 = 17 });
            listaPob.Add(new Poblaciones() { Poblacion1 = "Valencia", Poblacion2 = "Alicante", Temperatura1 = 12, Temperatura2 = 25 });
            listaPob.Add(new Poblaciones() { Poblacion1 = "Sevilla", Poblacion2 = "Malaga", Temperatura1 = 22, Temperatura2 = 35 });
            listaPob.Add(new Poblaciones() { Poblacion1 = "Vigo", Poblacion2 = "Ourense", Temperatura1 = 33, Temperatura2 = 30 });

            listBoxPoblaciones.ItemsSource = listaPob;  // el contenido del ListBox muestra lista
            
        }

        private void Mensaje()
        {
            if (listBoxPoblaciones.SelectedItem != null)
                MessageBox.Show((listBoxPoblaciones.SelectedItem as Poblaciones).Poblacion1 + " " +
                                (listBoxPoblaciones.SelectedItem as Poblaciones).Temperatura1 + " °C " +
                                (listBoxPoblaciones.SelectedItem as Poblaciones).Poblacion2 + " " +
                                (listBoxPoblaciones.SelectedItem as Poblaciones).Temperatura2 + " °C DifTemps " +
                                (listBoxPoblaciones.SelectedItem as Poblaciones).DifTemps + " °C"
                               );
            else
                MessageBox.Show("Selecciona un Item de la lista");
        }

        // se llama cuando se hace click en el boton
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           Mensaje();
        }

        // se llama cuando hacemos click sobre el ListBox
        void PrintText(object sender, SelectionChangedEventArgs args)
        {
            Mensaje();
        }

    }
}
