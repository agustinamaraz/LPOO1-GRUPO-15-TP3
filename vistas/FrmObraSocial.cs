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
    public partial class FrmObraSocial : Form
    {
        public FrmObraSocial()
        {
            InitializeComponent();
        }

        private void limpiarFormulario()
        {
            //dataGridViewUsuarios.Rows[0].Cells[0].Selected = false;
            foreach (var ctrl in groupBox1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox textBox = ctrl as TextBox;
                    if ((textBox.Name.ToString() != "textBoxBuscar"))
                    {
                        textBox.Clear();
                    }
                }
            }
        }

        private void FrmObraSocial_Load(object sender, EventArgs e)
        {
            load_obras();
            dataGridView1.Rows[0].Cells[0].Selected = false;
            limpiarFormulario();
        }

        private void load_obras()
        {
            dataGridView1.DataSource = TrabajarObraSocial.list_obras();

        }

        

        private void buttonCargar_Click(object sender, EventArgs e)
        {
            ObraSocial o = new ObraSocial();
            string codigo = textBoxCUIT.Text;
            Boolean codigoUnico = TrabajarObraSocial.comprobarCuit(codigo);

            if (codigoUnico == true)
            {
                o.Os_Cuit = textBoxCUIT.Text;
                o.Os_RazonSocial = textBoxRazon.Text;
                o.Os_Direccion = textBoxDireccion.Text;
                o.Os_Telefono = textBoxTelefono.Text;

                TrabajarObraSocial.insert_obrasocial(o);

                //llamar funcion para que se muestren o se refresquen los datos cargados
                load_obras();
                limpiarFormulario();
            }
            else
            {
                MessageBox.Show("Se ingreso un cuit ya existente", "Error");
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            ObraSocial o = new ObraSocial();

            o.Os_Cuit = textBoxCUIT.Text;
            o.Os_RazonSocial = textBoxRazon.Text;
            o.Os_Direccion = textBoxDireccion.Text;
            o.Os_Telefono = textBoxTelefono.Text;

            TrabajarObraSocial.update_obrasocial(o, o.Os_Cuit);

            //llamar funcion para que se muestren o se refresquen los datos cargados
            load_obras();
            dataGridView1.Rows[0].Cells[0].Selected = false;
            limpiarFormulario();

            MessageBox.Show("¡Obra social modificada exitosamente!", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            string codigo = textBoxCUIT.Text;

            DialogResult res = MessageBox.Show("Estas seguro que deseas eliminar este Obra social?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (res == DialogResult.Yes)
            {
                Boolean valor = TrabajarObraSocial.delete_obra(codigo);
                if (valor == false)
                {
                    MessageBox.Show("No se ha encontrado una obra con ese cuit", "Error en eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (valor == true)
                {
                    load_obras();
                    dataGridView1.Rows[0].Cells[0].Selected = false;
                    limpiarFormulario();
                    MessageBox.Show("¡Obra social eliminada exitosamente!", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                

            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (textBoxBuscar.Text != "")
            {

                dataGridView1.DataSource = TrabajarObraSocial.search_obra(textBoxBuscar.Text);
            }
            else
            {
                load_obras();

            }
            limpiarFormulario();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                textBoxCUIT.Text = dataGridView1.CurrentRow.Cells["OS_CUIT"].Value.ToString();
                textBoxRazon.Text = dataGridView1.CurrentRow.Cells["Razon_Social"].Value.ToString();
                textBoxDireccion.Text = dataGridView1.CurrentRow.Cells["Direccion"].Value.ToString();
                textBoxTelefono.Text = dataGridView1.CurrentRow.Cells["Telefono"].Value.ToString();
            }
        }






    }
}
