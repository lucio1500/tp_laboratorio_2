using Entidades;
using Excepciones;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Forms
{
    public partial class FormPrincipal : Form
    {

        #region Atributos

            #region Delegado y Evento.

            protected delegate void Evento(object sender, EventArgs e);
            protected event Evento Producir;

            #endregion

            #region Datatables

            protected DataTable dtInteligente;
            protected DataTable dtPulsera;
            protected DataTable dtInteligentesTerminados;
            protected DataTable dtPulseraTerminados;

            #endregion

            #region Base De Datos

            protected SqlConnection conexion;
            protected SqlDataAdapter daInteligente;
            protected SqlDataAdapter daPulsera;

            #endregion            

            protected Thread hilo;
            protected FormListado frmListado;
            public FabricaRelojes fabrica;

        #endregion

        public FormPrincipal()
        {
            InitializeComponent();

            try
            {
                this.fabrica = new FabricaRelojes(2, "Fabrica De Relojes");
                this.hilo = new Thread(MostrarFormListado);

                this.Producir += btnPulirRelojes_Click;
                this.Producir += btnCalibrarRelojes_Click;
                this.Producir += btnEmpaquetarRelojes_Click;

                this.dgvGrillaInteligente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dgvGrillaPulsera.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                this.dgvInteligentesTerminados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dgvPulseraTerminados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                this.lblCapacidad.Text = this.fabrica.capacidad.ToString();
                this.labelEstado.Text = this.fabrica.relojes.EstadoRelojes.ToString();                             

                this.ConfigurarDataTableInteligente();
                this.ConfigurarDataTablePulsera();
                this.ConfigurarDataAdapter();
                this.fabrica.ObtenerRelojesInteligentes(this.daInteligente.SelectCommand, conexion);
                this.fabrica.ObtenerRelojesPulsera(this.daPulsera.SelectCommand, conexion);

                this.lblTerminados.Text = this.fabrica.ProduccionDelDia().ToString();

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

        /// <summary>
        /// Aborta los posibles hilos que estan vivos antes de cerrar el form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.hilo.Abort();
            if (frmListado != null && frmListado.hiloRefresh.IsAlive)
                frmListado.hiloRefresh.Abort();
        }

        #region DataAdapter

        /// <summary>
        /// Configuracion de los Data Adapter del Form.
        /// </summary>
        /// <returns></returns>
        private bool ConfigurarDataAdapter()
        {
            bool rta = false;

            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.Conexion);

                this.daInteligente = new SqlDataAdapter();
                this.daPulsera = new SqlDataAdapter();

                this.daInteligente.SelectCommand = new SqlCommand("SELECT * FROM FabricaRelojes.dbo.RelojInteligente", conexion);

                this.daInteligente.InsertCommand = new SqlCommand("INSERT INTO FabricaRelojes.dbo.RelojInteligente (tipo, marca, modelo, material, hora, pantalla, resistencia) " +
                    "VALUES (@tipo, @marca, @modelo, @material, @hora, @pantalla, @resistencia)", conexion);

                this.daInteligente.UpdateCommand = new SqlCommand("UPDATE FabricaRelojes.dbo.RelojInteligente " +
                    "SET tipo=@tipo, marca=@marca, modelo=@modelo, material=@material, hora=@hora, pantalla=@pantalla, resistencia=@resistencia WHERE id=@id", conexion);

                this.daPulsera.SelectCommand = new SqlCommand("SELECT * FROM FabricaRelojes.dbo.RelojPulsera", conexion);

                this.daPulsera.InsertCommand = new SqlCommand("INSERT INTO FabricaRelojes.dbo.RelojPulsera (tipo, marca, modelo, material, hora, gama) " +
                    "VALUES (@tipo, @marca, @modelo, @material, @hora, @gama)", conexion);

                this.daPulsera.UpdateCommand = new SqlCommand("UPDATE FabricaRelojes.dbo.RelojPulsera " +
                    "SET tipo=@tipo, marca=@marca, modelo=@modelo, material=@material, hora=@hora, gama=@gama", conexion);

                ConfigurarSqlAdapter(this.daInteligente);
                ConfigurarSqlAdapter(this.daPulsera);

                this.daInteligente.InsertCommand.Parameters.Add("@pantalla", SqlDbType.Int, 10, "pantalla");
                this.daInteligente.InsertCommand.Parameters.Add("@resistencia", SqlDbType.Bit, 5, "resistencia");
                this.daInteligente.UpdateCommand.Parameters.Add("@pantalla", SqlDbType.Int, 10, "pantalla");
                this.daInteligente.UpdateCommand.Parameters.Add("@resistencia", SqlDbType.Bit, 5, "resistencia");

                this.daPulsera.InsertCommand.Parameters.Add("@gama", SqlDbType.Int, 10, "gama");
                this.daPulsera.UpdateCommand.Parameters.Add("@gama", SqlDbType.Int, 50, "gama");         

                this.daInteligente.Fill(this.dtInteligentesTerminados);
                this.dgvGrillaInteligente.DataSource = this.dtInteligentesTerminados;
                if(ObtenerId(this.dtInteligentesTerminados)>-1)
                this.dtInteligente.Columns["id"].AutoIncrementSeed = ObtenerId(this.dtInteligentesTerminados)+1;             

                this.daPulsera.Fill(this.dtPulseraTerminados);
                this.dgvGrillaPulsera.DataSource = this.dtPulseraTerminados;
                if(ObtenerId(this.dtPulseraTerminados)>-1)
                this.dtPulsera.Columns["id"].AutoIncrementSeed = ObtenerId(this.dtPulseraTerminados)+1;

                rta = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return rta;
        }

        /// <summary>
        /// Metodo que configura un SqlDataAdapter con los datos de un Reloj.
        /// </summary>
        /// <param name="dataAdapter"></param>
        void ConfigurarSqlAdapter(SqlDataAdapter dataAdapter)
        {
            dataAdapter.InsertCommand.Parameters.Add("@tipo", SqlDbType.Int, 10, "tipo");
            dataAdapter.InsertCommand.Parameters.Add("@marca", SqlDbType.Int, 10, "marca");
            dataAdapter.InsertCommand.Parameters.Add("@modelo", SqlDbType.VarChar, 50, "modelo");
            dataAdapter.InsertCommand.Parameters.Add("@material", SqlDbType.Int, 10, "material");
            dataAdapter.InsertCommand.Parameters.Add("@hora", SqlDbType.DateTime, 50, "hora");

            dataAdapter.UpdateCommand.Parameters.Add("@tipo", SqlDbType.Int, 50, "tipo");
            dataAdapter.UpdateCommand.Parameters.Add("@marca", SqlDbType.Int, 10, "marca");
            dataAdapter.UpdateCommand.Parameters.Add("@modelo", SqlDbType.VarChar, 50, "modelo");
            dataAdapter.UpdateCommand.Parameters.Add("@material", SqlDbType.Int, 50, "material");
            dataAdapter.UpdateCommand.Parameters.Add("@hora", SqlDbType.DateTime, 50, "hora");
        }

        #endregion 

        #region DataTable

        /// <summary>
        /// Configuracion de DataTable.
        /// </summary>
        /// <returns></returns>
        public DataTable ConfigurarDataTable()
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
            this.dtInteligente.Columns.Add("resistencia", typeof(bool));
            this.dtInteligentesTerminados.Columns.Add("pantalla", typeof(EPantalla));
            this.dtInteligentesTerminados.Columns.Add("resistencia", typeof(bool));
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
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (this.fabrica != frm.reloj && this.fabrica.Cantidad < this.fabrica.capacidad)
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
                        else if (this.fabrica.Cantidad >= this.fabrica.Capacidad)
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
            catch (CapacidadExcepcion ex)
            {
                DialogResult respuesta = MessageBox.Show("¿Desea liberar el espacio?", ex.Message, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {
                    this.Producir(sender, e);
                }
            }
            catch (Exception ex)
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
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (this.fabrica != frm.reloj && this.fabrica.Cantidad < this.fabrica.capacidad)
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
                        else if (this.fabrica.Cantidad >= this.fabrica.Capacidad)
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
            catch(CapacidadExcepcion ex)
            {
                DialogResult respuesta = MessageBox.Show("¿Desea liberar el espacio?", ex.Message, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if(respuesta==DialogResult.Yes)
                {
                    this.Producir(sender, e);
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
            if (this.fabrica.relojes.EstadoRelojes == EEstadoRelojes.EnFabricacion && this.fabrica.Cantidad > 0)
            {
                MessageBox.Show(this.fabrica.PulidoDeReloj(this.fabrica));
                this.labelEstado.Text = this.fabrica.relojes.EstadoRelojes.ToString();
            }
            else if (this.fabrica.Cantidad == 0)
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
            if (this.fabrica.relojes.EstadoRelojes == EEstadoRelojes.Calibrados)
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
        /// Genera un XMl con los datos de la fabrica, y los archivos XML de los datatables.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerarXml_Click(object sender, EventArgs e)
        {
            try
            {
                if (FabricaRelojes.Guardar(this.fabrica))
                {
                    MessageBox.Show("XML generado exitosamente.");
                }
                else
                {
                    MessageBox.Show("NO se pudo generar el XML.");
                }
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Lee un XMl con los datos de la fabrica y los archivos XML de los datatables.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeerXml_Click(object sender, EventArgs e)
        {
            FabricaRelojes fabricaRelojes = new FabricaRelojes();
            try
            {
                if (FabricaRelojes.Leer(Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"\FabricaRelojes.xml",out fabricaRelojes))
                {
                    MessageBox.Show(fabricaRelojes.ToString(), "XML Cargado Exitosamente");
                }
                else
                {
                    MessageBox.Show("NO se pudo Cargar el XML.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Guarda en la base de datos los relojes terminados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.daInteligente.Update(this.dtInteligentesTerminados);
                this.daPulsera.Update(this.dtPulseraTerminados);

                MessageBox.Show("Relojes Guardados con exito!!!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Al hacer click en el boton se crea un nuevo hilo en caso de no estar iniciado.
        /// Este hilo sera el en encargado de abrir el FormListado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListado_Click(object sender, EventArgs e)
        {
            if (!this.hilo.IsAlive)
            {
                this.hilo = new Thread(MostrarFormListado);
                this.hilo.Start();
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
            foreach (DataRow fila in dtInteligente.Rows)
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

        /// <summary>
        /// Metodo que Crea un FormListado y lo muestra.
        /// </summary>
        private void MostrarFormListado()
        {
            frmListado = new FormListado(this);
            frmListado.StartPosition = FormStartPosition.CenterScreen;
            frmListado.ShowDialog();
        }

        /// <summary>
        /// Obtiene el ultimo id de un dataTable si es que existe.
        /// Caso contrario devuelve -1.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        int ObtenerId(DataTable dataTable)
        {
            int index = -1;
            foreach(DataRow row in dataTable.Rows)
            {
                index=int.Parse(row["id"].ToString());
            }
            return index;
        }

        #endregion
    }
}
