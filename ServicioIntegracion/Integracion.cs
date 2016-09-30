using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Datos;
using Datos.Deudas;
using Datos.Facturas;
using Datos.Pagos;
using Datos.Pedidos;
using Datos.Personas;
using Datos.Revendedores;



using System.Timers;

namespace ServicioIntegracion
{
    public partial class Integracion : ServiceBase
    {
        private string _soloUnTicket;
        public bool SoloUnTicket
        {
            get
            {
                _soloUnTicket = Parametro.GetParametroXNombre("SoloUnTicketPorTabla").Select(x => x.Valor).FirstOrDefault();
                return _soloUnTicket == "SI";
            }
        }
        private string _tiempo;
        public int Tiempo
        {
            get
            {
                if (_tiempo == null)
                    _tiempo = Parametro.GetParametroXNombre("TiempoConexion").Select(x => x.Valor).FirstOrDefault();
                return Convert.ToInt32(_tiempo); // Devuelve el tiempo en minutos    
            }
        }
        public Integracion()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //quitar comentario para hacer debug con el servicio instalado...
            //System.Diagnostics.Debugger.Launch();
            var _timer = new System.Timers.Timer(Tiempo * 60 * 1000);
            _timer.Elapsed += timer_Elapsed;
            _timer.Enabled = true;
        }


        public void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            string ejecutando = Parametro.GetParametroXNombre("Ejecutando").Select(x => x.Valor).FirstOrDefault();
            if (ejecutando == "SI")
            {
                Contexto_Log(new ObjLog() { Mensaje = "Hay un proceso ejecutando, no voy a hacer nada, retornando..." });
                return;
            }
            Parametro.ActualizarParametro("Ejecutando", "SI");

            Contexto_Log(new ObjLog() { Mensaje = "================ INICIO DE CARGA DE TODOS LOS DATOS ======================" });
            if (Detener())
            {
                Parametro.ActualizarParametro("Ejecutando", "NO");
                return;
            }

            bool continuar = true;
            
            // 1.- Pedidos
            continuar = true;

            var pedidoContexto = new PedidoPadraoERPOut_v2_1_Contexto();
            pedidoContexto.Log += Contexto_Log;
            Contexto_Log(new ObjLog() { Mensaje = "INICIO DE CARGA DE  PEDIDOS..." });
            pedidoContexto.Ticket = 0;
            while (continuar) // Ultimo Ticket con la Version 1.0
            {
                string xml;
                try
                {
                    xml = pedidoContexto.GetXMLFromGera();
                }
                catch (Exception )
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
                        Tabla = "PedidoPadraoERP",
                        Mensaje = "No HAY TICKETS DE PEDIDOS DISPONIBLES, FINALIZANDO..."
                    });
                }
                else
                {
                    var aPedidos = pedidoContexto.GetPedidosFromXML(xml, true);
                    pedidoContexto.GrabarPedidos(aPedidos);
                    if (!pedidoContexto.CerrarTicket(aPedidos))
                    {
                        pedidoContexto.BorrarTicket(pedidoContexto.Ticket, "Pedidos");
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
            Contexto_Log(new ObjLog() { Mensaje = "FIN DE CARGA DE  PEDIDOS." });

            // 2.- Notas Fiscales
            continuar = true;

            var notaFiscalContexto = new NotaFiscalBoliviaPadraoERPOut_v1_1_Contexto();
            notaFiscalContexto.Log += Contexto_Log;
            Contexto_Log(new ObjLog() { Mensaje = "INICIANDO CARGA DE NOTAS FISCALES..." });
            while (continuar)
            {
                string xml;
                try
                {
                    xml = notaFiscalContexto.GetXMLFromGera();
                }
                catch (Exception )
                {
                    Parametro.ActualizarParametro("Ejecutando", "NO");
                    return;
                }
                if (xml == null)
                {
                    continuar = false;
                    Contexto_Log(new ObjLog
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
                    if (!notaFiscalContexto.CerrarTicket(aNotas))
                    {
                        notaFiscalContexto.BorrarTicket(notaFiscalContexto.Ticket, "Facturas");
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

            Contexto_Log(new ObjLog() { Mensaje = "FIN DE CARGA DE NOTAS FISCALES." });


            ///3.-  Deudas
            continuar = true;

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
                catch (Exception )
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

            ///4.1- Personas
            continuar = true;

            var personaContexto = new PessoaPadraoERPOut_v1_Contexto();
            personaContexto.Log += Contexto_Log;
            Contexto_Log(new ObjLog() { Mensaje = "INICIO DE CARGA DE  PERSONAS..." });
            while (continuar)
            {
                string xml ;
                try
                {
                    xml = personaContexto.GetXMLFromGera();
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
                        Tabla = "PessoaPadraoERP",
                        Mensaje = "No HAY TICKETS DE PERSONAS DISPONIBLES, FINALIZANDO..."
                    });
                }
                else
                {
                    var aPersonas = personaContexto.GetPessoaFromXML(xml, true);
                    personaContexto.GrabarPersonas(aPersonas);
                    if (!personaContexto.CerrarTicket(aPersonas))
                    {
                        personaContexto.BorrarTicket(personaContexto.Ticket, "Personas");
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
            Contexto_Log(new ObjLog() { Mensaje = "FIN DE CARGA DE  PERSONAS." });

            ///4.2- Personas
            continuar = true;

            var personaContextoV1_1 = new PessoaPadraoERPOut_v1_1_Contexto();
            personaContextoV1_1.Log += Contexto_Log;
            Contexto_Log(new ObjLog() { Mensaje = "INICIO DE CARGA DE  PERSONAS V1.1 ..." });
            while (continuar)
            {
                string xml ;
                try
                {
                    xml = personaContextoV1_1.GetXMLFromGera();
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
                        Tabla = "PessoaPadraoERP Version 1.1",
                        Mensaje = "No HAY TICKETS DE PERSONAS DISPONIBLES, FINALIZANDO..."
                    });
                }
                else
                {
                    var aPersonas = personaContextoV1_1.GetPessoaFromXML(xml, true);
                    personaContextoV1_1.GrabarPersonas(aPersonas);
                    if (!personaContextoV1_1.CerrarTicket(aPersonas))
                    {
                        personaContextoV1_1.BorrarTicket(personaContextoV1_1.Ticket, "Personas");
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
            Contexto_Log(new ObjLog() { Mensaje = "FIN DE CARGA DE  PERSONAS. Version 1.1" });



            //5  Revendedores
            continuar = true;

            var revendedorContexto = new RevendedorNatBO_v1_Contexto();
            revendedorContexto.Log += Contexto_Log;
            Contexto_Log(new ObjLog() { Mensaje = "INICIO DE CARGA DE  REVENDEDORES..." });
            while (continuar)
            {
                string xml ;
                try
                {
                    xml = revendedorContexto.GetXMLFromGera();
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
                        Tabla = "Revendedores",
                        Mensaje = "No HAY TICKETS DE REVENDEDORES DISPONIBLES, FINALIZANDO..."
                    });
                }
                else
                {
                    var aRevendedores = revendedorContexto.GetRevendedorFromXML(xml, true);
                    revendedorContexto.GrabarRevendedor(aRevendedores);
                    if (!revendedorContexto.CerrarTicket(aRevendedores))
                    {
                        revendedorContexto.BorrarTicket(revendedorContexto.Ticket, "Revendedores");
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
            Contexto_Log(new ObjLog() { Mensaje = "FIN DE CARGA DE  REVENDEDORES." });


            //6  Pagamento
            continuar = true;

            var pagamentoContexto = new PagamentoContaCorrenteNatBO_v1_Contexto();
            pagamentoContexto.Log += Contexto_Log;
            Contexto_Log(new ObjLog() { Mensaje = "INICIO DE CARGA DE  PAGAMENTO..." });
            while (continuar)
            {
                string xml ;
                try
                {
                    xml = pagamentoContexto.GetXMLFromGera();
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
                        Tabla = "Pagamento",
                        Mensaje = "No HAY TICKETS DE PAGAMENTO DISPONIBLES, FINALIZANDO..."
                    });
                }
                else
                {
                    var aPagamento = pagamentoContexto.GetPagamentoFromXML(xml, true);
                    pagamentoContexto.GrabarPagamento(aPagamento);
                    if (!pagamentoContexto.CerrarTicket(aPagamento))
                    {
                        pagamentoContexto.BorrarTicket(pagamentoContexto.Ticket, "Pagamento");
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
            Contexto_Log(new ObjLog() { Mensaje = "FIN DE CARGA DE  PAGAMENTO." });



            

            Contexto_Log(new ObjLog() { Mensaje = "============FIN DE CARGA DE TODOS LOS DATOS, DURMIENDO " + Tiempo.ToString() + " Minutos..." });
            Parametro.ActualizarParametro("Ejecutando", "NO");
        }


        protected override void OnStop()
        {
        }

        private static void Contexto_Log(ObjLog msg)
        {
            var sLog = Parametro.GetParametroXNombre("NivelLog").Select(x=> x.Valor).FirstOrDefault();
            var nLog = Convert.ToInt32(sLog);
            if(msg.Tipo<0)  /// Errores siempre se muestran.
                ObjLog.InsertarLog(msg);
            else if ( nLog == 0)  // Logear todos los errores.
            {
                ObjLog.InsertarLog(msg);
            }
            else if (nLog == 1 && (msg.Ticket==2 || msg.Ticket== 99 ))  // Logear solo lo necesario.
            {
                ObjLog.InsertarLog(msg);
            }


        }

        private bool Detener()
        {
            string detener = Parametro.GetParametroXNombre("DetenerServicio").Select(x => x.Valor).FirstOrDefault();
            if (detener == "SI")
            {
                Contexto_Log(new ObjLog() { Tipo = -10, Mensaje = "================ Servicio detenido por el parametro DetenerServicio..." });
                return true;
            }
            return false;
        }
    }
}