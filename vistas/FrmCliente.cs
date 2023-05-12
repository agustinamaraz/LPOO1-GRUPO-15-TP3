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
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void limpiarFormulario()
        {
            foreach (var ctrl in groupBoxCliente.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox textBox = ctrl as TextBox;
                    if ((textBox.Name.ToString() != "textBoxBuscarApellido" && textBox.Name.ToString() != "textBoxBuscarNombre"))
                    {
                        textBox.Clear();
                    }
                }
            }
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            load_combo_os();
            load_clientes();
            dataGridViewClientes.Rows[0].Cells[0].Selected = false;
            limpiarFormulario();
        }

        public void load_combo_os()
        {
            comboBoxClienteOSCUIT.DisplayMember = "OS_RazonSocial";
            comboBoxClienteOSCUIT.ValueMember = "OS_CUIT";
            comboBoxClienteOSCUIT.DataSource = TrabajarCliente.list_Os_Cuit();
        }

        private void load_clientes()
        {
            
            dataGridViewClientes.DataSource = TrabajarCliente.list_clientes();
        }

        private void buttonGuardarCliente_Click(object sender, EventArgs e)
        {
            Cliente oCliente = new Cliente();
            string dni = textBoxDNI.Text;
            Boolean dniUnico = TrabajarCliente.comprobarDNI(dni);

            if (dniUnico == true)
            {
                oCliente.Os_Cuit = comboBoxClienteOSCUIT.SelectedValue.ToString();
                oCliente.Cli_Apellido = textBoxClienteApellido.Text;
                oCliente.Cli_Nombre = textBoxClienteNombre.Text;
                oCliente.Cli_Direccion = textBoxClienteDireccion.Text;
                oCliente.Cli_Dni = textBoxDNI.Text; //aca podria poner dni
                oCliente.Cli_NroCarnet = textBoxClienteNroCarnet.Text;

                TrabajarCliente.insert_cliente(oCliente);
                MessageBox.Show("Cliente agregado Satisfactoriamente","Carga Exitosa");
                //llamar funcion para que se muestren o se refresquen los datos cargados
                load_clientes();
                limpiarFormulario();
            }
            else
            {
                MessageBox.Show("Se ingreso un Dni ya existente", "Error");
            }
                
        }

        private void buttonModificarCliente_Click(object sender, EventArgs e)
        {
            Cliente oCliente = new Cliente();

            oCliente.Cli_Dni = textBoxDNI.Text;
            oCliente.Cli_Apellido = textBoxClienteApellido.Text;
            oCliente.Cli_Nombre = textBoxClienteNombre.Text;
            oCliente.Os_Cuit = comboBoxClienteOSCUIT.SelectedValue.ToString();
            oCliente.Cli_Direccion = textBoxClienteDireccion.Text;
            oCliente.Cli_NroCarnet = textBoxClienteNroCarnet.Text;

            TrabajarCliente.update_cliente(oCliente, oCliente.Cli_Dni);

            //llamar funcion para que se muestren o se refresquen los datos cargados
            load_clientes();
            dataGridViewClientes.Rows[0].Cells[0].Selected = false;
            limpiarFormulario();

            MessageBox.Show("¡Cliente modificado exitosamente!", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridViewClientes_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridViewClientes.CurrentRow != null)
            {
                textBoxDNI.Text = dataGridViewClientes.CurrentRow.Cells["Cli_DNI"].Value.ToString();
                textBoxClienteApellido.Text = dataGridViewClientes.CurrentRow.Cells["Apellido"].Value.ToString();
                textBoxClienteNombre.Text = dataGridViewClientes.CurrentRow.Cells["Nombre"].Value.ToString();
                textBoxClienteDireccion.Text = dataGridViewClientes.CurrentRow.Cells["Direccion"].Value.ToString();
                comboBoxClienteOSCUIT.Text = dataGridViewClientes.CurrentRow.Cells["OS_CUIT"].Value.ToString();
                textBoxClienteNroCarnet.Text = dataGridViewClientes.CurrentRow.Cells["NroCarnet"].Value.ToString();
            }
        }

        private void buttonEliminarCliente_Click(object sender, EventArgs e)
        {
            string dni = textBoxDNI.Text;

            DialogResult res = MessageBox.Show("Estas seguro que deseas eliminar este cliente?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (res == DialogResult.Yes)
            {
                int valor = TrabajarCliente.delete_cliente(dni);
                if (valor == 0)
                {
                    MessageBox.Show("No se ha encontrado un cliente con ese dni", "Error en eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    load_clientes();
                    dataGridViewClientes.Rows[0].Cells[0].Selected = false;
                    limpiarFormulario();
                    MessageBox.Show("¡Cliente eliminado exitosamente!", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void buttonBuscarCliente_Click(object sender, EventArgs e)
        {
            string apellido = textBoxBuscarApellido.Text;
            string nombre = textBoxBuscarNombre.Text;

            if (apellido != "" && nombre != "")
            {
                dataGridViewClientes.DataSource = TrabajarCliente.search_cliente(nombre,apellido);
            }
            else
            {
                load_clientes();

            }

            limpiarFormulario();
        }
       

    }
}
