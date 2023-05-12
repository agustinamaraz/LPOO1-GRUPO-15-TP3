using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarCliente
    {

        //sera usado para el combobox de obra social, lista desplegable
        public static DataTable list_Os_Cuit()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM ObraSocial";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            //Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static void insert_cliente(Cliente cliente)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Cliente(Cli_DNI,Cli_Apellido,Cli_Nombre,Cli_Direccion,OS_CUIT,Cli_NroCarnet) values(@dni,@apellido,@nombre,@direccion,@os_cuit,@nro_carnet)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@dni", cliente.Cli_Dni);
            cmd.Parameters.AddWithValue("@apellido", cliente.Cli_Apellido);
            cmd.Parameters.AddWithValue("@nombre", cliente.Cli_Nombre);
            cmd.Parameters.AddWithValue("@direccion", cliente.Cli_Direccion);
            cmd.Parameters.AddWithValue("@os_cuit", cliente.Os_Cuit);
            cmd.Parameters.AddWithValue("@nro_carnet", cliente.Cli_NroCarnet);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static Boolean comprobarDNI(string dni) {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cnn.Open();
            cmd.CommandText = "SELECT COUNT(*) FROM Cliente WHERE Cli_DNI = @DNI;";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@DNI", dni);
            Int32 valor = Convert.ToInt32( cmd.ExecuteScalar());

            if (valor == 0) // o sea que no hay ningun cliente con ese dni
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void update_cliente(Cliente cliente, string dni)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Cliente SET Cli_Apellido = @apellido , Cli_Nombre = @nombre , Cli_Direccion = @direccion , OS_CUIT = @os_cuit, Cli_NroCarnet = @nro_carnet WHERE Cli_DNI = @DNI";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@DNI", dni);
            cmd.Parameters.AddWithValue("@apellido", cliente.Cli_Apellido);
            cmd.Parameters.AddWithValue("@nombre", cliente.Cli_Nombre);
            cmd.Parameters.AddWithValue("@direccion", cliente.Cli_Direccion);
            cmd.Parameters.AddWithValue("@os_cuit", cliente.Os_Cuit);
            cmd.Parameters.AddWithValue("@nro_carnet", cliente.Cli_NroCarnet);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static int delete_cliente(string dni)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Cliente WHERE Cli_DNI = @dni";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@dni", dni);

            cnn.Open();

            int valor = cmd.ExecuteNonQuery();//ejecuta una instrucción Transact-Sql contra la conexión y devuelve el número de filas afectadas
            cnn.Close();

            return valor;

        }

        //sera usado para mostrarse el datagridviewclientes
        public static DataTable list_clientes()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT ";
            cmd.CommandText += " OS_RazonSocial as 'Razon_Social', ";
            cmd.CommandText += " Cli_Apellido as 'Apellido', Cli_Nombre as 'Nombre', ";
            cmd.CommandText += " Cli_Direccion as 'Direccion', Cli_NroCarnet as 'NroCarnet', ";
            cmd.CommandText += " Cli_DNI, C.OS_CUIT ";
            cmd.CommandText += " FROM Cliente as C";
            cmd.CommandText += " LEFT JOIN ObraSocial as O ON (O.OS_CUIT=C.OS_CUIT)";
            //ObraSocial se llama mi tabla
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            //Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static DataTable search_cliente(string nombre,string apellido)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT";
            cmd.CommandText += " OS_RazonSocial as 'Razon_Social', ";
            cmd.CommandText += " Cli_Apellido as 'Apellido', Cli_Nombre as 'Nombre', ";
            cmd.CommandText += " Cli_Direccion as 'Direccion', Cli_NroCarnet as 'NroCarnet', ";
            cmd.CommandText += " Cli_DNI, C.OS_CUIT ";
            cmd.CommandText += " FROM Cliente as C";
            cmd.CommandText += " LEFT JOIN ObraSocial as O ON (O.OS_CUIT=C.OS_CUIT)";

            cmd.CommandText += " WHERE ";
            cmd.CommandText += " Cli_Nombre LIKE @nombre AND Cli_Apellido LIKE @apellido";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
            cmd.Parameters.AddWithValue("@apellido", "%" + apellido + "%");

            //Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;

        }


       
        public static DataTable listar_clientes_x_apellido()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "listar_clientes_x_apellido_sp";
            //cmd.CommandText = "listar_clientes_x_apellido";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Connection = cnn;

            //Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

    }
}
