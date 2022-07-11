/*
    Fuente: video86, video87
    // TODO: Estamos al comienzo del video87

    RADIOBUTTON (https://docs.microsoft.com/es-es/dotnet/api/system.web.ui.webcontrols.radiobutton?view=netframework-4.8&viewFallbackFrom=net-6.0)
    
        Se suelen agrupar y solo puede seleccionarse un RadioButton a la vez. 

    IMAGENES

        <Image Source="ruta .png" Width="250" Height="300" VerticalAlignment="Top"></Image>

    CREACION DE UNA ELIPSE 

        NOTA: La imagen y la elipse deberan estar dentro de un Grid. Es la unica forma que la elipse
              pueda solapar a la imagen

        <Ellipse Name="elipseVerde" Width="80" Height="80" Fill="Green" Margin="164,210,156,55" Visibility="Hidden"></Ellipse>

   
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

namespace WpfVideo086
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            elipseRojo.Visibility = Visibility.Visible;
            elipseAmbar.Visibility = Visibility.Hidden;
            elipseVerde.Visibility = Visibility.Hidden;
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            elipseRojo.Visibility = Visibility.Hidden;
            elipseAmbar.Visibility = Visibility.Visible;
            elipseVerde.Visibility = Visibility.Hidden;
        }

        private void RadioButton_Click_2(object sender, RoutedEventArgs e)
        {
            elipseRojo.Visibility = Visibility.Hidden;
            elipseAmbar.Visibility = Visibility.Hidden;
            elipseVerde.Visibility = Visibility.Visible;
        }
    }
}
