namespace Forms
{
    partial class FormPrincipal
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
            this.dgvGrillaInteligente = new System.Windows.Forms.DataGridView();
            this.dgvGrillaPulsera = new System.Windows.Forms.DataGridView();
            this.lblRelojInteligente = new System.Windows.Forms.Label();
            this.lblRelojPulsera = new System.Windows.Forms.Label();
            this.btnAltaRelojInteligente = new System.Windows.Forms.Button();
            this.btnAltaRelojPulsera = new System.Windows.Forms.Button();
            this.labelEstado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvInteligentesTerminados = new System.Windows.Forms.DataGridView();
            this.dgvPulseraTerminados = new System.Windows.Forms.DataGridView();
            this.btnPulirRelojes = new System.Windows.Forms.Button();
            this.btnCalibrarRelojes = new System.Windows.Forms.Button();
            this.btnEmpaquetarRelojes = new System.Windows.Forms.Button();
            this.lblTerminados = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGenerarXml = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCapacidad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaInteligente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaPulsera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInteligentesTerminados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPulseraTerminados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGrillaInteligente
            // 
            this.dgvGrillaInteligente.AllowUserToAddRows = false;
            this.dgvGrillaInteligente.AllowUserToDeleteRows = false;
            this.dgvGrillaInteligente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrillaInteligente.Location = new System.Drawing.Point(12, 80);
            this.dgvGrillaInteligente.Name = "dgvGrillaInteligente";
            this.dgvGrillaInteligente.ReadOnly = true;
            this.dgvGrillaInteligente.Size = new System.Drawing.Size(822, 179);
            this.dgvGrillaInteligente.TabIndex = 0;
            // 
            // dgvGrillaPulsera
            // 
            this.dgvGrillaPulsera.AllowUserToAddRows = false;
            this.dgvGrillaPulsera.AllowUserToDeleteRows = false;
            this.dgvGrillaPulsera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrillaPulsera.Location = new System.Drawing.Point(840, 80);
            this.dgvGrillaPulsera.Name = "dgvGrillaPulsera";
            this.dgvGrillaPulsera.ReadOnly = true;
            this.dgvGrillaPulsera.Size = new System.Drawing.Size(779, 179);
            this.dgvGrillaPulsera.TabIndex = 1;
            // 
            // lblRelojInteligente
            // 
            this.lblRelojInteligente.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelojInteligente.Location = new System.Drawing.Point(7, 44);
            this.lblRelojInteligente.Name = "lblRelojInteligente";
            this.lblRelojInteligente.Size = new System.Drawing.Size(355, 30);
            this.lblRelojInteligente.TabIndex = 2;
            this.lblRelojInteligente.Text = "RELOJES INTELIGENTES";
            // 
            // lblRelojPulsera
            // 
            this.lblRelojPulsera.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelojPulsera.Location = new System.Drawing.Point(834, 42);
            this.lblRelojPulsera.Name = "lblRelojPulsera";
            this.lblRelojPulsera.Size = new System.Drawing.Size(734, 30);
            this.lblRelojPulsera.TabIndex = 3;
            this.lblRelojPulsera.Text = "RELOJES PULSERA";
            // 
            // btnAltaRelojInteligente
            // 
            this.btnAltaRelojInteligente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAltaRelojInteligente.Location = new System.Drawing.Point(35, 484);
            this.btnAltaRelojInteligente.Name = "btnAltaRelojInteligente";
            this.btnAltaRelojInteligente.Size = new System.Drawing.Size(204, 57);
            this.btnAltaRelojInteligente.TabIndex = 4;
            this.btnAltaRelojInteligente.Text = "Agregar Reloj Inteligente";
            this.btnAltaRelojInteligente.UseVisualStyleBackColor = true;
            this.btnAltaRelojInteligente.Click += new System.EventHandler(this.btnAltaRelojInteligente_Click);
            // 
            // btnAltaRelojPulsera
            // 
            this.btnAltaRelojPulsera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAltaRelojPulsera.Location = new System.Drawing.Point(271, 484);
            this.btnAltaRelojPulsera.Name = "btnAltaRelojPulsera";
            this.btnAltaRelojPulsera.Size = new System.Drawing.Size(202, 57);
            this.btnAltaRelojPulsera.TabIndex = 5;
            this.btnAltaRelojPulsera.Text = "Agregar Reloj Pulsera";
            this.btnAltaRelojPulsera.UseVisualStyleBackColor = true;
            this.btnAltaRelojPulsera.Click += new System.EventHandler(this.btnAltaRelojPulsera_Click);
            // 
            // labelEstado
            // 
            this.labelEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstado.Location = new System.Drawing.Point(230, 9);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(288, 38);
            this.labelEstado.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 38);
            this.label1.TabIndex = 7;
            this.label1.Text = "Estado de los Relojes:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(655, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "RELOJES INTELIGENTES TERMINADOS";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(835, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(655, 30);
            this.label3.TabIndex = 9;
            this.label3.Text = "RELOJES PULSERA TERMINADOS";
            // 
            // dgvInteligentesTerminados
            // 
            this.dgvInteligentesTerminados.AllowUserToAddRows = false;
            this.dgvInteligentesTerminados.AllowUserToDeleteRows = false;
            this.dgvInteligentesTerminados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInteligentesTerminados.Location = new System.Drawing.Point(12, 304);
            this.dgvInteligentesTerminados.Name = "dgvInteligentesTerminados";
            this.dgvInteligentesTerminados.ReadOnly = true;
            this.dgvInteligentesTerminados.Size = new System.Drawing.Size(822, 142);
            this.dgvInteligentesTerminados.TabIndex = 10;
            // 
            // dgvPulseraTerminados
            // 
            this.dgvPulseraTerminados.AllowUserToAddRows = false;
            this.dgvPulseraTerminados.AllowUserToDeleteRows = false;
            this.dgvPulseraTerminados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPulseraTerminados.Location = new System.Drawing.Point(840, 304);
            this.dgvPulseraTerminados.Name = "dgvPulseraTerminados";
            this.dgvPulseraTerminados.ReadOnly = true;
            this.dgvPulseraTerminados.Size = new System.Drawing.Size(779, 142);
            this.dgvPulseraTerminados.TabIndex = 11;
            // 
            // btnPulirRelojes
            // 
            this.btnPulirRelojes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPulirRelojes.Location = new System.Drawing.Point(537, 484);
            this.btnPulirRelojes.Name = "btnPulirRelojes";
            this.btnPulirRelojes.Size = new System.Drawing.Size(204, 57);
            this.btnPulirRelojes.TabIndex = 12;
            this.btnPulirRelojes.Text = "Primer Paso: Pulir Relojes";
            this.btnPulirRelojes.UseVisualStyleBackColor = true;
            this.btnPulirRelojes.Click += new System.EventHandler(this.btnPulirRelojes_Click);
            // 
            // btnCalibrarRelojes
            // 
            this.btnCalibrarRelojes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalibrarRelojes.Location = new System.Drawing.Point(762, 484);
            this.btnCalibrarRelojes.Name = "btnCalibrarRelojes";
            this.btnCalibrarRelojes.Size = new System.Drawing.Size(204, 57);
            this.btnCalibrarRelojes.TabIndex = 13;
            this.btnCalibrarRelojes.Text = "Segundo Paso: Callibrar Relojes";
            this.btnCalibrarRelojes.UseVisualStyleBackColor = true;
            this.btnCalibrarRelojes.Click += new System.EventHandler(this.btnCalibrarRelojes_Click);
            // 
            // btnEmpaquetarRelojes
            // 
            this.btnEmpaquetarRelojes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpaquetarRelojes.Location = new System.Drawing.Point(1001, 484);
            this.btnEmpaquetarRelojes.Name = "btnEmpaquetarRelojes";
            this.btnEmpaquetarRelojes.Size = new System.Drawing.Size(204, 57);
            this.btnEmpaquetarRelojes.TabIndex = 14;
            this.btnEmpaquetarRelojes.Text = "Tercer y ultimo Paso: Empaquetar Relojes";
            this.btnEmpaquetarRelojes.UseVisualStyleBackColor = true;
            this.btnEmpaquetarRelojes.Click += new System.EventHandler(this.btnEmpaquetarRelojes_Click);
            // 
            // lblTerminados
            // 
            this.lblTerminados.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerminados.Location = new System.Drawing.Point(1563, 465);
            this.lblTerminados.Name = "lblTerminados";
            this.lblTerminados.Size = new System.Drawing.Size(83, 38);
            this.lblTerminados.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1270, 465);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(298, 38);
            this.label5.TabIndex = 16;
            this.label5.Text = "Cantidad de Relojes Terminados:";
            // 
            // btnGenerarXml
            // 
            this.btnGenerarXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarXml.Location = new System.Drawing.Point(1385, 511);
            this.btnGenerarXml.Name = "btnGenerarXml";
            this.btnGenerarXml.Size = new System.Drawing.Size(132, 35);
            this.btnGenerarXml.TabIndex = 17;
            this.btnGenerarXml.Text = "Generar XML";
            this.btnGenerarXml.UseVisualStyleBackColor = true;
            this.btnGenerarXml.Click += new System.EventHandler(this.btnGenerarXml_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1219, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(298, 38);
            this.label4.TabIndex = 18;
            this.label4.Text = "Capacidad de la Fabrica:";
            // 
            // lblCapacidad
            // 
            this.lblCapacidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacidad.Location = new System.Drawing.Point(1434, 9);
            this.lblCapacidad.Name = "lblCapacidad";
            this.lblCapacidad.Size = new System.Drawing.Size(83, 38);
            this.lblCapacidad.TabIndex = 19;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1648, 559);
            this.Controls.Add(this.lblCapacidad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGenerarXml);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTerminados);
            this.Controls.Add(this.btnEmpaquetarRelojes);
            this.Controls.Add(this.btnCalibrarRelojes);
            this.Controls.Add(this.btnPulirRelojes);
            this.Controls.Add(this.dgvPulseraTerminados);
            this.Controls.Add(this.dgvInteligentesTerminados);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.btnAltaRelojPulsera);
            this.Controls.Add(this.btnAltaRelojInteligente);
            this.Controls.Add(this.lblRelojPulsera);
            this.Controls.Add(this.lblRelojInteligente);
            this.Controls.Add(this.dgvGrillaPulsera);
            this.Controls.Add(this.dgvGrillaInteligente);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1665, 600);
            this.MinimumSize = new System.Drawing.Size(830, 400);
            this.Name = "FormPrincipal";
            this.Text = "Lucio Andres Gonzalez 2A";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaInteligente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaPulsera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInteligentesTerminados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPulseraTerminados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGrillaInteligente;
        private System.Windows.Forms.DataGridView dgvGrillaPulsera;
        private System.Windows.Forms.Label lblRelojInteligente;
        private System.Windows.Forms.Label lblRelojPulsera;
        private System.Windows.Forms.Button btnAltaRelojInteligente;
        private System.Windows.Forms.Button btnAltaRelojPulsera;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvInteligentesTerminados;
        private System.Windows.Forms.DataGridView dgvPulseraTerminados;
        private System.Windows.Forms.Button btnPulirRelojes;
        private System.Windows.Forms.Button btnCalibrarRelojes;
        private System.Windows.Forms.Button btnEmpaquetarRelojes;
        private System.Windows.Forms.Label lblTerminados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGenerarXml;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCapacidad;
    }
}

