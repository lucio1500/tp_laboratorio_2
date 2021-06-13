using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Entidades
{
    public class RelojPulsera : Reloj
    {
        #region Atributos

        EGama gama;

        #endregion

        #region Propiedades

        public EGama Gama 
        { 
            get 
            { 
                return this.gama; 
            } 

            set 
            { 
                this.gama = value; 
            } 
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor sin parametros.
        /// Necesario para serializar.
        /// </summary>
        public RelojPulsera() : base()
        {

        }

        /// <summary>
        /// Constructor parametrizado que llama al constructor parametrizado de Reloj  
        /// y asigna los parametros recibidos en los atributos propios.
        /// </summary>
        /// <param name="hora"></param>
        /// <param name="material"></param>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="gama"></param>
        public RelojPulsera(EMaterial material,EMarca marca, string modelo, EGama gama) : base(ETipo.Pulsera,material,marca,modelo)
        {
            this.gama = gama;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Sobrecarga del metodo Mostrar que devuelve una cadena con todos los datos de RelojPulsera.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.Mostrar());
            sb.AppendLine("Gama: " + this.gama.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del ToString que devuelve una cadena con los datos de RelojPulsera.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar();
        }

        #endregion        
    }
}
