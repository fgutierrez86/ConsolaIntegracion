using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Data;
using Dapper;
using System.IO;
using System.Data.SqlClient;
using Datos.PadraoPruebas;

namespace Datos.Facturas
{
    public class NotaFiscalBoliviaPadraoERPOut_v1_1_Contexto:Contexto
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
                    OnLog(new ObjLog() { Tipo = 1, Ticket = 0, CodigoDocumento = 0, Tabla = "NotaFiscalPadraoERP", Mensaje = "Conectando al web service...   " });
                    var export = conexion_SOAP.ExportarDados(Token, "NotaFiscalPadraoERP", "NFBolivia_1.1");
                    Ticket = export.CodigoTicket;
                    OnLog(new ObjLog() { Tipo = 2, Ticket = Ticket, CodigoDocumento = 0, Mensaje = "NotaFiscalPadraoERP: Retorno del WS, Tickets No." + Ticket.ToString() });
                    string xml;
                    if (export.Ticket != null)
                        xml = export.Ticket.ToString();
                    else
                        return null;
                    OnLog(new ObjLog() { Tipo = 3, Ticket = Ticket, CodigoDocumento = 0, Tabla = "NotaFiscalPadraoERP", Mensaje = "Grabando ticket NotaFiscal ..." });
                    return xml;
                }
                catch (Exception ex)
                {
                    OnLog(new ObjLog() { Tipo = -1, Ticket = Ticket, CodigoDocumento = 0, Tabla = "NotaFiscalPadraoERP", Mensaje = "Excepcion en la conexion SOAP para NotaFiscalPadraoERP: " + ex.Message });
                    throw new Exception("Excepcion en la Conexion SOAP con la NotaFiscal... " + ex.Message);
                }
            }

            public NotaFiscalBoliviaPadraoERPOut_v1_1[] GetNotaFiscalFromXML(string xml)
            {
                try
                {
                    OnLog(new ObjLog() { Tipo = 4, Ticket = Ticket, CodigoDocumento = 0, Tabla = "NotaFiscalPadraoERP", Mensaje = "Deserializando NotaFiscal..." });
                    XmlSerializer deserializer = new XmlSerializer(typeof(NotaFiscalBoliviaPadraoERPOut_v1_1[]), new XmlRootAttribute("ArrayOfNotaFiscalBoliviaPadraoERPOut_v1_1"));
                    NotaFiscalBoliviaPadraoERPOut_v1_1[] notas;
                    TextReader reader = new StringReader(xml);
                    OnLog(new ObjLog() { Tipo = 5, Ticket = Ticket, CodigoDocumento = 105, Tabla = "NotaFiscalPadraoERP", Mensaje = "Convertiendo a objetos NotaFiscal" });
                    notas = (NotaFiscalBoliviaPadraoERPOut_v1_1[])deserializer.Deserialize(reader);
                    GrabarTicket("Facturas", notas.Count(), Ticket, xml);
                    reader.Close();
                    return notas;
                }
                catch (Exception ex)
                {
                    OnLog(new ObjLog() { CodigoDocumento = 0, Tabla = "NotaFiscalBoliviaPadrao", Mensaje = "Excepcion: " + ex.Message });
                    throw new Exception("Excepcion en la serializacion de la NotaFiscal... " + ex.Message);
                }
            }

            public void GrabarNotasFiscales(NotaFiscalBoliviaPadraoERPOut_v1_1[] notas)
            {
                var cnn = ConexionBD.CadenaDeConexionIntermedia;
                using (var conn = new SqlConnection(cnn))
                {
                    try
                    {
                        foreach (var nota in notas)
                        {
                            var p = new DynamicParameters();
                            OnLog(new ObjLog() { Tipo = 6, Ticket = Ticket, CodigoDocumento = nota.CodigoPedido, Tabla = "inicio NotaPadraoERP", Mensaje = "Grabando NotaFiscal, pedido numero: " + nota.CodigoPedido });
                            p.Add(@"Ticket", Ticket);
                            p.Add(@"CodigoDocumento", nota.CodigoDocumento);
                            p.Add(@"Codigo", nota.Codigo);
                            p.Add(@"CodigoPedido", nota.CodigoPedido);
                            p.Add(@"CodigoPessoaEmissor", nota.PessoaEmissor.Codigo);
                            if (nota.Transportadora != null)
                                p.Add(@"CodigoPessoaTransportador", nota.Transportadora.Codigo);
                            else
                                p.Add(@"CodigoPessoaTransportador", null);
                            p.Add(@"Numero", nota.Numero);
                            p.Add(@"Serie", nota.Serie);
                            p.Add(@"Data", nota.Data);
                            p.Add(@"PesoLiquido", nota.PesoLiquido);
                            p.Add(@"PesoBruto", nota.PesoBruto);
                            p.Add(@"QuantidadeVolumes", nota.QuantidadeVolumes);
                            p.Add(@"Tipo", nota.Tipo);
                            p.Add(@"Situacao", nota.Situacao);
                            p.Add(@"TipoFrete", nota.TipoFrete);
                            p.Add(@"CentroFaturamento", nota.CentroFaturamento);
                            p.Add(@"DadosAdicionais", nota.DadosAdicionais);
                            conn.Execute(@"Facturas.NotaFiscalBoliviaPadraoERPOut_v1_Ins", p,
                                commandType: CommandType.StoredProcedure);

                            OnLog(new ObjLog()
                            {
                                Tipo = 7,
                                Ticket = Ticket,
                                CodigoDocumento = nota.CodigoDocumento,
                                Tabla = "NotaFiscalPadraoERP",
                                Mensaje = "Grabacion de NotaFiscalPadraoERP,  Nota.Numero: " + nota.Numero
                            });


                            p = new DynamicParameters();

                            var referencia = nota.NotaFiscalReferencia;
                            if (referencia != null)
                            {
                                p.Add(@"Ticket", Ticket);
                                p.Add(@"CodigoDocumento", nota.CodigoDocumento);
                                p.Add(@"Numero", referencia.Numero);
                                p.Add(@"Serie", referencia.Serie);
                                p.Add(@"DataEmissao", referencia.DataEmissao);
                                p.Add(@"CodigoPessoaEmissor", referencia.CodigoPessoaEmissor);
                                OnLog(new ObjLog()
                                {
                                    CodigoDocumento = referencia.Numero,
                                    Tabla = "NotaFiscalReferenciaPadraoERPOut_v1",
                                    Mensaje = "Insertando la nota de la nota " + nota.CodigoPedido
                                });
                                conn.Execute(@"Facturas.NotaFiscalReferenciaPadraoERPOut_v1_Ins", p,
                                    commandType: CommandType.StoredProcedure);

                                OnLog(new ObjLog()
                                {
                                    Tipo = 8,
                                    Ticket = Ticket,
                                    CodigoDocumento = nota.Numero,
                                    Tabla = "NotaFiscalReferenciaPadraoERP",
                                    Mensaje =
                                        "Grabacion de NotaFiscalReferenciaPadraoERP,  CodigoNotaFiscal: " +
                                        referencia.Numero
                                });
                            }
                            p = new DynamicParameters();

                            var destinatario = nota.Destinatario;
                            if (destinatario != null)
                            {
                                p.Add(@"Ticket", Ticket);
                                p.Add(@"CodigoDocumento", nota.CodigoDocumento);
                                p.Add(@"Nome", destinatario.Nome);
                                p.Add(@"Tipo", destinatario.Tipo);
                                p.Add(@"Identificacao", destinatario.Identificacao);
                                p.Add(@"TipoIdentificacao", destinatario.TipoIdentificacao);
                                p.Add(@"Telefone", destinatario.Telefone);
                                p.Add(@"Email", destinatario.Email);
                                p.Add(@"CodigoArea", destinatario.CodigoArea);
                                p.Add(@"EstruturaGeo0", destinatario.EstruturaGeo0);
                                p.Add(@"EstruturaGeo1", destinatario.EstruturaGeo1);
                                p.Add(@"EstruturaGeo2", destinatario.EstruturaGeo2);
                                p.Add(@"EstruturaGeo3", destinatario.EstruturaGeo3);
                                p.Add(@"EstruturaGeo4", destinatario.EstruturaGeo4);
                                p.Add(@"EstruturaGeo5", destinatario.EstruturaGeo5);
                                p.Add(@"EstruturaGeo6", destinatario.EstruturaGeo6);
                                p.Add(@"EstruturaGeo7", destinatario.EstruturaGeo7);
                                p.Add(@"EstruturaGeo8", destinatario.EstruturaGeo8);
                                p.Add(@"EstruturaGeo9", destinatario.EstruturaGeo9);
                                p.Add(@"Numero", destinatario.Numero);
                                p.Add(@"Complemento", destinatario.Complemento);
                                p.Add(@"Referencia", destinatario.Referencia);
                                p.Add(@"EntregaVizinho", destinatario.EntregaVizinho);
                                p.Add(@"NumeroVizinho", destinatario.NumeroVizinho);
                                p.Add(@"CodigoPedido", nota.CodigoPedido);
                                p.Add(@"CodigoAreaAuxiliar", destinatario.CodigoAreaAuxiliar);
                                p.Add(@"IdentificacaoAuxiliar", destinatario.IdentificacaoAuxiliar);
                                conn.Execute(@"Facturas.NotaFiscalBoliviaDestinatarioPadraoERPOut_v1_Ins", p,
                                    commandType: CommandType.StoredProcedure);

                                OnLog(new ObjLog()
                                {
                                    Tipo = 9,
                                    Ticket = Ticket,
                                    CodigoDocumento = destinatario.Codigo,
                                    Tabla = "NotaFiscalBoliviaDestinatarioPadraoERP",
                                    Mensaje = "Grabacion de NotaFiscalBoliviaDestinatarioPadraoERP,  CodigoNotaFiscal: " + nota.Codigo
                                });
                            }

                            p = new DynamicParameters();

                            var valores = nota.Valores;
                            if (valores != null)
                            {
                                p.Add(@"Ticket ", Ticket);
                                p.Add(@"CodigoDocumento ", nota.CodigoDocumento);
                                p.Add(@"ValorTotalNota", valores.ValorTotalNota);
                                p.Add(@"ValorProdutos", valores.ValorProdutos);
                                p.Add(@"BaseCalculoImposto1", valores.BaseCalculoImposto1);
                                p.Add(@"BaseCalculoImposto2", valores.BaseCalculoImposto2);
                                p.Add(@"BaseCalculoImposto3", valores.BaseCalculoImposto3);
                                p.Add(@"BaseCalculoImposto4", valores.BaseCalculoImposto4);
                                p.Add(@"BaseCalculoImposto5", valores.BaseCalculoImposto5);
                                p.Add(@"ValorImposto1", valores.ValorImposto1);
                                p.Add(@"ValorImposto2", valores.ValorImposto2);
                                p.Add(@"ValorImposto3", valores.ValorImposto3);
                                p.Add(@"ValorImposto4", valores.ValorImposto4);
                                p.Add(@"ValorImposto5", valores.ValorImposto5);
                                p.Add(@"Frete", valores.Frete);
                                p.Add(@"Seguro", valores.Seguro);
                                p.Add(@"OutrasDespesas", valores.OutrasDespesas);
                                p.Add(@"TotalDiferencialAliquotas", valores.TotalDiferencialAliquotas);
                                p.Add(@"CodigoPedido", nota.CodigoPedido);
                                p.Add(@"Descuento", 0); // Se actualiza en el pedido
                                conn.Execute(@"Facturas.NotaFiscalBoliviaValoresPadraoERPOut_v1_Ins", p,
                                    commandType: CommandType.StoredProcedure);

                                OnLog(new ObjLog()
                                {
                                    Tipo = 310,
                                    Ticket = Ticket,
                                    CodigoDocumento = nota.CodigoDocumento,
                                    Tabla = "NotaFiscalBoliviaValoresPadraoERP",
                                    Mensaje = "Grabacion de NotaFiscalBoliviaValoresPadraoERP,  CodigoNotaFiscal: " + nota.Codigo
                                });
                            }
                            p = new DynamicParameters();

                            var datos = nota.DadosBolivia;
                            if (datos != null)
                            {
                                p.Add(@"Ticket", Ticket);
                                p.Add(@"CodigoDocumento", nota.CodigoDocumento);
                                p.Add(@"NumeroAutorizacao", datos.NumeroAutorizacao);
                                p.Add(@"CodigoControle", datos.CodigoControle);
                                p.Add(@"NumeroDocumentoFiscalBO", datos.NumeroDocumentoFiscalBO);
                                p.Add(@"DataEmissao", datos.DataEmissao);
                                p.Add(@"DataLimiteEmissao", datos.DataLimiteEmissao);
                                p.Add(@"ChaveDosificacao", datos.ChaveDosificacao);
                                p.Add(@"CodigoPedido", nota.CodigoPedido);
                                conn.Execute(@"Facturas.NotaFiscalBoliviaDadosBoliviaPadraoERPOut_v1_Ins", p,
                                    commandType: CommandType.StoredProcedure);

                                OnLog(new ObjLog()
                                {
                                    Tipo = 311,
                                    Ticket = Ticket,
                                    CodigoDocumento = nota.CodigoDocumento,
                                    Tabla = "NotaFiscalBoliviaDadosPadraoERP",
                                    Mensaje = "Grabacion de NotaFiscalBoliviasDadosPadraoERP,  CodigoNotaFiscal: " + nota.Codigo
                                });
                            }
                            p = new DynamicParameters();

                            var itens = nota.ItensNotaFiscal;
                            if (itens != null)
                            {
                                foreach (var iten in itens)
                                {
                                    p.Add(@"Ticket", Ticket);
                                    p.Add(@"CodigoDocumento", nota.CodigoDocumento);
                                    p.Add(@"NumeroItem", iten.NumeroItem);
                                    p.Add(@"CodigoSKU", iten.CodigoSKU);
                                    p.Add(@"Material", iten.Material);
                                    p.Add(@"Quantidade", iten.Quantidade);
                                    p.Add(@"CodigoEstoque", iten.CodigoEstoque);
                                    p.Add(@"CFOP", iten.CFOP);
                                    p.Add(@"ClassificacaoFiscal", iten.ClassificacaoFiscal);
                                    p.Add(@"PercentualMVA", iten.PercentualMVA);
                                    p.Add(@"UnidadeMedida", iten.UnidadeMedida);
                                    p.Add(@"OperacaoFiscal", iten.OperacaoFiscal);
                                    p.Add(@"PrecoTabela", iten.Valores.PrecoTabela);
                                    p.Add(@"PrecoPraticado", iten.Valores.PrecoPraticado);
                                    p.Add(@"PrecoLiquido", iten.Valores.PrecoLiquido);
                                    p.Add(@"PrecoFaturamento", iten.Valores.PrecoFaturamento);
                                    p.Add(@"AliquotaImposto1", iten.Valores.AliquotaImposto1);
                                    p.Add(@"AliquotaImposto2", iten.Valores.AliquotaImposto2);
                                    p.Add(@"AliquotaImposto3", iten.Valores.AliquotaImposto3);
                                    p.Add(@"AliquotaImposto4", iten.Valores.AliquotaImposto4);
                                    p.Add(@"AliquotaImposto5", iten.Valores.AliquotaImposto5);
                                    p.Add(@"BaseCalculoImposto1", iten.Valores.BaseCalculoImposto1);
                                    p.Add(@"BaseCalculoImposto2", iten.Valores.BaseCalculoImposto2);
                                    p.Add(@"BaseCalculoImposto3", iten.Valores.BaseCalculoImposto3);
                                    p.Add(@"BaseCalculoImposto4", iten.Valores.BaseCalculoImposto4);
                                    p.Add(@"BaseCalculoImposto5", iten.Valores.BaseCalculoImposto5);
                                    p.Add(@"ValorImposto1", iten.Valores.ValorImposto1);
                                    p.Add(@"ValorImposto2", iten.Valores.ValorImposto2);
                                    p.Add(@"ValorImposto3", iten.Valores.ValorImposto3);
                                    p.Add(@"ValorImposto4", iten.Valores.ValorImposto4);
                                    p.Add(@"ValorImposto5", iten.Valores.ValorImposto5);
                                    p.Add(@"Frete", iten.Valores.Frete);
                                    p.Add(@"Seguro", iten.Valores.Seguro);
                                    p.Add(@"OutrasDespesas", iten.Valores.OutrasDespesas);
                                    p.Add(@"TotalDiferencialAliquotas", iten.Valores.TotalDiferencialAliquotas);
                                    p.Add(@"CodigoPedido", nota.CodigoPedido);

                                    conn.Execute(@"Facturas.NotaFiscalBoliviaItensPadraoERPOut_v1_Ins", p,
                                        commandType: CommandType.StoredProcedure);

                                    OnLog(new ObjLog()
                                    {
                                        Tipo = 312,
                                        Ticket = Ticket,
                                        CodigoDocumento = iten.NumeroItem,
                                        Tabla = "NotaFiscalBoliviaItensPadraoERP",
                                        Mensaje = "Grabacion de NotaFiscalBoliviasItensPadraoERP,  CodigoNotaFiscal: " + nota.Codigo
                                    });
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        OnLog(new ObjLog() { Tipo = -3, CodigoDocumento = Ticket, Tabla = "NotaFiscalBoliviaPadraoERP", Mensaje = "Excepcion Al grabar NotaFiscalBolivia: " + ex.Message });
                        throw new Exception("Excepcion en la grabacion en la BD de la NotaFiscal... " + ex.Message);
                    }
                }
            }

            public bool CerrarTicket(NotaFiscalBoliviaPadraoERPOut_v1_1[] notas)
            {
                // si esta puesto que no hay que cerrar ticket, retornar sin hacer nada...
                if (HayQueCerrarTicket == "NO")
                {
                    OnLog(new ObjLog()
                    {
                        Tipo = 99,
                        Ticket = Ticket,
                        CodigoDocumento = 0,
                        Tabla = "NotaFiscalBoliviaPadraoERP",
                        Mensaje = "No se esta cerando el Ticket NotaFiscalBoliviaPadraoERP"
                    });

                    return true;
                }
                OnLog(new ObjLog()
                {
                    Tipo = 99,
                    Ticket = Ticket,
                    CodigoDocumento = 0,
                    Tabla = "NotaFiscalBoliviaPadraoERP",
                    Mensaje = "Cerrando ticket NotaFiscalBoliviaPadraoERP"
                });
                DateTime fecha;
                ArrayOfString errores;
                ConfirmacaoDocumento documento;
                var documentos = new ArrayOfConfirmacaoDocumento();

                foreach (var d in notas)
                {
                    documento = new ConfirmacaoDocumento() { CodigoDocumento = d.CodigoDocumento, MensagemErro = "Error", Situacao = 1 };
                    documentos.Add(documento);
                }
                try
                {
                    var cierre = conexion_SOAP.AdicionarConfirmacaoTicket(Token, "NotaFiscalPadraoERP", "NFBolivia_1.0", Ticket, documentos, out fecha, out errores);
                    OnLog(new ObjLog()
                    {
                        Tipo = 0,
                        Ticket = Ticket,
                        CodigoDocumento = 0,
                        Tabla = "NotaFiscalPadraoERP",
                        Mensaje = "Tickets de NotaFiscalPadraoERP cerrado correctamente."
                    });
                    return true;
                }
                catch (Exception ex)
                {
                    OnLog(new ObjLog()
                    {
                        Tipo = -4,
                        Ticket = Ticket,
                        CodigoDocumento = 0,
                        Tabla = "NotaFiscalPadraoERP",
                        Mensaje = "Error cerrando ticket NotaFiscalPadraoERP: " + ex.Message
                    });
                    return false;
                }
            }

        }
}
