namespace vistas
{
    partial class FrmCliente
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
            this.groupBoxCliente = new System.Windows.Forms.GroupBox();
            this.comboBoxClienteOSCUIT = new System.Windows.Forms.ComboBox();
            this.textBoxClienteNroCarnet = new System.Windows.Forms.TextBox();
            this.textBoxClienteDireccion = new System.Windows.Forms.TextBox();
            this.textBoxClienteNombre = new System.Windows.Forms.TextBox();
            this.textBoxClienteApellido = new System.Windows.Forms.TextBox();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonModificarCliente = new System.Windows.Forms.Button();
            this.buttonEliminarCliente = new System.Windows.Forms.Button();
            this.buttonGuardarCliente = new System.Windows.Forms.Button();
            this.opticaDataSet = new vistas.opticaDataSet();
            this.dataGridViewClientes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBuscarApellido = new System.Windows.Forms.TextBox();
            this.buttonBuscarCliente = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBuscarNombre = new System.Windows.Forms.TextBox();
            this.groupBoxCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opticaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCliente
            // 
            this.groupBoxCliente.Controls.Add(this.comboBoxClienteOSCUIT);
            this.groupBoxCliente.Controls.Add(this.textBoxClienteNroCarnet);
            this.groupBoxCliente.Controls.Add(this.textBoxClienteDireccion);
            this.groupBoxCliente.Controls.Add(this.textBoxClienteNombre);
            this.groupBoxCliente.Controls.Add(this.textBoxClienteApellido);
            this.groupBoxCliente.Controls.Add(this.textBoxDNI);
            this.groupBoxCliente.Controls.Add(this.label8);
            this.groupBoxCliente.Controls.Add(this.label7);
            this.groupBoxCliente.Controls.Add(this.label6);
            this.groupBoxCliente.Controls.Add(this.label5);
            this.groupBoxCliente.Controls.Add(this.label4);
            this.groupBoxCliente.Controls.Add(this.label3);
            this.groupBoxCliente.Controls.Add(this.buttonModificarCliente);
            this.groupBoxCliente.Controls.Add(this.buttonEliminarCliente);
            this.groupBoxCliente.Controls.Add(this.buttonGuardarCliente);
            this.groupBoxCliente.Location = new System.Drawing.Point(678, 50);
            this.groupBoxCliente.Name = "groupBoxCliente";
            this.groupBoxCliente.Size = new System.Drawing.Size(352, 456);
            this.groupBoxCliente.TabIndex = 0;
            this.groupBoxCliente.TabStop = false;
            this.groupBoxCliente.Text = "Datos del Cliente";
            // 
            // comboBoxClienteOSCUIT
            // 
            this.comboBoxClienteOSCUIT.FormattingEnabled = true;
            this.comboBoxClienteOSCUIT.Location = new System.Drawing.Point(96, 241);
            this.comboBoxClienteOSCUIT.Name = "comboBoxClienteOSCUIT";
            this.comboBoxClienteOSCUIT.Size = new System.Drawing.Size(225, 24);
            this.comboBoxClienteOSCUIT.TabIndex = 15;
            // 
            // textBoxClienteNroCarnet
            // 
            this.textBoxClienteNroCarnet.Location = new System.Drawing.Point(96, 290);
            this.textBoxClienteNroCarnet.Name = "textBoxClienteNroCarnet";
            this.textBoxClienteNroCarnet.Size = new System.Drawing.Size(225, 22);
            this.textBoxClienteNroCarnet.TabIndex = 14;
            // 
            // textBoxClienteDireccion
            // 
            this.textBoxClienteDireccion.Location = new System.Drawing.Point(96, 193);
            this.textBoxClienteDireccion.Name = "textBoxClienteDireccion";
            this.textBoxClienteDireccion.Size = new System.Drawing.Size(225, 22);
            this.textBoxClienteDireccion.TabIndex = 11;
            // 
            // textBoxClienteNombre
            // 
            this.textBoxClienteNombre.Location = new System.Drawing.Point(96, 143);
            this.textBoxClienteNombre.Name = "textBoxClienteNombre";
            this.textBoxClienteNombre.Size = new System.Drawing.Size(225, 22);
            this.textBoxClienteNombre.TabIndex = 10;
            // 
            // textBoxClienteApellido
            // 
            this.textBoxClienteApellido.Location = new System.Drawing.Point(96, 99);
            this.textBoxClienteApellido.Name = "textBoxClienteApellido";
            this.textBoxClienteApellido.Size = new System.Drawing.Size(225, 22);
            this.textBoxClienteApellido.TabIndex = 9;
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Location = new System.Drawing.Point(96, 52);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(225, 22);
            this.textBoxDNI.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 244);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "OS CUIT";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Nro Carnet";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Direccion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "DNI";
            // 
            // buttonModificarCliente
            // 
            this.buttonModificarCliente.Location = new System.Drawing.Point(96, 396);
            this.buttonModificarCliente.Name = "buttonModificarCliente";
            this.buttonModificarCliente.Size = new System.Drawing.Size(153, 42);
            this.buttonModificarCliente.TabIndex = 2;
            this.buttonModificarCliente.Text = "Modificar";
            this.buttonModificarCliente.UseVisualStyleBackColor = true;
            this.buttonModificarCliente.Click += new System.EventHandler(this.buttonModificarCliente_Click);
            // 
            // buttonEliminarCliente
            // 
            this.buttonEliminarCliente.Location = new System.Drawing.Point(180, 348);
            this.buttonEliminarCliente.Name = "buttonEliminarCliente";
            this.buttonEliminarCliente.Size = new System.Drawing.Size(153, 42);
            this.buttonEliminarCliente.TabIndex = 1;
            this.buttonEliminarCliente.Text = "Eliminar";
            this.buttonEliminarCliente.UseVisualStyleBackColor = true;
            this.buttonEliminarCliente.Click += new System.EventHandler(this.buttonEliminarCliente_Click);
            // 
            // buttonGuardarCliente
            // 
            this.buttonGuardarCliente.Location = new System.Drawing.Point(21, 348);
            this.buttonGuardarCliente.Name = "buttonGuardarCliente";
            this.buttonGuardarCliente.Size = new System.Drawing.Size(153, 42);
            this.buttonGuardarCliente.TabIndex = 0;
            this.buttonGuardarCliente.Text = "Guardar";
            this.buttonGuardarCliente.UseVisualStyleBackColor = true;
            this.buttonGuardarCliente.Click += new System.EventHandler(this.buttonGuardarCliente_Click);
            // 
            // opticaDataSet
            // 
            this.opticaDataSet.DataSetName = "opticaDataSet";
            this.opticaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewClientes
            // 
            this.dataGridViewClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClientes.Location = new System.Drawing.Point(38, 102);
            this.dataGridViewClientes.Name = "dataGridViewClientes";
            this.dataGridViewClientes.RowTemplate.Height = 24;
            this.dataGridViewClientes.Size = new System.Drawing.Size(601, 403);
            this.dataGridViewClientes.TabIndex = 1;
            this.dataGridViewClientes.CurrentCellChanged += new System.EventHandler(this.dataGridViewClientes_CurrentCellChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Apellido";
            // 
            // textBoxBuscarApellido
            // 
            this.textBoxBuscarApellido.Location = new System.Drawing.Point(114, 23);
            this.textBoxBuscarApellido.Name = "textBoxBuscarApellido";
            this.textBoxBuscarApellido.Size = new System.Drawing.Size(340, 22);
            this.textBoxBuscarApellido.TabIndex = 3;
            // 
            // buttonBuscarCliente
            // 
            this.buttonBuscarCliente.Location = new System.Drawing.Point(481, 39);
            this.buttonBuscarCliente.Name = "buttonBuscarCliente";
            this.buttonBuscarCliente.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscarCliente.TabIndex = 4;
            this.buttonBuscarCliente.Text = "Buscar";
            this.buttonBuscarCliente.UseVisualStyleBackColor = true;
            this.buttonBuscarCliente.Click += new System.EventHandler(this.buttonBuscarCliente_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nombre";
            // 
            // textBoxBuscarNombre
            // 
            this.textBoxBuscarNombre.Location = new System.Drawing.Point(114, 63);
            this.textBoxBuscarNombre.Name = "textBoxBuscarNombre";
            this.textBoxBuscarNombre.Size = new System.Drawing.Size(340, 22);
            this.textBoxBuscarNombre.TabIndex = 6;
            // 
            // FrmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 547);
            this.Controls.Add(this.textBoxBuscarNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonBuscarCliente);
            this.Controls.Add(this.textBoxBuscarApellido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewClientes);
            this.Controls.Add(this.groupBoxCliente);
            this.Name = "FrmCliente";
            this.Text = "FrmCliente";
            this.Load += new System.EventHandler(this.FrmCliente_Load);
            this.groupBoxCliente.ResumeLayout(false);
            this.groupBoxCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opticaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCliente;
        private System.Windows.Forms.TextBox textBoxClienteNroCarnet;
        private System.Windows.Forms.TextBox textBoxClienteDireccion;
        private System.Windows.Forms.TextBox textBoxClienteNombre;
        private System.Windows.Forms.TextBox textBoxClienteApellido;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonModificarCliente;
        private System.Windows.Forms.Button buttonEliminarCliente;
        private System.Windows.Forms.Button buttonGuardarCliente;
        private opticaDataSet opticaDataSet;
        private System.Windows.Forms.DataGridView dataGridViewClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBuscarApellido;
        private System.Windows.Forms.Button buttonBuscarCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxBuscarNombre;
        private System.Windows.Forms.ComboBox comboBoxClienteOSCUIT;
    }
}