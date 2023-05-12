using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace vistas
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //11) 
            //Administrador, acceso al módulo de gestión de Usuarios y Productos;
            if (FrmLogin.rol == "1") {
                menuStrip1.Items.Remove(clienteToolStripMenuItem);
                menuStrip1.Items.Remove(ventaToolStripMenuItem);
                menuStrip1.Items.Remove(listadoVentasToolStripMenuItem);
                menuStrip1.Items.Remove(obraSocialToolStripMenuItem);
            }
            //Operador: acceso al módulo Clientes y Ventas
            else if (FrmLogin.rol == "2")
            {
                menuStrip1.Items.Remove(productoToolStripMenuItem);
                menuStrip1.Items.Remove(usuarioToolStripMenuItem);
                menuStrip1.Items.Remove(listadoVentasToolStripMenuItem);
                menuStrip1.Items.Remove(obraSocialToolStripMenuItem);

            }
            //Auditor: sin restricción de acceso
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuariocs oFrmUsuario = new FrmUsuariocs();
            //FrmMain.ActiveForm.Hide();
            oFrmUsuario.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Quieres salir de la aplicación?", "Mensaje de Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
                //this.Close(); solo cierra la ventana
            }
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCliente oFrmCliente = new FrmCliente();
            //FrmMain.ActiveForm.Hide();
            oFrmCliente.Show();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProducto oFrmProducto = new FrmProducto();
            oFrmProducto.Show();
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVenta formventa = new FrmVenta();
            formventa.Show();
        }

        private void listadoVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadoVentas formListado = new FrmListadoVentas();
            formListado.Show();
        }

        private void obraSocialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmObraSocial obra = new FrmObraSocial();
            obra.Show();
        }

        private void ordenarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaListadoCliente consulta = new ConsultaListadoCliente();
            consulta.Show();
        }

        private void ordenarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaListadoProductos p = new ConsultaListadoProductos();
            p.Show();
        }

        private void listarVentasPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaVentaPorCliente v = new ConsultaVentaPorCliente();
            v.Show();
        }

        private void listarProductosVendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaProductosCompradosPorCliente p = new ConsultaProductosCompradosPorCliente();
            p.Show();
        }

        private void listarProductosVendidosPorFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListarProductosPorFechas l = new ListarProductosPorFechas();
            l.Show();
        }

        private void listarVentasPorFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListarVentasPorFechas v = new ListarVentasPorFechas();
            v.Show();
        }


    }
}
