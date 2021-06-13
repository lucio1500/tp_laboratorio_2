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
    public partial class FormAltaPulsera : Form
    {
        public RelojPulsera reloj;

        public FormAltaPulsera()
        {
            InitializeComponent();

            comboBoxMarca.DataSource = Enum.GetValues(typeof(EMarca));
            comboBoxMaterial.DataSource = Enum.GetValues(typeof(EMaterial));
            comboBoxGama.DataSource = Enum.GetValues(typeof(EGama));
        }

        #region Eventos

        /// <summary>
        /// Crea un nuevo objeto RelojPulsera.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.reloj = new RelojPulsera((EMaterial)Enum.Parse(typeof(EMaterial),comboBoxMaterial.Text),(EMarca)Enum.Parse(typeof(EMarca), comboBoxMarca.Text), textBoxModelo.Text, (EGama)Enum.Parse(typeof(EGama), comboBoxGama.Text));
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
