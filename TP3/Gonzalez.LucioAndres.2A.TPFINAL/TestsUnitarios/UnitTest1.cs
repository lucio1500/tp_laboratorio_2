using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestsUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Verifica que los relojes cambien su estado a calibrados.
        /// </summary>
        [TestMethod]
        public void CalibrarRelojes()
        {
            bool rta;
            RelojInteligente reloj = new RelojInteligente(EMarca.Rolex, "ModelPrueba", EPantalla.LED, false);
            FabricaRelojes fabrica = new FabricaRelojes(1, "FABRICA");

            fabrica += reloj; //si no agrego ningun reloj no sera posible pulir, ya que no habria ningun reloj que pulir.

            fabrica.PulidoDeReloj(fabrica); //Si no se pulen los relojes no se pueden calibrar
            fabrica.CalibrarRelojes(fabrica);

            rta = fabrica.relojes.EstadoRelojes == EEstadoRelojes.Calibrados;

            Assert.IsTrue(rta);
        }

        /// <summary>
        /// Verifica que el metodo empaquetados vacie el atributo relojes.
        /// </summary>
        [TestMethod]
        public void Empaquetados()
        {
            bool rta;
            RelojInteligente reloj = new RelojInteligente(EMarca.Rolex, "ModelPrueba", EPantalla.LED, false);
            FabricaRelojes fabrica = new FabricaRelojes(1, "FABRICA");

            fabrica += reloj; //si no agrego ningun reloj no sera posible pulir, ya que no habria ningun reloj que pulir.

            fabrica.PulidoDeReloj(fabrica); //Si no se pulen los relojes no se pueden calibrar.
            fabrica.CalibrarRelojes(fabrica); //Si no se calibran los relojes no se pueden empaquetar.
            fabrica.Empaquetado(fabrica);

            rta = fabrica.Cantidad == 0;

            Assert.IsTrue(rta);
        }

        /// <summary>
        /// Verifica que el RelojInteligente no sea null.
        /// </summary>
        [TestMethod]
        public void CrearRelojInteligente()
        {
            RelojInteligente reloj = new RelojInteligente(EMarca.Rolex, "ModelPrueba", EPantalla.LED, false);

            Assert.IsNotNull(reloj);
        }

        /// <summary>
        /// Verifica que el RelojPulsera no sea null.
        /// </summary>
        [TestMethod]
        public void CrearRelojPulsera()
        {
            RelojPulsera reloj = new RelojPulsera(EMaterial.Plata, EMarca.Casio, "ModelEstandar", EGama.Baja);

            Assert.IsNotNull(reloj);

        }

        /// <summary>
        /// Verifica que la lista generica relojes no sea null.
        /// </summary>
        [TestMethod]
        public void Relojes()
        {
            FabricaRelojes fabrica = new FabricaRelojes();
            Assert.IsNotNull(fabrica.relojes);
        }

        /// <summary>
        /// Verifica que la lista generica productos no sea null. 
        /// </summary>
        [TestMethod]
        public void Productos()
        {
            FabricaRelojes fabrica = new FabricaRelojes();
            Assert.IsNotNull(fabrica.productos);
        }
    }
}
