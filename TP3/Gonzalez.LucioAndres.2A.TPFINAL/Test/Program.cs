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

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {   
                FabricaRelojes f = new FabricaRelojes(3, "Fabrica de Relojes");
                RelojInteligente r2 = new RelojInteligente(EMarca.Cartier, "ModelX", EPantalla.IPS, true);
                RelojPulsera r3 = new RelojPulsera(EMaterial.Oro, EMarca.Rolex, "ModelS", EGama.Alta);
                RelojPulsera r4 = new RelojPulsera(EMaterial.Plastico, EMarca.Casio, "ModelS", EGama.Baja);
                RelojInteligente r6 = new RelojInteligente(EMarca.Casio, "ModeloPrueba", EPantalla.LED, false);
                
                // reloj repetido. 
                RelojInteligente r5 = new RelojInteligente(EMarca.Cartier, "ModelX", EPantalla.IPS, true);                

                //Agrego los relojes a la fabrica.
                f += r2;
                f += r3;

                //Carga de un reloj repetido;
                f += r5;

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
                    f += r4;

                Console.WriteLine(f.Empaquetado(f) + "\n");                    


                //Muestra todos los datos de la fabrica junto con los relojes que fueron empaquetados.
                //Ahora si debe mostrar los relojes.
                Console.WriteLine(f.ToString());

                //Pulido de relojes vacio
                Console.WriteLine(f.PulidoDeReloj(f) + "\n");

                //Agrego un reloj y el segundo NO se debe agregar porque supera la capacidad.
                f += r4;
                f += r6;


                //Prueba de la gereneracion de un XML
                if (FabricaRelojes.Guardar(f))
                {
                    Console.WriteLine("Guardado");
                }
                else
                {
                    Console.WriteLine("NO Guardado");
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
