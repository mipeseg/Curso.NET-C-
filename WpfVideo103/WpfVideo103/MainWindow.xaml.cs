/*
    Fuente: video103, video104, video105, video106, video107
    // TODO: Estamos en el video

    CREAR LAS TABLAS Y EL ORIGEN DE DATOS

        Vamos a una aplicacion WPF que maneje una BD con cuatro tablas relacionadas:

                    Empresa ----> Empleados
                                     |
                                     |--> CargoEmpleados <--- Cargos

        Veamos los pasos a realizar:

            1. Creamos una DataGrid (dataGridPrincipal) en la MainWindow
            2. Vamos a "explorador de servidores" y nos conectamos a desktop-h2l8a0s\sqlservermps.GestionPedidos.dbo
            3. Ahora creamos en la carpeta "Tablas" las tablas Empleados, Empresas, CargoEmpleados y Cargos

                        CREATE TABLE [dbo].[Empresas]
                            (
	                            [id] INT NOT NULL PRIMARY KEY IDENTITY, 
                                [nombre] NVARCHAR(50) NULL,                    
                            )

                        CREATE TABLE [dbo].[Empleados]    
                            (
	                            [id] INT NOT NULL PRIMARY KEY IDENTITY, 
                                [nombre] NVARCHAR(50) NOT NULL, 
                                [apellidos] NVARCHAR(50) NOT NULL, 
                                [idEmpresa] INT NOT NULL, 
                                CONSTRAINT [idEmpresaFK] FOREIGN KEY ([idEmpresa]) REFERENCES [dbo].[Empresas]([id]) ON DELETE CASCADE
                            )

                        CREATE TABLE [dbo].[Cargos]
                        (
	                        [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
                            [nombre] NVARCHAR(50) NOT NULL
                        )

                        CREATE TABLE [dbo].[CargoEmpleados]
                        (
	                        [id] INT NOT NULL PRIMARY KEY IDENTITY, 
                            [idEmpleado] INT NOT NULL, 
                            [idCargo] INT NOT NULL, 
                            CONSTRAINT [idEmpleadoFK] FOREIGN KEY ([idEmpleado]) REFERENCES [dbo].[Empleados]([id]) ON DELETE CASCADE, 
                            CONSTRAINT [idCargoFK] FOREIGN KEY ([idCargo]) REFERENCES [dbo].[Cargos]([id]) ON DELETE CASCADE
                        )

            4. Creamos el origen de datos en la pestana "origenes de datos". Recordemos:

                      CrudLinqSQLConnectionString --> cadena de conexion

                           Data Source=DESKTOP-H2L8A0S\SQLSERVERMPS;Initial Catalog=GestionPedidos;
                                       Persist Security Info=True;User ID=sa;Password=6023miguelillo

                      CrudLinqSQLDataSet --> DataSet
                        CargoEmpleados
                        Cargos
                        Empleados
                        Empresas
                            

            5. Activamos la herramientas LINQ SQL, ya que por defecto estan desactivamos
               Vamos al instalador de visual studio. El proceso esta en video103 - 16:53
               Hay que "modificar/componentes individuales/herramientas de codigo/Herramientas LINQ to SQL"

    INSERTAR REGISTROS EN LA BBDD CON LINQ y SQL

        // boton derecho en Referencias/agregar referencia --> clickamos el check "System.Configuration"
        // despues anadimos using System.Configuration;
        string cadenaConexion = ConfigurationManager.ConnectionStrings
                                ["WpfVideo103.Properties.Settings.CrudLinqSQLConnectionString"].
                                ConnectionString;

        Agregamos en el proyecto boton derecho "nuevo elemento/clases de link to SQL". Se crea un fichero
        DataClasses1.dbml. Esto es un ORM o mapeador de nuestra base de datos

        Ahora vamos a Explorador de Servidores. Pinchamos las tablas y la arrastramos al fichero 
        DataClasses1.dbml. Esto nos permitira tratar a las tablas como objeto. Ej:

            // miEmpresa es un objeto que representa a la tabla Empresas que hemos anadido a DataClasses1
            Empresas miEmpresa = new Empresas();

     BORRAR TODO EL CONTENIDO DE UNA TABLA

        dataContext.ExecuteCommand("delete from Empresas");

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
using System.Configuration;
using System.Data;


namespace WpfVideo103
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Creamos la cadena de conexion
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["WpfVideo103.Properties.Settings.CrudLinqSQLConnectionString"].ConnectionString;

        // Definimos el mapeador ORM de la DDBB
        private DataClasses1DataContext dataContext;

        public MainWindow()
        {
            InitializeComponent();
            
            // creamos el mapeador ORM de la DDBB
            dataContext = new DataClasses1DataContext(cadenaConexion);

            // indicamos al DataGrid que cargue los datos del origen de los datos 
            dataGridEmpresas.ItemsSource = dataContext.Empresas;

            // indicamos al DataGrid que cargue los datos del origen de los datos 
            dataGridEmpleados.ItemsSource = dataContext.Empleados;

            // indicamos al DataGrid cual es el origen de los datos 
            dataGridCargos.ItemsSource = dataContext.Cargos;

            // indicamos al DataGrid cual es el origen de los datos 
            dataGridCargoEmpleados.ItemsSource = dataContext.CargoEmpleados;
        }

        private void btnInsertarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            if (txtbInsertar.Text.Length > 0)
            {
                // creamos el mapeador ORM de la DDBB
                dataContext = new DataClasses1DataContext(cadenaConexion);

                Empresas miEmpresa = new Empresas();    // miEmpresa es un registro que se anadira a la tabla Empresas que hemos anadido a DataClasses1
                miEmpresa.nombre = txtbInsertar.Text;  // damos un valor al campo nombre del registro miEmpresa
                dataContext.Empresas.InsertOnSubmit(miEmpresa); // El mapeador ORM dataContext inserta el registro miEmpresa en la tabla Empresas

                dataContext.SubmitChanges(); //El mapeador ORM guarda cambios  IMPORTANTE
                                             //dataGridEmpresas.ItemsSource = dataContext.Empresas; // indicamos al DataGrid cual es el origen de los datos 
                txtbInsertar.Clear(); // borramos el texto insertado

                // indicamos al DataGrid cual es el origen de los datos 
                dataGridEmpresas.ItemsSource = dataContext.Empresas;
            }
            else
                MessageBox.Show("Introduce un nombre de Empresa", "Atencion");
        }

        private void btnInsertarEmple_Click(object sender, RoutedEventArgs e)
        {
            if (txtbInsertarNomEmple.Text.Length > 0)
            {
                // creamos el mapeador ORM de la DDBB
                dataContext = new DataClasses1DataContext(cadenaConexion);


                Empleados miEmpleado = new Empleados();    // miEmpleado es un registro que se anadira a la tabla Empleados del DataClasses1
                miEmpleado.nombre = txtbInsertarNomEmple.Text;  // damos un valor al campo nombre
                miEmpleado.apellidos = txtbInsertarApeEmple.Text;  // damos un valor al campo apellidos
                
                // comprueba si la empresa existe

                try
                {
                    Empresas miEmpre = dataContext.Empresas.First(em => em.id.Equals(int.Parse(txtbInsertarIDEmpresa.Text))); // guarda la primera empresa que encuentre con el id que buscamos
                    miEmpleado.idEmpresa = miEmpre.id;  // Asignamos al empleado el id de la empresa encontrada

                    dataContext.Empleados.InsertOnSubmit(miEmpleado); // El mapeador ORM dataContext inserta el registro miEmpleado en la tabla Empleados

                    dataContext.SubmitChanges(); //El mapeador ORM guarda cambios  IMPORTANTE

                    txtbInsertarNomEmple.Clear();  // borramos los textBox
                    txtbInsertarApeEmple.Clear();
                    txtbInsertarIDEmpresa.Clear();

                    // indicamos al DataGrid cual es el origen de los datos 
                    dataGridEmpleados.ItemsSource = dataContext.Empleados;
                }
                catch(Exception ex)
                {
                    if (ex.HResult == -2146233079) MessageBox.Show("La empresa no existe");
                }
            }
            else
                MessageBox.Show("Introduce un nombre de Empleado", "Atencion");
        }

        private void btnInsertarCargo_Click(object sender, RoutedEventArgs e)
        {
            if (txtbInsertarCargo.Text.Length > 0)
            {
                // creamos el mapeador ORM de la DDBB
                dataContext = new DataClasses1DataContext(cadenaConexion);

                Cargos miCargo = new Cargos();    // miCargo es un registro que se anadira a la tabla Cargos que hemos anadido a DataClasses1
                miCargo.nombre = txtbInsertarCargo.Text;  // damos un valor al campo nombre del registro miCargo
                dataContext.Cargos.InsertOnSubmit(miCargo); // El mapeador ORM dataContext inserta el registro miCargo en la tabla Cargos

                dataContext.SubmitChanges(); //El mapeador ORM guarda cambios  IMPORTANTE
                txtbInsertarCargo.Clear(); // borramos el texto insertado

                // indicamos al DataGrid cual es el origen de los datos 
                dataGridCargos.ItemsSource = dataContext.Cargos;
            }
            else
                MessageBox.Show("Introduce un cargo", "Atencion");
        }

        private void btnInsertarCargoEmpleado_Click(object sender, RoutedEventArgs e)
        {
            if (txtbInsertarIdEmple.Text.Length > 0 && txtbInsertarIdCargo.Text.Length > 0)
            {
                // creamos el mapeador ORM de la DDBB
                dataContext = new DataClasses1DataContext(cadenaConexion);


                CargoEmpleados miCargoEmple = new CargoEmpleados();    // miCargoEmple es un registro que se anadira a la tabla CargoEmpleados del DataClasses1
                miCargoEmple.idEmpleado = int.Parse(txtbInsertarIdEmple.Text);  // damos un valor al campo idEmpleado
               
                // comprueba si el empleado existe
                try
                {
                    Empleados miEmple = dataContext.Empleados.First(emple => emple.id.Equals(int.Parse(txtbInsertarIdEmple.Text))); // guarda el primer empleado que encuentre con el id que buscamos
                    miCargoEmple.idEmpleado = miEmple.id;  // Asignamos al cargo del empleado el id encontrado

                    //dataContext.CargoEmpleados.InsertOnSubmit(miCargoEmple); // El mapeador ORM dataContext inserta el registro miCargoEmple en la tabla CargoEmpleados

                    //dataContext.SubmitChanges(); //El mapeador ORM guarda cambios  IMPORTANTE

                    //txtbInsertarIdEmple.Clear();  // borramos los textBox
                    //txtbInsertarIdCargo.Clear();

                    // indicamos al DataGrid cual es el origen de los datos 
                    //dataGridCargoEmpleados.ItemsSource = dataContext.CargoEmpleados;
                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2146233079) MessageBox.Show("El empleado no existe");
                }

                // comprueba si el cargo existe
                try
                {
                    Cargos miCargo = dataContext.Cargos.First(car => car.id.Equals(int.Parse(txtbInsertarIdCargo.Text))); // guarda el primer cargo que encuentre con el id que buscamos
                    miCargoEmple.idCargo = miCargo.id;  // Asignamos al cargo del empleado el id encontrado

                    dataContext.CargoEmpleados.InsertOnSubmit(miCargoEmple); // El mapeador ORM dataContext inserta el registro miCargoEmple en la tabla CargoEmpleados

                    dataContext.SubmitChanges(); //El mapeador ORM guarda cambios  IMPORTANTE

                    txtbInsertarIdEmple.Clear();  // borramos los textBox
                    txtbInsertarIdCargo.Clear();

                    // indicamos al DataGrid cual es el origen de los datos 
                    dataGridCargoEmpleados.ItemsSource = dataContext.CargoEmpleados;
                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2146233079) MessageBox.Show("El cargo no existe");
                }
            }
            else
                MessageBox.Show("Falta el cargo o el empleado", "Atencion");
        }

        private void dataGridEmpresas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Empresas emp = (Empresas)dataGridEmpresas.SelectedItem; //obtenemos el objeto actual seleccionado
            txtbInsertar.Text = emp.nombre;
            lblEmpresaTemp.Content = emp.nombre;
        }

        private void btnUpdateEmpresa_Click(object sender, RoutedEventArgs e)
        {
            if (txtbInsertar.Text.Length > 0)
            {
                Empresas miEmpre = dataContext.Empresas.First(em => em.nombre.Equals(lblEmpresaTemp.Content)); // guarda la primera empresa que encuentre con el nombre que buscamos
                miEmpre.nombre = txtbInsertar.Text;  // Asignamos el valor del textbox al campo nombre

                dataContext.SubmitChanges(); //El mapeador ORM guarda cambios  IMPORTANTE

                txtbInsertar.Clear();  // borramos los textBox
               
                // indicamos al DataGrid cual es el origen de los datos 
                dataGridEmpresas.ItemsSource = dataContext.Empresas;
            }
            else
                MessageBox.Show("Introduce un nombre de Empresa", "Atencion");
        }

        private void btnDeleteEmpresa_Click(object sender, RoutedEventArgs e)
        {
            Empresas emp = (Empresas)dataGridEmpresas.SelectedItem; //obtenemos el objeto actual seleccionado en el grid

            dataContext.Empresas.DeleteOnSubmit(emp); // objeto que queremos borrar de la tabla

            dataContext.SubmitChanges(); //El mapeador ORM guarda cambios  IMPORTANTE

            // indicamos al DataGrid cual es el origen de los datos para que refresque
           dataGridEmpresas.ItemsSource = dataContext.Empresas;
        }
    }
}
