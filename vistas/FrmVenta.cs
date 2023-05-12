using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ClasesBase;

namespace vistas
{
    public partial class FrmVenta : Form
    {
        public static DataTable dt = TrabajarVenta.list_productos();

        public FrmVenta()
        {
            InitializeComponent();
        }

        private void limpiarFormulario()
        {
            foreach (var ctrl in groupBoxVenta.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox textBox = ctrl as TextBox;
                    //if ((textBox.Name.ToString() != "textBoxBuscarApellido" && textBox.Name.ToString() != "textBoxBuscarNombre"))
                    //{
                        textBox.Clear();
                    //}
                }
            }
        }


        public void load_combo_clientes() {
            comboBoxClientes.DisplayMember = "DniNombreApellido";
            comboBoxClientes.ValueMember = "Cli_DNI";
            comboBoxClientes.DataSource = TrabajarVenta.list_clientes();
        }

        public void load_combo_productos()
        {
            comboBoxProductos.DisplayMember = "CategoriaDescripcion";
            comboBoxProductos.ValueMember = "Prod_Codigo"; //asi es como esta en TrabajarProducto.list_productos
            comboBoxProductos.DataSource = dt;
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            load_combo_clientes();
            load_combo_productos();
            load_detalles();
            limpiarFormulario();
        }

        private void buttonGenerarFactura_Click(object sender, EventArgs e)
        {
            // PARA QUE SE LLENEN TODOS LOS CAMPOS DE INGRESO ANTES DE GUARDAR UN USUARIO
            bool bVacio = false;

            // Buscamos en cada Control de nuestro groupBox.
            foreach (var ctrl in groupBoxVenta.Controls)
            {
                //Preguntamos por cada TextBox de los controles del formulario
                if (ctrl is TextBox)
                {
                    TextBox textBox = ctrl as TextBox;
                    //Si algún TextBox se encontrase vacío la variable auxiliar se vuelve "true"
                    if (textBox.Text == String.Empty)
                    {
                        bVacio = true;
                    }
                }
            }

            if (bVacio == true)
            {
                MessageBox.Show("No se llenaron todos los campos", "Advertencia: Datos No Válidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Venta ventaEncabezado = new Venta();

                ventaEncabezado.Cli_Dni = comboBoxClientes.SelectedValue.ToString();
                ventaEncabezado.Ven_Fecha = Convert.ToDateTime(dateTimePicker1.Text);
                
                TrabajarVenta.insert_venta(ventaEncabezado);

                MessageBox.Show("¡Nro de Factura, fecha y cliente cargados exitosamente!", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);

                limpiarFormulario();

            }
        }

        //-------------------------------------------- VENTA DETALLE -------------------------------------------------

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
                int nroFactura = TrabajarVenta.numero_factura_disponible();
                decimal precio = TrabajarVenta.getPrecio_producto();

                VentaDetalle ventaDetalle = new VentaDetalle();
                ventaDetalle.Ven_Nro = nroFactura;
                ventaDetalle.Prod_Codigo = (string)comboBoxProductos.SelectedValue;
                ventaDetalle.Det_Precio = precio;
                ventaDetalle.Det_Cantidad = Convert.ToDecimal(textBoxCantidad.Text);
                ventaDetalle.Det_Total = TrabajarVenta.calcularTotal(ventaDetalle.Det_Precio, ventaDetalle.Det_Cantidad);

                Console.WriteLine("Nro factura: "+nroFactura);
                Console.WriteLine("Precio: "+precio);
                Console.WriteLine("Codigo producto: " + ventaDetalle.Prod_Codigo);
                
                TrabajarVenta.insert_detalle(ventaDetalle);

                MessageBox.Show("¡Productos cargados exitosamente!", "Factura Detalle", MessageBoxButtons.OK, MessageBoxIcon.Information);

                load_detalles(); limpiarFormulario();
        }

        private void load_detalles()
        {
           
            dataGridViewVenta.DataSource = TrabajarVenta.list_detalles();

        }

        private void comboBoxProductos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int indice = comboBoxProductos.SelectedIndex;
            textBoxPrecio.Text = dt.Rows[indice]["Prod_Precio"].ToString();

            if(textBoxCantidad.Text!=""){
                decimal cantidad_precio = (decimal)dt.Rows[indice]["Prod_Precio"] * Convert.ToDecimal(textBoxCantidad.Text);
                textBoxTotal.Text = cantidad_precio.ToString();

                comprobarTotal();
            }
        }

        private void textBoxCantidad_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCantidad.Text != "")
            {
                int indice = comboBoxProductos.SelectedIndex;
                textBoxPrecio.Text = dt.Rows[indice]["Prod_Precio"].ToString();
                decimal cantidad_precio = (decimal)dt.Rows[indice]["Prod_Precio"] * Convert.ToDecimal(textBoxCantidad.Text);
                textBoxTotal.Text = cantidad_precio.ToString();

                comprobarTotal();
            }
            else {
                textBoxTotal.Text = "";
            }
        }

        private void comprobarTotal()
        {
            if (textBoxTotal.Text == "")
            {
                buttonRegistrar.Enabled = false;
            }
            else
            {
                buttonRegistrar.Enabled = true;
            }
        }

        private void dataGridViewVenta_CurrentCellChanged(object sender, EventArgs e)
        {

            if (dataGridViewVenta.CurrentRow != null)
            {
                comboBoxProductos.SelectedValue = dataGridViewVenta.CurrentRow.Cells["Prod_Codigo"].Value.ToString();
                textBoxCantidad.Text = dataGridViewVenta.CurrentRow.Cells["Cantidad"].Value.ToString();
                buttonRegistrar.Enabled = false;
                buttonModificar.Enabled = true;
                buttonEliminar.Enabled = true;
            }
        
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            VentaDetalle detalle = new VentaDetalle();

            detalle.Det_Nro = Convert.ToInt32(dataGridViewVenta.CurrentRow.Cells["Det_Nro"].Value.ToString()); // de la fila que estoy seleccionando me trae lo que este dentro de Det_Nro, o sea me trae el numero de factura de la fila que estoy seleccionando
            detalle.Prod_Codigo = comboBoxProductos.SelectedValue.ToString();
            detalle.Det_Precio = Convert.ToDecimal(textBoxPrecio.Text);
            detalle.Det_Cantidad = Convert.ToDecimal(textBoxCantidad.Text);
            detalle.Det_Total = Convert.ToDecimal(textBoxTotal.Text);

            Console.WriteLine("Nro detalle: "+ detalle.Det_Nro);
            TrabajarVenta.update_detalle(detalle, detalle.Det_Nro);

            //llamar funcion para que se muestren o se refresquen los datos cargados
            load_detalles();
            dataGridViewVenta.Rows[0].Cells[0].Selected = false;
            limpiarFormulario();

            MessageBox.Show("¡Detalle modificado exitosamente!", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int nroDetalle = Convert.ToInt32(dataGridViewVenta.CurrentRow.Cells["Det_Nro"].Value.ToString()); ;

            DialogResult res = MessageBox.Show("Estas seguro que deseas eliminar este detalle?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (res == DialogResult.Yes)
            {
                Boolean valor = TrabajarVenta.delete_detalle(nroDetalle);
                if (valor == false)
                {
                    MessageBox.Show("No se ha encontrado un detalle con ese número de detalle", "Error en eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    load_detalles();
                    dataGridViewVenta.Rows[0].Cells[0].Selected = false;
                    limpiarFormulario();
                    MessageBox.Show("¡Detalle eliminado exitosamente!", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
    }
}
