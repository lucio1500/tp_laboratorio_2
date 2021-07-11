using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IReloj
    {
        #region Propiedades

        DateTime Hora { get; set; }

        string Modelo { get; set; }

        EMaterial Material { get; set; }

        EMarca Marca { get; set; }

        ETipo Tipo { get; }

        #endregion
    }
}
