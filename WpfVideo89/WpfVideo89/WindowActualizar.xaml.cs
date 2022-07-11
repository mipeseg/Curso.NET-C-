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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WpfVideo89
{
    /// <summary>
    /// Lógica de interacción para WindowActualizar.xaml
    /// </summary>
    public partial class WindowActualizar : Window
    {
        // PROPIEDADES O CAMPOS DE CLASE

        private SqlConnection miConexionSql;  // definimos una conexion a una BBDD
        private int idCliente;  // es el idCliente que se le pasa a un objeto de clase WindowActualizar

        public WindowActualizar(int id)
        {
            InitializeComponent();

            this.idCliente = id;

            // creamos la cadena de conexion con las tablas articulo, clientes y pedidos
            string cadConexion = ConfigurationManager.ConnectionStrings["WpfVideo89.Properties.Settings.GestionPedidosConnectionString"].ConnectionString;

            miConexionSql = new SqlConnection(cadConexion);  // creamos la conexion con la BDD
        }

        // METODOS SETTER AND GETTER
        public int getIdCliente()
        {
            return this.idCliente;
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            //MainWindow ventanaPrincipal = new MainWindow();
            //ventanaPrincipal.buttonActualizarCliente.IsEnabled = true;
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxNombre.Text.Length > 0)
            {
                try
                {


                    // creamos una consulta con un parametro
                    string consultaSQL = "UPDATE clientes SET nombre=@nom WHERE Id=" + this.idCliente;

                    SqlCommand sqlComando = new SqlCommand(consultaSQL, miConexionSql); // permite hacer una consulta SQL con parametro

                    // abrimos la conexion con BBDD
                    miConexionSql.Open();

                    // indicamos cual es el parametro y que la info viene de un TextBox
                    sqlComando.Parameters.AddWithValue("@nom", textBoxNombre.Text);

                    sqlComando.ExecuteNonQuery(); // ejecutamos la consulta SQL

                    miConexionSql.Close(); // cerramos la conexion con la BBDD 

                    //MainWindow.nombreClientes();  // refrescamos el listBox lbClientes


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Excepcion: {ex.Message}");
                }
                finally
                {
                    miConexionSql.Close(); // cerramos la conexion con la BBDD 
                    this.Close(); // cierre esta ventana
                }
            }
            else
                MessageBox.Show($"Introduzca un nombre de cliente"); 
        }
    }
}
