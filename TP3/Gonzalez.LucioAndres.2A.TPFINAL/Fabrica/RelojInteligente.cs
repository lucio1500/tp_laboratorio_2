using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Entidades
{
    public class RelojInteligente :Reloj
    {
        #region Atributos

        EPantalla pantalla;
        bool resistenciaAgua;

        #endregion

        #region Propiedades

        public EPantalla Pantalla 
        { 
            get 
            { 
                return this.pantalla; 
            } 
            
            set 
            { 
                this.pantalla = value; 
            } 
        }

        public bool ResistenciaAgua 
        { 
            get 
            { 
                return this.resistenciaAgua; 
            } 
            
            set 
            { 
                this.resistenciaAgua = value; 
            } 
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor sin parametros.
        /// Necesario para serializar.
        /// </summary>
        public RelojInteligente():base()
        {

        }

        /// <summary>
        /// Constructor parametrizado que llama al constructor parametrizado de Reloj  
        /// y asigna los parametros recibidos en los atributos propios.
        /// </summary>
        /// <param name="hora"></param>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="pantalla"></param>
        /// <param name="resistenciaAgua"></param>
        public RelojInteligente(EMarca marca, string modelo, EPantalla pantalla, bool resistenciaAgua) 
            :base(ETipo.Inteligente,EMaterial.Plastico,marca,modelo)
        {
            this.pantalla = pantalla;
            this.resistenciaAgua = resistenciaAgua;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Sobrecarga del metodo Mostrar que devuelve una cadena con todos los datos de RelojInteligente.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.Mostrar());
            sb.AppendLine("Pantalla: " + this.pantalla.ToString());
            sb.AppendLine("Es resistente al agua: (true = si, false = no): " + this.resistenciaAgua.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del ToString que devuelve una cadena con los datos de RelojInteligente.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar();
        }

        #endregion
    }
}
