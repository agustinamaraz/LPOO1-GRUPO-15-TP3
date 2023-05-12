using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarVenta
    {

        //-------------------------------- VENTA ENCABEZADO ----------------------------------------

        public static void insert_venta(Venta venta)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Venta(Ven_Fecha,Cli_DNI) values(@fecha,@cliente)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@fecha", venta.Ven_Fecha);
            cmd.Parameters.AddWithValue("@cliente", venta.Cli_Dni);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static DataTable list_clientes()
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT *,(Cli_DNI+', '+Cli_Nombre+' '+Cli_apellido) AS DniNombreApellido FROM Cliente";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;

        }
        public static DataTable list_productos()
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * ,(Prod_Categoria+', '+Prod_Descripcion) AS CategoriaDescripcion FROM Producto";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;

        }

        public static DataTable exec_list_ventas_x_cliente(string dni)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "consultar_ventas_x_cliente_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@DNI", dni);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            return dt;
        }

        public static DataTable exec_list_productos_x_cliente(string dni)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listar_productos_x_cliente_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@DNI", dni);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            return dt;
        }

        //-------------------------------- VENTA DETALLE ----------------------------------------

        public static int numero_factura_disponible() {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT MAX(Ven_Nro) FROM Venta";
            cmd.CommandType = CommandType.Text;
            cnn.Open();
            int numeroFactura = Convert.ToInt32(cmd.ExecuteScalar());
            cnn.Close();

            return numeroFactura;
        }

        public static decimal getPrecio_producto()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT Prod_Precio FROM Producto";
            cmd.CommandType = CommandType.Text;
            cnn.Open();
            decimal precio = Convert.ToInt32(cmd.ExecuteScalar());
            cnn.Close();

            return precio;
        }

        public static decimal calcularTotal(decimal precio, decimal cantidad) {
            return precio * cantidad;
        }

        public static void insert_detalle(VentaDetalle detalle)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
           
            cmd.CommandText = "INSERT INTO VentaDetalle(Ven_Nro,Prod_Codigo,Det_Precio,Det_Cantidad,Det_Total) values(@factura,@producto,@precio,@cantidad,@total)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@factura", detalle.Ven_Nro);
            cmd.Parameters.AddWithValue("@producto", detalle.Prod_Codigo);
            cmd.Parameters.AddWithValue("@precio", detalle.Det_Precio);
            cmd.Parameters.AddWithValue("@cantidad", detalle.Det_Cantidad);
            cmd.Parameters.AddWithValue("@total", detalle.Det_Total);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }

        public static DataTable list_detalles()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT ";
            cmd.CommandText += " Cli_DNI as 'Cliente_DNI', ";
            cmd.CommandText += " Prod_Descripcion as 'Descripcion', ";
            cmd.CommandText += " Det_Precio as 'Precio', Det_Cantidad as 'Cantidad', ";
            cmd.CommandText += " Det_Total as 'Total', Det_Nro, VD.Prod_Codigo, VD.Ven_Nro as 'Nro_Factura'";
            cmd.CommandText += " FROM VentaDetalle as VD";
            cmd.CommandText += " INNER JOIN Producto as P ON (P.Prod_Codigo=VD.Prod_Codigo)";
            cmd.CommandText += " INNER JOIN Venta as V ON (VD.Ven_Nro=V.Ven_Nro)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            //Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static void update_detalle(VentaDetalle detalle, int nrodetalle)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE VentaDetalle SET Prod_Codigo = @codigo, Det_Precio = @precio, Det_Cantidad = @cantidad, Det_Total = @total WHERE Det_Nro = @detallenumero";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@detallenumero", nrodetalle);
            cmd.Parameters.AddWithValue("@codigo", detalle.Prod_Codigo);
            cmd.Parameters.AddWithValue("@precio", detalle.Det_Precio);
            cmd.Parameters.AddWithValue("@cantidad", detalle.Det_Cantidad);
            cmd.Parameters.AddWithValue("@total", detalle.Det_Total);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static Boolean delete_detalle(int nroDetalle)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM VentaDetalle WHERE Det_Nro = @numero";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@numero", nroDetalle);

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

        //-------------------------------- LISTADO VENTAS ----------------------------------------

        public static DataTable list_ventas()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Venta";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            //Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        //------------------- STORED PROCEDURES-----------------------
        public static DataTable listar_ventas_por_fechas(DateTime fecha1, DateTime fecha2)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.opticaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "listar_ventas_x_fechas_sp";
            
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@fecha1", fecha1);
            cmd.Parameters.AddWithValue("@fecha2", fecha2);

            

            //Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}
