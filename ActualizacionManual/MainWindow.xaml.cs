using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Datos;

namespace ActualizacionManual
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnCargar.Click += btnCargar_Click;
            //TxtTicket.Text = @"7354";    
        }

        void btnVarios_Click(object sender, RoutedEventArgs e)
        {
            var tickets = Tickets.GetTicketPorTablaYFecha("Facturas", DateTime.Now);
            var contexto = new NotaFiscalBoliviaPadraoERPOut_v1_Contexto();
            contexto.Log +=Contexto_Log;
            foreach (var ticket in tickets)
            {
                contexto.Ticket = ticket.Ticket;
                var xml = ticket.Valor;
                var aNotas = contexto.GetNotaFiscalFromXML(xml);
                contexto.GrabarNotasFiscales(aNotas);

                Console.WriteLine(xml);
            }
        }

        void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            var delimiters = new char[] { '\r', '\n' };
            var tickets = TxtTicket.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            foreach (var ticket in tickets)
            {
                var oTicket = Tickets.GetTicketPorNumero(Int32.Parse(ticket));
                switch (oTicket.Tabla)
                {
                    case "Pedidos":
                    {
                        GrabarPedido( oTicket);
                        break;
                    }
                    case "Facturas":
                    {
                        GrabarFactura(oTicket);
                        break; 
                    }
                    case "Personas":
                    {
                        GrabarPersonas(oTicket);
                        break;
                    }
                    case "Titulos":
                    {
                        GrabarTitulos(oTicket);
                        break;
                    }
                };

 
            }




            
            
        }

        private void GrabarFactura(Tickets oTicket)
        {
            var contexto = new NotaFiscalBoliviaPadraoERPOut_v1_Contexto();
            contexto.Log += Contexto_Log;
            contexto.Ticket = oTicket.Ticket;
            var aNotas = contexto.GetNotaFiscalFromXML(oTicket.Valor);
            contexto.GrabarNotasFiscales(aNotas);


        }
private void GrabarPersonas(Tickets oTicket)
        {
            var contexto = new PessoaPadraoERPOut_v1_Contexto();
            contexto.Log += Contexto_Log;
            contexto.Ticket = oTicket.Ticket;
            var aPersonas = contexto.GetPessoaFromXML(oTicket.Valor, false);
            contexto.GrabarPersonas(aPersonas);
        }


        private void GrabarPedido(Tickets oTicket)
        {
            var contexto = new PedidoPadraoERPOut_v2_1_Contexto();
            contexto.Log += Contexto_Log;
            contexto.Ticket = oTicket.Ticket;
            var aPedidos = contexto.GetPedidosFromXML(oTicket.Valor, false);
            contexto.GrabarPedidos(aPedidos);
        }


        private void GrabarTitulos(Tickets oTicket)
        {
            var contexto = new TituloPadraoERPOut_v1_Contexto();
            contexto.Log += Contexto_Log;
            contexto.Ticket = oTicket.Ticket;
            var aPedidos = contexto.GetTituloFromXML(oTicket.Valor, false);
            contexto.GrabarTitulo(aPedidos);
        }


        private static void Contexto_Log(ObjLog msg)
        {
            ObjLog.InsertarLog(msg);
            Console.WriteLine(@"Ticket: " + msg.Ticket + @"\t  CodigoDocumento: " + msg.CodigoDocumento + @"\t Tabla: " + msg.Tabla + @"  \t  " + msg.Mensaje);
        }

        private void btnTicket_Click(object sender, RoutedEventArgs e)
        {
            MovimientoEstoquePadraoERPIn_v1_Contexto.Enviar();
        }
    }
}
