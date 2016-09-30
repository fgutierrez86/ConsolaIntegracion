using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

using Datos.Deudas;
using Datos.Facturas;
using Datos.Pagos;
using Datos.Pedidos;
using Datos.Personas;
using Datos.Revendedores;

namespace RegenerarTicket
{
    class Program
    {
        private static string _solounticket;
        public static bool SoloUnTicket
        {
            get
            {
                _solounticket = Parametro.GetParametroXNombre("solounticketportabla").Select(x => x.Valor).FirstOrDefault();
                return _solounticket == "si";
            }
        }
        static void Main(string[] args)
        {
            bool continuar = true;
            var deudaContexto = new TituloPadraoERPOut_v1_Contexto();
            deudaContexto.Log += Contexto_Log;
            Contexto_Log(new ObjLog() { Mensaje = "INICIO DE CARGA DE DEUDAS..." });
            while (continuar)
            {
                string xml;
                try
                {
                    xml = deudaContexto.GetXMLFromGera();
                }
                catch (Exception)
                {
                    Parametro.ActualizarParametro("Ejecutando", "NO");
                    return;
                }
                if (xml == null)
                {
                    continuar = false;
                    Contexto_Log(new ObjLog()
                    {
                        CodigoDocumento = 0,
                        Tabla = "TituloPadraoERP",
                        Mensaje = "No HAY TICKETS DE TITULOS DISPONIBLES, FINALIZANDO..."
                    });
                }
                else
                {
                    var aTitulos = deudaContexto.GetTituloFromXML(xml, true);
                    deudaContexto.GrabarTitulo(aTitulos);
                    if (!deudaContexto.CerrarTicket(aTitulos))
                    {
                        deudaContexto.BorrarTicket(deudaContexto.Ticket, "Deudas");
                        return;
                    }
                }
                if (Detener())
                {

                    Parametro.ActualizarParametro("Ejecutando", "NO");
                    return;
                }
                if (SoloUnTicket)
                    continuar = false;
            }
            Contexto_Log(new ObjLog() { Mensaje = "FIN DE CARGA DE  TITULOS." });

        }


        public static void GrabarRevendedores()
        {
            bool continuar = true;
            var contexto = new RevendedorNatBO_v1_Contexto();
            contexto.Log += Contexto_Log;
            while (continuar)
            {
                var xml = contexto.GetXMLFromGera();
                if (xml == null)
                {
                    Console.WriteLine("No hay más tickets...");
                    Console.ReadLine();
                    continuar = false;
                }
                else
                {
                    var revendedores = contexto.GetRevendedorFromXML(xml, true);
                    contexto.GrabarRevendedor(revendedores);
                    contexto.CerrarTicket(revendedores);
                }
            }
        }



        private static void GrabarFactura(Tickets oTicket)
        {
            var contexto = new NotaFiscalBoliviaPadraoERPOut_v1_Contexto();
            contexto.Log += Contexto_Log;
            contexto.Ticket = oTicket.Ticket;
            var aNotas = contexto.GetNotaFiscalFromXML(oTicket.Valor);
            contexto.GrabarNotasFiscales(aNotas);


        }
private static void GrabarPersonas(Tickets oTicket)
        {
            var contexto = new PessoaPadraoERPOut_v1_Contexto();
            contexto.Log += Contexto_Log;
            contexto.Ticket = oTicket.Ticket;
            var aPersonas = contexto.GetPessoaFromXML(oTicket.Valor, false);
            contexto.GrabarPersonas(aPersonas);
        }


        private static void GrabarPedido(Tickets oTicket)
        {
            var contexto = new PedidoPadraoERPOut_v2_1_Contexto();
            contexto.Log += Contexto_Log;
            contexto.Ticket = oTicket.Ticket;
            var aPedidos = contexto.GetPedidosFromXML(oTicket.Valor, false);
            contexto.GrabarPedidos(aPedidos);
        }


        private static void GrabarTitulos(Tickets oTicket)
        {
            var contexto = new TituloPadraoERPOut_v1_Contexto();
            contexto.Log += Contexto_Log;
            contexto.Ticket = oTicket.Ticket;
            var aPedidos = contexto.GetTituloFromXML(oTicket.Valor, false);
            contexto.GrabarTitulo(aPedidos);
        }

private static bool Detener()
        {
            string detener = Parametro.GetParametroXNombre("DetenerServicio").Select(x => x.Valor).FirstOrDefault();
            if (detener == "SI")
            {
                Contexto_Log(new ObjLog() { Tipo = -10, Mensaje = "================ Servicio detenido por el parametro DetenerServicio..." });
                return true;
            }
            return false;
        }




        private static void Contexto_Log(ObjLog msg)
        {
            ObjLog.InsertarLog(msg);
            Console.WriteLine(@"Ticket: " + msg.Ticket + @"\t  CodigoDocumento: " + msg.CodigoDocumento + @"\t Tabla: " + msg.Tabla + @"  \t  " + msg.Mensaje);
        }

    }
}
