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
    public partial class ConsultaListadoCliente : Form
    {
        public ConsultaListadoCliente()
        {
            InitializeComponent();
        }

        private void ConsultaListadoCliente_Load(object sender, EventArgs e)
        {
            list_clientes_por_apellido();
        }

        private void list_clientes_por_apellido() {
            dataGridViewClientes.DataSource = TrabajarCliente.listar_clientes_x_apellido();
        }

    }
}
