#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2EF756D84010875ADB9413D9968A768993367A3A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WpfVideo084;


namespace WpfVideo084 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbCapitales;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chbTodasC;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chbMadrid;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chbBogota;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chbLima;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chbMexicoDF;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chbSantiago;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chbBuenosAires;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfVideo084;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cbCapitales = ((System.Windows.Controls.ComboBox)(target));
            
            #line 15 "..\..\..\MainWindow.xaml"
            this.cbCapitales.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbCapitales_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.chbTodasC = ((System.Windows.Controls.CheckBox)(target));
            
            #line 30 "..\..\..\MainWindow.xaml"
            this.chbTodasC.Checked += new System.Windows.RoutedEventHandler(this.chbTodasC_Checked);
            
            #line default
            #line hidden
            
            #line 30 "..\..\..\MainWindow.xaml"
            this.chbTodasC.Unchecked += new System.Windows.RoutedEventHandler(this.chbTodasC_Unchecked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.chbMadrid = ((System.Windows.Controls.CheckBox)(target));
            
            #line 32 "..\..\..\MainWindow.xaml"
            this.chbMadrid.Checked += new System.Windows.RoutedEventHandler(this.individual_checked);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\MainWindow.xaml"
            this.chbMadrid.Unchecked += new System.Windows.RoutedEventHandler(this.individual_noChecked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.chbBogota = ((System.Windows.Controls.CheckBox)(target));
            
            #line 33 "..\..\..\MainWindow.xaml"
            this.chbBogota.Checked += new System.Windows.RoutedEventHandler(this.individual_checked);
            
            #line default
            #line hidden
            
            #line 33 "..\..\..\MainWindow.xaml"
            this.chbBogota.Unchecked += new System.Windows.RoutedEventHandler(this.individual_noChecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.chbLima = ((System.Windows.Controls.CheckBox)(target));
            
            #line 34 "..\..\..\MainWindow.xaml"
            this.chbLima.Checked += new System.Windows.RoutedEventHandler(this.individual_checked);
            
            #line default
            #line hidden
            
            #line 34 "..\..\..\MainWindow.xaml"
            this.chbLima.Unchecked += new System.Windows.RoutedEventHandler(this.individual_noChecked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.chbMexicoDF = ((System.Windows.Controls.CheckBox)(target));
            
            #line 35 "..\..\..\MainWindow.xaml"
            this.chbMexicoDF.Checked += new System.Windows.RoutedEventHandler(this.individual_checked);
            
            #line default
            #line hidden
            
            #line 35 "..\..\..\MainWindow.xaml"
            this.chbMexicoDF.Unchecked += new System.Windows.RoutedEventHandler(this.individual_noChecked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.chbSantiago = ((System.Windows.Controls.CheckBox)(target));
            
            #line 36 "..\..\..\MainWindow.xaml"
            this.chbSantiago.Checked += new System.Windows.RoutedEventHandler(this.individual_checked);
            
            #line default
            #line hidden
            
            #line 36 "..\..\..\MainWindow.xaml"
            this.chbSantiago.Unchecked += new System.Windows.RoutedEventHandler(this.individual_noChecked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.chbBuenosAires = ((System.Windows.Controls.CheckBox)(target));
            
            #line 37 "..\..\..\MainWindow.xaml"
            this.chbBuenosAires.Checked += new System.Windows.RoutedEventHandler(this.individual_checked);
            
            #line default
            #line hidden
            
            #line 37 "..\..\..\MainWindow.xaml"
            this.chbBuenosAires.Unchecked += new System.Windows.RoutedEventHandler(this.individual_noChecked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

