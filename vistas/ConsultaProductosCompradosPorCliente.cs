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
    public partial class ConsultaProductosCompradosPorCliente : Form
    {
        public ConsultaProductosCompradosPorCliente()
        {
            InitializeComponent();
        }

        private void ConsultaProductosCompradosPorCliente_Load(object sender, EventArgs e)
        {
            load_combo_clientes();
        }

        public void load_combo_clientes()
        {
            comboBox1.DisplayMember = "DniNombreApellido";
            comboBox1.ValueMember = "Cli_DNI";
            comboBox1.DataSource = TrabajarVenta.list_clientes();
        }

        private void buttonActualizar_Click_1(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Cli_Dni = comboBox1.SelectedValue.ToString();
            dataGridView1.DataSource = TrabajarVenta.exec_list_productos_x_cliente(cliente.Cli_Dni);
        }

    }
}
