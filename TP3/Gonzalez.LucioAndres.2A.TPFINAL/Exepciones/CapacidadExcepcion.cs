using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class CapacidadExcepcion :Exception
    {
        public CapacidadExcepcion(string mensaje) : base(mensaje)
        {

        }

        public CapacidadExcepcion(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}
