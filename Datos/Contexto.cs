using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;



namespace Datos
{

    public class Contexto
    {



        
        public long Ticket { get; set; }

        public string hayQueCerrarTicket;
        public string HayQueCerrarTicket
        {
            get
            {
                var sCerrarTicket = Parametro.GetParametroXNombre("HayQueCerrarTicket");
                hayQueCerrarTicket = sCerrarTicket.Select(x => x.Valor).FirstOrDefault();
                return hayQueCerrarTicket;
            }
        }

        private string token;
        public string Token
        {
            get
            {
                if (token == null)
                {
                    IEnumerable<Parametro> sToken;
                    sToken = Parametro.GetParametroXNombre("Token");
                    token = sToken.Select(x => x.Valor).FirstOrDefault();
                }
                return token;
            }
        }


        protected void GrabarTicket(string tabla, int cantReg, long ticketNo, string xml )
        {
            var ticket = new Tickets(){Tabla = tabla, CantReg = cantReg ,Ticket = ticketNo, Valor = xml};
            Tickets.GrabarTicket(ticket);
        }


        public void BorrarTicket(long ticketNumero, string tabla)
        {
            Tickets.BorrarTicket(ticketNumero, tabla);
        }


        public event Action<ObjLog> Log;


        public virtual void OnLog(ObjLog objlog)
        {
            Action<ObjLog> handler = Log;
            if (handler != null)
            {
                handler(objlog);
            }
        }
    }
}
