namespace Forms
{
    partial class FormListado
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
            this.dgvRelojes = new System.Windows.Forms.DataGridView();
            this.comboBoxMarca = new System.Windows.Forms.ComboBox();
            this.lbl1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelojes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRelojes
            // 
            this.dgvRelojes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelojes.Location = new System.Drawing.Point(12, 69);
            this.dgvRelojes.Name = "dgvRelojes";
            this.dgvRelojes.Size = new System.Drawing.Size(623, 504);
            this.dgvRelojes.TabIndex = 0;
            // 
            // comboBoxMarca
            // 
            this.comboBoxMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMarca.FormattingEnabled = true;
            this.comboBoxMarca.Location = new System.Drawing.Point(473, 25);
            this.comboBoxMarca.Name = "comboBoxMarca";
            this.comboBoxMarca.Size = new System.Drawing.Size(162, 26);
            this.comboBoxMarca.TabIndex = 1;
            this.comboBoxMarca.SelectedValueChanged += new System.EventHandler(this.comboBoxMarca_SelectedValueChanged);
            // 
            // lbl1
            // 
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(12, 25);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(77, 35);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "Marca: ";
            // 
            // FormListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 586);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.comboBoxMarca);
            this.Controls.Add(this.dgvRelojes);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(665, 625);
            this.Name = "FormListado";
            this.Text = "Listado de Relojes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormListado_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelojes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRelojes;
        private System.Windows.Forms.ComboBox comboBoxMarca;
        private System.Windows.Forms.Label lbl1;
    }
}