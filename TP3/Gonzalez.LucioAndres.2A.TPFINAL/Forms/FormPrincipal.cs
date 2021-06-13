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
using Excepciones;


namespace Forms
{
    public partial class FormPrincipal : Form
    {
        protected DataTable dtInteligente;
        protected DataTable dtPulsera;
        protected DataTable dtInteligentesTerminados;
        protected DataTable dtPulseraTerminados;
        protected FabricaRelojes fabrica;

        public FormPrincipal()
        {
            InitializeComponent();

            try
            {
                this.fabrica = new FabricaRelojes(100, "Fabrica De Relojes");

                this.labelEstado.Text = this.fabrica.relojes.EstadoRelojes.ToString();
                this.lblTerminados.Text = this.fabrica.ProduccionDelDia().ToString();
                this.lblCapacidad.Text = this.fabrica.capacidad.ToString();

                this.ConfigurarDataTableInteligente();
                this.ConfigurarDataTablePulsera();

                this.dgvGrillaInteligente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dgvGrillaPulsera.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                this.dgvInteligentesTerminados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dgvPulseraTerminados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                this.dgvGrillaInteligente.DataSource = this.dtInteligente;
                this.dgvGrillaPulsera.DataSource = this.dtPulsera;

                this.dgvInteligentesTerminados.DataSource = this.dtInteligentesTerminados;
                this.dgvPulseraTerminados.DataSource = this.dtPulseraTerminados;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        #region DataTable

        /// <summary>
        /// Configuracion de DataTable.
        /// </summary>
        /// <returns></returns>
        private DataTable ConfigurarDataTable()
        {
            DataTable dt = new DataTable("Fabrica De Relojes");

            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("tipo", typeof(ETipo));
            dt.Columns.Add("marca", typeof(EMarca));
            dt.Columns.Add("modelo", typeof(string));
            dt.Columns.Add("material", typeof(EMaterial));
            dt.Columns.Add("hora", typeof(string));

            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementSeed = 1;
            dt.Columns["id"].AutoIncrementStep = 1;           

            return dt;
        }

        /// <summary>
        /// Configuracion de DataTable para RelojInteligente.
        /// </summary>
        private void ConfigurarDataTableInteligente()
        {
            this.dtInteligente = this.ConfigurarDataTable();
            this.dtInteligentesTerminados = this.ConfigurarDataTable();

            this.dtInteligente.Columns.Add("pantalla", typeof(EPantalla));
            this.dtInteligente.Columns.Add("resistencia al agua", typeof(bool));
            this.dtInteligentesTerminados.Columns.Add("pantalla", typeof(EPantalla));
            this.dtInteligentesTerminados.Columns.Add("resistencia al agua", typeof(bool));
        }

        /// <summary>
        /// Configuracion de DataTable para RelojPulsera.
        /// </summary>
        private void ConfigurarDataTablePulsera()
        {
            this.dtPulsera = this.ConfigurarDataTable();
            this.dtPulseraTerminados = this.ConfigurarDataTable();

            this.dtPulsera.Columns.Add("gama", typeof(EGama));
            this.dtPulseraTerminados.Columns.Add("gama", typeof(EGama));
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Alta de un nuevo RelojInteligente.
        /// Solo se puede dar de alta si los relojes cargados anteriormente no empezaron su produccion.
        /// En otras palabras solo si el EEstadoRelojes es igual a EnFabricacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAltaRelojInteligente_Click(object sender, EventArgs e)
        {
            FormAltaInteligente frm = new FormAltaInteligente();
            frm.StartPosition = FormStartPosition.CenterScreen;

            try
            {
                if (this.fabrica.relojes.EstadoRelojes == EEstadoRelojes.EnFabricacion)
                {
                        if(frm.ShowDialog() == DialogResult.OK)
                        {
                            if (this.fabrica != frm.reloj && this.fabrica.Cantidad + this.fabrica.productos.Count < this.fabrica.capacidad)
                            {
                                this.fabrica += frm.reloj;
                                DataRow fila = this.dtInteligente.NewRow();

                                fila[1] = frm.reloj.Tipo;
                                fila[2] = frm.reloj.Marca;
                                fila[3] = frm.reloj.Modelo;
                                fila[4] = frm.reloj.Material;
                                fila[5] = frm.reloj.Hora;
                                fila[6] = frm.reloj.Pantalla;
                                fila[7] = frm.reloj.ResistenciaAgua;

                                this.dtInteligente.Rows.Add(fila);
                            }
                            else if (this.fabrica == frm.reloj)
                            {
                                throw new RelojRepetidoExcepcion("Reloj Repetido");
                            }
                            else if (this.fabrica.Cantidad + this.fabrica.productos.Count >= this.fabrica.Capacidad)
                            {
                            throw new CapacidadExcepcion("No hay mas espacio en la fabrica!!!");
                            }
                    }

                }
                else
                {
                    MessageBox.Show("No se puede agregar un reloj mientras se estan produciendo los anteriores!!!." +
                        "\n Primero debe terminar de Pulir, Calibrar o Empaquetar.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        /// <summary>
        /// Alta de un nuevo RelojPulsera.
        /// Solo se puede dar de alta si los relojes cargados anteriormente no empezaron su produccion.
        /// En otras palabras solo si el EEstadoRelojes es igual a EnFabricacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAltaRelojPulsera_Click(object sender, EventArgs e)
        {
            FormAltaPulsera frm = new FormAltaPulsera();
            frm.StartPosition = FormStartPosition.CenterScreen;
            try
            {
                if (this.fabrica.relojes.EstadoRelojes == EEstadoRelojes.EnFabricacion)
                {
                    if(frm.ShowDialog() == DialogResult.OK)
                    {
                        if (this.fabrica != frm.reloj && this.fabrica.Cantidad + this.fabrica.productos.Count < this.fabrica.capacidad)
                        {
                            this.fabrica += frm.reloj;
                            DataRow fila = this.dtPulsera.NewRow();

                            fila[1] = frm.reloj.Tipo;
                            fila[2] = frm.reloj.Marca;
                            fila[3] = frm.reloj.Modelo;
                            fila[4] = frm.reloj.Material;
                            fila[5] = frm.reloj.Hora;
                            fila[6] = frm.reloj.Gama;

                            this.dtPulsera.Rows.Add(fila);
                        }
                        else if (this.fabrica == frm.reloj)
                        {
                            throw new RelojRepetidoExcepcion("Reloj Repetido");
                        }
                        else if (this.fabrica.Cantidad + this.fabrica.productos.Count >= this.fabrica.Capacidad)
                        {
                            throw new CapacidadExcepcion("No hay mas espacio en la fabrica!!!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se puede agregar un reloj mientras se estan produciendo los anteriores!!!." +
                        "\n Primero debe terminar de Pulir, Calibrar o Empaquetar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Llama la metodo PulidoDeReloj de FabricaRelojes y actualiza el label de Estado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPulirRelojes_Click(object sender, EventArgs e)
        {
            if (this.fabrica.relojes.EstadoRelojes == EEstadoRelojes.EnFabricacion && this.fabrica.Cantidad>0)
            {
                MessageBox.Show(this.fabrica.PulidoDeReloj(this.fabrica)); 
                this.labelEstado.Text = this.fabrica.relojes.EstadoRelojes.ToString();
            }
            else if(this.fabrica.Cantidad==0)
            {
                MessageBox.Show("Para pulir los relojes debe haber al menos uno");
            }
            else
            {
                MessageBox.Show("Para pulir los relojes debe terminar de producir los anteriores");
            }
        }

        /// <summary>
        /// Calibra los relojes de la fabrica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalibrarRelojes_Click(object sender, EventArgs e)
        {
            if (this.fabrica.relojes.EstadoRelojes == EEstadoRelojes.Pulidos)
            {                
                MessageBox.Show(this.fabrica.CalibrarRelojes(this.fabrica));

                this.Actualizar();

                this.labelEstado.Text = this.fabrica.relojes.EstadoRelojes.ToString();
            }
            else
            {
                MessageBox.Show("Para calibrar los relojes primero debe pulirlos.");
            }
        }

        /// <summary>
        /// Llama al metodo Empaquetar de FabricaRelojes.
        /// Limpia los DataGridView de los relojes y estos pasan a los DataGridView terminados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmpaquetarRelojes_Click(object sender, EventArgs e)
        {
            if(this.fabrica.relojes.EstadoRelojes==EEstadoRelojes.Calibrados)
            {
                this.CargarDataTableTerminados();

                this.dgvInteligentesTerminados.DataSource = this.dtInteligentesTerminados;
                this.dgvPulseraTerminados.DataSource = this.dtPulseraTerminados;

                MessageBox.Show(this.fabrica.Empaquetado(this.fabrica));

                this.dtInteligente.Rows.Clear();
                this.dtPulsera.Rows.Clear();

                
                this.labelEstado.Text = this.fabrica.relojes.EstadoRelojes.ToString();
                this.lblTerminados.Text = this.fabrica.ProduccionDelDia().ToString();
            }
            else
            {
                MessageBox.Show("Para empaquetar los relojes primero debe calibrarlos.");
            }
        }

        /// <summary>
        /// Genera un XMl con los datos de la fabrica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerarXml_Click(object sender, EventArgs e)
        {
            if(FabricaRelojes.Guardar(this.fabrica))
            {
                MessageBox.Show("XML generado exitosamente.");
            }
            else
            {
                MessageBox.Show("NO se pudo generar el XML.");
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Carga los DataTable de los relojes terminados. 
        /// Es decir que ya fueron pulidos, calibrados y empaquetados.
        /// </summary>
        private void CargarDataTableTerminados()
        {
            foreach(DataRow fila in dtInteligente.Rows)
            {
                this.dtInteligentesTerminados.ImportRow(fila);
            }
            foreach (DataRow fila in dtPulsera.Rows)
            {
                this.dtPulseraTerminados.ImportRow(fila);
            }
        }

        /// <summary>
        /// Actualiza la columna hora.
        /// </summary>
        private void Actualizar()
        {
            foreach (DataRow fila in dtInteligente.Rows)
            {
                fila[5] = DateTime.Now;
            }
            foreach (DataRow fila in dtPulsera.Rows)
            {
                fila[5] = DateTime.Now;
            }
        }

        #endregion
    }
}
