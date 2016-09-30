using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ConexionBD
    {

        public static string CadenaDeConexionIntermedia
        {
            get
            {
                return ConexionBD.GetCadenaDeConexion("Intermedia");
            }
        }
        public static string CadenaDeConexionIntermedia_Log
        {
            get
            {
                return ConexionBD.GetCadenaDeConexion("Intermedia_Log");
            }
        }



        public static string GetCadenaDeConexion(string cual)
        {
            System.IO.StreamReader file = new System.IO.StreamReader("C:\\inetpub\\wwwroot\\cnnIntegracionGera.txt");
            var line = file.ReadLine();
            if (cual == "Intermedia")
            {
                return line;
            }
            else
            {
                line = file.ReadLine();
                return line;
            }
        }
    }
}
