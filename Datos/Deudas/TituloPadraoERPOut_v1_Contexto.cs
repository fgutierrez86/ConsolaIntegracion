using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Dapper;
using Datos.PadraoPruebas;


namespace Datos.Deudas
{
    public class TituloPadraoERPOut_v1_Contexto:Contexto
    {
        public WSIntegracaoPadraoSoapClient conexion_SOAP
        {
            get
            {
                return new WSIntegracaoPadraoSoapClient();
            }
        }


 public string GetXMLFromGera()
        {
            try
            {
                OnLog(new ObjLog() { Tipo = 1, Ticket = 0, CodigoDocumento = 0, Tabla = "TituloPadrao", Mensaje = "Conectando al web service...   " });
                var export = conexion_SOAP.ExportarDados(Token, "TituloPadraoERP", "1.0");
                Ticket = export.CodigoTicket;
                OnLog(new ObjLog() { Tipo = 2, Ticket = Ticket, CodigoDocumento = 0, Mensaje = "TituloPadraoERP: Retorno del WS, Tickets No." + Ticket.ToString() });
                string xml;
                if (export.Ticket != null)
                    xml = export.Ticket.ToString();
                else
                    return null;
                OnLog(new ObjLog() { Tipo = 3, Ticket = Ticket, CodigoDocumento = 0, Tabla = "", Mensaje = "Grabando ticket Titulo..." });
                return xml;
            }
            catch (Exception ex)
            {
                OnLog(new ObjLog() { Tipo = -1, CodigoDocumento = Ticket, Tabla = "TituloPadraoERP", Mensaje = "Excepcion en la conexion SOAP para TituloPadraoERP:  " + ex.Message });
                throw  new Exception("Excepcion en la conexion de Titulos... " + ex.Message);
            }
        }

        public TituloPadraoERPOut_v1[] GetTituloFromXML(string xml, bool grabarTicket )
        {
            try
            {
                OnLog(new ObjLog() {Tipo = 4, Ticket = Ticket, CodigoDocumento = 0, Tabla = "TituloPadraoERP", Mensaje = "Deserializando Titulos..." });
                var deserializer = new XmlSerializer(typeof(TituloPadraoERPOut_v1[]), new XmlRootAttribute("ArrayOfTituloPadraoERPOut_v1"));
                TextReader reader = new StringReader(xml);
                OnLog(new ObjLog() {Tipo = 5 ,Ticket = Ticket, CodigoDocumento = 105, Tabla = "TituloPadraoERP", Mensaje = "Convertiendo a objetos Titulos" });
                var titulos = (TituloPadraoERPOut_v1[])deserializer.Deserialize(reader);
                if(grabarTicket)
                    GrabarTicket("Titulos", titulos.Count() ,Ticket, xml);
                reader.Close();
                return titulos;
            }
            catch (Exception ex)
            {
                    OnLog(new ObjLog(){ Tipo =-2, CodigoDocumento = Ticket, Tabla = "TituloPadraoERP", Mensaje = "Excepcion: " + ex.Message});
                    throw  new Exception("Excepcion en la serializacion de Titulos... " + ex.Message);
            }
        
        }

        public void GrabarTitulo(TituloPadraoERPOut_v1[] titulos)
        {
            var cnnIntermedia = ConexionBD.CadenaDeConexionIntermedia;
            using (var conn = new SqlConnection(cnnIntermedia))
            {
                foreach (var titulo in titulos)
                {
                    try
                    {
                        var p = new DynamicParameters();
                        OnLog(new ObjLog() { Tipo = 6, Ticket = Ticket, CodigoDocumento = titulo.CodigoDocumento, Tabla = "inicio TituloPadraoERP", Mensaje = "Grabando Titulo: " + titulo.CodigoTitulo });
                        p.Add(@"Ticket", Ticket);
                        p.Add(@"CodigoDocumento", titulo.CodigoDocumento);
                        p.Add(@"CodigoTitulo ", titulo.CodigoTitulo);
                        p.Add(@"CodigoPedido ", titulo.CodigoPedido);
                        p.Add(@"NossoNumero ", titulo.NossoNumero);
                        p.Add(@"MeioRecebimento ", titulo.MeioRecebimento);
                        p.Add(@"FormaPagamento", titulo.FormaPagamento);
                        p.Add(@"Operacao", titulo.Operacao);
                        p.Add(@"DataOperacao ", titulo.DataOperacao);
                        p.Add(@"DataEmissao ", titulo.DataEmissao);
                        p.Add(@"DataVencimento ", titulo.DataVencimento);
                        p.Add(@"DataValidade ", titulo.DataValidade);
                        p.Add(@"ValorPrincipalOperacao", titulo.ValorPrincipalOperacao);
                        p.Add(@"ValorFinanceiroOperacao", titulo.ValorFinanceiroOperacao);
                        p.Add(@"SaldoPrincipal", titulo.SaldoPrincipal);
                        p.Add(@"SaldoFinanceiro", titulo.SaldoFinanceiro);
                        p.Add(@"NivelNegociacao ", titulo.NivelNegociacao);
                        p.Add(@"Origen", "WebService");
                        conn.Execute(@"Deudas.TituloPadraoERPOut_v1_Ins", p, commandType: CommandType.StoredProcedure);
                        OnLog(new ObjLog() { Tipo = 7, Ticket = Ticket, CodigoDocumento = titulo.CodigoDocumento, Tabla = "TituloPadraoERP",
                            Mensaje = "Grabacion de TituloPadraoERP,  CódigoTitulo: " + titulo.CodigoTitulo
                        });
                    }
                    catch (Exception ex)
                    {
                        OnLog(new ObjLog(){ Tipo =-3, CodigoDocumento = Ticket, Tabla = "TituloPadraoERP", Mensaje = "Excepcion Al grabar Titulo: " + ex.Message});
                        throw  new Exception("Excepcion en la grabacion de Titulos... " + ex.Message);
                    }
                }
            }

        }
        public bool CerrarTicket(TituloPadraoERPOut_v1[] titulos)
        {
            // si esta puesto que no hay que cerrar ticket, retornar sin hacer nada...
            if (HayQueCerrarTicket == "NO")
            {
                OnLog(new ObjLog()
                {
                    Tipo = 99,
                    Ticket = Ticket,
                    CodigoDocumento = 0,
                    Tabla = "TituloPadraoERPOut_v1",
                    Mensaje = "No se esta cerando el Ticket TituloPadraoERPOut_v1"
                });
                return true;
            }



            OnLog(new ObjLog() {Tipo=99, Ticket=Ticket, CodigoDocumento = 100, Tabla = "TituloPadraoERP", 
                Mensaje = "Cerrando ticket TituloPadrao" });
            var parametros = new WSIntegracaoPadraoSoapClient();
            DateTime fecha;
            ArrayOfString errores;
            ConfirmacaoDocumento documento;
            var documentos = new ArrayOfConfirmacaoDocumento();

            foreach (var d in titulos)
            {
                documento = new ConfirmacaoDocumento() { CodigoDocumento = d.CodigoDocumento, MensagemErro = "Error", Situacao = 1 };
                documentos.Add(documento);
            }
            try
            {
                var cierre = parametros.AdicionarConfirmacaoTicket(Token, "TituloPadraoERP", "1.0", Ticket, documentos, out fecha, out errores );
                OnLog(new ObjLog() { Tipo=100, Ticket=Ticket, CodigoDocumento = 0, Tabla = "TituloPadraoERP", 
                    Mensaje = "Tickets de titulos cerrado correctamente." });
                return true;
            }
            catch (Exception ex)
            {
                OnLog(new ObjLog() {Tipo=-4, Ticket=Ticket, CodigoDocumento = 102, Tabla = "PessoaPadraoERP", 
                    Mensaje = "Error cerrando ticket TituloPadraoERP: " + ex.Message });
                    return false;
            }
        }
    }
}
