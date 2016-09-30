using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Data.SqlClient;
using Dapper;
using System.Data;

using Datos.NaturaBoliviaPadraoPruebas;

namespace Datos.Pagos
{
    public class PagamentoContaCorrenteNatBO_v1_Contexto : Contexto
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
                OnLog(new ObjLog() { Tipo = 1, Ticket = 0, CodigoDocumento = 0, Tabla = "Pagamento", Mensaje = "Conectando al web service...   " });
                var export = conexion_SOAP.ExportarDados(Token, "InformacoesPagamentoseCCR", "1.0");
                Ticket = export.CodigoTicket;
                OnLog(new ObjLog() { Tipo = 2, Ticket = Ticket, CodigoDocumento = 0, Mensaje = "Pagamento: Retorno del WS, Tickets No." + Ticket.ToString() });
                string xml;
                if (export.Ticket != null)
                    xml = export.Ticket.ToString();
                else
                    return null;
                OnLog(new ObjLog() { Tipo = 3, Ticket = Ticket, CodigoDocumento = 0, Tabla = "Pagamento", Mensaje = "Grabando ticket Pagamento..." });
                return xml;
            }
            catch (Exception ex)
            {
                OnLog(new ObjLog() { Tipo = -1, CodigoDocumento = Ticket, Tabla = "Pagamento", Mensaje = "Excepcion en la conexion SOAP para Pagamento:  " + ex.Message });
                throw new Exception("Excepcion en la conexion de Pagamento... " + ex.Message);
            }
        }

        public PagamentoContaCorrenteNatBO_v1[] GetPagamentoFromXML(string xml, bool grabarTicket)
        {
            try
            {
                OnLog(new ObjLog() { Tipo = 4, Ticket = Ticket, CodigoDocumento = 0, Tabla = "Pagamento", Mensaje = "Deserializando s..." });
                var deserializer = new XmlSerializer(typeof(PagamentoContaCorrenteNatBO_v1[]), new XmlRootAttribute("ArrayOfPagamentoContaCorrenteNatBO_v1"));
                TextReader reader = new StringReader(xml);
                OnLog(new ObjLog() { Tipo = 5, Ticket = Ticket, CodigoDocumento = 105, Tabla = "Pagamento", Mensaje = "Convertiendo a objetos Pagamento" });
                var pagamento = (PagamentoContaCorrenteNatBO_v1[])deserializer.Deserialize(reader);
                if (grabarTicket)
                    GrabarTicket("Pagamentos", pagamento.Count(), Ticket, xml);
                reader.Close();
                return pagamento;
            }
            catch (Exception ex)
            {
                OnLog(new ObjLog() { Tipo = -2, CodigoDocumento = Ticket, Tabla = "Pagamento", Mensaje = "Excepcion: " + ex.Message });
                throw new Exception("Excepcion en la serializacion de Pagamentos... " + ex.Message);
            }

        }

        public void GrabarPagamento(PagamentoContaCorrenteNatBO_v1[] pagamentos)
        {
            var cnnIntermedia = ConexionBD.CadenaDeConexionIntermedia;
            using (var conn = new SqlConnection(cnnIntermedia))
            {
                foreach (var pagamento in pagamentos)
                {
                    try
                    {
                        var p = new DynamicParameters();
                        OnLog(new ObjLog() { Tipo = 6, Ticket = Ticket, CodigoDocumento = pagamento.CodigoDocumento, Tabla = "Pagamento", Mensaje = "Grabando Pagamento: " + pagamento.CodigoTitulo });

                        DateTime databaixa;
                        if (pagamento.DataBaixaSpecified)
                            databaixa = pagamento.DataBaixa;
                        else
                            databaixa = new DateTime(1900, 1, 1);

                        DateTime datapagamento;
                        if (pagamento.DataPagamentoSpecified)
                            datapagamento = pagamento.DataPagamento;
                        else
                            datapagamento = new DateTime(1900, 1, 1);



                            p.Add(@"Ticket", Ticket);
                        p.Add(@"CodigoDocumento", pagamento.CodigoDocumento);
                        p.Add(@"CodigoTitulo", pagamento.CodigoTitulo);
                        p.Add(@"CodigoPessoa", pagamento.CodigoPessoa);
                        p.Add(@"Nome", pagamento.Nome);
                        p.Add(@"CodigoEntidadeConciliacao", pagamento.CodigoEntidadeConciliacao);
                        p.Add(@"EntidadeDeConciliacao", pagamento.EntidadeDeConciliacao);
                        p.Add(@"DataBaixa", databaixa);
                        p.Add(@"DataPagamento", datapagamento);
                        p.Add(@"ValorPrincipalTitulo", pagamento.ValorPrincipalTitulo);
                        p.Add(@"ValorFinanceiroTitulo", pagamento.ValorFinanceiroTitulo);
                        p.Add(@"TipoBaixa", pagamento.TipoBaixa);
                        p.Add(@"Valor", pagamento.Valor);
                        p.Add(@"CodigoContaCorrenteResidual", pagamento.CodigoContaCorrenteResidual);
                        p.Add(@"TipoRegistro", pagamento.TipoRegistro);
                        p.Add(@"Origem", pagamento.Origem);
                        p.Add(@"Notificacao", pagamento.Notificacao);
                        p.Add(@"TipoSac", pagamento.TipoSac);
                        p.Add(@"CodigoRegistroPagamento", pagamento.CodigoRegistroPagamento);
                        p.Add(@"TipoObjeto", pagamento.TipoObjeto);

                        conn.Execute(@"Deudas.PagamentoContaCorrenteNatBO_v1_Ins", p, commandType: CommandType.StoredProcedure);
                        OnLog(new ObjLog()
                        {
                            Tipo = 7,
                            Ticket = Ticket,
                            CodigoDocumento = pagamento.CodigoDocumento,
                            Tabla = "Pagamento",
                            Mensaje = "Grabacion de Pagamento,  CódigoPagamento: " + pagamento.CodigoTitulo
                        });
                    }
                    catch (Exception ex)
                    {
                        OnLog(new ObjLog() { Tipo = -3, CodigoDocumento = Ticket, Tabla = "PagamePagamento", Mensaje = "Excepcion Al grabar Pagamento: " + ex.Message });
                        throw new Exception("Excepcion en la grabacion de Pagamento... " + ex.Message);
                    }
                }
            }

        }
        public bool CerrarTicket(PagamentoContaCorrenteNatBO_v1[] pagamentos)
        {
            // si esta puesto que no hay que cerrar ticket, retornar sin hacer nada...
            if (HayQueCerrarTicket == "NO")
            {
                OnLog(new ObjLog()
                {
                    Tipo = 99,
                    Ticket = Ticket,
                    CodigoDocumento = 0,
                    Tabla = "Pagamento",
                    Mensaje = "No se esta cerando el Ticket Pagamento"
                });
                return true;
            }



            OnLog(new ObjLog()
            {
                Tipo = 99,
                Ticket = Ticket,
                CodigoDocumento = 100,
                Tabla = "Pagamento",
                Mensaje = "Cerrando ticket Pagamento"
            });
            var parametros = new WSIntegracaoPadraoSoapClient();
            DateTime fecha;
            ArrayOfString errores;
            ConfirmacaoDocumento documento;
            var documentos = new ArrayOfConfirmacaoDocumento();

            foreach (var d in pagamentos)
            {
                documento = new ConfirmacaoDocumento() { CodigoDocumento = d.CodigoDocumento, MensagemErro = "Error", Situacao = 1 };
                documentos.Add(documento);
            }
            try
            {
                var cierre = parametros.AdicionarConfirmacaoTicket(Token, "InformacoesPagamentoseCCR", "1.0", Ticket, documentos, out fecha, out errores);
                OnLog(new ObjLog()
                {
                    Tipo = 100,
                    Ticket = Ticket,
                    CodigoDocumento = 0,
                    Tabla = "Pagamento",
                    Mensaje = "Tickets de pagamento cerrado correctamente."
                });
                return true;
            }
            catch (Exception ex)
            {
                OnLog(new ObjLog()
                {
                    Tipo = -4,
                    Ticket = Ticket,
                    CodigoDocumento = 102,
                    Tabla = "Pagamento",
                    Mensaje = "Error cerrando ticket Pagamento: " + ex.Message
                });
                return false;
            }
        }
    }
}
