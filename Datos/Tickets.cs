using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Datos
{
    public class Tickets
    {
        public string Tabla {get;set;}

        public int CantReg { get; set; }
        public long Ticket { get; set; }
        public string Valor { get; set; }

        public static void GrabarTicket(Tickets ticket)
        {
            var cnn = ConexionBD.CadenaDeConexionIntermedia_Log;
            using (var conn = new SqlConnection(cnn))
            {
                var p = new DynamicParameters();

                p.Add(@"Tabla", ticket.Tabla);
                p.Add(@"CantReg", ticket.CantReg);
                p.Add(@"Ticket", ticket.Ticket);
                p.Add(@"Valor", ticket.Valor);
                conn.Execute(@"Ticket_Ins", p, commandType: CommandType.StoredProcedure);
            }
        }

        public static Tickets GetTicketPorNumero(int ticketNumero)
        {
            var cnn = ConexionBD.CadenaDeConexionIntermedia_Log;
            using (var conn = new SqlConnection(cnn))
            {
                var p=new DynamicParameters();
                p.Add(@"TicketNumero", ticketNumero);
                var ticket = conn.Query<Tickets>(@"Ticket_Sel", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return ticket;
            }

        }

        public static IEnumerable<Tickets> GetTicketPorTablaYFecha(string tabla, DateTime fecha)
        {
            var cnn = ConexionBD.CadenaDeConexionIntermedia_Log;
            using (var conn = new SqlConnection(cnn))
            {
                var p = new DynamicParameters();
                p.Add(@"Tabla", tabla);
                p.Add(@"Fecha", fecha);
                var tickets = conn.Query<Tickets>(@"Tickets_SelXTablaXFecha", p, commandType: CommandType.StoredProcedure);
                return tickets;
            }

        }

        public static void BorrarTicket(long ticketNumero, string tabla)
        {
            var cnn = ConexionBD.CadenaDeConexionIntermedia_Log;
            using (var conn = new SqlConnection(cnn))
            {
                var p = new DynamicParameters();
                p.Add(@"TicketNumero", ticketNumero);
                p.Add(@"Tabla", tabla);
                conn.Execute(@"Ticket_Del", p,
                           commandType: CommandType.StoredProcedure);
            }
        }
    }
}
