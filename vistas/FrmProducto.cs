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
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void limpiarFormulario()
        {
            foreach (var ctrl in groupBoxProductos.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox textBox = ctrl as TextBox;
                    if ((textBox.Name.ToString() != "textBoxBuscarCodigo"))
                    {
                        textBox.Clear();
                    }
                }
            }
        }

        private void load_productos()
        {

            dataGridViewProductos.DataSource = TrabajarProducto.list_productos();
        }

        private void buttonCargar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            string codigo = textBoxCodigo.Text;
            Boolean codigoUnico = TrabajarProducto.comprobarCodigo(codigo);

            if (codigoUnico == true)
            {
                producto.Prod_Codigo = textBoxCodigo.Text;
                producto.Prod_Categoria = textBoxCategoria.Text;
                producto.Prod_Descripcion = textBoxDescripcion.Text;
                producto.Prod_Precio = Convert.ToDecimal(textBoxPrecio.Text);

                //TrabajarProducto.insert_producto(producto);
                TrabajarProducto.exec_insert_producto_sp(producto);

                MessageBox.Show("¡Producto guardado correctamente!","Producto");

                //llamar funcion para que se muestren o se refresquen los datos cargados
                load_productos();
                limpiarFormulario();
            }
            else {
                MessageBox.Show("Se ingreso un codigo ya existente", "Error");
            }

            
        }

        private void dataGridViewProductos_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridViewProductos.CurrentRow != null)
            {
                textBoxCodigo.Text = dataGridViewProductos.CurrentRow.Cells["Codigo"].Value.ToString();
                textBoxCategoria.Text = dataGridViewProductos.CurrentRow.Cells["Categoria"].Value.ToString();
                textBoxDescripcion.Text = dataGridViewProductos.CurrentRow.Cells["Descripcion"].Value.ToString();
                textBoxPrecio.Text = dataGridViewProductos.CurrentRow.Cells["Precio"].Value.ToString();
            }
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            load_productos();
            limpiarFormulario();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();

            producto.Prod_Codigo = textBoxCodigo.Text;
            producto.Prod_Categoria = textBoxCategoria.Text;
            producto.Prod_Descripcion = textBoxDescripcion.Text;
            producto.Prod_Precio = Convert.ToDecimal(textBoxPrecio.Text);

            //TrabajarProducto.update_producto(producto, producto.Prod_Codigo);
            TrabajarProducto.exec_update_producto_sp(producto,producto.Prod_Codigo);


            //llamar funcion para que se muestren o se refresquen los datos cargados
            load_productos();
            dataGridViewProductos.Rows[0].Cells[0].Selected = false;
            limpiarFormulario();

            MessageBox.Show("¡Producto modificado exitosamente!", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            string codigo = textBoxCodigo.Text;

            DialogResult res = MessageBox.Show("Estas seguro que deseas eliminar este Producto?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (res == DialogResult.Yes)
            {
                //string valor = TrabajarProducto.delete_producto(codigo);
                string valor = TrabajarProducto.exec_delete_producto_sp(codigo);
                if (valor == "false")
                {
                    MessageBox.Show("No se ha encontrado un producto con ese codigo", "Error en eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if(valor =="true")
                {
                    load_productos();
                    dataGridViewProductos.Rows[0].Cells[0].Selected = false;
                    limpiarFormulario();
                    MessageBox.Show("¡Producto eliminado exitosamente!", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }else if(valor=="venta"){
                    MessageBox.Show("No se puede eliminar este producto, ya que existen facturas que lo poseen", "Eliminacion fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (textBoxBuscarCodigo.Text != "")
            {
                
                dataGridViewProductos.DataSource = TrabajarProducto.search_producto(textBoxBuscarCodigo.Text);
            }
            else
            {
                load_productos();

            }
            limpiarFormulario();
        }



    }
}
