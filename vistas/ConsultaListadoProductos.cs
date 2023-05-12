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
    public partial class ConsultaListadoProductos : Form
    {
        public ConsultaListadoProductos()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewProductos.DataSource = TrabajarProducto.exec_list_productos_x_categoria_sp();
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            dataGridViewProductos.DataSource = TrabajarProducto.exec_list_productos_x_descripcion_sp();
        }
    }
}
