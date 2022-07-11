/*
    Fuente: video77, video78
    // TODO: Estamos empezando el video

    DEPENDENCY PROPERTIES (DP)

        El sistema de propiedades de WPF es un cjto de servicios que amplian
        la funcionalidad de las propiedades. 

        Las DP son propiedades que dependen del sistema de propiedades de WPF
        para su completo funcionamiento

        Cualquier control WPF que incluimos en nuestro proyecto (ej: Button)
        tiene propiedades. Pues estas propiedades,para extender su funcionalidad,
        dependen del Sist.propiedades WPF
        
                Control WPF
                    prop1
                    prop2   ----dependencia----->  Sistema de propiedades WPF
                    ....

        A tener en cuenta:
            1) Al usar propiedades -> no nos preocupa. Esto ocurre de forma
               transparente al usuario
            2) Cuando definamos propiedades de usuario. Si que tenemos que
               registrarlas en el sistema de propiedades (Ya lo veremos)

        Ej)

    DEPENDENCY PROPERTIES DE USUARIO
    
        Vamos a ver como crear una DP. https://docs.microsoft.com/es-es/dotnet/desktop/wpf/properties/how-to-implement-a-dependency-property?view=netdesktop-6.0


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

namespace WpfVideo077
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int miProperty  // creamos la propiedad
        {
            get { return (int)GetValue(miDependencyProperty); }
            set { SetValue(miDependencyProperty, value); }
        }

        // registramos la propiedad en el sistema de propiedades WPF
        public static readonly DependencyProperty miDependencyProperty =
            DependencyProperty.Register("miProperty", typeof(int),
                 typeof(MainWindow), new PropertyMetadata(0));


        public MainWindow()
        {
            InitializeComponent();
            Button miBoton;

            /* si hacemos dobleclick sobre una clase, pej Button, se subraya.
               Si pulsamos F12 se abre la definicion, donde vemos codigo
               de las propiedades y metodos:
             
                namespace System.Windows.Controls
                {
                    public class Button : ButtonBase
                    {
                        public static readonly DependencyProperty IsCancelProperty;
                        public static readonly DependencyProperty IsDefaultedProperty;
                        public static readonly DependencyProperty IsDefaultProperty;

                        public Button();

                        public bool IsCancel { get; set; }
                        public bool IsDefault { get; set; }
                        public bool IsDefaulted { get; }

                        protected override void OnClick();
                        protected override AutomationPeer OnCreateAutomationPeer();
                    }
                }

                Observamos que las propiedades IsCancel, IsDefault y IsDefaulted
                necesitan para funcionar las dependency propierties 
                DependencyProperty, DependencyProperty y DependencyProperty
                de solo lectura para que no se puedan modificar.
             */

        }
    }
}
