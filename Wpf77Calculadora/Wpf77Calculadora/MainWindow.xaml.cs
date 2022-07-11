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

namespace Wpf77Calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private double memoria = 0;
        private bool banderaOp = false;

        private void Pantalla(string digito, bool inicializaPantalla)
        {
            if (inicializaPantalla)
                tbPantalla.Text = "0";
            else
            {
                if ((tbPantalla.Text == "0" && tbPantalla.Text.Length == 1)||(banderaOp))
                {
                    tbPantalla.Text = digito;
                    banderaOp = false;
                }
                else
                    tbPantalla.Text += digito;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Pantalla("0", true); // incializamos la pantalla a 0
        }

        private void boton7_Click(object sender, RoutedEventArgs e)
        {
            Pantalla("7", false);
        }

        private void botonCE_Click(object sender, RoutedEventArgs e)
        {
            Pantalla("0", true); // incializamos la pantalla a 0
            memoria = 0;
            banderaOp = false;
        }

        private void botonC_Click(object sender, RoutedEventArgs e)
        {
            Pantalla("0", true); // incializamos la pantalla a 0
            memoria = 0;
            banderaOp = false;
        }

        private void botonSuprimir_Click(object sender, RoutedEventArgs e)
        {
            string cadena="";
            
            if(tbPantalla.Text.Length>1)
            {
                for (int i = 1; i < tbPantalla.Text.Length; i++)
                {
                    cadena = cadena + tbPantalla.Text[i];
                }

                tbPantalla.Text = cadena;
            }
            else
                Pantalla("0", true); // incializamos la pantalla a 0

        }

        private void boton8_Click(object sender, RoutedEventArgs e)
        {
            Pantalla("8", false);
        }

        private void boton9_Click(object sender, RoutedEventArgs e)
        {
            Pantalla("9", false);
        }

        private void boton4_Click(object sender, RoutedEventArgs e)
        {
            Pantalla("4", false);
        }

        private void boton5_Click(object sender, RoutedEventArgs e)
        {
            Pantalla("5", false);
        }

        private void boton6_Click(object sender, RoutedEventArgs e)
        {
            Pantalla("6", false);
        }

        private void boton1_Click(object sender, RoutedEventArgs e)
        {
            Pantalla("1", false);
        }

        private void boton2_Click(object sender, RoutedEventArgs e)
        {
            Pantalla("2", false);
        }

        private void boton3_Click(object sender, RoutedEventArgs e)
        {
            Pantalla("3", false);
        }

        private void botonSuma_Click(object sender, RoutedEventArgs e)
        {
            banderaOp = true;
            /*if (memoria==0)
            {
                memoria += double.Parse(tbPantalla.Text);
            }
            else
            {
                memoria += double.Parse(tbPantalla.Text);
                tbPantalla.Text = memoria.ToString();
            }*/

            memoria += double.Parse(tbPantalla.Text);
            tbPantalla.Text = memoria.ToString();

        }

        private void boton0_Click(object sender, RoutedEventArgs e)
        {
            Pantalla("0", false);
        }

        private void botonIgual_Click(object sender, RoutedEventArgs e)
        {
            banderaOp = true;
            memoria += double.Parse(tbPantalla.Text);
            tbPantalla.Text = memoria.ToString();
        }
    }
}
