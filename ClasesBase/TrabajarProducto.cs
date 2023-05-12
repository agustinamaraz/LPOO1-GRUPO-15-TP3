using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarProducto
    {
        public static void insert_producto(Producto producto)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
                                     //nombre de mi tabla: Producto
            cmd.CommandText = "INSERT INTO Producto(Prod_Codigo,Prod_Categoria,Prod_Descripcion,Prod_Precio) values(@codigo,@categoria,@descripcion,@precio)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@codigo", producto.Prod_Codigo);
            cmd.Parameters.AddWithValue("@categoria", producto.Prod_Categoria);
            cmd.Parameters.AddWithValue("@descripcion", producto.Prod_Descripcion);
            cmd.Parameters.AddWithValue("@precio", producto.Prod_Precio);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static Boolean comprobarCodigo(string codigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cnn.Open();
            cmd.CommandText = "SELECT COUNT(*) FROM Producto WHERE Prod_Codigo = @CODIGO;";
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

        public static void update_producto(Producto producto,string codigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
                                            // que cambie todo menos el codigo por eso no lo pongo
            cmd.CommandText = "UPDATE Producto SET Prod_Categoria = @categoria , Prod_Descripcion = @descripcion , Prod_Precio = @precio WHERE Prod_Codigo = @codigo";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@categoria", producto.Prod_Categoria);
            cmd.Parameters.AddWithValue("@descripcion", producto.Prod_Descripcion);
            cmd.Parameters.AddWithValue("@precio", producto.Prod_Precio);
            cmd.Parameters.AddWithValue("@codigo", codigo);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /*public static Boolean delete_producto(string codigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Producto WHERE Prod_Codigo = @codigo";
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

        }*/

        public static string delete_producto(string codigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@Codigo", codigo);

            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT * FROM VentaDetalle WHERE Prod_Codigo = @Codigo";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                return "venta"; //quiere decir que el producto está dentro de un detalle y no se lo puede sacar
            }
            else
            {
                cmd.CommandText = " DELETE FROM Producto WHERE Prod_Codigo = @Codigo";

                //Almacena la cantidad de lineas afectadas por el comando
                int valor = cmd.ExecuteNonQuery();
                //Si se ven afectadas 0 lineas quiere decir que no se encontraron coincidencias
                if (valor == 0)
                { //no existe el codigo
                    return "false";
                }
                else
                {//lo borro correctamente
                    return "true";
                }
            }
        }

        public static DataTable list_productos()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT ";
            cmd.CommandText += " Prod_Categoria as 'Categoria', Prod_Descripcion as 'Descripcion', ";
            cmd.CommandText += " Prod_Precio as 'Precio', ";
            cmd.CommandText += " Prod_Codigo as 'Codigo' ";
            cmd.CommandText += " FROM Producto";
           
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            //Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static DataTable search_producto(string codigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT ";
            cmd.CommandText += " Prod_Categoria as 'Categoria', Prod_Descripcion as 'Descripcion', ";
            cmd.CommandText += " Prod_Precio as 'Precio', ";
            cmd.CommandText += " Prod_Codigo as 'Codigo' ";
            cmd.CommandText += " FROM Producto";
            cmd.CommandText += " WHERE ";
            cmd.CommandText += " Prod_Codigo = @codigo ";

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

        //---------------------------------------------- CON STORED PROCEDURES/TP3 -------------------------------------
        public static DataTable exec_list_productos_x_categoria_sp()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "listar_productos_x_categoria_sp";
            //cmd.CommandText = "listar_productos_x_categoria_sp2";
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Connection = cnn;

            //Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public static DataTable exec_list_productos_x_descripcion_sp()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "listar_productos_x_descripcion_sp";
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

        public static void exec_insert_producto_sp(Producto producto)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            
            cmd.CommandText = "insertar_producto_sp";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@codigo", producto.Prod_Codigo);
            cmd.Parameters.AddWithValue("@categoria", producto.Prod_Categoria.ToString());
            cmd.Parameters.AddWithValue("@descripcion", producto.Prod_Descripcion.ToString());
            cmd.Parameters.AddWithValue("@precio", producto.Prod_Precio);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void exec_update_producto_sp(Producto producto, string codigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "actualizar_producto_sp";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@categoria", producto.Prod_Categoria);
            cmd.Parameters.AddWithValue("@descripcion", producto.Prod_Descripcion);
            cmd.Parameters.AddWithValue("@precio", producto.Prod_Precio);
            cmd.Parameters.AddWithValue("@codigo", codigo);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static string exec_delete_producto_sp(string codigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@Codigo", codigo);

            DataTable dt = new DataTable();
            cmd.CommandText = "consultar_producto_en_ventadetalle_sp";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                return "venta"; //quiere decir que el producto está dentro de un detalle y no se lo puede sacar
            }
            else
            {
                cmd.CommandText = "eliminar_producto_sp";
                cmd.CommandType = CommandType.StoredProcedure;

                //Almacena la cantidad de lineas afectadas por el comando
                int valor = cmd.ExecuteNonQuery();
                //Si se ven afectadas 0 lineas quiere decir que no se encontraron coincidencias
                if (valor == 0)
                { //no existe el codigo
                    return "false";
                }
                else
                {//lo borro correctamente
                    return "true";
                }
            }
        }

        public static DataTable listar_productos_por_fechas(DateTime f1, DateTime f2){
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "listar_productos_x_fechas_sp";
            
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@fecha1", f1);
            cmd.Parameters.AddWithValue("@fecha2", f2);

            

            //Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}
