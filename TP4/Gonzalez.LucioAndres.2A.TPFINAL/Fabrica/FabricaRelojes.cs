using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public class FabricaRelojes: Fabrica
    {
        #region Atributos

        public int capacidad;
        public Relojes<Reloj> relojes; //Relojes sin acabar.

        #endregion

        #region Propiedades
        
        /// <summary>
        /// Devuelve la cantidad de relojes.
        /// </summary>
        public int Cantidad
        {
            get
            {
                return this.relojes.Count;
            }
        }

        /// <summary>
        /// Devuelve la capacidad de la fabrica.
        /// </summary>
        public int Capacidad
        {
            get
            {
                return this.capacidad;
            }
            set
            {
                this.capacidad = value;
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Contructor sin parametros que incializa Relojes y utiliza en contructor parametrizado de la clase Fabrica.
        /// </summary>
        public FabricaRelojes(): base("", EMaquinaria.Ligera)
        {
            this.relojes = new Relojes<Reloj>(EEstadoRelojes.EnFabricacion);
        }

        /// <summary>
        /// Contructor Parametrizado que inicializa Relojes asigna la capacidad, el nombre y la maquinaria.
        /// </summary>
        /// <param name="capacidad"></param>
        /// <param name="nombre"></param>
        public FabricaRelojes(int capacidad, string nombre) : base(nombre,EMaquinaria.Ligera)
        {
            this.relojes = new Relojes<Reloj>(EEstadoRelojes.EnFabricacion);
            this.capacidad = capacidad;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que simula el pulido de los relojes que no son de plastico.
        /// Solo se realizara si los relojes estan EnFabricacion y si hay por lo menos un reloj para pulir.
        /// </summary>
        /// <param name="fabrica"></param>
        /// <returns></returns>
        public string PulidoDeReloj(FabricaRelojes fabrica)
        {
            int relojesPulidos = 0;

            if(fabrica.relojes.EstadoRelojes==EEstadoRelojes.EnFabricacion && fabrica.Cantidad>0)
            {
                 foreach (Reloj r in fabrica.relojes)
                 {
                    if (r.Material != EMaterial.Plastico)
                        relojesPulidos++;
                 }

                if(relojesPulidos==fabrica.relojes.CountMaterial())
                {
                    fabrica.relojes.EstadoRelojes = EEstadoRelojes.Pulidos;
                    return "Relojes Pulidos con exito";
                }
            }            

            return "Los relojes NO fueron pulidos";
        }

        /// <summary>
        /// Metodo que establece el atributo hora de relojes en DateTime.Now, logrando asi que esten calibrados.
        /// Solo sera posible si los relojes antes fueron pulidos.
        /// </summary>
        /// <param name="fabrica"></param>
        /// <returns></returns>
        public string CalibrarRelojes(FabricaRelojes fabrica)
        {
            string ret;
            if(fabrica.relojes.EstadoRelojes==EEstadoRelojes.Pulidos)
            {
                foreach(Reloj r in fabrica.relojes)
                {
                r.Hora = DateTime.Now;
                }    
                
                fabrica.relojes.EstadoRelojes = EEstadoRelojes.Calibrados;
                ret = "Relojes Calibrados";
            }
            else
            {
                ret= "Antes de calibrar debe pulir los relojes.";
            }

            return ret;
        }

        /// <summary>
        /// Si los relojes fueron calibrados los agregara al atributo productos, cargando asi los relojes terminados.
        /// Tambien elimina los elementos del atributo relojes ya que tal atributo solo almacena los relojes en produccion.
        /// </summary>
        /// <param name="fabrica"></param>
        /// <returns></returns>
        public string Empaquetado(FabricaRelojes fabrica)
        {
            string ret;
            if (fabrica.relojes.EstadoRelojes == EEstadoRelojes.Calibrados)
            {                       
                foreach(Reloj r in fabrica.relojes)
                {
                    fabrica.productos.Add(r);
                }

                fabrica.relojes.EstadoRelojes = EEstadoRelojes.EnFabricacion;
                fabrica.relojes.Clear();
                ret = "Relojes Empaquetados exitosamente";
            }
            else
            {
                ret = "Antes de empaquetar debe calibrar los relojes.";
            }

            return ret;
        }

        /// <summary>
        /// Devuelve la cantidad de relojes acabados.
        /// </summary>
        /// <returns></returns>
        public int ProduccionDelDia()
        {
            return this.productos.Count;
        }

        /// <summary>
        /// Metodo que devuelve un informe con todos los datos de la fabrica y los relojes terminados en el dia
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.Mostrar());
            sb.AppendLine("Cantidad De Relojes hechos en el dia: " + this.ProduccionDelDia().ToString()+ "\n");
            sb.AppendLine("RELOJES TERMINADOS\n");
            sb.AppendLine(this.productos.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Devuelve un informe con todos los datos de la fabrica y los relojes terminados en el dia.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar();
        }
       
        /// <summary>
        /// Metodo que genera un xml de la fabrica.
        /// </summary>
        /// <param name="fabrica"></param>
        /// <returns></returns>
        public static bool Guardar(FabricaRelojes fabrica)
        {          
            try
            {
                if(fabrica.productos.Count > 0 || fabrica.Cantidad > 0)
                {
                    Xml<FabricaRelojes> xml = new Xml<FabricaRelojes>();

                    return xml.Guardar(Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"\FabricaRelojes.xml",fabrica);
                }

                return false;                
            }
            catch
            {
                throw new Exception("Error al guardar el archivo");
            }            
        }

        /// <summary>
        /// Metodo que lee un xml de la fabrica.
        /// </summary>
        /// <param name="fabrica"></param>
        /// <returns></returns>
        public static bool Leer(string path, out FabricaRelojes fabrica)
        {
            try
            {
                Xml<FabricaRelojes> auxiliarXml = new Xml<FabricaRelojes>();
                if (auxiliarXml.Leer(path, out fabrica))
                    return true;

                return false;
            }
            catch
            {
                throw new Exception("Error al leer el archivo.");
            }
        }

        /// <summary>
        /// Obtiene de la base de datos los relojes inteligentes, los reconstruye y los agrega a la fabrica.
        /// Esto se realiza para que a la hora de agregar un reloj nuevo no sea posible superar la capacidad
        /// o tener un Reloj Repetido.
        /// </summary>
        /// <param name="comando"></param>
        /// <param name="cn"></param>
        public void ObtenerRelojesInteligentes(SqlCommand comando, SqlConnection cn)
        {
            try
            {
                cn.Open();

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    RelojInteligente item = new RelojInteligente((EMarca)lector[2], lector[3].ToString(), (EPantalla)lector[6], lector.GetBoolean(7));

                    item.Hora = (DateTime)lector[5];

                    this.productos.Add(item);
                }

                lector.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }

        /// <summary>
        /// Obtiene de la base de datos los relojes pulsera, los reconstruye y los agrega a la fabrica.
        /// Esto se realiza para que a la hora de agregar un reloj nuevo no sea posible superar la capacidad
        /// o tener un Reloj Repetido.
        /// </summary>
        /// <param name="comando"></param>
        /// <param name="cn"></param>
        public void ObtenerRelojesPulsera(SqlCommand comando, SqlConnection cn)
        {
            try
            {
                cn.Open();

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    RelojPulsera item = new RelojPulsera((EMaterial)lector[4], (EMarca)lector[2], lector[3].ToString(), (EGama)lector[6]);

                    item.Hora = (DateTime)lector[5];

                    this.productos.Add(item);
                }

                lector.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Sobrecarga del operador de igualdad.
        /// Una FabricaRelojes sera igual a un Reloj siempre y cuando el reloj se encuentre dentro de la fabrica;
        /// para corroborar esto se recorre la lista generica de relojes y productos.
        /// </summary>
        /// <param name="fabrica"></param>
        /// <param name="reloj"></param>
        /// <returns></returns>
        public static bool operator ==(FabricaRelojes fabrica, Reloj reloj)
        {
            bool retorno = false;

            try
            {
                foreach (Reloj item in fabrica.relojes)
                {
                    if (reloj.Equals(item))
                    {
                        retorno = true;
                        break;
                    }
                }

                foreach (Reloj item in fabrica.productos)
                {
                    if (reloj.Equals(item))
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }

            return retorno;
        }

        /// <summary>
        /// Una FabricaRelojes sera distinta a un Reloj siempre que este reloj no se encuentre 
        /// en la fabrica.
        /// </summary>
        /// <param name="fabrica"></param>
        /// <param name="reloj"></param>
        /// <returns></returns>
        public static bool operator !=(FabricaRelojes fabrica, Reloj reloj)
        {
            return !(fabrica == reloj);
        }

        /// <summary>
        /// Sobrecarga de operador de adicion.
        /// Agregara el Reloj recibido siempre y cuando este NO se encuentre en la fabrica o haya lugar disponible.
        /// </summary>
        /// <param name="fabrica"></param>
        /// <param name="reloj"></param>
        /// <returns></returns>
        public static FabricaRelojes operator +(FabricaRelojes fabrica, Reloj reloj)
        {
            if (fabrica == reloj)
            {
                throw new RelojRepetidoExcepcion("Reloj Repetido");
            }
            else if (fabrica.Cantidad < fabrica.capacidad && fabrica.relojes.EstadoRelojes == EEstadoRelojes.EnFabricacion)
            {
                fabrica.relojes.Add(reloj);
            }
            else if (fabrica.relojes.Count + fabrica.productos.Count >= fabrica.capacidad)
            {
                throw new CapacidadExcepcion("No hay mas espacio en la fabrica!!!");
            }
            else if(fabrica.relojes.EstadoRelojes != EEstadoRelojes.EnFabricacion)
            {
                throw new Exception("No se puede agregar un reloj mientras se estan produciendo los anteriores!!!." +
                        "\n Primero debe terminar de Pulir, Calibrar o Empaquetar.");
            }

            return fabrica;
        }

        /// <summary>
        /// Sobrecarga de operador de sustraccion.
        /// Remueve el Reloj recibido siempre y cuando este se encuentre en la fabrica.
        /// </summary>
        /// <param name="fabrica"></param>
        /// <param name="reloj"></param>
        /// <returns></returns>
        public static FabricaRelojes operator -(FabricaRelojes fabrica, Reloj reloj)
        {
            if (fabrica == reloj)
            {
                fabrica.relojes.Remove(reloj);
            }
            else
            {
                throw new Exception("El Reloj no esta en la Fabrica!!!\n");
            }

            return fabrica;
        }

        #endregion
    }
}
