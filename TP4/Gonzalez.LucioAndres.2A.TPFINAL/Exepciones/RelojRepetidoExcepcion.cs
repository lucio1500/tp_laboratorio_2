using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class RelojRepetidoExcepcion :Exception
    {
        public RelojRepetidoExcepcion(string mensaje) : base(mensaje)
        {

        }

        public RelojRepetidoExcepcion(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }
    }
}
