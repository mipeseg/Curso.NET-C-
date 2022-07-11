/*
    Fuente: video84, video85
    // TODO: Estamos al comienzo del video

    COMBOBOX (https://docs.microsoft.com/es-es/dotnet/api/system.windows.forms.combobox?view=windowsdesktop-6.0)

        Este control representa una lista desplegable.

    CHECKBOX (https://docs.microsoft.com/es-es/dotnet/api/system.web.ui.webcontrols.checkbox?view=netframework-4.8)
      OnCheckedChanged
 
      Tienen 3 estados: activado, desactivado, null (gris. En checks q controlan a otros indica q 
                        algunos estan activados y otros no. Hay que activarle la propiedad isThreeState=True)
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

namespace WpfVideo084
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public class Capital
    {
        // PROPERTIES

        public string NombreCapital { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // List<Capital> listaCapitales = new List<Capital>() { new Capital { NombreCapital = "Madrid"}, ... };
            List<Capital> listaCapitales = new List<Capital>(); // creamos una lista

            listaCapitales.Add( new Capital { NombreCapital = "Madrid"});   // Rellenamos la lista 
            listaCapitales.Add(new Capital { NombreCapital = "Bogota" });
            listaCapitales.Add(new Capital { NombreCapital = "Lima" });
            listaCapitales.Add(new Capital { NombreCapital = "MexicoDF" });
            listaCapitales.Add(new Capital { NombreCapital = "Santiago" });
            listaCapitales.Add(new Capital { NombreCapital = "Buenos Aires" });

            cbCapitales.ItemsSource = listaCapitales; // pasamos la lista creada que se usa como contenido del comboBox
        }

        
        private void cbCapitales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           MessageBox.Show((cbCapitales.Items.CurrentItem as Capital).NombreCapital);
            
        }

        private void chbTodasC_Checked(object sender, RoutedEventArgs e)
        {
            chbMadrid.IsChecked = true;
            chbBogota.IsChecked = true;
            chbLima.IsChecked = true;
            chbMexicoDF.IsChecked = true;
            chbSantiago.IsChecked = true;
            chbBuenosAires.IsChecked = true;
        }

        private void chbTodasC_Unchecked(object sender, RoutedEventArgs e)
        {
            chbMadrid.IsChecked = false;
            chbBogota.IsChecked = false;
            chbLima.IsChecked = false;
            chbMexicoDF.IsChecked = false;
            chbSantiago.IsChecked = false;
            chbBuenosAires.IsChecked = false;
        }

        // este evento sera llamado por los chbMadrid, chbBogota, chbLima ... chbBuenosAires
        // cuando su estado sea checked
        private void individual_checked(object sender, RoutedEventArgs e)
        {
            if(chbMadrid.IsChecked == true && chbBogota.IsChecked == true && chbLima.IsChecked == true &&
               chbMexicoDF.IsChecked == true && chbSantiago.IsChecked == true && chbBuenosAires.IsChecked == true)
            {
                chbTodasC.IsChecked = true;
            }
            else
            {
                chbTodasC.IsChecked = null; // el tercer estado
            }
        }

        // este evento sera llamado por los chbMadrid, chbBogota, chbLima ... chbBuenosAires
        // cuando su estado sea unchecked
        private void individual_noChecked(object sender, RoutedEventArgs e)
        {
            if (chbMadrid.IsChecked == false && chbBogota.IsChecked == false && chbLima.IsChecked == false &&
               chbMexicoDF.IsChecked == false && chbSantiago.IsChecked == false && chbBuenosAires.IsChecked == false)
            {
                chbTodasC.IsChecked = false;
            }
            else
            {
                chbTodasC.IsChecked = null; // el tercer estado
            }
        }
    }
}
