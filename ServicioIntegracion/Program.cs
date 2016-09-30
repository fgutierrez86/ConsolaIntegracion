using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServicioIntegracion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main()
        {
            // quitar comentario para que funcione como servicio.
            /*
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Integracion()
            };
            ServiceBase.Run(ServicesToRun);
            */
            // Quitar comentario para que funcione como consola.
            Integracion integracion = new Integracion();
            integracion.timer_Elapsed(null, null);
        }

    }
}