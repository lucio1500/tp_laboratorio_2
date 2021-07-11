using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Excepciones;
using Archivos;
using Extension;


namespace Extension
{
    public static class ClaseExtension
    {
        /// <summary>
        /// Obtiene la lista de relojes que son de la misma marca. 
        /// Independientemente de si estan terminados o en fabricacion.
        /// </summary>
        /// <param name="fabrica"></param>
        /// <param name="reloj"></param>
        /// <returns></returns>
        public static List<Reloj> ObtenerListado(this FabricaRelojes fabrica, EMarca marca)
        {
           List<Reloj> fabricaRelojes = new List<Reloj>();
            foreach(Reloj r in fabrica.relojes)
            {
                if (r.Marca == marca)
                    fabricaRelojes.Add(r);
                
            }

            foreach (Reloj r in fabrica.productos)
            {
                if (r.Marca == marca)
                    fabricaRelojes.Add(r);
            }

            return fabricaRelojes;
        }
    }
}
