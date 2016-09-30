using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Datos
{
    public class Parametro
    {
        public string Nombre { get; set; }
        public string Valor { get; set; }


        public static IEnumerable<Parametro> GetParametroXNombre(string nombre)
        {
            var cnn = ConexionBD.CadenaDeConexionIntermedia_Log;
            using (var conn = new SqlConnection(cnn))
            {
                var p = new DynamicParameters();
                p.Add(@"Nombre", nombre);
                var parametros = conn.Query<Parametro>(@"Parametros_Sel", p,
                           commandType: CommandType.StoredProcedure);
                return parametros;
            }
        }

        public static void ActualizarParametro(string nombre, string valor)
        {
            //var cnn = ConfigurationManager.ConnectionStrings[3].ConnectionString;
            var cnn = ConexionBD.CadenaDeConexionIntermedia_Log;
            using (var conn = new SqlConnection(cnn))
            {
                var p = new DynamicParameters();
                p.Add(@"Nombre", nombre);
                p.Add(@"Valor", valor);
                conn.Execute(@"Parametro_Upd", p,
                           commandType: CommandType.StoredProcedure);
            }

        }
    }
}
