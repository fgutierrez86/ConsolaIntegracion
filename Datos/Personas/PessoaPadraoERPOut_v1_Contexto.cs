using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Dapper;
using Datos.PadraoPruebas;

namespace Datos.Personas
{
    public class PessoaPadraoERPOut_v1_Contexto:Contexto
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
              OnLog(new ObjLog() { Tipo = 1, Ticket = 0, CodigoDocumento = 0, Tabla = "PessoaPadraoERP", Mensaje = "Conectando al web service...   " });
                var export = conexion_SOAP.ExportarDados(Token, "PessoaPadraoERP", "1.0");
                Ticket = export.CodigoTicket;
                OnLog(new ObjLog() { Tipo = 2, Ticket = Ticket, CodigoDocumento = 0, Mensaje = "PessoaPadraoERP: Retorno del WS, Tickets No." + Ticket.ToString() });
                string xml;
                if(export.Ticket !=null)
                    xml = export.Ticket.ToString();
                else
                    return null;
                OnLog(new ObjLog() { Tipo = 3, Ticket = Ticket, CodigoDocumento = 0, Tabla = "PessoaPadraoERP", Mensaje = "Grabando ticket Pedido..." });
                return xml;
            }
            catch (Exception ex)
            {
                OnLog(new ObjLog(){ Tipo =-1, CodigoDocumento = Ticket, Tabla = "PessoaPadraoERP", Mensaje = "Excepcion en la conexion SOAP para PessoaPadraoERP:  " + ex.Message});
                throw  new Exception("Excepcion en la conexion SOAP para Personas: " + ex.Message);

            }
        }

        public PessoaPadraoERPOut_v1[] GetPessoaFromXML(string xml, bool grabarTicket)
        {
          try{ 
                OnLog(new ObjLog() {Tipo = 4, Ticket = Ticket, CodigoDocumento = 0, Tabla = "PessoaPadraoERP", Mensaje = "Deserializando..." });
                XmlSerializer deserializer = new XmlSerializer(typeof(PessoaPadraoERPOut_v1[]), new XmlRootAttribute("ArrayOfPessoaPadraoERPOut_v1"));
                PessoaPadraoERPOut_v1[] personas;
                OnLog(new ObjLog() {Tipo = 5 ,Ticket = Ticket, CodigoDocumento = 0, Tabla = "PessoaPadraoERP", Mensaje = "Convertiendo a objetos Personas" });
                TextReader reader = new StringReader(xml);
                personas = (PessoaPadraoERPOut_v1[])deserializer.Deserialize(reader);
              if(grabarTicket)
                    GrabarTicket("Personas", personas.Count(), Ticket, xml);
                reader.Close();
                return personas;
            }
            catch (Exception ex)
            {
                OnLog(new ObjLog(){ Tipo =-2, CodigoDocumento = Ticket, Tabla = "PessoaPadraoERP", Mensaje = "Excepcion en la serializacion de PessoaPadraoERP: " + ex.Message});
                throw  new Exception("Excepcion en la serializacion de Personas: " + ex.Message);
            }
        }


              public string GrabarPersonas(PessoaPadraoERPOut_v1[] personas)
      {
            var cnn = ConexionBD.CadenaDeConexionIntermedia;
          using (var conn = new SqlConnection(cnn))
          {
              foreach (var persona in personas)
              {
                  try
                  {
                      var p = new DynamicParameters();
                      OnLog(new ObjLog() { Tipo=6, Ticket=Ticket, CodigoDocumento = persona.CodigoDocumento, Tabla = "inicio PessoaPadraoERP", Mensaje = "Grabando Persona: " + persona.Codigo });
                      p.Add(@"Ticket", Ticket);
                      p.Add(@"CodigoDocumento", persona.CodigoDocumento);
                      p.Add(@"Codigo", persona.Codigo);
                      p.Add(@"Nome", persona.Nome);
                      p.Add(@"Apellido", persona.Apelido);
                      p.Add(@"Tipo", persona.Tipo);
                      var insertUpdate = conn.Query<string>(@"Personas.PessoaPadraoERPOut_v1_Ins", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    OnLog(new ObjLog() { Tipo = 7 ,Ticket=Ticket, CodigoDocumento = persona.CodigoDocumento, Tabla = "PessoaPadraoERP", Mensaje = "Grabacion de PessoaPadraoERP, tipo: " + insertUpdate + " Código: " + persona.Codigo });

                      p = new DynamicParameters();
                      if (persona.Funcao != null)
                      {
                          foreach (var funcao in persona.Funcao)
                          {
                              p.Add(@"Ticket", Ticket);
                              p.Add(@"CodigoDocumento", persona.CodigoDocumento);
                              p.Add(@"CodigoPessoa", persona.Codigo);
                              p.Add(@"CodigoFuncao", funcao.CodigoFuncao);
                              p.Add(@"NomeFuncao", funcao.NomeFuncao);
                              p.Add(@"SituacaoComercial", funcao.SituacaoComercial);
                              p.Add(@"Campanha", funcao.Campanha);
                              p.Add(@"SaldoCredito", funcao.SaldoCredito);
                              p.Add(@"LimiteCredito", funcao.LimiteCredito);
                              p.Add(@"EstruturaComercial0", funcao.EstruturaComercial0);
                              p.Add(@"EstruturaComercial1", funcao.EstruturaComercial1);
                              p.Add(@"EstruturaComercial2", funcao.EstruturaComercial2);
                              p.Add(@"EstruturaComercial3", funcao.EstruturaComercial3);
                              p.Add(@"EstruturaComercial4", funcao.EstruturaComercial4);
                              p.Add(@"EstruturaComercial5", funcao.EstruturaComercial5);
                              p.Add(@"EstruturaComercial6", funcao.EstruturaComercial6);
                              p.Add(@"EstruturaComercial7", funcao.EstruturaComercial7);
                              p.Add(@"EstruturaComercial8", funcao.EstruturaComercial8);
                              p.Add(@"EstruturaComercial9", funcao.EstruturaComercial9);
                              insertUpdate = conn.Query<string>(@"Personas.PessoaFuncaoPadraoERPOut_v1_Ins", p,
                                  commandType: CommandType.StoredProcedure).FirstOrDefault();
                              OnLog(new ObjLog() { Tipo = 8,Ticket=Ticket, CodigoDocumento = persona.CodigoDocumento, Tabla = "PessoaFuncaoPadraoERP", Mensaje = "Grabación de PessoaFuncaoPadraoERP, tipo: " + insertUpdate + " Código: " + persona.Codigo });
                          }
                      }



                      p = new DynamicParameters();
                      if (persona.Documento != null)
                      {
                          foreach (var doc in persona.Documento)
                          {
                              p.Add(@"Ticket", Ticket);
                              p.Add(@"CodigoDocumento", persona.CodigoDocumento);
                              p.Add(@"CodigoPessoa", persona.Codigo);
                              p.Add(@"Tipo", doc.Tipo);
                              p.Add(@"Documento", doc.Documento);
                              p.Add(@"InformacaoExtra", doc.InformacaoExtra);
                              insertUpdate = conn.Query<string>(@"Personas.PessoaDocumentoPadraoERPOut_v1_Ins", p,
                                  commandType: CommandType.StoredProcedure).FirstOrDefault();
                              OnLog(new ObjLog() {Tipo=9, Ticket=Ticket, CodigoDocumento = persona.CodigoDocumento, Tabla = "PessoaDocumentoPadraoERP", Mensaje = "Grabación de PessoaDocumentoPadraoERP, tipo: " + insertUpdate + " Código: " + persona.Codigo });
                          }
                      }
                      p = new DynamicParameters();
                      if (persona.Endereco != null)
                      {
                          foreach (var endereco in persona.Endereco)
                          {
                              p.Add(@"Ticket", Ticket);
                              p.Add(@"CodigoDocumento", persona.CodigoDocumento);
                              p.Add(@"CodigoPessoa", persona.Codigo);
                              p.Add(@"Tipo", endereco.Tipo);
                              p.Add(@"CodigoArea", endereco.CodigoArea);
                              p.Add(@"EstruturaGeo0", endereco.EstruturaGeo0);
                              p.Add(@"EstruturaGeo1", endereco.EstruturaGeo1);
                              p.Add(@"EstruturaGeo2", endereco.EstruturaGeo2);
                              p.Add(@"EstruturaGeo3", endereco.EstruturaGeo3);
                              p.Add(@"EstruturaGeo4", endereco.EstruturaGeo4);
                              p.Add(@"EstruturaGeo5", endereco.EstruturaGeo5);
                              p.Add(@"EstruturaGeo6", endereco.EstruturaGeo6);
                              p.Add(@"EstruturaGeo7", endereco.EstruturaGeo7);
                              p.Add(@"EstruturaGeo8", endereco.EstruturaGeo8);
                              p.Add(@"EstruturaGeo9", endereco.EstruturaGeo9);
                              p.Add(@"Numero", endereco.Numero);
                              p.Add(@"Complemento", endereco.Complemento);
                              p.Add(@"Referencia", endereco.Referencia);
                              insertUpdate = conn.Query<string>(@"Personas.PessoaEnderecoPadraoERPOut_v1_Ins", p,
                                  commandType: CommandType.StoredProcedure).FirstOrDefault();
                              OnLog(new ObjLog() {Tipo=10, Ticket=Ticket, CodigoDocumento = persona.CodigoDocumento, Tabla = "PessoaEnderecoPadraoERP", Mensaje = "Grabación de PessoaEnderecoPadraoERP, tipo: " + insertUpdate + " Código: " + persona.Codigo });
                          }
                      }
                      p = new DynamicParameters();
                      if (persona.Telefone != null)
                      {
                          foreach (var telefone in persona.Telefone)
                          {
                              p.Add(@"Ticket", Ticket);
                              p.Add(@"CodigoDocumento", persona.CodigoDocumento);
                              p.Add(@"CodigoPessoa", persona.Codigo);
                              p.Add(@"Tipo", telefone.Tipo);
                              p.Add(@"Telefone", telefone.Telefone);
                              p.Add(@"Ramal", telefone.Ramal);
                              insertUpdate = conn.Query<string>(@"Personas.PessoaTelefonePadraoERPOut_v1_Ins", p,
                                  commandType: CommandType.StoredProcedure).FirstOrDefault();
                              OnLog(new ObjLog() {Tipo=11, Ticket=Ticket, CodigoDocumento = persona.CodigoDocumento, Tabla = "PessoaTelefonePadraoERP", Mensaje = "Grabación de PessoaTelefonePadraoERP, tipo: " + insertUpdate + " Código: " + persona.Codigo });
                          }
                      }
                      
                      p = new DynamicParameters();
                      if (persona.Email != null)
                      {
                          foreach (var email in persona.Email)
                          {
                              p.Add(@"Ticket", Ticket);
                              p.Add(@"CodigoDocumento", persona.CodigoDocumento);
                              p.Add(@"CodigoPessoa", persona.Codigo);
                              p.Add(@"Tipo", email.Tipo);
                              p.Add(@"Email", email.Email);
                              insertUpdate = conn.Query<string>(@"Personas.PessoaEmailPadraoERPOut_v1_Ins", p,
                                  commandType: CommandType.StoredProcedure).FirstOrDefault();
                              OnLog(new ObjLog() {Tipo=12, Ticket=Ticket, CodigoDocumento = persona.CodigoDocumento, Tabla = "PessoaEmailPadraoERP", Mensaje = "Grabación de PessoaEmailPadraoERP, tipo: " + insertUpdate + " Código: " + persona.Codigo });
                          }
                      }
                      p = new DynamicParameters();
                      if (persona.PessoaFisica != null)
                      {
                          var pessoa = persona.PessoaFisica;
                          DateTime fecNac = pessoa.DataNascimento;
                          if(pessoa.DataNascimento.Year < 1900)
                              fecNac = new DateTime(1900,1,1);

                            p.Add(@"Ticket", Ticket);
                            p.Add(@"CodigoDocumento", persona.CodigoDocumento);
                            p.Add(@"CodigoPessoa", persona.Codigo);
                            p.Add(@"DataNascimento", fecNac);
                            p.Add(@"Sexo", pessoa.Sexo);
                            p.Add(@"EstadoCivil", pessoa.EstadoCivil);
                            p.Add(@"Filhos", pessoa.Filhos);
                          insertUpdate = conn.Query<string>(@"Personas.PessoaFisicaPadraoERPOut_v1_Ins", p,
                              commandType: CommandType.StoredProcedure).FirstOrDefault();
                              OnLog(new ObjLog() {Tipo=13, Ticket=Ticket, CodigoDocumento = persona.CodigoDocumento, Tabla = "PessoaFisicaPadraoERP", Mensaje = "Grabación de PessoaFisicaPadraoERP, tipo: " + insertUpdate + " Código: " + persona.Codigo });
                      }
                      p = new DynamicParameters();
                      if (persona.PessoaJuridica != null)
                      {
                          var pessoa = persona.PessoaJuridica;

                            p.Add(@"Ticket", Ticket);
                            p.Add(@"CodigoDocumento", persona.CodigoDocumento);
                          p.Add(@"CodigoPessoa", persona.Codigo);
                          p.Add(@"Tipo", pessoa.Tipo);
                          p.Add(@"ContribuinteICMS", pessoa.ContribuinteICMS);
                          p.Add(@"CodigoExterno", pessoa.CodigoExterno);
                          insertUpdate = conn.Query<string>(@"Personas.PessoaJuridicaPadraoERPOut_v1_Ins", p,
                              commandType: CommandType.StoredProcedure).FirstOrDefault();
                              OnLog(new ObjLog() {Tipo=14, Ticket=Ticket, CodigoDocumento = persona.CodigoDocumento, Tabla = "PessoaJuridicaPadraoERP", Mensaje = "Grabación de PessoaJuridicaPadraoERP, tipo: " + insertUpdate + " Código: " + persona.Codigo });
                      }
                  }
                  catch (Exception ex)
                  {
                              OnLog(new ObjLog() {Tipo=-3, Ticket=Ticket, CodigoDocumento = persona.CodigoDocumento, Tabla = "Pessoa", 
                                  Mensaje = "\n\nExcepcion en la grabacion de persona :  " + ex.Message });
                            throw  new Exception("Excepcion en la grabacion de Personas: " + ex.Message);
                  }
              }
          }
          return null;
      }

        public bool CerrarTicket(PessoaPadraoERPOut_v1[] personas)
        {
            // si esta puesto que no hay que cerrar ticket, retornar sin hacer nada...
            if (HayQueCerrarTicket == "NO")
            {
                OnLog(new ObjLog()
                {
                    Tipo = 99,
                    Ticket = Ticket,
                    CodigoDocumento = 0,
                    Tabla = "PessoaPadraoERPOut_v1",
                    Mensaje = "No se esta cerando el Ticket PessoaPadraoERPOut_v1"
                });
                return true;
            }

            OnLog(new ObjLog() {Tipo=99, Ticket=Ticket, CodigoDocumento = 0, Tabla = "PessoaPadraoERP", Mensaje = "Cerrando ticket " });
            DateTime fecha;
            ArrayOfString errores;
            ConfirmacaoDocumento documento;
            var documentos = new ArrayOfConfirmacaoDocumento();

            foreach (var d in personas)
            {
                documento = new ConfirmacaoDocumento() { CodigoDocumento = d.CodigoDocumento, MensagemErro = "Error", Situacao = 1 };
                documentos.Add(documento);
            }
            try
            {
                var cierre = conexion_SOAP.AdicionarConfirmacaoTicket(Token, "PessoaPadraoERP", "1.0", Ticket, documentos, out fecha, out errores );
                OnLog(new ObjLog() { Tipo=100, Ticket=Ticket, CodigoDocumento = 0, Tabla = "PessoaPadraoERP", Mensaje = "Tickets cerrado correctamente." });
                return true;

            }
            catch (Exception ex)
            {
                OnLog(new ObjLog() {Tipo=-4, Ticket=Ticket, CodigoDocumento = 0, Tabla = "PessoaPadraoERP", Mensaje = "Error cerrando ticket PessoaPadraoERP: " + ex.Message });
                return false;
            }
        }
    }
}