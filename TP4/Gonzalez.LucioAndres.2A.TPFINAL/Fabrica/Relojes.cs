using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Entidades
{
    public class Relojes<T> : Productos<T> where T : Reloj
    {
        #region Atributos

        EEstadoRelojes estadoRelojes;

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad que retorna el estado de los relojes.
        /// </summary>
        public EEstadoRelojes EstadoRelojes 
        { 
            get
            { 
                return this.estadoRelojes; 
            } 
            
            set 
            { 
                this.estadoRelojes = value; 
            } 
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor sin parametros.
        /// </summary>
        public Relojes() : base()
        {

        }

        /// <summary>
        /// Constuctor parametrizado que asigna EEstadoRelojes.
        /// </summary>
        /// <param name="estadoRelojes"></param>
        public Relojes(EEstadoRelojes estadoRelojes) :this()
        {
            this.estadoRelojes = estadoRelojes;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que retorna la cantidad de relojes que no son de plastico.
        /// </summary>
        /// <returns></returns>
        public int CountMaterial()
        {
            int contador = 0;
            foreach (Reloj r in this.productos)
            {
                if(r.Material!=EMaterial.Plastico)
                {
                    contador++;
                }
            }
            return contador;
        }

        #endregion
    }
}
