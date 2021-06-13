using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

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
            sb.AppendLine("RELOJES\n");
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
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
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
                Console.WriteLine(e.Message);
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
                Console.WriteLine("El Reloj ya esta en la Fabrica!!!\n");
            }
            else if (fabrica.Cantidad + fabrica.productos.Count < fabrica.capacidad && fabrica.relojes.EstadoRelojes == EEstadoRelojes.EnFabricacion)
            {
                fabrica.relojes.Add(reloj);
            }
            else if (fabrica.relojes.Count + fabrica.productos.Count >= fabrica.capacidad)
            {
                Console.WriteLine("No hay mas lugar en la Fabrica!!!\n");
            }
            else if(fabrica.relojes.EstadoRelojes != EEstadoRelojes.EnFabricacion)
            {
                Console.WriteLine("No se puede agregar un reloj mientras se entan produciendo los anteriores!!!\n");
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
                Console.WriteLine("El Reloj no esta en la Fabrica!!!\n");
            }

            return fabrica;
        }

        #endregion
    }
}
