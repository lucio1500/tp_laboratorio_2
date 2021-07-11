using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Entidades
{
    public abstract class Fabrica: IMostrar
    {
        #region Atributos

        protected string nombre;
        protected EMaquinaria maquinaria;
        public Productos<object> productos; //En este caso almacena los relojes acabados.

        #endregion

        #region Propiedades

        public string Nombre 
        {
            get
            {
                return this.nombre;
            }

            set 
            {
                this.nombre = value;
            }
        }

        public EMaquinaria Maquinaria
        {
            get
            {
                return this.maquinaria;
            }

            set 
            {
                this.maquinaria = value;
            } 
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor sin parametros que inicializa Productos.
        /// </summary>
        public Fabrica()
        {
            this.productos = new Productos<object>();
        }

        /// <summary>
        /// Constructor Parametrizado que recibe nombre y maquinaria para luego asignarlos.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="maquinaria"></param>
        public Fabrica(string nombre, EMaquinaria maquinaria) :this()
        {
            this.nombre = nombre;
            this.maquinaria = maquinaria;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que devuelve un string con todos los datos de Fabrica.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Nombre de la Fabrica: " + this.nombre);
            sb.AppendLine("Tipo de Maquinaria que se utiliza: " + this.maquinaria.ToString());

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
        /// Retornara true si el obj recibido es de tipo Fabrica y es igual al objeto fabrica que invoco el Equals.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj != null && obj is Fabrica && this == (Fabrica)obj;
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Dos Fabricas seran iguales si comparten el nombre y la maquinaria
        /// </summary>
        /// <param name="fabricaA"></param>
        /// <param name="fabricaB"></param>
        /// <returns></returns>
        public static bool operator ==(Fabrica fabricaA, Fabrica fabricaB)
        {
            return fabricaA.nombre==fabricaB.nombre && fabricaA.maquinaria==fabricaB.maquinaria;
        }

        /// <summary>
        /// Dos Fabricas seran distintas si no tienen el mismo nombre y maquinaria.
        /// </summary>
        /// <param name="fabricaA"></param>
        /// <param name="fabricaB"></param>
        /// <returns></returns>
        public static bool operator !=(Fabrica fabricaA, Fabrica fabricaB)
        {
            return !(fabricaA == fabricaB);
        }

        #endregion
    }
}
