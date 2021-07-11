using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Forms
{
    public partial class FormAltaInteligente : Form
    {
        public RelojInteligente reloj;

        public FormAltaInteligente()
        {
            InitializeComponent();

            comboBoxMarca.DataSource = Enum.GetValues(typeof(EMarca));
            comboBoxPantalla.DataSource = Enum.GetValues(typeof(EPantalla));
        }

        #region Eventos

        /// <summary>
        /// Aceptar doy de alta un RelojInteligente y creo la nueva instancia de dicho objeto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.reloj = new RelojInteligente((EMarca)Enum.Parse(typeof(EMarca),comboBoxMarca.Text), textBoxModelo.Text,(EPantalla)Enum.Parse(typeof(EPantalla),comboBoxPantalla.Text),checkBox1.Checked);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// Cancelar Alta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
           this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        #endregion
    }
}
