using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarUsuario
    {
        public static DataTable list_roles()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Rol";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            //Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static void insert_usuario(Usuario user)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Usuario(rol_id,usr_apellido,usr_nombre,usr_username,usr_password,usr_email) values(@rol,@apellido,@nombre,@usuario,@password,@email)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@rol", user.Rol_Id);
            cmd.Parameters.AddWithValue("@apellido", user.Usr_Apellido);
            cmd.Parameters.AddWithValue("@nombre", user.Usr_Nombre);
            cmd.Parameters.AddWithValue("@usuario", user.Usr_UserName);
            cmd.Parameters.AddWithValue("@password", user.Usr_Password);
            cmd.Parameters.AddWithValue("@email", user.Usr_Email);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }


        public static void update_usuario(Usuario user, string username)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Usuario SET rol_id = @rol, usr_apellido = @apellido , usr_nombre = @nombre , usr_password = @password , usr_email = @email WHERE usr_username = @usuario";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@rol", user.Rol_Id);
            cmd.Parameters.AddWithValue("@apellido", user.Usr_Apellido);
            cmd.Parameters.AddWithValue("@nombre", user.Usr_Nombre);
            cmd.Parameters.AddWithValue("@usuario", username);
            cmd.Parameters.AddWithValue("@password", user.Usr_Password);
            cmd.Parameters.AddWithValue("@email", user.Usr_Email);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static Boolean delete_usuario(string username)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Usuario WHERE usr_username = @usuario";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@usuario", username);

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

        public static DataTable list_usuarios()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            /*cmd.CommandText = "SELECT ";
            cmd.CommandText += " rol_descripcion as 'Rol', ";
            cmd.CommandText += " usr_apellido as 'Apellido', usr_nombre as 'Nombre', ";
            cmd.CommandText += " usr_username as 'Usuario', usr_password as 'Contraseña', ";
            cmd.CommandText += " usr_email as 'Email', usr_id, U.rol_id ";
            cmd.CommandText += " FROM Usuario as U";
            cmd.CommandText += " LEFT JOIN Rol as R ON (R.rol_id=U.rol_id)";
             cmd.CommandType = CommandType.Text;*/

            cmd.CommandText = "listar_usuarios_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            
            
            cmd.Connection = cnn;

            //Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static DataTable search_usuarios(string sPattern)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT";
            cmd.CommandText += " rol_descripcion as 'Rol', ";
            cmd.CommandText += " usr_apellido as 'Apellido', usr_nombre as 'Nombre', ";
            cmd.CommandText += " usr_username as 'Usuario', usr_password as 'Contraseña', ";
            cmd.CommandText += " usr_email as 'Email', usr_id, U.rol_id ";
            cmd.CommandText += " FROM Usuario as U";
            cmd.CommandText += " LEFT JOIN Rol as R ON (R.rol_id=U.rol_id)";

            cmd.CommandText += " WHERE ";
            cmd.CommandText += " usr_username LIKE @pattern ";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@pattern", "%" + sPattern + "%");

            //Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;

        }

        //---------------------------------------------- CON STORED PROCEDURES/TP3 -------------------------------------
        public static DataTable exec_list_usuarios_sp()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
         
            cmd.CommandText = "listar_usuarios_sp";
            //cmd.CommandText = "vw_listar_usuarios";
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
