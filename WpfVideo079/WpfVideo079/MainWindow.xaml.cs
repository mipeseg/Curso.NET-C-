/*
    Fuente: video79
    // TODO: Estamos al comienzo del video

    DATA BINDING (ENLACE A DATOS)
    
        - Que es?

            El Data Binding es un enlace o puente a traves del cual un control
            WPF puede enviar/recibir informacion de/a diversas 
            fuentes (BBDD, objetos C#, otros controles WPF, etc...)

        - Tipos de Data Binding

                        Control WPF    <---oneWay----         Fuente
                         (Target)    ---oneWayToSource-->    (Source) 
                                      <---twoWays -------->
                                       <---oneTime---- 

            a) Data Binding oneWay ( la info viene de la fuente al control WPF)
            b) Data Binding oneWayToSource ( la info va del control WPF a la fuente)
            c) Data Binding twoWays ( la info fluye en ambas direcciones entre target y source)
            d) Data Binding oneTime (la info fluye 1 SOLA VEZ del source al target)

         - Ejemplo: Hacemos DataBiding entre un TextBox y un Slider

             <StackPanel>  <!-- Movemos el slider y cambia el valor del TextBox -->
                <Slider Width="350" Name="miSlider" Minimum="0" Maximum="100"></Slider>  <!-- SOURCE  -->
                <TextBox  Width="100" Name="miCuadro" Margin="100" Text="{Binding ElementName=miSlider,Path=Value,Mode=OneWay}"></TextBox>  <!-- TARGET  -->
             </StackPanel>

             <StackPanel>  <!-- Introducimos un valor en el TextBox, pulsamos TAB y se mueve el slider -->
                <Slider Width="350" Name="miSlider" Minimum="0" Maximum="100"></Slider>  <!-- SOURCE  -->
                <TextBox  Width="100" Name="miCuadro" Margin="100" Text="{Binding ElementName=miSlider,Path=Value,Mode=OneWayToSource}"></TextBox>  <!-- TARGET  -->
             </StackPanel>

             <StackPanel>  <!-- Bidireccional -->
                <Slider Width="350" Name="miSlider" Minimum="0" Maximum="100"></Slider>  <!-- SOURCE  -->
                <TextBox  Width="100" Name="miCuadro" Margin="100" Text="{Binding ElementName=miSlider,Path=Value,Mode=TwoWay}"></TextBox>  <!-- TARGET  -->
             </StackPanel>

             Observa: - Binding ElementName = SOURCE
                      - Path  = indica a que propiedad del SOURCE hacemos binding
                      - Mode = tipo de Binding

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

namespace WpfVideo079
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
    }
}
