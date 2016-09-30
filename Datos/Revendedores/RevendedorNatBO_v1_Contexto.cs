using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Datos.NaturaBoliviaPadraoPruebas  ;


namespace Datos.Revendedores
{
    public class RevendedorNatBO_v1_Contexto:Contexto
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
                OnLog(new ObjLog() { Tipo = 1, Ticket = 0, CodigoDocumento = 0, Tabla = "Revendedores", Mensaje = "Conectando al web service...   " });
                var conexion = new WSIntegracaoPadraoSoapClient();
                var export = conexion.ExportarDados(Token, "RevendedorNatBO", "1.0");
                Ticket = export.CodigoTicket;
                OnLog(new ObjLog() { Tipo = 2, Ticket = Ticket, CodigoDocumento = 0, Mensaje = "Revendedores: Retorno del WS, Tickets No." + Ticket.ToString() });
                string xml;
                if (export.Ticket != null)
                    xml = export.Ticket.ToString();
                else
                    return null;
                OnLog(new ObjLog() { Tipo = 3, Ticket = Ticket, CodigoDocumento = 0, Tabla = "", Mensaje = "Grabando ticket Revendedores..." });
                return xml;
            }
            catch (Exception ex)
            {
                OnLog(new ObjLog() { Tipo = -1, CodigoDocumento = Ticket, Tabla = "Revendedores", Mensaje = "Excepcion en la conexion SOAP :  " + ex.Message });
                throw new Exception("Excepcion en la conexion de Revendedores... " + ex.Message);
            }
        }

        public RevendedorNaturaBoliviaOut_v1[] GetRevendedorFromXML(string xml, bool grabarTicket)
        {
            try
            {
                OnLog(new ObjLog() { Tipo = 4, Ticket = Ticket, CodigoDocumento = 0, Tabla = "Revendedores", Mensaje = "Deserializando Revendedores..." });
                var deserializer = new XmlSerializer(typeof(RevendedorNaturaBoliviaOut_v1[]), new XmlRootAttribute("ArrayOfRevendedorNaturaBoliviaOut_v1"));
                TextReader reader = new StringReader(xml);
                OnLog(new ObjLog() { Tipo = 5, Ticket = Ticket, CodigoDocumento = 105, Tabla = "Revendedores", Mensaje = "Convertiendo a objetos Revendedores" });
                var revendedores = (RevendedorNaturaBoliviaOut_v1[])deserializer.Deserialize(reader);
                if (grabarTicket)
                    GrabarTicket("Revendedor", revendedores.Count(), Ticket, xml);
                reader.Close();
                return revendedores;
            }
            catch (Exception ex)
            {
                OnLog(new ObjLog() { Tipo = -2, CodigoDocumento = Ticket, Tabla = "Revendedores", Mensaje = "Excepcion: " + ex.Message });
                throw new Exception("Excepcion en la serializacion de Revendedores... " + ex.Message);
            }
        }

        public void GrabarRevendedor(RevendedorNaturaBoliviaOut_v1[] revendedores)
        {
            var cnnIntermedia = ConexionBD.CadenaDeConexionIntermedia;
            using (var conn = new SqlConnection(cnnIntermedia))
            {
                foreach (var revendedor in revendedores)
                {
                    try
                    {
                        var p = new DynamicParameters();
                        OnLog(new ObjLog() { Tipo = 6, Ticket = Ticket, CodigoDocumento = revendedor.CodigoPessoa, Tabla = "inicio Revendedores", Mensaje = "Grabando Revendedor Ticket: " + Ticket + ", documento: " + revendedor.CodigoDocumento });

                        DateTime dataHoraPrimerPedido;
                        if (revendedor.DataHoraPrimeiroPedidoSpecified)
                            dataHoraPrimerPedido = revendedor.DataHoraPrimeiroPedido;
                        else
                            dataHoraPrimerPedido = new DateTime(1900, 1, 1);

                        DateTime dataHoraUltimoPedido;
                        if (revendedor.DataHoraCaptacaoUltimoPedidoSpecified)
                            dataHoraUltimoPedido = revendedor.DataHoraCaptacaoUltimoPedido;
                        else
                            dataHoraUltimoPedido = new DateTime(1900, 1, 1);



                        p.Add("Ticket", Ticket);
                        p.Add("CodigoDocumento", revendedor.CodigoDocumento);
                        p.Add("CodigoPessoa", revendedor.CodigoPessoa);
                        p.Add("CampanhaPrimeiroPedido", revendedor.CampanhaPrimeiroPedido);
                        p.Add("DataHoraPrimeiroPedido", dataHoraPrimerPedido);
                        p.Add("CampanhaReativacao", revendedor.CampanhaReativacao);
                        p.Add("CampanhaCessamento", revendedor.CampanhaCessamento);
                        p.Add("QuantidadeCampanhasSemPedido", revendedor.QuantidadeCampanhasSemPedido);
                        p.Add("CodigoPapel", revendedor.CodigoPapel);
                        p.Add("DescricaoPapel", revendedor.DescricaoPapel);
                        p.Add("LimiteCredito", revendedor.LimiteCredito);
                        p.Add("CodigoEstruturaNivel0", revendedor.CodigoEstruturaNivel0);
                        p.Add("CodigoEstruturaNivel1", revendedor.CodigoEstruturaNivel1);
                        p.Add("CodigoEstruturaNivel2", revendedor.CodigoEstruturaNivel2);
                        p.Add("CodigoEstruturaNivel3", revendedor.CodigoEstruturaNivel3);
                        p.Add("DescricaoEstruturaNivel0", revendedor.DescricaoEstruturaNivel0);
                        p.Add("DescricaoEstruturaNivel1", revendedor.DescricaoEstruturaNivel1);
                        p.Add("DescricaoEstruturaNivel2", revendedor.DescricaoEstruturaNivel2);
                        p.Add("DescricaoEstruturaNivel3", revendedor.DescricaoEstruturaNivel3);
                        p.Add("Bloqueado", revendedor.Bloqueado);
                        p.Add("MotivoBloqueio", revendedor.MotivoBloqueio);
                        p.Add("CodigoUltimoPedido", revendedor.CodigoUltimoPedido);
                        p.Add("DataHoraCaptacaoUltimoPedido", dataHoraUltimoPedido);
                        p.Add("CodigoPessoaIndicacao", revendedor.CodigoPessoaIndicacao);
                        p.Add("NomePessoaIndicacao", revendedor.NomePessoaIndicacao);
                        p.Add("PossuiPerfilComercial", revendedor.PossuiPerfilComercial);
                        p.Add("SaldoCredito", revendedor.SaldoCredito);
                        p.Add("TipoSituacaoComprador", revendedor.TipoSituacaoComprador);
                        p.Add("SituacaoComprador", revendedor.SituacaoComprador);

                        conn.Execute(@"Revendedores.RevendedorNatBO_v1_Ins", p, commandType: CommandType.StoredProcedure);
                        OnLog(new ObjLog()
                        {
                            Tipo = 7,
                            Ticket = Ticket,
                            CodigoDocumento = revendedor.CodigoDocumento,
                            Tabla = "Revendedores",
                            Mensaje = "Grabacion de Revendedores,  CódigoRevendedor: " + revendedor.CodigoPessoa
                        });
                    }
                    catch (Exception ex)
                    {
                        OnLog(new ObjLog() { Tipo = -3, CodigoDocumento = Ticket, Tabla = "Revendedores", Mensaje = "Excepcion Al grabar: " + ex.Message });
                        throw new Exception("Excepcion en la grabacion de Revendedores... " + ex.Message);
                    }
                }
            }

        }
        public bool CerrarTicket(RevendedorNaturaBoliviaOut_v1[] revendedores)
        {
            // si esta puesto que no hay que cerrar ticket, retornar sin hacer nada...
            if (HayQueCerrarTicket == "NO")
            {
                OnLog(new ObjLog()
                {
                    Tipo = 99,
                    Ticket = Ticket,
                    CodigoDocumento = 0,
                    Tabla = "Revendedores",
                    Mensaje = "No se esta cerrando el Ticket Revendedores"
                });
                return true;
            }



            OnLog(new ObjLog()
            {
                Tipo = 99,
                Ticket = Ticket,
                CodigoDocumento = 100,
                Tabla = "Revendedores",
                Mensaje = "Cerrando ticket Revendedores"
            });
            var parametros = new WSIntegracaoPadraoSoapClient();
            DateTime fecha;
            ArrayOfString errores;
            ConfirmacaoDocumento documento;
            var documentos = new ArrayOfConfirmacaoDocumento();

            foreach (var d in revendedores)
            {
                documento = new ConfirmacaoDocumento() { CodigoDocumento = d.CodigoDocumento, MensagemErro = "Error", Situacao = 1 };
                documentos.Add(documento);
            }
            try
            {
                var cierre = parametros.AdicionarConfirmacaoTicket(Token, "RevendedorNatBo", "1.0", Ticket, documentos, out fecha, out errores);
                OnLog(new ObjLog()
                {
                    Tipo = 100,
                    Ticket = Ticket,
                    CodigoDocumento = 0,
                    Tabla = "Revendedores",
                    Mensaje = "Tickets de Revendedores cerrado correctamente."
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
                    Tabla = "Revendedores",
                    Mensaje = "Error cerrando ticket Revendedores: " + ex.Message
                });
                return false;
            }
        }

    }
}