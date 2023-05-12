namespace vistas
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obraSocialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordenarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordenarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarVentasPorClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarVentasPorFechasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarProductosVendidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarProductosVendidosPorFechasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarioToolStripMenuItem,
            this.clienteToolStripMenuItem,
            this.productoToolStripMenuItem,
            this.ventaToolStripMenuItem,
            this.listadoVentasToolStripMenuItem,
            this.obraSocialToolStripMenuItem,
            this.consultasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1018, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            this.usuarioToolStripMenuItem.Click += new System.EventHandler(this.usuarioToolStripMenuItem_Click);
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // productoToolStripMenuItem
            // 
            this.productoToolStripMenuItem.Name = "productoToolStripMenuItem";
            this.productoToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.productoToolStripMenuItem.Text = "Producto";
            this.productoToolStripMenuItem.Click += new System.EventHandler(this.productoToolStripMenuItem_Click);
            // 
            // ventaToolStripMenuItem
            // 
            this.ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            this.ventaToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.ventaToolStripMenuItem.Text = "Venta";
            this.ventaToolStripMenuItem.Click += new System.EventHandler(this.ventaToolStripMenuItem_Click);
            // 
            // listadoVentasToolStripMenuItem
            // 
            this.listadoVentasToolStripMenuItem.Name = "listadoVentasToolStripMenuItem";
            this.listadoVentasToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.listadoVentasToolStripMenuItem.Text = "Listado Ventas";
            this.listadoVentasToolStripMenuItem.Click += new System.EventHandler(this.listadoVentasToolStripMenuItem_Click);
            // 
            // obraSocialToolStripMenuItem
            // 
            this.obraSocialToolStripMenuItem.Name = "obraSocialToolStripMenuItem";
            this.obraSocialToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.obraSocialToolStripMenuItem.Text = "Obra Social";
            this.obraSocialToolStripMenuItem.Click += new System.EventHandler(this.obraSocialToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ordenarClienteToolStripMenuItem,
            this.ordenarProductoToolStripMenuItem,
            this.listarVentasPorClienteToolStripMenuItem,
            this.listarVentasPorFechasToolStripMenuItem,
            this.listarProductosVendidosToolStripMenuItem,
            this.listarProductosVendidosPorFechasToolStripMenuItem});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // ordenarClienteToolStripMenuItem
            // 
            this.ordenarClienteToolStripMenuItem.Name = "ordenarClienteToolStripMenuItem";
            this.ordenarClienteToolStripMenuItem.Size = new System.Drawing.Size(323, 24);
            this.ordenarClienteToolStripMenuItem.Text = "Ordenar Cliente Por Apellido";
            this.ordenarClienteToolStripMenuItem.Click += new System.EventHandler(this.ordenarClienteToolStripMenuItem_Click);
            // 
            // ordenarProductoToolStripMenuItem
            // 
            this.ordenarProductoToolStripMenuItem.Name = "ordenarProductoToolStripMenuItem";
            this.ordenarProductoToolStripMenuItem.Size = new System.Drawing.Size(323, 24);
            this.ordenarProductoToolStripMenuItem.Text = "Ordenar Producto";
            this.ordenarProductoToolStripMenuItem.Click += new System.EventHandler(this.ordenarProductoToolStripMenuItem_Click);
            // 
            // listarVentasPorClienteToolStripMenuItem
            // 
            this.listarVentasPorClienteToolStripMenuItem.Name = "listarVentasPorClienteToolStripMenuItem";
            this.listarVentasPorClienteToolStripMenuItem.Size = new System.Drawing.Size(323, 24);
            this.listarVentasPorClienteToolStripMenuItem.Text = "Listar Ventas Por Cliente";
            this.listarVentasPorClienteToolStripMenuItem.Click += new System.EventHandler(this.listarVentasPorClienteToolStripMenuItem_Click);
            // 
            // listarVentasPorFechasToolStripMenuItem
            // 
            this.listarVentasPorFechasToolStripMenuItem.Name = "listarVentasPorFechasToolStripMenuItem";
            this.listarVentasPorFechasToolStripMenuItem.Size = new System.Drawing.Size(323, 24);
            this.listarVentasPorFechasToolStripMenuItem.Text = "Listar Ventas Por Fechas";
            this.listarVentasPorFechasToolStripMenuItem.Click += new System.EventHandler(this.listarVentasPorFechasToolStripMenuItem_Click);
            // 
            // listarProductosVendidosToolStripMenuItem
            // 
            this.listarProductosVendidosToolStripMenuItem.Name = "listarProductosVendidosToolStripMenuItem";
            this.listarProductosVendidosToolStripMenuItem.Size = new System.Drawing.Size(323, 24);
            this.listarProductosVendidosToolStripMenuItem.Text = "Listar Productos Vendidos Por Cliente";
            this.listarProductosVendidosToolStripMenuItem.Click += new System.EventHandler(this.listarProductosVendidosToolStripMenuItem_Click);
            // 
            // listarProductosVendidosPorFechasToolStripMenuItem
            // 
            this.listarProductosVendidosPorFechasToolStripMenuItem.Name = "listarProductosVendidosPorFechasToolStripMenuItem";
            this.listarProductosVendidosPorFechasToolStripMenuItem.Size = new System.Drawing.Size(323, 24);
            this.listarProductosVendidosPorFechasToolStripMenuItem.Text = "Listar Productos Vendidos Por Fechas";
            this.listarProductosVendidosPorFechasToolStripMenuItem.Click += new System.EventHandler(this.listarProductosVendidosPorFechasToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(866, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Salir";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(211, 117);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(532, 244);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(161, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(674, 50);
            this.label1.TabIndex = 3;
            this.label1.Text = "¡BIENVENIDO A NUESTRA ÓPTICA!";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 397);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obraSocialToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordenarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordenarProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarVentasPorClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarVentasPorFechasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarProductosVendidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarProductosVendidosPorFechasToolStripMenuItem;
    }
}