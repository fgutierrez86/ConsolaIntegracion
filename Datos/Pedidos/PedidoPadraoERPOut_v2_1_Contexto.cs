using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Dapper;
using Datos.PadraoPruebas;

namespace Datos.Pedidos
{
    public class PedidoPadraoERPOut_v2_1_Contexto:Contexto
    {
        public WSIntegracaoPadraoSoapClient conexion_SOAP
        {
            get
            {
                return new WSIntegracaoPadraoSoapClient();
            }
        }



        private int codigoCuentaContableCostoDeMateriales = Convert.ToInt32(Parametro.GetParametroXNombre("CodigoCuentaCosto").Select(x => x.Valor).FirstOrDefault());
        public string GetXMLFromGera()
        {
            try
            {
                OnLog(new ObjLog() { Tipo = 1, Ticket = 0, CodigoDocumento = 0, Tabla = "PedidoPadraoERP", Mensaje = "Conectando al web service...   " });
                var export = conexion_SOAP.ExportarDados(Token, "PedidoPadraoERP", "2.1");
                Ticket = export.CodigoTicket;
                OnLog(new ObjLog() { Tipo = 2, Ticket = Ticket, CodigoDocumento = 0, Mensaje = "PedidoPadraoERP: Retorno del WS, Tickets No." + Ticket.ToString() });
                string xml;
                if (export.Ticket != null)
                    xml = export.Ticket.ToString();
                else
                    return null;
                OnLog(new ObjLog() { Tipo = 3, Ticket = Ticket, CodigoDocumento = 0, Tabla = "PedidoPadraoERP", Mensaje = "Grabando ticket Pedido..." });
                return xml;
            }
            catch (Exception ex)
            {
                OnLog(new ObjLog() { Tipo = -1, CodigoDocumento = Ticket, Tabla = "PedidoPadraoERP", Mensaje = "Excepcion en la conexion SOAP para PedidoPadraoERP:  " + ex.Message });
                throw new Exception("Excepcion en la conexion de pedidos... " + ex.Message);
            }

        }
        public PedidoPadraoERPOut_v2_1[] GetPedidosFromXML(string xml, bool grabarTicket)
        {
            OnLog(new ObjLog() { Tipo = 4, Ticket = Ticket, CodigoDocumento = 0, Tabla = "PedidoPadraoERP", Mensaje = "Deserializando Pedidos..." });
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(PedidoPadraoERPOut_v2_1[]), new XmlRootAttribute("ArrayOfPedidoPadraoERPOut_v2_1"));
                PedidoPadraoERPOut_v2_1[] pedidos;
                TextReader reader = new StringReader(xml);
                OnLog(new ObjLog() { Tipo = 5, Ticket = Ticket, CodigoDocumento = 0, Tabla = "PedidoPadraoERP", Mensaje = "Convertiendo a objetos Pedidos" });
                pedidos = (PedidoPadraoERPOut_v2_1[])deserializer.Deserialize(reader);
                if (grabarTicket)
                    GrabarTicket("Pedidos", pedidos.Count(), Ticket, xml);
                reader.Close();
                return pedidos;
            }
            catch (Exception ex)
            {
                OnLog(new ObjLog() { Tipo = -2, CodigoDocumento = 0, Ticket = Ticket, Tabla = "PedidoPadraoERP", Mensaje = "Excepcion en la serializacion de PedidoPadraoERP: " + ex.Message });
                throw new Exception("Excepcion en la serializacion de pedidos... " + ex.Message);
            }
        }

        public string GrabarPedidos(PedidoPadraoERPOut_v2_1[] pedidos)
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
                            Tipo = 6,
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
                        p.Add(@"CodigoContaContabil ", pedido.ContaContabil.CodigoContaContabil);
                        p.Add(@"ContaContabil ", pedido.ContaContabil.ContaContabil);
                        p.Add(@"MeioCaptacao", pedido.MeioCaptacao);
                        p.Add(@"SistemaOrigem", pedido.SistemaOrigem);
                        p.Add(@"CodigoModeloComercial ", pedido.CodigoModeloComercial);
                        p.Add(@"ModeloComercial ", pedido.ModeloComercial);
                        p.Add(@"Volume", pedido.Volume);
                        p.Add(@"Peso ", pedido.Peso);
                        p.Add(@"ValorContaCorrenteResidual ", pedido.ValorContaCorrenteResidual);
                        p.Add(@"CodigoExternoPoliticaEntrega ", pedido.CodigoExternoPoliticaEntrega);
                        p.Add(@"OpcaoEntrega ", pedido.OpcaoEntrega);
                        p.Add(@"CodigoPessoa", pedido.PessoaPedido.CodigoPessoa);
                        var insertUpdate =
                            conn.Query<string>(@"Pedidos.PedidoPadraoERPOut_v2_1_Ins", p,
                                commandType: CommandType.StoredProcedure).FirstOrDefault();
                        OnLog(new ObjLog() { Tipo = 7, Ticket = Ticket, CodigoDocumento = pedido.CodigoPedido, Tabla = "PedidoPadraoERP", Mensaje = "Grabacion de PedidoPadraoERP, tipo: " + insertUpdate + " Código: " + pedido.CodigoPedido });


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
                        OnLog(new ObjLog() { Tipo = 112, Ticket = Ticket, CodigoDocumento = pedido.PessoaPedido.CodigoPessoa, Tabla = "PessoaPedidoPadraoERP", Mensaje = "Grabacion de ItemPedidoPadraoERP, Tipo: " + insertUpdate + " Código: " + pedido.CodigoPedido });



                        foreach (var item in pedido.ItensPedido)
                        {
                            var contaContabil = item.ContaContabil.CodigoContaContabil == 0 ? pedido.ContaContabil.ContaContabil : item.ContaContabil.ContaContabil;
                            var codigoContaContabil = item.ContaContabil.CodigoContaContabil == 0 ? pedido.ContaContabil.CodigoContaContabil : item.ContaContabil.CodigoContaContabil;
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
                            p.Add(@"CodigoContaContabil", codigoContaContabil);
                            p.Add(@"ContaContabil", contaContabil);


                            conn.Execute(@"Pedidos.ItemPedidoPadraoERPOut_v2_1_Ins", p,
                                commandType: CommandType.StoredProcedure);
                            OnLog(new ObjLog() { Tipo = 8, Ticket = Ticket, CodigoDocumento = item.Produto.CodigoProduto, Tabla = "ItemPedidoPadraoERP", Mensaje = "Grabacion de ItemPedidoPadraoERP, Tipo: " + insertUpdate + " Código: " + pedido.CodigoPedido });

                            InsertarMaterial(pedido.CodigoDocumento, "I", pedido.CodigoPedido, item.NumeroItem,
                                item.Produto.Materiais, codigoContaContabil);
                        }
                        foreach (var brinde in pedido.Brindes)
                        {
                            var contaContabil = brinde.ContaContabil.CodigoContaContabil == 0 ? pedido.ContaContabil.ContaContabil : brinde.ContaContabil.ContaContabil;
                            var codigoContaContabil = brinde.ContaContabil.CodigoContaContabil == 0 ? pedido.ContaContabil.CodigoContaContabil : brinde.ContaContabil.CodigoContaContabil;
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
                            p.Add(@"CodigoContaContabil", codigoContaContabil);
                            p.Add(@"ContaContabil", contaContabil);


                            conn.Execute(@"Pedidos.PedidoBrindePadraoERPOut_v2_1_Ins", p,
                                commandType: CommandType.StoredProcedure);

                            OnLog(new ObjLog() { Tipo = 10, Ticket = Ticket, CodigoDocumento = brinde.Produto.CodigoProduto, Tabla = "PedidoBrindePadraoERP", Mensaje = "Grabacion de PedidoBrindePadraoERP, Tipo: " + insertUpdate + " Código: " + pedido.CodigoPedido });

                            InsertarMaterial(pedido.CodigoDocumento, "B", pedido.CodigoPedido, brinde.NumeroItemBrinde,
                                brinde.Produto.Materiais, codigoContaContabil);
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
                                itemCortado.Produto.CodigoProduto, itemCortado.Produto.Materiais, 0);
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
                            Tipo = -3,
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

        private void InsertarMaterial(long codigoDocumento, string itemBrindeCorte, int codigoPedido, int numeroItem, IEnumerable<PedidoMaterialPadraoERPOut_v2_1> materiales, int cuentaContable)
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
                        decimal descuento = 0;
                        if (cuentaContable == codigoCuentaContableCostoDeMateriales && material.PrecoLiquido == 0)
                        {
                            descuento = material.PrecoTabela * material.Quantidade * 0.7m;
                        }
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
                        p.Add(@"Descuento", descuento);
                        conn.Execute(@"Pedidos.PedidoMaterialPadraoERPOut_v2_1_Ins", p,
                           commandType: CommandType.StoredProcedure);
                        OnLog(new ObjLog()
                        {
                            Tipo = 9,
                            Ticket = Ticket,
                            CodigoDocumento = numeroItem,
                            Tabla = "PedidoMaterialPadraoERP",
                            Mensaje = "Grabacion de PedidoMaterialPadraoERP,  CódigoPedido: " + codigoPedido
                        });
                    }
                }
                catch (Exception ex)
                {

                    OnLog(new ObjLog()
                    {
                        Tipo = 7,
                        Ticket = Ticket,
                        CodigoDocumento = codigoDocumento,
                        Tabla = "PedidoMaterialPadraoERP",
                        Mensaje = "Excepcion: Grabacion de PedidoMaterialPadraoERP, ItemBrindeCorte: " + itemBrindeCorte + " Código: " + codigoPedido + " " + ex.Message
                    });
                    throw new Exception("Excepcion en la grabacion de materiales del pedidos... " + ex.Message);
                }
            }
        }
        public bool CerrarTicket(PedidoPadraoERPOut_v2_1[] pedidos)
        {
            // si esta puesto que no hay que cerrar ticket, retornar sin hacer nada...
            if (HayQueCerrarTicket == "NO")
            {
                OnLog(new ObjLog()
                {
                    Tipo = 99,
                    Ticket = Ticket,
                    CodigoDocumento = 0,
                    Tabla = "PedidoPadraoERPOut_v2_1",
                    Mensaje = "No se esta cerando el Ticket PedidoPadraoERPOut_v2_1"
                });

                return true;
            }
            OnLog(new ObjLog()
            {
                Tipo = 99,
                Ticket = Ticket,
                CodigoDocumento = 0,
                Tabla = "PedidoPadraoERP",
                Mensaje = "Cerrando ticket "
            });
            var conexion = new WSIntegracaoPadraoSoapClient();
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
                var cierre = conexion.AdicionarConfirmacaoTicket(Token, "PedidoPadraoERP", "2.1", Ticket, documentos, out fecha, out errores);
                OnLog(new ObjLog()
                {
                    Tipo = 100,
                    Ticket = Ticket,
                    CodigoDocumento = 0,
                    Tabla = "PedidoPadraoERP",
                    Mensaje = "Tickets cerrado correctamente."
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
                    Tabla = "PedidoPadraoERP",
                    Mensaje = "Error cerrando ticket PedidoPadraoERP: " + ex.Message
                });
                return false;
            }
        }
    }
}
