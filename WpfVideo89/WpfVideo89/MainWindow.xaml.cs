/*  
    Fuente: video89, video90, video91, video92, video93, video94, video95, video96, video97, video98,
            video99

    // TODO: Estamos al comienzo el video
 
    CREAR NUEVO ORIGEN DE DATOS (DATASET)

        Hasta ahora hemos creado un servidor SQL, hemos conectado con el desde Visual Studio y
        creado la BBDD GestionPedidos.dbo con la tabla articulo y anadido registros. 
        Sin embargo, queda lo mas importante. 

        Crearemos un proyecto WPF (OJO .NET framework 4.8. *** NO .NET 6). El motivo es que la
        pestana origen de datos solo funciona con .NET framwork 4.8

        Pestana Origen de datos/ agregar y nos sale el siguiente asistente:
            - Tipo de origen de datos: Base de datos
            - tipo de modelo de base de datos: conjuntos de datos
            - Conexion de datos: desktop-h2l8a0s\sqlservermps.GestionPedidos.dbo
                NOTA: Un proyecto puede usar distintas conexiones de datos
              Pulsamos incluir contrasena en la "cadena de conexion". Como es un proyecto local
              no pasa nada
            - Guardar cadena de conexion en el archivo de configuracion de la aplicacion?
              SI.  Cadena de conexion = "GestionPedidosConnectionString"
            - Conecta con la base de datos gracias a la cadena de conexion. Elegir los objetos de la BBDD
              que vamos a usar en esta aplicacion. Elegimos la tabla articulos, clientes y pedidos
            - Finalizar
            - Si nos fijamos nos ha anadido el origen de datos GestionPedidosDataSet. Con el boton derecho
              "Editar Dataset con el disenador" por si hay que hacer cambios visuales en las tablas

    CREAR CADENA DE CONEXION
    
        Para que el proyecto conecte con el DataSet creado, hay que implementar la cadena de conexion

         string cadConexion = ConfigurationManager.
         ConnectionStrings["WpfVideo89.Properties.Settings.GestionPedidosConnectionString"].ConnectionString;

                NOTA: si no reconoce la clase ConfigurationManager hay que importarla. Nos vamos a la solucion
                      buscamos la carpeta "referencias" y boton derecho "agregar referencia". Activamos
                      el check de System.Configuration y aceptamos. Despues incluimos la instruccion:

                                using System.Configuration;

    RELACIONES ENTRE TABLAS

        Para que dos tablas se relacionen es necesario que la clave principal de una, sea clave secundaria
        o foranea en la otra. Ej:

            CLIENTES                      PEDIDOS
            PK cod_cliente                PK num_pedido
                1 |________________> INF  FK cod_cliente

            Para hacer la clave foranea marcammos el campo pedidos.cod_cliente y pulsamos a la 
            derecha "Claves externas" boton derecho "agregar clave externa". Esto genera:

                CREATE TABLE [dbo].[pedidos] (
                    [idPedido]    INT           IDENTITY (1, 1) NOT NULL,
                    [idCliente]   INT           NOT NULL,
                    [fechaPedido] DATETIME      NULL,
                    [formaPago]   NVARCHAR (50) NULL,
                    PRIMARY KEY CLUSTERED ([idPedido] ASC),
                    CONSTRAINT [FK_pedidos_ToTable] FOREIGN KEY ([idCliente]) REFERENCES [dbo].[clientes] ([Id])
                );
                // despues ponemos el nombre de la FK q es idCliente y a que PK referencia [dbo].[clientes]([Id])

    RELLENAR TABLAS CON REGISTROS Y REALIZAR CONSULTAS SQL 

        Primero rellenamos las tablas de datos. Para ello seleccionamos la tabla en el explorador de servidores,
        boton derecho y click en "Mostrar datos de tabla".

        Ahora probamos con sentiencias SQL si somos capaces de recuperar informacion de la BBDD. Boton
        derecho sobre la base de datos "desktop-h2l8a0s\sqlservermps.GestionPedidos.dbo" y "Nueva Consulta".
        Se abre una consola de SQL y podemos probar con algunas instrucciones SQL de seleccion de registros:

            SELECT * FROM clientes                                -> muestra todos los clientes
            SELECT * FROM clientes  WHERE poblacion = 'Madrid'    -> muestra los clientes de Madrid
            SELECT * FROM clientes   --> muestra info de todos los clientes y todos los pedidos que han hecho
	            INNER JOIN pedidos ON clientes.Id = pedidos.idCliente

            SELECT * FROM clientes   --> muestra aquellos clientes de Madrid que han hecho pedidos
	            INNER JOIN pedidos ON clientes.Id = pedidos.idCliente
            WHERE clientes.poblacion = "Madrid"

        Asi q de momento funciona todo OK
                
    MOSTRAR DATOS DE UNA BD SQL Server EN UNA APLICACION WPF  

        Vamos a tratar de transladar la info de la tabla clientes a una aplicacion WPF. Anadimos un ListBox
        donde queremos que se cargue el campo "clientes.nombre"

        Es recomendable que revisemos estos manuales:
        
            SqlConecction Clase -> https://docs.microsoft.com/es-es/dotnet/api/system.data.sqlclient.sqlconnection?view=dotnet-plat-ext-6.0
                                   using System.Data.SqlClient;

            SqlDataAdapter Clase -> https://docs.microsoft.com/es-es/dotnet/api/system.data.sqlclient.sqldataadapter?view=dotnet-plat-ext-6.0
                                    using System.Data;
             
            SqlCommand.Parameters Propiedad -> https://docs.microsoft.com/es-es/dotnet/api/system.data.sqlclient.sqlcommand.parameters?view=dotnet-plat-ext-6.0
                                    using System.Data.SqlClient;

        Pasos a seguir:

            1. Creamos la cadena de conexion con las tablas articulo, clientes y pedidos

                    string cadConexion = ConfigurationManager.ConnectionStrings["WpfVideo89.Properties.Settings.GestionPedidosConnectionString"].ConnectionString;
       
            2. Creamos la conexion con la BBDD

                    miConexionSql = new SqlConnection(cadConexion);  // creamos la conexion con la BDD

            3. Monstamos la consulta SQL

                    string consultaSQL = "SELECT * FROM CLIENTES";

            4. Los registros resultantes de la consulta han de almacenarse en un 
               DataTable o en un DataSet (RecordSet en otros lenguajes) para que no se pierdan

        echar un vitazo a los metodos:

            - nombreClientes()

                Carga todos los clientes.nombre en el listbox lbClientes. Cuando hacemos click
                en el nombre de un cliente se invoca el metodo lbClientes_SelectionChanged()
                y este llama a infoPedidos()

            - infoPedidos()

                Carga los pedidos.fechaPedido en el ListBox lbClientes, del cliente seleccionado
                en el ListBox lbClientes

    MOSTRAR TODOS LOS CAMPOS DE UNA TABLA EN UN LISTBOX  ( CONSULTA SQL CON CAMPO CALCULADO)

        Agregamos un ListBox lbPedidosTotal que al cargar la aplicacion muestre todos los pedidos. 
        Necesitamos crear una consulta de campo nuevo calculado, ya que queremos mostrar
        en el ListBox la info de 3 campos. Ver el metodo pedidosAll()

    BORRAR REGISTROS DE UNA TABLA

        Elegiremos un pedido del ListBox lbPedidosTotal y pulsaremos el boton Borrar para
        eliminar ese registro de la tabla pedidos

    INSERTAR REGISTROS DE UNA TABLA
       
        Agregar un nuevo cliente a la tabla clientes

    ACTUALIZAR REGISTROS DE UNA TABLA

        Al clickar un cliente del ListBox lbClientes y pulsar el boton actualizar,
        se abre otro formulario donde nos permite hacer cambios en el nombre y guardarlo
 
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
using System.Data.SqlClient;


namespace WpfVideo89
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // PROPIEDADES O CAMPOS DE CLASE

        private SqlConnection miConexionSql;  // definimos una conexion a una BBDD

        private void nombreClientes()
        {
            try
            {
                string consultaSQL = "SELECT * FROM CLIENTES";  // creamos la consulta

                // hacemos la consulta a la BDD
                SqlDataAdapter adaptadorSql = new SqlDataAdapter(consultaSQL, miConexionSql);


                using (adaptadorSql)
                {
                    DataTable dtClientes = new DataTable();  // creamos el objeto DataTable

                    adaptadorSql.Fill(dtClientes);  // rellenamos el objeto DataTable

                    lbClientes.ItemsSource = dtClientes.DefaultView; // indicamos al ListBox el origen de los datos   
                    lbClientes.DisplayMemberPath = "nombre";  // mostramos en el ListBox solo la info de clientes.nombre
                    lbClientes.SelectedValuePath = "Id";  // campo clave de la tabla clientes
                }
            }
            catch(Exception e)
            {
                MessageBox.Show($"Excepcion: {e.Message}");
            }     
        }

        private void pedidosAll()
        {
            try 
            {
                // creamos la consulta con el campo calculado infoCompleta, que es una concatenacion de los campos
                // idCliente, fechaPedido y formaPago. Y ademas decimos que se incluyan el resto de campos pq
                // lo necesitamos para cuando queramos borrar un registro

                string consultaSQL = "SELECT *, CONCAT(idPedido, '-', idCliente, '-', fechaPedido, '-', formaPago) AS infoCompleta FROM pedidos ";

                // hacemos la consulta a la BDD
                SqlDataAdapter adaptadorSql = new SqlDataAdapter(consultaSQL, miConexionSql);


                using (adaptadorSql)
                {
                    DataTable dtPedidos = new DataTable();  // creamos el objeto DataTable

                    adaptadorSql.Fill(dtPedidos);  // rellenamos el objeto DataTable

                    lbPedidosTotal.ItemsSource = dtPedidos.DefaultView; // indicamos al ListBox el origen de los datos
                    lbPedidosTotal.DisplayMemberPath = "infoCompleta";  // mostramos en el ListBox solo la info de pedidos.fechaPedido
                    lbPedidosTotal.SelectedValuePath = "idPedido";  // campo clave de la tabla pedidos
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Excepcion: {e.Message}");
            }     
        }

        private void infoPedidos()
        {
            try
            {
                // creamos la consulta SQL con parametro
                string consultaSQL = "SELECT * FROM pedidos P INNER JOIN clientes C ON C.ID = P.IDCLIENTE WHERE C.ID=@clienteId";

                //MessageBox.Show(consultaSQL);

                SqlCommand sqlComando = new SqlCommand(consultaSQL, miConexionSql); // permite hacer una consulta SQL con parametro

                // hacemos la consulta a la BBDD
                SqlDataAdapter adaptadorSql = new SqlDataAdapter(sqlComando);

                using (adaptadorSql)
                {
                    // indicamos cual es el parametro y de donde viene
                    sqlComando.Parameters.AddWithValue("@clienteId", lbClientes.SelectedValue);

                    DataTable dtPedidos = new DataTable();  // creamos el objeto DataTable

                    adaptadorSql.Fill(dtPedidos);  // rellenamos el objeto DataTable

                    lbPedidos.ItemsSource = dtPedidos.DefaultView; // indicamos al ListBox el origen de los datos
                    lbPedidos.DisplayMemberPath = "fechaPedido";  // mostramos en el ListBox solo la info de pedidos.fechaPedido
                    lbPedidos.SelectedValuePath = "idPedido";  // campo clave de la tabla Pedidos
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Excepcion: {e.Message}");
            }   
        }

        public MainWindow()
        {
            InitializeComponent();
            
            // creamos la cadena de conexion con las tablas articulo, clientes y pedidos
            string cadConexion = ConfigurationManager.ConnectionStrings["WpfVideo89.Properties.Settings.GestionPedidosConnectionString"].ConnectionString;

            miConexionSql = new SqlConnection(cadConexion);  // creamos la conexion con la BDD

            nombreClientes();  // muestra en el ListBox los nombres de todos los clientes

            pedidosAll(); // carga todos los pedidos.fechaPedido en el ListBox lbPedidosTotal

        }

        private void lbClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //infoPedidos();
        }

        // Borrar pedido seleccionado en lbPedidosTotal
        private void buttonBorrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // MessageBox.Show(lbPedidosTotal.SelectedValue.ToString());  //  muestra el valor del campo idPedido, ya que lbPedidos.SelectedValuePath = "idPedido"; 

                // creamos una consulta con un parametro
                string consultaSQL = "DELETE FROM pedidos WHERE idPedido = @PEDIDO_ID";

                SqlCommand sqlComando = new SqlCommand(consultaSQL, miConexionSql); // permite hacer una consulta SQL con parametro

                // abrimos la conexion con BBDD
                miConexionSql.Open();

                // indicamos cual es el parametro y de donde viene la info
                sqlComando.Parameters.AddWithValue("@PEDIDO_ID", lbPedidosTotal.SelectedValue);

                sqlComando.ExecuteNonQuery(); // ejecutamos la consulta SQL

                miConexionSql.Close(); // cerramos la conexion con la BBDD 

                pedidosAll();  // refrescamos el listBox lbPedidosTotal     
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepcion: {ex.Message}");
            }  
        }

        private void buttonAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(textBoxNombreCliente.Text.Length > 0)
                {
                    // MessageBox.Show(lbPedidosTotal.SelectedValue.ToString());  //  muestra el valor del campo idPedido, ya que lbPedidos.SelectedValuePath = "idPedido"; 

                    // creamos una consulta con un parametro
                    string consultaSQL = "INSERT INTO clientes (nombre) VALUES (@NOMBRE)";

                    SqlCommand sqlComando = new SqlCommand(consultaSQL, miConexionSql); // permite hacer una consulta SQL con parametro

                    // abrimos la conexion con BBDD
                    miConexionSql.Open();

                    // indicamos cual es el parametro y que la info viene de un TextBox
                    sqlComando.Parameters.AddWithValue("@NOMBRE", textBoxNombreCliente.Text);

                    sqlComando.ExecuteNonQuery(); // ejecutamos la consulta SQL

                    miConexionSql.Close(); // cerramos la conexion con la BBDD 

                    textBoxNombreCliente.Clear();

                    nombreClientes();  // refrescamos el listBox lbClientes
                }
                else
                    MessageBox.Show($"Introduzca un nombre de cliente");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepcion: {ex.Message}");
            }
        }

        private void buttonBorrarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // MessageBox.Show(lbPedidosTotal.SelectedValue.ToString());  //  muestra el valor del campo idPedido, ya que lbPedidos.SelectedValuePath = "idPedido"; 

                // creamos una consulta con un parametro
                string consultaSQL = "DELETE FROM clientes WHERE Id = @CLI_ID";

                SqlCommand sqlComando = new SqlCommand(consultaSQL, miConexionSql); // permite hacer una consulta SQL con parametro

                // abrimos la conexion con BBDD
                miConexionSql.Open();

                //MessageBox.Show(lbClientes.SelectedValue.ToString());

                // indicamos cual es el parametro y de donde viene la info
                sqlComando.Parameters.AddWithValue("@CLI_ID", lbClientes.SelectedValue);

                sqlComando.ExecuteNonQuery(); // ejecutamos la consulta SQL

                miConexionSql.Close(); // cerramos la conexion con la BBDD 

                nombreClientes();  // refrescamos el listBox lbClientes  
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepcion: {ex.Message}");
            }
            finally
            {
                miConexionSql.Close(); // cerramos la conexion con la BBDD 
            }
        }

        private void lbClientes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            infoPedidos();
        }

        private void buttonActualizarCliente_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                string consultaSQL = "SELECT nombre FROM CLIENTES WHERE Id = @CLI_ID";  // escribimos el codigo SQL de la consulta

                SqlCommand sqlComando = new SqlCommand(consultaSQL, miConexionSql); // creamos la consulta SQL con parametro

                // ejecutamos la consulta a la DDBB
                SqlDataAdapter adaptadorSql = new SqlDataAdapter(sqlComando);

                using (adaptadorSql)
                {
                    // rescatamos el Id del cliente que hemos seleccionado en lbClientes
                    // y se lo pasamos al parametro @CLI_ID
                    sqlComando.Parameters.AddWithValue("@CLI_ID",lbClientes.SelectedValue);
                    
                    // Creamos un DataTable o tabla virtual

                    DataTable dtClientes = new DataTable();

                    // Rellenamos el DataTable con los registros obtenidos de la consulta SQL

                    adaptadorSql.Fill(dtClientes);

                    // Creamos el objeto ventaUpdate y le pasamos el id del cliente seleccionado
                    // despues abrir la ventana actualizar de forma modal con showDialog. Esto
                    // significa dos cosas:
                    //  - la ventana actualizar siempre estara en primer plano hasta que la cerremos
                    //  - el flujo de ejecucion se detiene en esta instruccion y permanece en
                    // standby hasta que el usuario cierre la ventana actualizar

                    WindowActualizar ventanaUpdate = new WindowActualizar((int)lbClientes.SelectedValue);

                    // obtengo el nombre del cliente seleccionado y lo almaceno en el TextBox
                    // de la ventanaUpdate
                    ventanaUpdate.textBoxNombre.Text = dtClientes.Rows[0]["nombre"].ToString();

                    ventanaUpdate.ShowDialog();  // abre la ventanaActualizar en modo modal

                    nombreClientes(); // refresca el lbClientes
                }
            }
            catch (Exception ex)
            {
                if(ex.HResult == -2146232060)
                    MessageBox.Show($"No ha seleccionado ningun cliente");
                else
                    MessageBox.Show($"Excepcion: {ex.Message}");
            }
        }
    }
}
