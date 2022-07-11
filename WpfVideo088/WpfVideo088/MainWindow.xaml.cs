/*
    Fuente: video
    // TODO: Estamos al principio del video88

    INSTALACION Y CONFIGURACION DE SQL Server
        
        Descargamos SQL Server 2019 Developer gratuitamente desde este enlace https://www.microsoft.com/es-es/sql-server/sql-server-downloads
        Veamos el proceso de instalacion:
            - tipo de instalacion: Personalizado
            - Especificar la ubicacion: C:\SQL2019   Pulsamos instalar   (ocupa 1,5 GB)
            - ventana Centro de instalacion de SQLServer
                - Clickamos la pestana de Instalacion
                - Elegimos la opcion "nueva instalacion indep de SQL Server / Agregar caracteristicas a una
                  instalacion existente"
                - Clave de producto -> especificamops que es la version gratuita Developer. Inicia un
                  proceso que tardara 
                - Ventana "instalar reglas". Pulsamos siguiente
                        V    Validacion de las claves del registro de SQL Server  Correcto
                        V    Controlador de Dominio del equipo   Correcto
                        !    Firewall de windows   Advertencia
                        V    SQL 2019 CTP minimo para actualizacion...   Correcto
                - Seleccion de caracteristicas:
                    Servicio de motor de base de datos   (pulsamos siguiente)
                - Configuracion de instancia
                    instancia con nombre: SQLserverMPS  (siguiente)
                - config. del servidor
                            Agente SQL server     Manual
                            Motor de base de...   Auto
                            SQL Server browser    Deshabilitado
                - Configuracion del motor de BBDD
                    Modo mixto (autenticacion SQLserver y Windows) -> escribimos una constrasena 6023miguelillo
                - Listo para instalar (tardara)
                - operacion completa (muestra el estado de todo los procesos instalados)
                ....
                - instalar las herramientas de administracion de SQL server (pulsamos)
                - nos lleva a un enlace donde descargar SQL Server Management Studio 18.12.1 (SSMS)
                    NOTA: busquemos la version espanol
                - Comienza el proceso de instalacion de SSMS 18.12.1 (dejamos la ruta default)
                - instalacion completa

                - Abrimos SSMS
                    - tipo de servidor: Motor de base de datos
                    - Nombre de servidor: DESKTOP-H2L8A0S\SQLSERVERMPS
                    - autenticacion: autenticacion de SQL server
                          inicio de sesion: sa
                          password: 6023miguelillo
                   - Si todo a ido bien el servidor SQL server estara corriendo
            
                - Ahora abrimos Visual Studio y continuamos sin codigo
                - menu Ventana/explorador de servidores
                                Azure
                                Conexiones de datos --> boton derecho / agregar conexion
                                    origen de datos: Microsoft SQL Server (sql client)
                                    nombre del servidor: copiamos el nombre del servidor de SSMS (video 88 16:22)
                                    autenticacion: autenticacion SQL server
                                       user: sa   pass: 6023miguelillo
                                    selecciona o crear base de datos: GestionPedidos
                                    Aceptamos (si todo va bien crea la BD y la conexion de datos)

                                    NOTA: Puede salir algun mensaje en Visual Studio que diga que necesita
                                          instalar paquetes. Le decimos que ok.

                                Servidores
                                    DESKTOP-H2L8A0S\SQLSERVERMPS

                  - Si volvemos a SSMS y vemos conexiones de datos deberiamos ver algo asi:

                            conexiones de datos
                                laptop87538947593\pildorasSQL.GestionPedidos.dbo
                                    Tablas --> agregar nueva tabla
                                    Vistas
                                    Procedimiento almacenados
                                    Funciones
                                    Sinonimos
                                    Tipos
                                    Ensamblados
    
    CREACION DE UNA TABLA

        Tablas/Agregar nueva tabla. Abre el disenador grafico de tablas y vemos todos sus campos

                        Nombre     tipo de datos    Permitir valores NULL  predeterminado
              (clave)   id         int              NO                                      --> para hacerlo autoincrental. Propiedades especificacion de identidad True. Es una identidad True  incremento de identidad 1 valor inicial 1
                        seccion    nvarchar(50)     SI
 
        En la pestana T-SQL vemos el SQL de la tabla que estamos creando:
            CREATE TABLE [dbo].articulo  --> le llamamos articulo
               {
                    [id] INT NOT NULL PRIMARY KEY IDENTITY,
                    [seccion] NVARCHAR(50) NULL
               }
        Para guardar cambios pulsar ACTUALIZAR encima del disenador visual de la tabla.
        Actualizar base de datos

     CRUD  -> Vamos a realizar operaciones de Create,Update, Delete de registros en nuestra BBDD

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

namespace WpfVideo088
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
