using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Entidades
{
    [XmlInclude(typeof(Relojes<Reloj>))]

    public class Productos<T> where T :class
    {
        #region Atributos

        protected List<T> productos;

        #endregion

        #region Propiedades

        public int Count 
        { 
            get 
            { 
                return this.productos.Count;
            } 
        }

        public List<T> ProductosAlmacenados 
        { 
            get 
            { 
                return this.productos; 
            } 
            
            set
            { 
                this.productos = value;
            } 
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constuctor sin paramtetros de Productos.
        /// </summary>
        public Productos()
        {
            this.productos = new List<T>();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Limpia todos los elementos dentro del atributo productos. 
        /// </summary>
        public void Clear()
        {
            this.productos.Clear();
        }

        /// <summary>
        /// Agrega un elemento al atributo productos.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool Add(T a)
        {
            return this + a;
        }

        /// <summary>
        /// Elimina un elemento al atributo productos.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool Remove(T a)
        {
            return this - a;
        }

        /// <summary>
        /// Devuelve una cadena con todos los elementos dentro de productos.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T a in this.productos)
            {
                sb.AppendLine(a.ToString());
            }

            return sb.ToString();
        }
        
        /// <summary>
        /// Metodo necesario para poder recorrer productos con un foreach.
        /// </summary>
        /// <returns></returns>
        public List<T>.Enumerator GetEnumerator()
        {
            return this.productos.GetEnumerator();
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Elimina un elemento del atributo productos siempre y cuando este se encuentre.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator -(Productos<T> d, T a)
        {
            foreach (T obj in d.productos)
            {
                if (obj == a)
                {
                    d.productos.Remove(a);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Agrega un elemento al atributo productos siempre y cuando este NO se encuentre. 
        /// </summary>
        /// <param name="d"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator +(Productos<T> d, T a)
        {
            foreach (T obj in d.productos)
            {
                if (obj.Equals(a))
                return false;
            }
          
            d.productos.Add(a);

            return true;
        }

        #endregion
    }
}
