using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Entidades;
using Archivos;
using Excepciones;
using System.Data.SqlClient;
using System.Data;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = FabricaRelojes; Integrated Security = True");
                FabricaRelojes f = new FabricaRelojes(3, "Fabrica de Relojes");
                RelojInteligente r2 = new RelojInteligente(EMarca.Cartier, "ModelX", EPantalla.IPS, true);
                RelojPulsera r3 = new RelojPulsera(EMaterial.Oro, EMarca.Rolex, "ModelS", EGama.Alta);
                RelojPulsera r4 = new RelojPulsera(EMaterial.Plastico, EMarca.Casio, "ModelS", EGama.Baja);
                RelojInteligente r6 = new RelojInteligente(EMarca.Casio, "ModeloPrueba", EPantalla.LED, false);
                RelojInteligente r7 = new RelojInteligente(EMarca.Casio, "ModeloPrueba1", EPantalla.LED, false);
                RelojInteligente r8 = new RelojInteligente(EMarca.Casio, "ModeloPrueba2", EPantalla.LED, false);

                // reloj repetido. 
                RelojInteligente r5 = new RelojInteligente(EMarca.Cartier, "ModelX", EPantalla.IPS, true);                

                //Agrego los relojes a la fabrica.
                f += r2;
                f += r3;

                //Carga de un reloj repetido;
                try
                {
                    f += r5;
                }
                catch(RelojRepetidoExcepcion ex)
                {
                    Console.WriteLine(ex.Message + "\n");
                }
                

                //Funcionalidades sin respetar el orden
                Console.WriteLine(f.Empaquetado(f) + "\n");
                Console.WriteLine(f.CalibrarRelojes(f) + "\n");

                //Muestra todos los datos de la fabrica junto con los relojes que fueron empaquetados.
                //En este caso no debe mostrar ningun reloj.
                Console.WriteLine(f.ToString());

                //Funcionalidades en orden.
                Console.WriteLine(f.PulidoDeReloj(f));
                Console.WriteLine(f.CalibrarRelojes(f) + "\n");

                    //Intento agregar un reloj mientras se estas produciendo los anteriores.
                    //No debe agregarlo.
                    try
                    {
                       f += r4; 
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message + "\n");
                    }
                    

                Console.WriteLine(f.Empaquetado(f) + "\n");                    


                //Muestra todos los datos de la fabrica junto con los relojes que fueron empaquetados.
                //Ahora si debe mostrar los relojes.
                Console.WriteLine(f.ToString());

                //Pulido de relojes vacio
                Console.WriteLine(f.PulidoDeReloj(f) + "\n");

                //Agrego 3 relojes y el cuarto NO se debe agregar porque supera la capacidad.
                f += r4;
                f += r6;
                f += r7;

                try
                {
                    f += r8;
                }
                catch(CapacidadExcepcion ex)
                {
                    Console.WriteLine(ex.Message + "\n");
                }

                //Prueba de la gereneracion de un XML.
                try
                {
                    if (FabricaRelojes.Guardar(f))
                    {
                        Console.WriteLine("Guardado" + "\n");
                    }
                    else
                    {
                        Console.WriteLine("NO Guardado" + "\n");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n");
                }

                //Prueba la lectura de un XML.
                try
                {
                    if (FabricaRelojes.Leer(Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"\FabricaRelojes.xml", out f))
                    {
                        Console.WriteLine("XML deserializado" + "\n");
                    }
                    else
                    {
                        Console.WriteLine("XML NO deserializado" + "\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n");
                }

                //Prueba de conexion a la base de datos.
                try
                {
                    f.ObtenerRelojesInteligentes(new SqlCommand("SELECT * FROM FabricaRelojes.dbo.RelojInteligente", conexion), conexion);
                    f.ObtenerRelojesPulsera(new SqlCommand("SELECT * FROM FabricaRelojes.dbo.RelojPulsera", conexion), conexion);
                    //Debe imprimir los relojes que estan en la fabrica sumado a los que traiga de la base de datos.
                    //Deben ser la cantidad de relojes que haya en la en la base (ya sea 1, mas o ninguno) sumado a los 2 que ya estan empaquetados.
                    Console.WriteLine(f.ToString());
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.ReadLine();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            
        }
    }
}
