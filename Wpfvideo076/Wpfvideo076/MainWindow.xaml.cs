/*
    Fuente: video76, 
    TODO:// Estamos empezando el video

    EL CONTROL GRID

        Grid es el control WPF mas versatil. Grid es un contenedor de controles 
        que se puede divide en filas y columnas. Las dimensiones (Width y Height) de 
        los controles WPF se pueden expresar en:

         - valor absoluto (pixeles) (indicados por el programador)
         - valor automatico (por defecto)
              Un control, nada mas crearse, se adapta a las dimensiones de su 
              contenido
         - valor proporcional (muy utilizado) (*)
              el control se adapta al espacio disponible que quede en 
              su contenedor.
        
        Seria como una matriz. En cada celda hay un control

                    0,0  1,0  2,0  3,0  4,0 ...
                    0,1  1,1  2,1  ...
                    0,2  1,2  2,2  ..
                    0,3
                    ...

        Ejemplo: Tenemos un Grid con dimensiones automaticas que se adapta
                 a una Window de Height="450" Width="800" pixeles. Definimos
                 en el Grid 2 columnas con 1 boton cada una:

                    <!-- PRIMERA OPCION: WIDTHs ABSOLUTOS -->
                    <Grid>  
                        <Grid.ColumnDefinitions>  <!-- Grid de 2 columnas-->
                            <ColumnDefinition Width="175"></ColumnDefinition>
                            <ColumnDefinition Width="375"></ColumnDefinition>
                            <!-- a la derecha sobraran 250px -->
                        </Grid.ColumnDefinitions>
                        <Button Grid.Column="0">Boton1</Button>
                        <Button Grid.Column="1">Boton2</Button>
                    </Grid>

                    <!-- SEGUNDA OPCION: WIDTH ABSOLUTO vs WIDTH PROPORCIONAL -->
                    <Grid>  
                        <Grid.ColumnDefinitions>  <!-- Grid de 2 columnas-->
                            <ColumnDefinition Width="175"></ColumnDefinition>
                            <ColumnDefinition Width="*"></ColumnDefinition>
                            <!-- La segunda columna se adapta al espacio restante de 625px -->
                        </Grid.ColumnDefinitions>
                        <Button Grid.Column="0">Boton1</Button>
                        <Button Grid.Column="1">Boton2</Button>
                    </Grid> 

                    <!-- TERCERA OPCION: WIDTHs PROPORCIONALES -->
                    <Grid>  
                        <Grid.ColumnDefinitions>  <!-- Grid de 2 columnas-->
                            <ColumnDefinition Width="*"></ColumnDefinition>
                            <ColumnDefinition Width="*"></ColumnDefinition>
                            <!-- Las columnas se reparten el espacio del grid al 50% 
                                 Si ponemos * y 2* col0 25% y col1 75%-->
                        </Grid.ColumnDefinitions>
                        <Button Grid.Column="0">Boton1</Button>
                        <Button Grid.Column="1">Boton2</Button>
                    </Grid> 

                    <!-- CUARTA OPCION: WIDTH PROPORCIONAL vs WIDTH AUTOMATICO -->
                    <Grid>  
                        <Grid.ColumnDefinitions>  <!-- Grid de 2 columnas-->
                            <ColumnDefinition Width="*"></ColumnDefinition>
                            <ColumnDefinition Width="auto"></ColumnDefinition>
                            <!-- La columna1 se adapta al boton que contiene -->
                        </Grid.ColumnDefinitions>
                        <Button Grid.Column="0">Boton1</Button>
                        <Button Grid.Column="1">Boton2</Button>
                    </Grid> 

        Ejemplo: Grid con 4 filas y 4 columnas. 12 botones y un textblock
                 en 0,3. Despues mete dos textblock que ocupen 2 celdas

                    <Grid>
                        <Grid.ColumnDefinitions>  <!-- Grid de 4 columnas-->
                            <ColumnDefinition Width="*"></ColumnDefinition>
                            <ColumnDefinition Width="*"></ColumnDefinition>
                            <ColumnDefinition Width="*"></ColumnDefinition>
                            <ColumnDefinition Width="*"></ColumnDefinition>
                        </Grid.ColumnDefinitions>
                        <Grid.RowDefinitions>  <!-- Grid de 4 filas -->
                            <RowDefinition Height="*"></RowDefinition>
                            <RowDefinition Height="*"></RowDefinition>
                            <RowDefinition Height="*"></RowDefinition>
                            <RowDefinition Height="*"></RowDefinition>
                        </Grid.RowDefinitions>

                        <Button Grid.Column="0" Grid.Row="0">Boton1</Button>
                        <Button Grid.Column="1" Grid.Row="0">Boton2</Button>
                        <Button Grid.Column="2" Grid.Row="0">Boton3</Button>
                        <Button Grid.Column="3" Grid.Row="0">Boton4</Button>
        
                        <Button Grid.Column="0" Grid.Row="1">Boton5</Button>
                        <Button Grid.Column="1" Grid.Row="1">Boton6</Button>
                        <Button Grid.Column="2" Grid.Row="1">Boton7</Button>
                        <Button Grid.Column="3" Grid.Row="1">Boton8</Button>

                        <Button Grid.Column="0" Grid.Row="2">Boton9</Button>
                        <Button Grid.Column="1" Grid.Row="2">Boton10</Button>
                        <Button Grid.Column="2" Grid.Row="2">Boton11</Button>
                        <Button Grid.Column="3" Grid.Row="2">Boton12</Button>

                        <!-- ColumnSpan indica las columnas que ocupa el control-->
                        <!--RowSpan indica las filas que ocupa el control-->
                        <TextBlock Grid.ColumnSpan="2" Grid.Row="3" Background="Beige" HorizontalAlignment="Center" VerticalAlignment="Center" FontSize="26">Juan</TextBlock>
                        <TextBlock Grid.ColumnSpan="2" Grid.Row="3" Grid.Column="2" Background="Beige" HorizontalAlignment="Center" VerticalAlignment="Center" FontSize="26">Pedro</TextBlock>
                        <!--<TextBlock Grid.Column="0" Grid.Row="3" Background="Beige" HorizontalAlignment="Center" VerticalAlignment="Center" FontSize="26">Juan</TextBlock>-->
                    </Grid>


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
using System.Diagnostics;

namespace Wpfvideo076
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
