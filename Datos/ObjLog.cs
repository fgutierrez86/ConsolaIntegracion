using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Datos
{
    public class ObjLog
    {
        public int IdLog { get; set; }
        public int Tipo { get; set; }
        public long Ticket { get; set; }
        public long CodigoDocumento { get; set; }
        public string Tabla { get; set; }
        public string Mensaje { get; set; }
        public static void InsertarLog(ObjLog log)
        {

            var cnn = ConexionBD.CadenaDeConexionIntermedia_Log;
            using (var conn = new SqlConnection(cnn))
            {
                var p = new DynamicParameters();
                p.Add(@"Tipo", log.Tipo);
                p.Add(@"Ticket", log.Ticket);
                p.Add(@"CodigoDocumento", log.CodigoDocumento);
                p.Add(@"Tabla", log.Tabla);
                p.Add(@"Mensaje", log.Mensaje);
                conn.Execute(@"ObjLog_Ins", p,
                           commandType: CommandType.StoredProcedure);
            }
        }
     }
} 