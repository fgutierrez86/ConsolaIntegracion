using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ConsolaIntegracion.GeraWS;
using Datos;

namespace ConsolaIntegracion
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Presione Enter para empezar...");
            Contexto_Log(new ObjLog() { Mensaje = "================ INICIO DE CARGA DE TODOS LOS DATOS ======================" });
            if (Detener())
                return;


            Console.ReadLine();
            while (true)
            {
                bool continuar = true;

                //1.- Notas Fiscales
                var notaFiscalContexto = new NotaFiscalBoliviaPadraoERPOut_v1_Contexto();
                notaFiscalContexto.Log += Contexto_Log;
                Contexto_Log(new ObjLog() { Mensaje = "INICIANDO CARGA DE NOTAS FISCALES..." });
                while (continuar)
                {
                    var xml = notaFiscalContexto.GetXMLFromGera();
                    if (xml == null)
                    {
                        continuar = false;
                        Contexto_Log(new ObjLog()
                        {
                            CodigoDocumento = 0,
                            Tabla = "NotaFiscalPadraoERP",
                            Mensaje = "No HAY TICKETS DE NOTA FISCAL DISPONIBLES, FINALIZANDO..."
                        });
                    }
                    else
                    {
                        var aNotas = notaFiscalContexto.GetNotaFiscalFromXML(xml);
                        notaFiscalContexto.GrabarNotasFiscales(aNotas);
                        notaFiscalContexto.CerrarTicket(aNotas);
                    }
                    continuar = false;
                }

                Contexto_Log(new ObjLog() { Mensaje = "FIN DE CARGA DE NOTAS FISCALES." });
                if (Detener())
                    return;

                // 2.- Pedidos
                continuar = true;

                var pedidoContexto = new PedidoPadraoERPOut_v2_1_Contexto();
                pedidoContexto.Log += Contexto_Log;
                Contexto_Log(new ObjLog() { Mensaje = "INICIO DE CARGA DE  PEDIDOS..." });
                int cont = 1;
                pedidoContexto.Ticket = 0;
                while (continuar) // Ultimo Ticket con la Version 1.0
                {
                    cont++;
                    var xml = pedidoContexto.GetXMLFromGera();
                    if (xml == null)
                    {
                        continuar = false;
                        Contexto_Log(new ObjLog()
                        {
                            CodigoDocumento = 0,
                            Tabla = "PedidoPadraoERP",
                            Mensaje = "No HAY TICKETS DE PEDIDOS DISPONIBLES, FINALIZANDO..."
                        });
                    }
                    else
                    {
                        var aPedidos = pedidoContexto.GetPedidosFromXML(xml, true);
                        pedidoContexto.GrabarPedidos(aPedidos);
                        pedidoContexto.CerrarTicket(aPedidos);
                    }

                    continuar = false;
                }
                Contexto_Log(new ObjLog() { Mensaje = "FIN DE CARGA DE  PEDIDOS." });
                if (Detener())
                    return;
                ///3.-  Deudas
                continuar = true;

                var deudaContexto = new TituloPadraoERPOut_v1_Contexto();
                deudaContexto.Log += Contexto_Log;
                Contexto_Log(new ObjLog() { Mensaje = "INICIO DE CARGA DE DEUDAS..." });
                while (continuar)
                {
                    var xml = deudaContexto.GetXMLFromGera();
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
                        deudaContexto.CerrarTicket(aTitulos);
                    }
                    continuar = false;
                }
                Contexto_Log(new ObjLog() { Mensaje = "FIN DE CARGA DE  TITULOS." });

                if (Detener())
                    return;

                ///4.- Personas
                continuar = true;

                var personaContexto = new PessoaPadraoERPOut_v1_Contexto();
                personaContexto.Log += Contexto_Log;
                Contexto_Log(new ObjLog() { Mensaje = "INICIO DE CARGA DE  PERSONAS..." });
                while (continuar)
                {
                    var xml = personaContexto.GetXMLFromGera();
                    if (xml == null)
                    {
                        continuar = false;
                        Contexto_Log(new ObjLog()
                        {
                            CodigoDocumento = 0,
                            Tabla = "PessoaPadraoERP",
                            Mensaje = "No HAY TICKETS DE PERSONAS DISPONIBLES, FINALIZANDO..."
                        });
                    }
                    else
                    {
                        var aPersonas = personaContexto.GetPessoaFromXML(xml, true);
                        personaContexto.GrabarPersonas(aPersonas);
                        personaContexto.CerrarTicket(aPersonas);
                    }
                    continuar = false;
                }
                Contexto_Log(new ObjLog() { Mensaje = "FIN DE CARGA DE  PERSONAS." });
                if (Detener())
                    return;
                Contexto_Log(new ObjLog() { Mensaje = "================ FIN DE CARGA DE TODOS LOS DATOS ======================" });

                string sTiempo = Parametro.GetParametroXNombre("TiempoConexion").Select(x => x.Valor).FirstOrDefault();
                var tiempo = Convert.ToInt32(sTiempo); // Devuelve el tiempo en segundos
                Contexto_Log(new ObjLog() { Mensaje = "Durmiendo " + sTiempo + " segundos ..." });
                Thread.Sleep(tiempo * 1000);
            }
        }


       

        private static void Contexto_Log(ObjLog msg)
        {
            ObjLog.InsertarLog(msg);
            if (msg.Tipo == 0)
                Console.WriteLine(msg.Mensaje);
            else if(msg.Tipo < 0)
                Console.WriteLine("Excepcion en Ticket " + msg.Ticket + "; CodigoDocumento: " + msg.CodigoDocumento + "; Tabla: " + msg.Tabla  + "; Error: " + msg.Mensaje );
            else
                Console.WriteLine("Ticket: " + msg.Ticket + "\t  Codigo: " + msg.CodigoDocumento + "\t Tabla: " + msg.Tabla  );
        }

        private static bool Detener()
        {
            string detener = Parametro.GetParametroXNombre("DetenerServicio").Select(x=> x.Valor).FirstOrDefault();
            if (detener == "SI")
            {
                Contexto_Log(new ObjLog() { Mensaje="================ Servicio detenido, revise los parametros ======================"});
                Console.ReadLine();
                return true;
            }
            return false;
        }
    }
}