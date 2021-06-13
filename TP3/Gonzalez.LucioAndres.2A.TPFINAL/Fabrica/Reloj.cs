using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Entidades
{
    [XmlInclude(typeof(RelojInteligente))]
    [XmlInclude(typeof(RelojPulsera))]

    public abstract class Reloj :IMostrar, IReloj
    {
        #region Atributos

        ETipo tipo;
        DateTime hora;
        EMaterial material;
        EMarca marca;
        string modelo;

        #endregion

        #region Propiedades

        public DateTime Hora 
        { 
            get 
            { 
                return this.hora; 
            } 
            
            set 
            { 
                this.hora = value; 
            } 
        }

        public string Modelo 
        { 
            get 
            { 
                return this.modelo;  
            } 
            
            set 
            { 
                this.modelo = value; 
            } 
        }

        public EMaterial Material 
        { 
            get 
            { 
                return this.material; 
            } 
            
            set 
            { 
                this.material = value; 
            } 
        }

        public EMarca Marca 
        { 
            get 
            { 
                return this.marca; 
            } 
            
            set 
            { 
                this.marca = value; 
            } 
        }

        public ETipo Tipo 
        { 
            get 
            { 
                return this.tipo; 
            } 
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor sin parametros de Reloj, inializa el campo hora en DateTime.MinValue
        /// </summary>
        public Reloj()
        {
            this.hora = DateTime.MinValue;
        }

        /// <summary>
        /// Constructor parametrizado de Reloj donde se asignan el tipo, hora, material, marca y modelo recibidos en sus respectivos atributos.
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="hora"></param>
        /// <param name="material"></param>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        public Reloj(ETipo tipo,EMaterial material, EMarca marca, string modelo) :this()
        {
            this.tipo = tipo;
            this.material = material;
            this.marca = marca;
            this.modelo = modelo;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que devuelve un string con todos los datos de Reloj.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("RELOJ");
            sb.AppendLine("Tipo: " + this.Tipo.ToString());
            sb.AppendLine("Marca: " + this.marca.ToString());
            sb.AppendLine("Modelo: " + this.modelo);
            sb.AppendLine("Material: " + this.material.ToString());
            sb.AppendLine("Hora: " + this.Hora.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Metodo que devuelve un string con todos los datos de Reloj.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar(); 
        }

        /// <summary>
        /// Sobrecarga del Equals donde se reutiliza el == de Reloj.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj != null && obj is Reloj && this == (Reloj)obj;
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Dos objetos de tipo Reloj solo seran igual si poseen la misma marca y modelo.
        /// </summary>
        /// <param name="relojA"></param>
        /// <param name="relojB"></param>
        /// <returns></returns>
        public static bool operator ==(Reloj relojA, Reloj relojB)
        {
            return relojA.marca == relojB.marca && relojA.modelo == relojB.modelo;
        }

        /// <summary>
        /// Dos objetos de tipo Reloj seran distintos si NO poseen la misma marca y modelo.
        /// </summary>
        /// <param name="relojA"></param>
        /// <param name="relojB"></param>
        /// <returns></returns>
        public static bool operator !=(Reloj relojA, Reloj relojB)
        {
            return !(relojA == relojB);
        }

        #endregion
    }
}
