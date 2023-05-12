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
    public partial class ConsultaVentaPorCliente : Form
    {
        public ConsultaVentaPorCliente()
        {
            InitializeComponent();
        }

        private void ConsultaVentaPorCliente_Load(object sender, EventArgs e)
        {
            load_combo_clientes();
        }

        public void load_combo_clientes()
        {
            comboBox1.DisplayMember = "DniNombreApellido";
            comboBox1.ValueMember = "Cli_DNI";
            comboBox1.DataSource = TrabajarVenta.list_clientes();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Cli_Dni = comboBox1.SelectedValue.ToString();
            dataGridView1.DataSource = TrabajarVenta.exec_list_ventas_x_cliente(cliente.Cli_Dni);
        }



    }
}
