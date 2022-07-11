/*
    Fuente: video72, video73, video74, video75
    //TODO: estamos al inicio del video

    CREACION DE INTERFACES GRAFICAS WPF

        - WPF (Windows Presentation Foundation) es una API (Applications Programming Interface)
           integrada en el framework .NET para desarrollar aplicaciones desktop en Windows.
        - WPF es la sucesora de Windows Form
        - WPF permite desarrollar aplicaciones Desktop combinando tres formas de trabajo:
           a) desarrollo de la interfaz grafica en vista XAML (XAML es un lenguaje de marcado 
              muy parecido a HTML))
           b) desarrollo de la interfaz grafica en vista disenyo (drag&drop de controles WPF sobre 
              un grid, q acaba generando automaticamnete codigo XAMP)
           c) desarrollo con CodeBehind (en este caso programado en C#)
        - WPF genera interfaces graficas vectoriales (se pueden reescalar sin perdida de calidad)
        - WPF utiliza Data Biding, lo que permite crear aplicaciones MVC (usan el patron ModeloVistaControlador)

    COMO CREAR UN PROYECTO WPF

        Abrimos nuevo proyecto. Buscamos WPF y la primera opcion que aparece es "Aplicacion WPF.
        proyecto para crear aplicacion WPF de .NET". Lo seleccionamos. llamamos a la solucion
        WpfVideo72.

        Podemos distinguir en el proyecto:

        - MainWindow.xaml -> interfaz grafica de usuario
        - MainWindow.xaml.cs -> donde programaremos en C#

        Una aplicacion WPF en VisuaL Studio se trabaja de 3 formas combinadas: vista disenyo,
        vista XAMP y CodeBehind (en este caso usaremos C#)

    CREAR BUTTON UTILIZANDO XAML

        Ya hemos creado controles mediante drag&drop. Ahora vamos a crear dos 
        Buttons en el Grid. Despues modificamos algunas de sus propiedades:

        <Grid HorizontalAlignment="Stretch" VerticalAlignment="Stretch">
            <Button Name="buttonCancelar" Content="Cancelar" Width="150" Height="90" FontSize="24"/>

            <Button Name="buttonMulticolor">
                <Button.Width>200</Button.Width>
                <Button.Height>100</Button.Height>
                <Button.Content>  --> accedemos a la propiedad Content
                    <WrapPanel>
                        <TextBlock Foreground="Red">Hola</TextBlock>
                        <TextBlock Foreground="Blue">Click</TextBlock>
                        <TextBlock Foreground="Yellow">Enviar</TextBlock>
                    </WrapPanel>
                </Button.Content>
            </Button>
        </Grid>

    CREAR BUTTON UTILIZANDO C#

        Vamos a agregar un Button pero desde codigo C#. Ver el ejemplo

        Documentacion controles -> https://docs.microsoft.com/es-es/dotnet/api/system.windows.controls.textblock.foreground?view=windowsdesktop-6.0
        Documentacion clase Grid -> https://docs.microsoft.com/es-es/dotnet/api/system.windows.controls.grid?view=windowsdesktop-6.0
        Documentacion clase Button -> https://docs.microsoft.com/es-es/dotnet/api/system.windows.controls.button?view=windowsdesktop-6.0
        Documentacion clase WrapPanel -> https://docs.microsoft.com/es-es/dotnet/api/system.windows.controls.wrappanel?view=windowsdesktop-6.0
        Documentacion clase TextBlock -> https://docs.microsoft.com/es-es/dotnet/api/system.windows.controls.textblock?view=windowsdesktop-6.0
        Documentacion clase Brushes -> https://docs.microsoft.com/es-es/dotnet/api/system.drawing.brushes?view=windowsdesktop-6.0

        Propiedades del Button

            Button button = new Button();  // Creamos un boton
            button.Content = "Enviar";
            button.Width = 100;
            button.Height = 50;
            button.Background = Brushes.Green;
            button.Margin = 15;  // 15 px en todos los margenes 
            button.HorizontalAlignment = HorizontalAlignment.Left;
            myGrid.Children.Add(button); // Anadimos el boton al Grid 

        Eventos del Button

            Un evento es un desencadenante de una accion 
            (ej: cuando se dispare el evento click que se realiza alguna tarea)

            En el codigo XAML escribimos la propiedad Click="". Si posicionamos
            el mouse entre "" nos da la posibilidad de agregar un nuevo controlador.
            Si hace click el codigo XAML se queda asi:

                <Button Name ="botonAtras" Content="Atras" Margin="15" Click="botonAtras_Click"> 

                </Button>

            Y ademas en el codigo C# se nos crea este metodo

                private void botonAtras_Click(object sender, RoutedEventArgs e)
                {
                    MessageBox.Show("Pulsaste el boton Atras");

                    // si queremos lanzar mensajes de Salida que solo se
                    // veran al terminar la app.
                    Trace.WriteLine("Pulsaste el boton Atras"); // necesita  using System.Diagnostics;
                }
            
    EL CONTROL STACKPANEL

        Es un organizador de elementos dentro de la interfaz grafica. En realidad
        es una coleccion Stack (pila). Por defecto, el width de los elementos que
        vamos apilando se ajusta al width del StackPanel

        Ej) ver el codigo XAMP de miStackPanel
    
    TIPOS DE EVENTOS EN WPF

        En WPF los eventos son enrutados, es decir, siguen una ruta o propagacion.
        Los tipos de eventos enrutados son:

        - eventos directos

            No tienen propagacion. Son los que acabamos de ver. Sintaxis:

                <Button Name ="botonAtras" ... Click="botonAtras_Click"> 
                    ....
                </Button>

                private void botonAtras_Click(object sender, RoutedEventArgs e)
                {
                   ....
                }

        - eventos bubbling (eventos burbuja)

            Cuando ocurre un evento bubbling propaga hacia arriba en la jerarquia
            de controles de la interfaz grafica. Ej) en nuestro ultimo ejemplo

                Window
                    Grid
                        StackPanel
                            Boton1  Boton2  Boton3
                                Text    Text    Text

            Cuando ocurra el evento click en Boton1, se propaga al StackPanel, al
            Grid y al Window. Pero imaginemos que definimos varios eventos click 
            para boton1, stackpanel y grid?. Al estar anidados los controles, 
            cual evento click ocurre antes?  En este caso boton1

            Veamos la sintaxis con un ejemplo: 

                <StackPanel x:Name="miStackPanel" ... ButtonBase.Click="miStackPanel_Click">  <!-- miStackPanel_Click es bubbling -->
                    <Button Name ="botonAdelante" ...  Click="botonAdelante_Click">
                        .....
                    </Button>
                    ...
                </StackPanel>

                private void botonAdelante_Click(object sender, RoutedEventArgs e)
                {
                    Trace.WriteLine("Pulsaste el boton Adelante");
                }

                private void miStackPanel_Click(object sender, RoutedEventArgs e)
                {
                    Trace.WriteLine("Pulsaste el StackPanel");
                }

             NOTAS: Si clickamos el botonAdelante se propaga hacia arriba y vemos
                    los mensajes: 
                         "Pulsaste el boton Adelante"   1. en ocurrir
                         "Pulsaste el StackPanel"       2. en ocurrir

                    Si clickamos en el StackPanel no se lanza ningun evento

        - eventos tunneling (eventos tunelados)

            La propagacion ocurre hacia abajo. Asi que si definimos eventos click
            en boton1, stackpanel y grid, el primero que ocurre sera el del grid

             Veamos la sintaxis modificando el ejemplo anterior: 

                <StackPanel x:Name="miStackPanel" ... PreviewMouseLeftButtonDown="miStackPanel_PreviewMouseLeftButtonDown"">  <!-- miStackPanel_Click es tunneling -->
                    <Button Name ="botonAdelante" ...  Click="botonAdelante_Click">
                        .....
                    </Button>
                    ...
                </StackPanel>

                private void botonAdelante_Click(object sender, RoutedEventArgs e)
                {
                    Trace.WriteLine("Pulsaste el boton Adelante");
                }

                private void miStackPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
                {
                    Trace.WriteLine("Pulsaste el StackPanel");
                }   

             NOTAS: Si clickamos el botonAdelante se propaga hacia abajo y vemos
                    los mensajes: 
                         "Pulsaste el StackPanel"        1. en ocurrir
                         "Pulsaste el boton Adelante"    2. en ocurrir

                    Si clickamos en el StackPanel se lanza el evento click:

                         "Pulsaste el StackPanel" 
 */

using System;
using System.Diagnostics;
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


namespace WpfVideo72
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()  
        {
            InitializeComponent();  // inicia la ventana principal del proyecto

            // Creamos un boton
            
            //Grid miGrid = new Grid();  // creamos un Grid
            //this.Content = miGrid;  // metemos el Grid en el contenido de la ventana
            Button button = new Button(); // Creamos un boton
            WrapPanel miWrap = new WrapPanel(); // Creamos un wrapPanel
            TextBlock txt1 = new TextBlock(); // Creamos un textBlock
            txt1.Text = "Click";
            txt1.Foreground = Brushes.Red;  // accedemos a la propiedad Foreground y anadimos color rojo
            miWrap.Children.Add(txt1);
            TextBlock txt2 = new TextBlock(); // Creamos un textBlock
            txt2.Text = "Enviar";
            txt2.Foreground = Brushes.Blue;
            miWrap.Children.Add(txt2);
            TextBlock txt3 = new TextBlock(); // Creamos un textBlock
            txt3.Text = "Adios";
            txt3.Foreground = Brushes.Yellow;
            miWrap.Children.Add(txt3);
            button.Content = miWrap;
            button.Width = 100;
            button.Height = 50;
            button.Background = Brushes.Green;
            myGrid.Children.Add(button); // Anadimos el boton al Grid 
        }

        private void botonAtras_Click(object sender, RoutedEventArgs e)
        {
            // Configuramos y lanzamos un popup
            //MessageBox.Show("Pulsaste el boton Atras");

            // documentacion enumerado MessageBoxResult -> https://docs.microsoft.com/es-es/dotnet/api/system.windows.messageboxresult?view=windowsdesktop-6.0
            // documentacion MessageBox -> https://docs.microsoft.com/es-es/dotnet/api/system.windows.messagebox?view=windowsdesktop-6.0
            MessageBoxResult result = MessageBox.Show("Pulsaste el boton Atras","Atencion", 
                            MessageBoxButton.YesNo, MessageBoxImage.Information); // 

            /*  Resultados que devuelve el metodo MessageBox.Show()
                Aceptar -> 1 OK   Cancelar -> 2 Cancel  
                Si -> 6 Yes       No -> 7 No
                None -> 0    
             */

            textblockBienvenida.Text = result.ToString();
            Trace.WriteLine("Pulsaste el boton Atras");

        }
        private void botonAdelante_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Pulsaste el boton Adelante");
        }

        /*
        private void miStackPanel_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Pulsaste el StackPanel");
        }*/
        private void miStackPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Trace.WriteLine("Pulsaste el StackPanel");
        }
    }
}
