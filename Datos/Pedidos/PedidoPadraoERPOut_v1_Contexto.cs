using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Dapper;
using Datos.PadraoPruebas;

namespace Datos.Pedidos
{

    public class PedidoPadraoERPOut_v1_Contexto:Contexto
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
                OnLog(new ObjLog() { Tipo = 101, Ticket = 0, CodigoDocumento = 0, Tabla = "PedidoPadrao_v1", Mensaje = "Conectando al web service...   " });
                var export = conexion_SOAP.ExportarDados(Token, "PedidoPadraoERP", "2.1");
                Ticket = export.CodigoTicket;
                OnLog(new ObjLog() { Tipo = 102, Ticket = Ticket, CodigoDocumento = 0, Mensaje = "PedidoPadrao_v1: Retorno del WS, Tickets No." + Ticket.ToString() });
                string xml;
                if (export.Ticket != null)
                    xml = export.Ticket.ToString();
                else
                    return null;
                OnLog(new ObjLog() { Tipo = 103, Ticket = Ticket, CodigoDocumento = 0, Tabla = "PedidoPadrao_v1", Mensaje = "Grabando ticket Pedido..." });
                return xml;
            }
            catch (Exception ex)
            {
                OnLog(new ObjLog() { Tipo = -101, CodigoDocumento = Ticket, Tabla = "PedidoPadrao_v1", Mensaje = "Excepcion en la conexion SOAP para PedidoPadrao_v1:  " + ex.Message });
                throw new Exception("Excepcion en la conexion de pedidos... " + ex.Message);
            }

        }
        public PedidoPadraoERPOut_v1[] GetPedidosFromXML(string xml, bool grabarTicket)
        {
            OnLog(new ObjLog() { Tipo = 104, Ticket = Ticket, CodigoDocumento = 0, Tabla = "PedidoPadrao_v1", Mensaje = "Deserializando Pedidos..." });
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(PedidoPadraoERPOut_v1[]), new XmlRootAttribute("ArrayOfPedidoPadraoERPOut_v1"));      //   FOR PROD
                PedidoPadraoERPOut_v1[] pedidos;
                TextReader reader = new StringReader(xml);
                OnLog(new ObjLog() { Tipo = 105, Ticket = Ticket, CodigoDocumento = 0, Tabla = "PedidoPadrao_v1", Mensaje = "Convertiendo a objetos Pedidos" });
                pedidos = (PedidoPadraoERPOut_v1[])deserializer.Deserialize(reader);
                if (grabarTicket)
                    GrabarTicket("Pedidos", pedidos.Count(), Ticket, xml);
                reader.Close();
                return pedidos;
            }
            catch (Exception ex)
            {
                OnLog(new ObjLog() { Tipo = -102, CodigoDocumento = 0, Ticket = Ticket, Tabla = "PedidoPadrao_v1", Mensaje = "Excepcion en la serializacion de PedidoPadrao_v1: " + ex.Message });
                throw new Exception("Excepcion en la serializacion de pedidos... " + ex.Message);
            }
        }

        public string GrabarPedidos(PedidoPadraoERPOut_v1[] pedidos)
        {
            var cnn = ConexionBD.CadenaDeConexionIntermedia;

            using (var conn = new SqlConnection(cnn))
            {
                foreach (var pedido in pedidos)
                {
                    try
                    {
                        var p = new DynamicParameters();
                        OnLog(new ObjLog()
                        {
                            Tipo = 106,
                            Ticket = Ticket,
                            CodigoDocumento = pedido.CodigoDocumento,
                            Tabla = "inicio Grabacion Pedidos...",
                            Mensaje = "Grabando Pedido: " + pedido.CodigoPedido
                        });
                        p.Add(@"Ticket", Ticket);
                        p.Add(@"CodigoDocumento", pedido.CodigoDocumento);
                        p.Add(@"CodigoPedido ", pedido.CodigoPedido);
                        p.Add(@"SituacaoComercial", pedido.SituacaoComercial);
                        p.Add(@"SituacaoFiscal", pedido.SituacaoFiscal);
                        p.Add(@"Campanha ", pedido.Campanha);
                        p.Add(@"CampanhaMarketing ", pedido.CampanhaMarketing);
                        p.Add(@"CampanhaIndicador ", pedido.CampanhaIndicador);
                        p.Add(@"Funcao ", pedido.Funcao);
                        p.Add(@"Papel ", pedido.Papel);
                        p.Add(@"CentroDistribuicao ", pedido.CentroDistribuicao);
                        p.Add(@"TipoCentroDistribuicao", pedido.TipoCentroDistribuicao);
                        p.Add(@"CentroDistribuicaoFaturamento ", pedido.CentroDistribuicaoFaturamento);
                        p.Add(@"DataHoraPedido ", pedido.DataHoraPedido);
                        p.Add(@"DataHoraAprovacao ", pedido.DataHoraAprovacao);
                        p.Add(@"CodigoContaContabil ", null);
                        p.Add(@"ContaContabil ", null);
                        p.Add(@"MeioCaptacao", pedido.MeioCaptacao);
                        p.Add(@"SistemaOrigem", pedido.SistemaOrigem);
                        p.Add(@"CodigoModeloComercial ", pedido.CodigoModeloComercial);
                        p.Add(@"ModeloComercial ", pedido.ModeloComercial);
                        p.Add(@"Volume", pedido.Volume);
                        p.Add(@"Peso ", pedido.Peso);
                        p.Add(@"ValorContaCorrenteResidual ", null);
                        p.Add(@"CodigoExternoPoliticaEntrega ", pedido.CodigoExternoPoliticaEntrega);
                        p.Add(@"OpcaoEntrega ", pedido.OpcaoEntrega);
                        p.Add(@"CodigoPessoa", pedido.PessoaPedido.CodigoPessoa);
                        var insertUpdate =
                            conn.Query<string>(@"Pedidos.PedidoPadraoERPOut_v2_1_Ins", p,
                                commandType: CommandType.StoredProcedure).FirstOrDefault();
                        OnLog(new ObjLog() { Tipo = 107, Ticket = Ticket, CodigoDocumento = pedido.CodigoPedido, Tabla = "PedidoPadrao_v1", Mensaje = "Grabacion de PedidoPadrao_v1, tipo: " + insertUpdate + " Código: " + pedido.CodigoPedido });



                        var pessoa = pedido.PessoaPedido;
                        p = new DynamicParameters();
                        p.Add(@"Ticket", Ticket);
                        p.Add(@"CodigoDocumento", pedido.CodigoDocumento);
                        p.Add(@"CodigoPedido", pedido.CodigoPedido);
                        p.Add(@"CodigoPessoa", pessoa.CodigoPessoa);
                        p.Add(@"NomePessoa", pessoa.PessoaNome);
                        p.Add(@"TipoIdentificacao", pessoa.TipoIdentificacao);

                        conn.Execute(@"Pedidos.PessoaPedidoPadraoERPOut_v2_1_Ins", p,
                                commandType: CommandType.StoredProcedure);
                        OnLog(new ObjLog() { Tipo = 112, Ticket = Ticket, CodigoDocumento = pessoa.CodigoPessoa, Tabla = "PessoaPedidoPadraoERP", Mensaje = "Grabacion de ItemPedidoPadraoERP, Tipo: " + insertUpdate + " Código: " + pedido.CodigoPedido });



                        foreach (var item in pedido.ItensPedido)
                        {
                            p = new DynamicParameters();
                            p.Add(@"Ticket", Ticket);
                            p.Add(@"CodigoDocumento", pedido.CodigoDocumento);
                            p.Add(@"CodigoPedido", pedido.CodigoPedido);
                            p.Add(@"NumeroItem", item.NumeroItem);
                            p.Add(@"Quantidade", item.Quantidade);
                            p.Add(@"PrecoTabela", item.PrecoTabela);
                            p.Add(@"PrecoPraticado", item.PrecoPraticado);
                            p.Add(@"PrecoLiquido", item.PrecoLiquido);
                            p.Add(@"PrecoCusto", item.PrecoCusto);
                            p.Add(@"ValorComissao", item.ValorComissao);
                            p.Add(@"QuantidadePontos", item.QuantidadePontos);
                            p.Add(@"Kit", item.Kit);
                            p.Add(@"TipoProduto", item.TipoProduto);
                            p.Add(@"CodigoProduto", item.Produto.CodigoProduto);
                            p.Add(@"NomeProduto", item.Produto.NomeProduto);
                            p.Add(@"CodigoContaContabil", null);
                            p.Add(@"ContaContabil", null);


                            conn.Execute(@"Pedidos.ItemPedidoPadraoERPOut_v2_1_Ins", p,
                                commandType: CommandType.StoredProcedure);
                            OnLog(new ObjLog() { Tipo = 108, Ticket = Ticket, CodigoDocumento = item.Produto.CodigoProduto, Tabla = "ItemPedidoPadraoERP", Mensaje = "Grabacion de ItemPedidoPadraoERP, Tipo: " + insertUpdate + " Código: " + pedido.CodigoPedido });

                            InsertarMaterial(pedido.CodigoDocumento, "I", pedido.CodigoPedido, item.NumeroItem,
                                item.Produto.Materiais);
                        }
                        foreach (var brinde in pedido.Brindes)
                        {
                            p = new DynamicParameters();
                            p.Add(@"Ticket", Ticket);
                            p.Add(@"CodigoDocumento", pedido.CodigoDocumento);
                            p.Add(@"NumeroPedido", pedido.CodigoPedido);
                            p.Add(@"NumeroItemBrinde", brinde.NumeroItemBrinde);
                            p.Add(@"Quantidade", brinde.Quantidade);
                            p.Add(@"PrecoTabela", brinde.PrecoTabela);
                            p.Add(@"PrecoCusto", brinde.PrecoCusto);
                            p.Add(@"Kit", brinde.Kit);
                            p.Add(@"TipoProduto", brinde.TipoProduto);
                            p.Add(@"CodigoProduto", brinde.Produto.CodigoProduto);
                            p.Add(@"NomeProduto", brinde.Produto.NomeProduto);
                            p.Add(@"CodigoPromocao", brinde.Promocao.CodigoPromocao);
                            p.Add(@"NomePromocao", brinde.Promocao.NomePromocao);
                            p.Add(@"CodigoContaContabil", null);
                            p.Add(@"ContaContabil", null);


                            conn.Execute(@"Pedidos.PedidoBrindePadraoERPOut_v2_1_Ins", p,
                                commandType: CommandType.StoredProcedure);

                            OnLog(new ObjLog() { Tipo = 110, Ticket = Ticket, CodigoDocumento = brinde.Produto.CodigoProduto, Tabla = "PedidoBrindePadraoERP", Mensaje = "Grabacion de PedidoBrindePadraoERP, Tipo: " + insertUpdate + " Código: " + pedido.CodigoPedido });

                            InsertarMaterial(pedido.CodigoDocumento, "B", pedido.CodigoPedido, brinde.NumeroItemBrinde,
                                brinde.Produto.Materiais);
                        }
                        foreach (var itemCortado in pedido.ItensCortados)
                        {
                            p = new DynamicParameters();
                            p.Add(@"Ticket", Ticket);
                            p.Add(@"CodigoDocumento", pedido.CodigoDocumento);
                            p.Add(@"CodigoPedido", pedido.CodigoPedido);
                            p.Add(@"CodigoProduto", itemCortado.Produto.CodigoProduto);
                            p.Add(@"NomeProduto", itemCortado.Produto.NomeProduto);
                            p.Add(@"PrecoTabela", itemCortado.PrecoTabela);
                            p.Add(@"PrecoPraticado", itemCortado.PrecoPraticado);
                            p.Add(@"Quantidade", itemCortado.Quantidade);
                            p.Add(@"MotivoCorteItemPedido", itemCortado.MotivoCorteItemPedido);


                            conn.Execute(@"Pedidos.PedidoItemCortadoPadraoERPOut_v1_Ins", p,
                                commandType: CommandType.StoredProcedure);

                            OnLog(new ObjLog() { Tipo = 111, Ticket = Ticket, CodigoDocumento = itemCortado.Produto.CodigoProduto, Tabla = "PedidoItemCortadoPadraoERP", Mensaje = "Grabacion de PedidoItemCortadoPadraoERP, Tipo: " + insertUpdate + " Código: " + pedido.CodigoPedido });

                            InsertarMaterial(pedido.CodigoDocumento, "C", pedido.CodigoPedido,
                                itemCortado.Produto.CodigoProduto, itemCortado.Produto.Materiais);
                        }
                        var entrega = pedido.EntregaPedido;
                        p = new DynamicParameters();
                        p.Add(@"Ticket", Ticket);
                        p.Add(@"CodigoDocumento", pedido.CodigoDocumento);
                        p.Add(@"CodigoPedido", pedido.CodigoPedido);
                        p.Add(@"PoliticaEntrega", entrega.PoliticaEntrega);
                        p.Add(@"ValorEntrega", entrega.ValorEntrega);
                        p.Add(@"EntregaCodigoArea", entrega.EntregaCodigoArea);
                        p.Add(@"EstruturaGeograficaNivel0 ", entrega.EstruturaGeograficaNivel0);
                        p.Add(@"EstruturaGeograficaNivel1", entrega.EstruturaGeograficaNivel1);
                        p.Add(@"EstruturaGeograficaNivel2", entrega.EstruturaGeograficaNivel2);
                        p.Add(@"EstruturaGeograficaNivel3", entrega.EstruturaGeograficaNivel3);
                        p.Add(@"EstruturaGeograficaNivel4", entrega.EstruturaGeograficaNivel4);
                        p.Add(@"EstruturaGeograficaNivel5", entrega.EstruturaGeograficaNivel5);
                        p.Add(@"EstruturaGeograficaNivel6", entrega.EstruturaGeograficaNivel6);
                        p.Add(@"EstruturaGeograficaNivel7", entrega.EstruturaGeograficaNivel7);
                        p.Add(@"EstruturaGeograficaNivel8", entrega.EstruturaGeograficaNivel8);
                        p.Add(@"EstruturaGeograficaNivel9", entrega.EstruturaGeograficaNivel9);
                        p.Add(@"EntregaNumero", entrega.EntregaNumero);
                        p.Add(@"EntregaComplemento", entrega.EntregaComplemento);
                        p.Add(@"EntregaReferencia", entrega.EntregaReferencia);
                        p.Add(@"DataPrevisaoEntrega", entrega.DataPrevisaoEntrega);
                        p.Add(@"EntregaVizinho", entrega.EntregaVizinho);
                        p.Add(@"EntregaNumeroVizinho", entrega.EntregaNumeroVizinho);

                        conn.Execute(@"Pedidos.EntregaPedidoPadraoERPOut_v2_1_Ins", p, commandType: CommandType.StoredProcedure);

                        OnLog(new ObjLog() { Tipo = 111, Ticket = Ticket, CodigoDocumento = pedido.CodigoPedido, Tabla = "PedidoItemCortadoPadraoERP", Mensaje = "Grabacion de PedidoItemCortadoPadraoERP, Tipo: " + insertUpdate + " Código: " + pedido.CodigoPedido });
                    }
                    catch (Exception ex)
                    {

                        OnLog(new ObjLog()
                        {
                            Tipo = -103,
                            Ticket = Ticket,
                            CodigoDocumento = pedido.CodigoDocumento,
                            Tabla = "Pedidos",
                            Mensaje = "\n\nExcepcion en la grabacion de Pedido :  " + ex.Message
                        });
                        throw new Exception("Excepcion en la grabacion de pedidos... " + ex.Message);
                    }


                }


            }
            return null;
        }

        private void InsertarMaterial(long codigoDocumento, string itemBrindeCorte, int codigoPedido, int numeroItem, IEnumerable<PedidoMaterialPadraoERPOut_v1> materiales)
        {
            if (materiales == null)
                return;
            var cnn = ConexionBD.CadenaDeConexionIntermedia;

            using (var conn = new SqlConnection(cnn))
            {
                try
                {
                    foreach (var material in materiales)
                    {
                        var p = new DynamicParameters();
                        p.Add(@"Ticket", Ticket);
                        p.Add(@"CodigoDocumento", codigoDocumento);
                        p.Add(@"CodigoPedido", codigoPedido);
                        p.Add(@"NumeroItem", numeroItem);
                        p.Add(@"CodigoMaterialSKU", material.CodigoMaterialSKU);
                        p.Add(@"Item_Brinde_Corte", itemBrindeCorte);
                        p.Add(@"Quantidade", material.Quantidade);
                        p.Add(@"PrecoTabela", material.PrecoTabela);
                        p.Add(@"PrecoPraticado", material.PrecoPraticado);
                        p.Add(@"PrecoLiquido", material.PrecoLiquido);
                        p.Add(@"PrecoCusto", material.PrecoCusto);
                        p.Add(@"ValorComissao", material.ValorComissao);
                        conn.Execute(@"Pedidos.PedidoMaterialPadraoERPOut_v2_1_Ins", p,
                           commandType: CommandType.StoredProcedure);
                        OnLog(new ObjLog()
                        {
                            Tipo = 109,
                            Ticket = Ticket,
                            CodigoDocumento = numeroItem,
                            Tabla = "PedidoMaterialPadraoERP",
                            Mensaje = "Grabacion de PedidoMaterialPadraoERP,  CódigoPedido: " + codigoPedido + ", Item_Brinde: " + itemBrindeCorte
                        });
                    }
                }
                catch (Exception ex)
                {

                    OnLog(new ObjLog()
                    {
                        Tipo = 7,
                        Ticket = Ticket,
                        CodigoDocumento = numeroItem,
                        Tabla = "PedidoMaterialPadraoERP",
                        Mensaje = "Excepcion: Grabacion de PedidoMaterialPadraoERP, ItemBrindeCorte: " + itemBrindeCorte + " Código: " + codigoPedido + " " + ex.Message
                    });
                    throw new Exception("Excepcion en la grabacion de materiales del pedidos... " + ex.Message);
                }
            }
        }
        public void CerrarTicket(PedidoPadraoERPOut_v1[] pedidos)
        {
            // si esta puesto que no hay que cerrar ticket, retornar sin hacer nada...
            if (HayQueCerrarTicket == "NO")
            {
                OnLog(new ObjLog()
                {
                    Tipo = 99,
                    Ticket = Ticket,
                    CodigoDocumento = 0,
                    Tabla = "PedidoPadraoERPOut_v1",
                    Mensaje = "No se esta cerando el Ticket PedidoPadraoERPOut_v1"
                });
                return;
            }

            OnLog(new ObjLog()
            {
                Tipo = 99,
                Ticket = Ticket,
                CodigoDocumento = 0,
                Tabla = "PedidoPadraoERP",
                Mensaje = "Cerrando ticket "
            });
            DateTime fecha;
            ArrayOfString errores;
            ConfirmacaoDocumento documento;
            var documentos = new ArrayOfConfirmacaoDocumento();

            foreach (var d in pedidos)
            {
                documento = new ConfirmacaoDocumento() { CodigoDocumento = d.CodigoDocumento, MensagemErro = "Error", Situacao = 1 };
                documentos.Add(documento);
            }
            try
            {
                var cierre = conexion_SOAP.AdicionarConfirmacaoTicket(Token, "PedidoPadraoERP", "1.0", Ticket, documentos, out fecha, out errores);
                OnLog(new ObjLog()
                {
                    Tipo = 200,
                    Ticket = Ticket,
                    CodigoDocumento = 0,
                    Tabla = "PedidoPadrao_v1",
                    Mensaje = "Tickets cerrado correctamente."
                });

            }
            catch (Exception ex)
            {
                OnLog(new ObjLog()
                {
                    Tipo = -104,
                    Ticket = Ticket,
                    CodigoDocumento = 0,
                    Tabla = "PedidoPadrao_v1",
                    Mensaje = "Error cerrando ticket PedidoPadrao_v1: " + ex.Message
                });
                throw new Exception("Excepcion al cerrar ticket de pedidos... " + ex.Message);
            }
        }



    }
}
