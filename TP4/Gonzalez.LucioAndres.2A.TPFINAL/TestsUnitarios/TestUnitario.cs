using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Excepciones;
using Archivos;
using System.Data.SqlClient;
using System.Data;

namespace TestsUnitarios
{
    [TestClass]
    public class TestUnitario
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

        /// <summary>
        /// Test que prueba si esta bien lanzada la excepcion RelojRepetidoExcepcion.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(RelojRepetidoExcepcion))]
        public void RelojRepetido()
        {
            FabricaRelojes fabrica = new FabricaRelojes(3, "Fabrica");
            RelojInteligente r5 = new RelojInteligente(EMarca.Cartier, "ModelX", EPantalla.IPS, true);
            RelojPulsera r2 = new RelojPulsera(EMaterial.Plata, EMarca.Cartier, "ModelX", EGama.Alta);

            fabrica += r5;
            fabrica += r2;            
        }

        /// <summary>
        /// Test que prueba si esta bien lanzada la excepcion CapacidadExcepcion.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CapacidadExcepcion))]
        public void Capacidad()
        {
            FabricaRelojes fabrica = new FabricaRelojes(2, "Fabrica");
            RelojInteligente r5 = new RelojInteligente(EMarca.Cartier, "ModelX", EPantalla.IPS, true);
            RelojPulsera r2 = new RelojPulsera(EMaterial.Plata, EMarca.Cartier, "ModelS", EGama.Alta);
            Reloj r = new RelojInteligente();

            fabrica += r5;
            fabrica += r2;
            fabrica += r;
        }

        /// <summary>
        /// Test que prueba la serializacion de un archivo XML.
        /// </summary>
        [TestMethod]
        public void GuardarArchivo()
        {
            Xml<FabricaRelojes> xml = new Xml<FabricaRelojes>();
            FabricaRelojes fabrica = new FabricaRelojes();

            Assert.IsTrue(xml.Guardar("FabricaRelojes.xml", fabrica));
        }

        /// <summary>
        /// Test que prueba la deserializacion de un archivo XML.
        /// </summary>
        [TestMethod]
        public void LeerArchivo()
        {
            Xml<FabricaRelojes> xml = new Xml<FabricaRelojes>();
            FabricaRelojes fabrica = new FabricaRelojes();

            Assert.IsTrue(xml.Leer("FabricaRelojes.xml", out fabrica));
        }

        /// <summary>
        /// Prueba la conexion a la base de datos.
        /// </summary>
        [TestMethod]
        public void BaseDatos()
        {
            SqlConnection conexion = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = FabricaRelojes; Integrated Security = True");

            conexion.Open();
        
            Assert.IsTrue(conexion.State == ConnectionState.Open);

            conexion.Close();

            Assert.IsTrue(conexion.State == ConnectionState.Closed);
        }
    }
}
