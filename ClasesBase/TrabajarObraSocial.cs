using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarObraSocial
    {
        public static void insert_obrasocial(ObraSocial obrasocial)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            //nombre de mi tabla: Producto
            cmd.CommandText = "INSERT INTO ObraSocial(OS_CUIT,OS_RazonSocial,OS_Direccion,OS_Telefono) values(@cuit,@razon,@direccion,@telefono)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@cuit", obrasocial.Os_Cuit);
            cmd.Parameters.AddWithValue("@razon", obrasocial.Os_RazonSocial);
            cmd.Parameters.AddWithValue("@direccion", obrasocial.Os_Direccion);
            cmd.Parameters.AddWithValue("@telefono", obrasocial.Os_Telefono);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static Boolean comprobarCuit(string codigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cnn.Open();
            cmd.CommandText = "SELECT COUNT(*) FROM ObraSocial WHERE OS_CUIT = @CODIGO;";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@CODIGO", codigo);
            Int32 valor = Convert.ToInt32(cmd.ExecuteScalar());

            if (valor == 0) // o sea que no hay ningun producto con ese codigo
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void update_obrasocial(ObraSocial obra, string cuit)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            // que cambie todo menos el codigo por eso no lo pongo
            cmd.CommandText = "UPDATE ObraSocial SET OS_RazonSocial = @razon , OS_Direccion = @direccion , OS_Telefono = @telefono WHERE OS_CUIT = @codigo";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@razon", obra.Os_RazonSocial);
            cmd.Parameters.AddWithValue("@direccion", obra.Os_Direccion);
            cmd.Parameters.AddWithValue("@telefono", obra.Os_Telefono);
            cmd.Parameters.AddWithValue("@codigo", cuit);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static DataTable list_obras()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT ";
            cmd.CommandText += " OS_RazonSocial as 'Razon_Social', OS_Direccion as 'Direccion', ";
            cmd.CommandText += " OS_Telefono as 'Telefono', ";
            cmd.CommandText += " OS_CUIT ";
            cmd.CommandText += " FROM ObraSocial";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            //Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static Boolean delete_obra(string codigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM ObraSocial WHERE OS_CUIT = @codigo";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@codigo", codigo);

            cnn.Open();
            int valor = cmd.ExecuteNonQuery();
            cnn.Close();

            if (valor == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public static DataTable search_obra(string codigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT ";
            cmd.CommandText += " OS_RazonSocial as 'Razon_Social', OS_Direccion as 'Direccion', ";
            cmd.CommandText += " OS_Telefono as 'Telefono', ";
            cmd.CommandText += " OS_CUIT ";
            cmd.CommandText += " FROM ObraSocial";
            cmd.CommandText += " WHERE ";
            cmd.CommandText += " OS_CUIT = @codigo ";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@codigo", codigo);

            //Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;

        }

    }
}
