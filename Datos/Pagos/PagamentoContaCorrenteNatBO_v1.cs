﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión del motor en tiempo de ejecución:2.0.50727.8745
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// Este código fuente fue generado automáticamente por xsd, Versión=2.0.50727.3038.
// 


/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.gera.com.br/", IsNullable=true)]
public partial class ArrayOfPagamentoContaCorrenteNatBO_v1 {
    
    private PagamentoContaCorrenteNatBO_v1[] registroField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("Registro", IsNullable=true)]
    public PagamentoContaCorrenteNatBO_v1[] Registro {
        get {
            return this.registroField;
        }
        set {
            this.registroField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class PagamentoContaCorrenteNatBO_v1 {
    
    private long codigoDocumentoField;
    
    private int codigoTituloField;
    
    private bool codigoTituloFieldSpecified;
    
    private int codigoPessoaField;
    
    private bool codigoPessoaFieldSpecified;
    
    private string nomeField;
    
    private int codigoEntidadeConciliacaoField;
    
    private bool codigoEntidadeConciliacaoFieldSpecified;
    
    private string entidadeDeConciliacaoField;
    
    private System.DateTime dataBaixaField;
    
    private bool dataBaixaFieldSpecified;
    
    private System.DateTime dataPagamentoField;
    
    private bool dataPagamentoFieldSpecified;
    
    private decimal valorPrincipalTituloField;
    
    private bool valorPrincipalTituloFieldSpecified;
    
    private decimal valorFinanceiroTituloField;
    
    private bool valorFinanceiroTituloFieldSpecified;
    
    private string tipoBaixaField;
    
    private decimal valorField;
    
    private bool valorFieldSpecified;
    
    private int codigoContaCorrenteResidualField;
    
    private bool codigoContaCorrenteResidualFieldSpecified;
    
    private string tipoRegistroField;
    
    private string origemField;
    
    private int notificacaoField;
    
    private bool notificacaoFieldSpecified;
    
    private string tipoSacField;
    
    private int codigoRegistroPagamentoField;
    
    private bool codigoRegistroPagamentoFieldSpecified;
    
    private byte tipoObjetoField;
    
    /// <comentarios/>
    public long CodigoDocumento {
        get {
            return this.codigoDocumentoField;
        }
        set {
            this.codigoDocumentoField = value;
        }
    }
    
    /// <comentarios/>
    public int CodigoTitulo {
        get {
            return this.codigoTituloField;
        }
        set {
            this.codigoTituloField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool CodigoTituloSpecified {
        get {
            return this.codigoTituloFieldSpecified;
        }
        set {
            this.codigoTituloFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public int CodigoPessoa {
        get {
            return this.codigoPessoaField;
        }
        set {
            this.codigoPessoaField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool CodigoPessoaSpecified {
        get {
            return this.codigoPessoaFieldSpecified;
        }
        set {
            this.codigoPessoaFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public string Nome {
        get {
            return this.nomeField;
        }
        set {
            this.nomeField = value;
        }
    }
    
    /// <comentarios/>
    public int CodigoEntidadeConciliacao {
        get {
            return this.codigoEntidadeConciliacaoField;
        }
        set {
            this.codigoEntidadeConciliacaoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool CodigoEntidadeConciliacaoSpecified {
        get {
            return this.codigoEntidadeConciliacaoFieldSpecified;
        }
        set {
            this.codigoEntidadeConciliacaoFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public string EntidadeDeConciliacao {
        get {
            return this.entidadeDeConciliacaoField;
        }
        set {
            this.entidadeDeConciliacaoField = value;
        }
    }
    
    /// <comentarios/>
    public System.DateTime DataBaixa {
        get {
            return this.dataBaixaField;
        }
        set {
            this.dataBaixaField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool DataBaixaSpecified {
        get {
            return this.dataBaixaFieldSpecified;
        }
        set {
            this.dataBaixaFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public System.DateTime DataPagamento {
        get {
            return this.dataPagamentoField;
        }
        set {
            this.dataPagamentoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool DataPagamentoSpecified {
        get {
            return this.dataPagamentoFieldSpecified;
        }
        set {
            this.dataPagamentoFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public decimal ValorPrincipalTitulo {
        get {
            return this.valorPrincipalTituloField;
        }
        set {
            this.valorPrincipalTituloField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ValorPrincipalTituloSpecified {
        get {
            return this.valorPrincipalTituloFieldSpecified;
        }
        set {
            this.valorPrincipalTituloFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public decimal ValorFinanceiroTitulo {
        get {
            return this.valorFinanceiroTituloField;
        }
        set {
            this.valorFinanceiroTituloField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ValorFinanceiroTituloSpecified {
        get {
            return this.valorFinanceiroTituloFieldSpecified;
        }
        set {
            this.valorFinanceiroTituloFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public string TipoBaixa {
        get {
            return this.tipoBaixaField;
        }
        set {
            this.tipoBaixaField = value;
        }
    }
    
    /// <comentarios/>
    public decimal Valor {
        get {
            return this.valorField;
        }
        set {
            this.valorField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ValorSpecified {
        get {
            return this.valorFieldSpecified;
        }
        set {
            this.valorFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public int CodigoContaCorrenteResidual {
        get {
            return this.codigoContaCorrenteResidualField;
        }
        set {
            this.codigoContaCorrenteResidualField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool CodigoContaCorrenteResidualSpecified {
        get {
            return this.codigoContaCorrenteResidualFieldSpecified;
        }
        set {
            this.codigoContaCorrenteResidualFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public string TipoRegistro {
        get {
            return this.tipoRegistroField;
        }
        set {
            this.tipoRegistroField = value;
        }
    }
    
    /// <comentarios/>
    public string Origem {
        get {
            return this.origemField;
        }
        set {
            this.origemField = value;
        }
    }
    
    /// <comentarios/>
    public int Notificacao {
        get {
            return this.notificacaoField;
        }
        set {
            this.notificacaoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool NotificacaoSpecified {
        get {
            return this.notificacaoFieldSpecified;
        }
        set {
            this.notificacaoFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public string TipoSac {
        get {
            return this.tipoSacField;
        }
        set {
            this.tipoSacField = value;
        }
    }
    
    /// <comentarios/>
    public int CodigoRegistroPagamento {
        get {
            return this.codigoRegistroPagamentoField;
        }
        set {
            this.codigoRegistroPagamentoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool CodigoRegistroPagamentoSpecified {
        get {
            return this.codigoRegistroPagamentoFieldSpecified;
        }
        set {
            this.codigoRegistroPagamentoFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public byte TipoObjeto {
        get {
            return this.tipoObjetoField;
        }
        set {
            this.tipoObjetoField = value;
        }
    }
}
