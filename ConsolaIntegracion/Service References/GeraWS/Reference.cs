﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsolaIntegracion.GeraWS {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RetornoExportacao", Namespace="http://www.geravd.com.br/")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsolaIntegracion.GeraWS.ArrayOfString))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsolaIntegracion.GeraWS.ArrayOfConfirmacaoDocumento))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsolaIntegracion.GeraWS.ConfirmacaoDocumento))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ConsolaIntegracion.GeraWS.RetornoImportacao))]
    public partial class RetornoExportacao : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DataHoraField;
        
        private long CodigoTicketField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object TicketField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CheckSumField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsolaIntegracion.GeraWS.ArrayOfString ErrosField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DataHora {
            get {
                return this.DataHoraField;
            }
            set {
                if ((this.DataHoraField.Equals(value) != true)) {
                    this.DataHoraField = value;
                    this.RaisePropertyChanged("DataHora");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public long CodigoTicket {
            get {
                return this.CodigoTicketField;
            }
            set {
                if ((this.CodigoTicketField.Equals(value) != true)) {
                    this.CodigoTicketField = value;
                    this.RaisePropertyChanged("CodigoTicket");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public object Ticket {
            get {
                return this.TicketField;
            }
            set {
                if ((object.ReferenceEquals(this.TicketField, value) != true)) {
                    this.TicketField = value;
                    this.RaisePropertyChanged("Ticket");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string CheckSum {
            get {
                return this.CheckSumField;
            }
            set {
                if ((object.ReferenceEquals(this.CheckSumField, value) != true)) {
                    this.CheckSumField = value;
                    this.RaisePropertyChanged("CheckSum");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public ConsolaIntegracion.GeraWS.ArrayOfString Erros {
            get {
                return this.ErrosField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrosField, value) != true)) {
                    this.ErrosField = value;
                    this.RaisePropertyChanged("Erros");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfString", Namespace="http://www.geravd.com.br/", ItemName="DescricaoErro")]
    [System.SerializableAttribute()]
    public class ArrayOfString : System.Collections.Generic.List<string> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfConfirmacaoDocumento", Namespace="http://www.geravd.com.br/", ItemName="Documento")]
    [System.SerializableAttribute()]
    public class ArrayOfConfirmacaoDocumento : System.Collections.Generic.List<ConsolaIntegracion.GeraWS.ConfirmacaoDocumento> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ConfirmacaoDocumento", Namespace="http://www.geravd.com.br/")]
    [System.SerializableAttribute()]
    public partial class ConfirmacaoDocumento : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private long CodigoDocumentoField;
        
        private int SituacaoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodigoErroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MensagemErroField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long CodigoDocumento {
            get {
                return this.CodigoDocumentoField;
            }
            set {
                if ((this.CodigoDocumentoField.Equals(value) != true)) {
                    this.CodigoDocumentoField = value;
                    this.RaisePropertyChanged("CodigoDocumento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Situacao {
            get {
                return this.SituacaoField;
            }
            set {
                if ((this.SituacaoField.Equals(value) != true)) {
                    this.SituacaoField = value;
                    this.RaisePropertyChanged("Situacao");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string CodigoErro {
            get {
                return this.CodigoErroField;
            }
            set {
                if ((object.ReferenceEquals(this.CodigoErroField, value) != true)) {
                    this.CodigoErroField = value;
                    this.RaisePropertyChanged("CodigoErro");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string MensagemErro {
            get {
                return this.MensagemErroField;
            }
            set {
                if ((object.ReferenceEquals(this.MensagemErroField, value) != true)) {
                    this.MensagemErroField = value;
                    this.RaisePropertyChanged("MensagemErro");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RetornoImportacao", Namespace="http://www.geravd.com.br/")]
    [System.SerializableAttribute()]
    public partial class RetornoImportacao : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DataHoraField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ConsolaIntegracion.GeraWS.ArrayOfString ErrosField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DataHora {
            get {
                return this.DataHoraField;
            }
            set {
                if ((this.DataHoraField.Equals(value) != true)) {
                    this.DataHoraField = value;
                    this.RaisePropertyChanged("DataHora");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public ConsolaIntegracion.GeraWS.ArrayOfString Erros {
            get {
                return this.ErrosField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrosField, value) != true)) {
                    this.ErrosField = value;
                    this.RaisePropertyChanged("Erros");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.geravd.com.br/", ConfigurationName="GeraWS.WSIntegracaoPadraoSoap")]
    public interface WSIntegracaoPadraoSoap {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de contenedor (ParametrosExportacao) del mensaje ExportarDadosRequest no coincide con el valor predeterminado (ExportarDados)
        [System.ServiceModel.OperationContractAttribute(Action="http://www.geravd.com.br/ExportarDados", ReplyAction="*")]
        ConsolaIntegracion.GeraWS.ExportarDadosResponse ExportarDados(ConsolaIntegracion.GeraWS.ExportarDadosRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.geravd.com.br/ExportarDados", ReplyAction="*")]
        System.Threading.Tasks.Task<ConsolaIntegracion.GeraWS.ExportarDadosResponse> ExportarDadosAsync(ConsolaIntegracion.GeraWS.ExportarDadosRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.geravd.com.br/AdicionaConfirmacao", ReplyAction="*")]
        ConsolaIntegracion.GeraWS.AdicionarConfirmacaoTicketResponse AdicionarConfirmacaoTicket(ConsolaIntegracion.GeraWS.AdicionarConfirmacaoTicketRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.geravd.com.br/AdicionaConfirmacao", ReplyAction="*")]
        System.Threading.Tasks.Task<ConsolaIntegracion.GeraWS.AdicionarConfirmacaoTicketResponse> AdicionarConfirmacaoTicketAsync(ConsolaIntegracion.GeraWS.AdicionarConfirmacaoTicketRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de contenedor (ParametrosImportacao) del mensaje ImportarDadosRequest no coincide con el valor predeterminado (ImportarDados)
        [System.ServiceModel.OperationContractAttribute(Action="http://www.geravd.com.br/ImportarDados", ReplyAction="*")]
        ConsolaIntegracion.GeraWS.ImportarDadosResponse ImportarDados(ConsolaIntegracion.GeraWS.ImportarDadosRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.geravd.com.br/ImportarDados", ReplyAction="*")]
        System.Threading.Tasks.Task<ConsolaIntegracion.GeraWS.ImportarDadosResponse> ImportarDadosAsync(ConsolaIntegracion.GeraWS.ImportarDadosRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ParametrosExportacao", WrapperNamespace="http://www.geravd.com.br/", IsWrapped=true)]
    public partial class ExportarDadosRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.geravd.com.br/", Order=0)]
        public string tokenAutenticacao;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.geravd.com.br/", Order=1)]
        public string interfaceIntegracao;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.geravd.com.br/", Order=2)]
        public string versao;
        
        public ExportarDadosRequest() {
        }
        
        public ExportarDadosRequest(string tokenAutenticacao, string interfaceIntegracao, string versao) {
            this.tokenAutenticacao = tokenAutenticacao;
            this.interfaceIntegracao = interfaceIntegracao;
            this.versao = versao;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ExportacaoResponse", WrapperNamespace="http://www.geravd.com.br/", IsWrapped=true)]
    public partial class ExportarDadosResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.geravd.com.br/", Order=0)]
        public ConsolaIntegracion.GeraWS.RetornoExportacao IntegracaoResult;
        
        public ExportarDadosResponse() {
        }
        
        public ExportarDadosResponse(ConsolaIntegracion.GeraWS.RetornoExportacao IntegracaoResult) {
            this.IntegracaoResult = IntegracaoResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AdicionarConfirmacaoTicketRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ParametrosConfirmacaoTicket", Namespace="http://www.geravd.com.br/", Order=0)]
        public ConsolaIntegracion.GeraWS.AdicionarConfirmacaoTicketRequestBody Body;
        
        public AdicionarConfirmacaoTicketRequest() {
        }
        
        public AdicionarConfirmacaoTicketRequest(ConsolaIntegracion.GeraWS.AdicionarConfirmacaoTicketRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.geravd.com.br/")]
    public partial class AdicionarConfirmacaoTicketRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string TokenAutenticacao;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string InterfaceIntegracao;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Versao;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public long CodigoTicket;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public ConsolaIntegracion.GeraWS.ArrayOfConfirmacaoDocumento Documentos;
        
        public AdicionarConfirmacaoTicketRequestBody() {
        }
        
        public AdicionarConfirmacaoTicketRequestBody(string TokenAutenticacao, string InterfaceIntegracao, string Versao, long CodigoTicket, ConsolaIntegracion.GeraWS.ArrayOfConfirmacaoDocumento Documentos) {
            this.TokenAutenticacao = TokenAutenticacao;
            this.InterfaceIntegracao = InterfaceIntegracao;
            this.Versao = Versao;
            this.CodigoTicket = CodigoTicket;
            this.Documentos = Documentos;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AdicionarConfirmacaoTicketResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ConfirmacaoTicketResponse", Namespace="http://www.geravd.com.br/", Order=0)]
        public ConsolaIntegracion.GeraWS.AdicionarConfirmacaoTicketResponseBody Body;
        
        public AdicionarConfirmacaoTicketResponse() {
        }
        
        public AdicionarConfirmacaoTicketResponse(ConsolaIntegracion.GeraWS.AdicionarConfirmacaoTicketResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.geravd.com.br/")]
    public partial class AdicionarConfirmacaoTicketResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool ProcessamentoOK;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public System.DateTime DataHora;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public ConsolaIntegracion.GeraWS.ArrayOfString Erros;
        
        public AdicionarConfirmacaoTicketResponseBody() {
        }
        
        public AdicionarConfirmacaoTicketResponseBody(bool ProcessamentoOK, System.DateTime DataHora, ConsolaIntegracion.GeraWS.ArrayOfString Erros) {
            this.ProcessamentoOK = ProcessamentoOK;
            this.DataHora = DataHora;
            this.Erros = Erros;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ParametrosImportacao", WrapperNamespace="http://www.geravd.com.br/", IsWrapped=true)]
    public partial class ImportarDadosRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.geravd.com.br/", Order=0)]
        public string tokenAutenticacao;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.geravd.com.br/", Order=1)]
        public string interfaceIntegracao;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.geravd.com.br/", Order=2)]
        public string versao;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.geravd.com.br/", Order=3)]
        public string CodigoTicket;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.geravd.com.br/", Order=4)]
        public string Ticket;
        
        public ImportarDadosRequest() {
        }
        
        public ImportarDadosRequest(string tokenAutenticacao, string interfaceIntegracao, string versao, string CodigoTicket, string Ticket) {
            this.tokenAutenticacao = tokenAutenticacao;
            this.interfaceIntegracao = interfaceIntegracao;
            this.versao = versao;
            this.CodigoTicket = CodigoTicket;
            this.Ticket = Ticket;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImportacaoResponse", WrapperNamespace="http://www.geravd.com.br/", IsWrapped=true)]
    public partial class ImportarDadosResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.geravd.com.br/", Order=0)]
        public ConsolaIntegracion.GeraWS.RetornoImportacao IntegracaoResult;
        
        public ImportarDadosResponse() {
        }
        
        public ImportarDadosResponse(ConsolaIntegracion.GeraWS.RetornoImportacao IntegracaoResult) {
            this.IntegracaoResult = IntegracaoResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WSIntegracaoPadraoSoapChannel : ConsolaIntegracion.GeraWS.WSIntegracaoPadraoSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WSIntegracaoPadraoSoapClient : System.ServiceModel.ClientBase<ConsolaIntegracion.GeraWS.WSIntegracaoPadraoSoap>, ConsolaIntegracion.GeraWS.WSIntegracaoPadraoSoap {
        
        public WSIntegracaoPadraoSoapClient() {
        }
        
        public WSIntegracaoPadraoSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WSIntegracaoPadraoSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSIntegracaoPadraoSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSIntegracaoPadraoSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ConsolaIntegracion.GeraWS.ExportarDadosResponse ConsolaIntegracion.GeraWS.WSIntegracaoPadraoSoap.ExportarDados(ConsolaIntegracion.GeraWS.ExportarDadosRequest request) {
            return base.Channel.ExportarDados(request);
        }
        
        public ConsolaIntegracion.GeraWS.RetornoExportacao ExportarDados(string tokenAutenticacao, string interfaceIntegracao, string versao) {
            ConsolaIntegracion.GeraWS.ExportarDadosRequest inValue = new ConsolaIntegracion.GeraWS.ExportarDadosRequest();
            inValue.tokenAutenticacao = tokenAutenticacao;
            inValue.interfaceIntegracao = interfaceIntegracao;
            inValue.versao = versao;
            ConsolaIntegracion.GeraWS.ExportarDadosResponse retVal = ((ConsolaIntegracion.GeraWS.WSIntegracaoPadraoSoap)(this)).ExportarDados(inValue);
            return retVal.IntegracaoResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ConsolaIntegracion.GeraWS.ExportarDadosResponse> ConsolaIntegracion.GeraWS.WSIntegracaoPadraoSoap.ExportarDadosAsync(ConsolaIntegracion.GeraWS.ExportarDadosRequest request) {
            return base.Channel.ExportarDadosAsync(request);
        }
        
        public System.Threading.Tasks.Task<ConsolaIntegracion.GeraWS.ExportarDadosResponse> ExportarDadosAsync(string tokenAutenticacao, string interfaceIntegracao, string versao) {
            ConsolaIntegracion.GeraWS.ExportarDadosRequest inValue = new ConsolaIntegracion.GeraWS.ExportarDadosRequest();
            inValue.tokenAutenticacao = tokenAutenticacao;
            inValue.interfaceIntegracao = interfaceIntegracao;
            inValue.versao = versao;
            return ((ConsolaIntegracion.GeraWS.WSIntegracaoPadraoSoap)(this)).ExportarDadosAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ConsolaIntegracion.GeraWS.AdicionarConfirmacaoTicketResponse ConsolaIntegracion.GeraWS.WSIntegracaoPadraoSoap.AdicionarConfirmacaoTicket(ConsolaIntegracion.GeraWS.AdicionarConfirmacaoTicketRequest request) {
            return base.Channel.AdicionarConfirmacaoTicket(request);
        }
        
        public bool AdicionarConfirmacaoTicket(string TokenAutenticacao, string InterfaceIntegracao, string Versao, long CodigoTicket, ConsolaIntegracion.GeraWS.ArrayOfConfirmacaoDocumento Documentos, out System.DateTime DataHora, out ConsolaIntegracion.GeraWS.ArrayOfString Erros) {
            ConsolaIntegracion.GeraWS.AdicionarConfirmacaoTicketRequest inValue = new ConsolaIntegracion.GeraWS.AdicionarConfirmacaoTicketRequest();
            inValue.Body = new ConsolaIntegracion.GeraWS.AdicionarConfirmacaoTicketRequestBody();
            inValue.Body.TokenAutenticacao = TokenAutenticacao;
            inValue.Body.InterfaceIntegracao = InterfaceIntegracao;
            inValue.Body.Versao = Versao;
            inValue.Body.CodigoTicket = CodigoTicket;
            inValue.Body.Documentos = Documentos;
            ConsolaIntegracion.GeraWS.AdicionarConfirmacaoTicketResponse retVal = ((ConsolaIntegracion.GeraWS.WSIntegracaoPadraoSoap)(this)).AdicionarConfirmacaoTicket(inValue);
            DataHora = retVal.Body.DataHora;
            Erros = retVal.Body.Erros;
            return retVal.Body.ProcessamentoOK;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ConsolaIntegracion.GeraWS.AdicionarConfirmacaoTicketResponse> ConsolaIntegracion.GeraWS.WSIntegracaoPadraoSoap.AdicionarConfirmacaoTicketAsync(ConsolaIntegracion.GeraWS.AdicionarConfirmacaoTicketRequest request) {
            return base.Channel.AdicionarConfirmacaoTicketAsync(request);
        }
        
        public System.Threading.Tasks.Task<ConsolaIntegracion.GeraWS.AdicionarConfirmacaoTicketResponse> AdicionarConfirmacaoTicketAsync(string TokenAutenticacao, string InterfaceIntegracao, string Versao, long CodigoTicket, ConsolaIntegracion.GeraWS.ArrayOfConfirmacaoDocumento Documentos) {
            ConsolaIntegracion.GeraWS.AdicionarConfirmacaoTicketRequest inValue = new ConsolaIntegracion.GeraWS.AdicionarConfirmacaoTicketRequest();
            inValue.Body = new ConsolaIntegracion.GeraWS.AdicionarConfirmacaoTicketRequestBody();
            inValue.Body.TokenAutenticacao = TokenAutenticacao;
            inValue.Body.InterfaceIntegracao = InterfaceIntegracao;
            inValue.Body.Versao = Versao;
            inValue.Body.CodigoTicket = CodigoTicket;
            inValue.Body.Documentos = Documentos;
            return ((ConsolaIntegracion.GeraWS.WSIntegracaoPadraoSoap)(this)).AdicionarConfirmacaoTicketAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ConsolaIntegracion.GeraWS.ImportarDadosResponse ConsolaIntegracion.GeraWS.WSIntegracaoPadraoSoap.ImportarDados(ConsolaIntegracion.GeraWS.ImportarDadosRequest request) {
            return base.Channel.ImportarDados(request);
        }
        
        public ConsolaIntegracion.GeraWS.RetornoImportacao ImportarDados(string tokenAutenticacao, string interfaceIntegracao, string versao, string CodigoTicket, string Ticket) {
            ConsolaIntegracion.GeraWS.ImportarDadosRequest inValue = new ConsolaIntegracion.GeraWS.ImportarDadosRequest();
            inValue.tokenAutenticacao = tokenAutenticacao;
            inValue.interfaceIntegracao = interfaceIntegracao;
            inValue.versao = versao;
            inValue.CodigoTicket = CodigoTicket;
            inValue.Ticket = Ticket;
            ConsolaIntegracion.GeraWS.ImportarDadosResponse retVal = ((ConsolaIntegracion.GeraWS.WSIntegracaoPadraoSoap)(this)).ImportarDados(inValue);
            return retVal.IntegracaoResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ConsolaIntegracion.GeraWS.ImportarDadosResponse> ConsolaIntegracion.GeraWS.WSIntegracaoPadraoSoap.ImportarDadosAsync(ConsolaIntegracion.GeraWS.ImportarDadosRequest request) {
            return base.Channel.ImportarDadosAsync(request);
        }
        
        public System.Threading.Tasks.Task<ConsolaIntegracion.GeraWS.ImportarDadosResponse> ImportarDadosAsync(string tokenAutenticacao, string interfaceIntegracao, string versao, string CodigoTicket, string Ticket) {
            ConsolaIntegracion.GeraWS.ImportarDadosRequest inValue = new ConsolaIntegracion.GeraWS.ImportarDadosRequest();
            inValue.tokenAutenticacao = tokenAutenticacao;
            inValue.interfaceIntegracao = interfaceIntegracao;
            inValue.versao = versao;
            inValue.CodigoTicket = CodigoTicket;
            inValue.Ticket = Ticket;
            return ((ConsolaIntegracion.GeraWS.WSIntegracaoPadraoSoap)(this)).ImportarDadosAsync(inValue);
        }
    }
}