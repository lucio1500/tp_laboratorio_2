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
using Extension;
using System.Threading;

namespace Forms
{
    public partial class FormListado : Form
    {
        DataTable dtListado;
        FormPrincipal frm;
        List<Reloj> listadoRelojes;
        public Thread hiloRefresh;

        public FormListado(FormPrincipal formPrincipal)
        {
            InitializeComponent();

            
            frm = formPrincipal;
            dtListado = frm.ConfigurarDataTable();
            dtListado.Columns.Remove("id");

            dgvRelojes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            comboBoxMarca.DataSource = Enum.GetValues(typeof(EMarca));

            hiloRefresh = new Thread(Actualizaciones);
            hiloRefresh.Start();
        }

        #region Metodos

        /// <summary>
        /// Metodo utilizado por el hiloRefresh para mantener actualizado el dataGridView 
        /// sin nesecidad de estar cambiando el ComboBoxMarca para que se actualice.
        /// </summary>
        public void Actualizaciones()
        {
            while (true)
            {
                if (this.dgvRelojes.InvokeRequired)
                {
                    this.dgvRelojes.BeginInvoke((MethodInvoker)delegate ()
                    {
                        Filtrar();
                    });
                }
                Thread.Sleep(3000);
            }
        }

        /// <summary>
        /// Se encarga de limpiar el DataTable y completarlo con el List de relojes obtenido 
        /// por el metodo ObtenerListado.
        /// </summary>
        private void Filtrar()
        {
            listadoRelojes = new List<Reloj>();

            dtListado.Rows.Clear();

            listadoRelojes = frm.fabrica.ObtenerListado((EMarca)comboBoxMarca.SelectedItem);

            this.CargarDatatable(listadoRelojes);
        }

        /// <summary>
        /// Carga el DataTable.
        /// </summary>
        /// <param name="listadoRelojes"></param>
        private void CargarDatatable(List<Reloj> listadoRelojes)
        {
            foreach (Reloj r in listadoRelojes)
            {
                DataRow fila = this.dtListado.NewRow();

                fila[0] = r.Tipo;
                fila[1] = r.Marca;
                fila[2] = r.Modelo;
                fila[3] = r.Material;
                fila[4] = r.Hora;

                this.dtListado.Rows.Add(fila);
            }
            this.dgvRelojes.DataSource = this.dtListado;
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Si cambia el valor del comboBoxMarca llama al metodo filtrar para mostrar los cambios
        /// en el dataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxMarca_SelectedValueChanged(object sender, EventArgs e)
        {
            this.Filtrar();
        }

        /// <summary>
        /// Aborta el hilo antes de cerrar el Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormListado_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.hiloRefresh.Abort();
        }

        #endregion
    }
}
