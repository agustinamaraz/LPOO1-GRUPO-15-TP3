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
    public partial class FrmLogin : Form
    {
        public static string rol = "";
        DataTable dt = new DataTable();

        public FrmLogin()
        {
            InitializeComponent();
        }       

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            dt = TrabajarUsuario.list_usuarios();
        }

        private void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Boolean UserFound = false;
            /*Usuario oUser1 = new Usuario("agustina", "123");
            Usuario oUser2 = new Usuario("tiffany", "456");
            Usuario oUser3 = new Usuario("juan", "123");*/
            int i = 0;
            for (i = 0; i < dt.Rows.Count; i++) {
                if (dt.Rows[i]["Usuario"].ToString() == txtUserName.Text && dt.Rows[i]["Contraseña"].ToString() == txtUserPassword.Text) { 
                    UserFound = true;
                    break;
                }
            }

                /*if (oUser1.Usr_UserName == txtUserName.Text && oUser1.Usr_Password == txtUserPassword.Text)
                {
                    bUserFound = true;
                }
                else if (oUser1.Usr_UserName == txtUserName.Text && oUser1.Usr_Password == txtUserPassword.Text)
                {
                    bUserFound = true;
                }
            */


            FrmMain oFrmMain = new FrmMain();

            if (UserFound)
            {
     //fila i donde lo encontro   nombre de columna
                rol = dt.Rows[i]["rol_id"].ToString();
               
                MessageBox.Show("Bienvenido/a: " + txtUserName.Text +" con rol de: "+dt.Rows[i]["Rol"].ToString());
                oFrmMain.Show(); 
            }
            else
            {
                MessageBox.Show("Datos de acceso incorrectos");
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            ButtonAceptar.BackColor = Color.Aqua;
            ButtonAceptar.ForeColor = Color.Blue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            ButtonAceptar.BackColor = SystemColors.Control;
            ButtonAceptar.ForeColor = SystemColors.ControlText;
        }

    }
}
