namespace MineriaDatos
{
    partial class ManejoDatos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dtgProducts = new System.Windows.Forms.DataGridView();
            this.btnCargaCSV = new System.Windows.Forms.Button();
            this.BorrarFiltros = new System.Windows.Forms.Button();
            this.EnviarDatos = new System.Windows.Forms.Button();
            this.Filtro1 = new System.Windows.Forms.ComboBox();
            this.ImagenFondo1 = new System.Windows.Forms.PictureBox();
            this.Filtro2 = new System.Windows.Forms.ComboBox();
            this.lblCountEjecutivo = new System.Windows.Forms.Label();
            this.lblCountTipodeVenta = new System.Windows.Forms.Label();
            this.lblCountPlan = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.programBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.form1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenFondo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgProducts
            // 
            this.dtgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProducts.Location = new System.Drawing.Point(66, 126);
            this.dtgProducts.Name = "dtgProducts";
            this.dtgProducts.Size = new System.Drawing.Size(561, 310);
            this.dtgProducts.TabIndex = 0;
            // 
            // btnCargaCSV
            // 
            this.btnCargaCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargaCSV.Location = new System.Drawing.Point(673, 182);
            this.btnCargaCSV.Name = "btnCargaCSV";
            this.btnCargaCSV.Size = new System.Drawing.Size(138, 65);
            this.btnCargaCSV.TabIndex = 1;
            this.btnCargaCSV.Text = "Cargar archivo .CSV";
            this.btnCargaCSV.UseVisualStyleBackColor = true;
            this.btnCargaCSV.Click += new System.EventHandler(this.btnCargaCSV_Click);
            // 
            // BorrarFiltros
            // 
            this.BorrarFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorrarFiltros.Location = new System.Drawing.Point(511, 81);
            this.BorrarFiltros.Name = "BorrarFiltros";
            this.BorrarFiltros.Size = new System.Drawing.Size(116, 33);
            this.BorrarFiltros.TabIndex = 6;
            this.BorrarFiltros.Text = "Borrar Filtros";
            this.BorrarFiltros.UseVisualStyleBackColor = true;
            this.BorrarFiltros.Click += new System.EventHandler(this.BorrarFiltros_Click);
            // 
            // EnviarDatos
            // 
            this.EnviarDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnviarDatos.Location = new System.Drawing.Point(673, 306);
            this.EnviarDatos.Name = "EnviarDatos";
            this.EnviarDatos.Size = new System.Drawing.Size(138, 65);
            this.EnviarDatos.TabIndex = 7;
            this.EnviarDatos.Text = "Mostrar Estadisticas";
            this.EnviarDatos.UseVisualStyleBackColor = true;
            this.EnviarDatos.Click += new System.EventHandler(this.EnviarDatos_Click);
            // 
            // Filtro1
            // 
            this.Filtro1.FormattingEnabled = true;
            this.Filtro1.Location = new System.Drawing.Point(128, 93);
            this.Filtro1.Name = "Filtro1";
            this.Filtro1.Size = new System.Drawing.Size(124, 21);
            this.Filtro1.TabIndex = 8;
            this.Filtro1.SelectedIndexChanged += new System.EventHandler(this.btnFiltro1_SelectedIndexChanged_1);
            // 
            // ImagenFondo1
            // 
            this.ImagenFondo1.Image = global::MineriaDatos.Properties.Resources.fondo2;
            this.ImagenFondo1.Location = new System.Drawing.Point(2, -1);
            this.ImagenFondo1.Name = "ImagenFondo1";
            this.ImagenFondo1.Size = new System.Drawing.Size(909, 454);
            this.ImagenFondo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagenFondo1.TabIndex = 9;
            this.ImagenFondo1.TabStop = false;
            // 
            // Filtro2
            // 
            this.Filtro2.FormattingEnabled = true;
            this.Filtro2.Location = new System.Drawing.Point(313, 93);
            this.Filtro2.Name = "Filtro2";
            this.Filtro2.Size = new System.Drawing.Size(135, 21);
            this.Filtro2.TabIndex = 10;
            this.Filtro2.SelectedIndexChanged += new System.EventHandler(this.btnFiltro2_SelectedIndexChanged);
            // 
            // lblCountEjecutivo
            // 
            this.lblCountEjecutivo.AutoSize = true;
            this.lblCountEjecutivo.Location = new System.Drawing.Point(138, 398);
            this.lblCountEjecutivo.Name = "lblCountEjecutivo";
            this.lblCountEjecutivo.Size = new System.Drawing.Size(0, 13);
            this.lblCountEjecutivo.TabIndex = 11;
            // 
            // lblCountTipodeVenta
            // 
            this.lblCountTipodeVenta.AutoSize = true;
            this.lblCountTipodeVenta.Location = new System.Drawing.Point(279, 398);
            this.lblCountTipodeVenta.Name = "lblCountTipodeVenta";
            this.lblCountTipodeVenta.Size = new System.Drawing.Size(0, 13);
            this.lblCountTipodeVenta.TabIndex = 12;
            // 
            // lblCountPlan
            // 
            this.lblCountPlan.AutoSize = true;
            this.lblCountPlan.Location = new System.Drawing.Point(411, 398);
            this.lblCountPlan.Name = "lblCountPlan";
            this.lblCountPlan.Size = new System.Drawing.Size(0, 16);
            this.lblCountPlan.TabIndex = 13;
            this.lblCountPlan.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(262, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "\" *NOMBRE DEL PROYECTO* \"";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Filtro principal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(313, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Filtro secundario (Opcional)";
            // 
            // programBindingSource1
            // 
            this.programBindingSource1.DataSource = typeof(MineriaDatos.Program);
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(MineriaDatos.ManejoDatos);
            // 
            // programBindingSource
            // 
            this.programBindingSource.DataSource = typeof(MineriaDatos.Program);
            // 
            // form1BindingSource1
            // 
            this.form1BindingSource1.DataSource = typeof(MineriaDatos.ManejoDatos);
            // 
            // ManejoDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackgroundImage = global::MineriaDatos.Properties.Resources.fondo2;
            this.ClientSize = new System.Drawing.Size(908, 448);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCountPlan);
            this.Controls.Add(this.lblCountTipodeVenta);
            this.Controls.Add(this.lblCountEjecutivo);
            this.Controls.Add(this.Filtro2);
            this.Controls.Add(this.Filtro1);
            this.Controls.Add(this.EnviarDatos);
            this.Controls.Add(this.BorrarFiltros);
            this.Controls.Add(this.btnCargaCSV);
            this.Controls.Add(this.dtgProducts);
            this.Controls.Add(this.ImagenFondo1);
            this.MaximizeBox = false;
            this.Name = "ManejoDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dtgProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenFondo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BorrarFiltros;
        private System.Windows.Forms.ComboBox Filtro1;
        private System.Windows.Forms.BindingSource programBindingSource1;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.BindingSource programBindingSource;
        private System.Windows.Forms.PictureBox ImagenFondo1;
        private System.Windows.Forms.ComboBox Filtro2;
        private System.Windows.Forms.BindingSource form1BindingSource1;
        public System.Windows.Forms.DataGridView dtgProducts;
        public System.Windows.Forms.Button btnCargaCSV;
        public System.Windows.Forms.Button EnviarDatos;
        private System.Windows.Forms.Label lblCountEjecutivo;
        private System.Windows.Forms.Label lblCountTipodeVenta;
        private System.Windows.Forms.Label lblCountPlan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

