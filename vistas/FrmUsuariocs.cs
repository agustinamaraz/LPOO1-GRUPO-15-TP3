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
    public partial class FrmUsuariocs : Form
    {
        public FrmUsuariocs()
        {
            InitializeComponent();
        }

        private void FrmUsuariocs_Load(object sender, EventArgs e)
        {
            load_combo_roles();
            //load_usuarios();
            load_usuarios_sp();
            dataGridViewUsuarios.Rows[0].Cells[0].Selected = false;
            limpiarFormulario();
        }

        private void load_combo_roles()
        {
            comboBoxRol_Id.DataSource = TrabajarUsuario.list_roles();
            comboBoxRol_Id.DisplayMember = "rol_descripcion";
            comboBoxRol_Id.ValueMember = "rol_id";
        }

        private void load_usuarios()
        {
            //cuando selecciono la dataGridView en Diseño, a la izq salen Properties y en Name es el nombre del control DataGridView
            dataGridViewUsuarios.DataSource = TrabajarUsuario.list_usuarios();

        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {

            // PARA QUE SE LLENEN TODOS LOS CAMPOS DE INGRESO ANTES DE GUARDAR UN USUARIO
            bool bVacio = false;

            // Buscamos en cada Control de nuestro groupBox.
            foreach (var ctrl in groupBox1.Controls)
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
                Usuario oUser = new Usuario();

                oUser.Rol_Id = (int)comboBoxRol_Id.SelectedValue;
                oUser.Usr_Apellido = textBoxApellido.Text;
                oUser.Usr_Nombre = textBoxNombre.Text;
                oUser.Usr_UserName = textBoxUsuario.Text;
                oUser.Usr_Password = textBoxPassword.Text;
                oUser.Usr_Email = textBoxEmail.Text;

                TrabajarUsuario.insert_usuario(oUser);

                //llamar funcion para que se muestren o se refresquen los datos cargados
                load_usuarios();
                limpiarFormulario();

            }
        }

        private void limpiarFormulario()
        {
            //dataGridViewUsuarios.Rows[0].Cells[0].Selected = false;
            foreach (var ctrl in groupBox1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox textBox = ctrl as TextBox;
                    if ((textBox.Name.ToString() != "textBoxBuscarUsuario"))
                    {
                        textBox.Clear();
                    }
                }
            }
        }

        private void buttonBuscarUsuario_Click(object sender, EventArgs e)
        {
            // asi se llama mi textBox 
            if (textBoxBuscarUsuario.Text != "")
            {
                dataGridViewUsuarios.DataSource = TrabajarUsuario.search_usuarios(textBoxBuscarUsuario.Text);
            }
            else
            {
                load_usuarios();

            }
            limpiarFormulario();
        }

        private void dataGridViewUsuarios_CurrentCellChanged(object sender, EventArgs e)
        {
            //cuando click en la fila o registro me aparecen en el formulario los datos de ese registro


            //PREGUNTA: Aca es donde se define como se van a llamar las columnas de la tabla?
            if (dataGridViewUsuarios.CurrentRow != null)
            {
                comboBoxRol_Id.SelectedValue = dataGridViewUsuarios.CurrentRow.Cells["rol_id"].Value.ToString();

                textBoxApellido.Text = dataGridViewUsuarios.CurrentRow.Cells["Apellido"].Value.ToString();
                textBoxNombre.Text = dataGridViewUsuarios.CurrentRow.Cells["Nombre"].Value.ToString();
                textBoxUsuario.Text = dataGridViewUsuarios.CurrentRow.Cells["Usuario"].Value.ToString();
                textBoxPassword.Text = dataGridViewUsuarios.CurrentRow.Cells["Contraseña"].Value.ToString();
                textBoxEmail.Text = dataGridViewUsuarios.CurrentRow.Cells["Email"].Value.ToString();
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            Usuario oUser = new Usuario();

            oUser.Rol_Id = (int)comboBoxRol_Id.SelectedValue;
            oUser.Usr_Apellido = textBoxApellido.Text;
            oUser.Usr_Nombre = textBoxNombre.Text;
            oUser.Usr_UserName = textBoxUsuario.Text;
            oUser.Usr_Password = textBoxPassword.Text;
            oUser.Usr_Email = textBoxEmail.Text;

            TrabajarUsuario.update_usuario(oUser, oUser.Usr_UserName);

            //llamar funcion para que se muestren o se refresquen los datos cargados
            load_usuarios();
            dataGridViewUsuarios.Rows[0].Cells[0].Selected = false;
            limpiarFormulario();

            MessageBox.Show("¡Usuario modificado exitosamente!", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            string UserName = textBoxUsuario.Text;

            DialogResult res = MessageBox.Show("Estas seguro que deseas eliminar este usuario?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (res == DialogResult.Yes)
            {
                Boolean valor = TrabajarUsuario.delete_usuario(UserName);
                if (valor == false)
                {
                    MessageBox.Show("No se ha encontrado un usuario con ese Username", "Error en eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    load_usuarios();
                    dataGridViewUsuarios.Rows[0].Cells[0].Selected = false;
                    limpiarFormulario();
                    MessageBox.Show("¡Usuario eliminado exitosamente!", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        //----------------------------------------------------------- CON STORED PROCEDURES --------------------------------------------
        private void load_usuarios_sp()
        {
            dataGridViewUsuarios.DataSource = TrabajarUsuario.exec_list_usuarios_sp();
        }
    }
}
