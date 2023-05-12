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
    public partial class ListarProductosPorFechas : Form
    {
        public ListarProductosPorFechas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fecha1 = dateTimePicker1.Value;
            DateTime fecha2 = dateTimePicker2.Value;

            dataGridView1.DataSource = TrabajarProducto.listar_productos_por_fechas(fecha1,fecha2);
        }



    }
}
