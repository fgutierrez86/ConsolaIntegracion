﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión del motor en tiempo de ejecución:2.0.50727.8670
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
public partial class ArrayOfTituloPadraoERPOut_v1 {
    
    private TituloPadraoERPOut_v1[] registroField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("Registro", IsNullable=true)]
    public TituloPadraoERPOut_v1[] Registro {
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
public partial class TituloPadraoERPOut_v1 {
    
    private long codigoDocumentoField;
    
    private int codigoTituloField;
    
    private int codigoPedidoField;
    
    private int nossoNumeroField;
    
    private string meioRecebimentoField;
    
    private byte formaPagamentoField;
    
    private TituloPessoaPadraoERPOut_v1 pessoaEmissorField;
    
    private TituloPessoaPadraoERPOut_v1 pessoaDestinatarioField;
    
    private byte operacaoField;
    
    private System.DateTime dataOperacaoField;
    
    private System.DateTime dataEmissaoField;
    
    private System.DateTime dataVencimentoField;
    
    private System.DateTime dataValidadeField;
    
    private decimal valorPrincipalOperacaoField;
    
    private decimal valorFinanceiroOperacaoField;
    
    private decimal saldoPrincipalField;
    
    private decimal saldoFinanceiroField;
    
    private int nivelNegociacaoField;
    
    private TituloPadraoERPOut_v1Renegociacao renegociacaoField;
    
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
    public int CodigoPedido {
        get {
            return this.codigoPedidoField;
        }
        set {
            this.codigoPedidoField = value;
        }
    }
    
    /// <comentarios/>
    public int NossoNumero {
        get {
            return this.nossoNumeroField;
        }
        set {
            this.nossoNumeroField = value;
        }
    }
    
    /// <comentarios/>
    public string MeioRecebimento {
        get {
            return this.meioRecebimentoField;
        }
        set {
            this.meioRecebimentoField = value;
        }
    }
    
    /// <comentarios/>
    public byte FormaPagamento {
        get {
            return this.formaPagamentoField;
        }
        set {
            this.formaPagamentoField = value;
        }
    }
    
    /// <comentarios/>
    public TituloPessoaPadraoERPOut_v1 PessoaEmissor {
        get {
            return this.pessoaEmissorField;
        }
        set {
            this.pessoaEmissorField = value;
        }
    }
    
    /// <comentarios/>
    public TituloPessoaPadraoERPOut_v1 PessoaDestinatario {
        get {
            return this.pessoaDestinatarioField;
        }
        set {
            this.pessoaDestinatarioField = value;
        }
    }
    
    /// <comentarios/>
    public byte Operacao {
        get {
            return this.operacaoField;
        }
        set {
            this.operacaoField = value;
        }
    }
    
    /// <comentarios/>
    public System.DateTime DataOperacao {
        get {
            return this.dataOperacaoField;
        }
        set {
            this.dataOperacaoField = value;
        }
    }
    
    /// <comentarios/>
    public System.DateTime DataEmissao {
        get {
            return this.dataEmissaoField;
        }
        set {
            this.dataEmissaoField = value;
        }
    }
    
    /// <comentarios/>
    public System.DateTime DataVencimento {
        get {
            return this.dataVencimentoField;
        }
        set {
            this.dataVencimentoField = value;
        }
    }
    
    /// <comentarios/>
    public System.DateTime DataValidade {
        get {
            return this.dataValidadeField;
        }
        set {
            this.dataValidadeField = value;
        }
    }
    
    /// <comentarios/>
    public decimal ValorPrincipalOperacao {
        get {
            return this.valorPrincipalOperacaoField;
        }
        set {
            this.valorPrincipalOperacaoField = value;
        }
    }
    
    /// <comentarios/>
    public decimal ValorFinanceiroOperacao {
        get {
            return this.valorFinanceiroOperacaoField;
        }
        set {
            this.valorFinanceiroOperacaoField = value;
        }
    }
    
    /// <comentarios/>
    public decimal SaldoPrincipal {
        get {
            return this.saldoPrincipalField;
        }
        set {
            this.saldoPrincipalField = value;
        }
    }
    
    /// <comentarios/>
    public decimal SaldoFinanceiro {
        get {
            return this.saldoFinanceiroField;
        }
        set {
            this.saldoFinanceiroField = value;
        }
    }
    
    /// <comentarios/>
    public int NivelNegociacao {
        get {
            return this.nivelNegociacaoField;
        }
        set {
            this.nivelNegociacaoField = value;
        }
    }
    
    /// <comentarios/>
    public TituloPadraoERPOut_v1Renegociacao Renegociacao {
        get {
            return this.renegociacaoField;
        }
        set {
            this.renegociacaoField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class TituloPessoaPadraoERPOut_v1 {
    
    private int codigoField;
    
    private string nomeField;
    
    private byte tipoField;
    
    private string identificacaoField;
    
    private byte tipoIdentificacaoField;
    
    /// <comentarios/>
    public int Codigo {
        get {
            return this.codigoField;
        }
        set {
            this.codigoField = value;
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
    public byte Tipo {
        get {
            return this.tipoField;
        }
        set {
            this.tipoField = value;
        }
    }
    
    /// <comentarios/>
    public string Identificacao {
        get {
            return this.identificacaoField;
        }
        set {
            this.identificacaoField = value;
        }
    }
    
    /// <comentarios/>
    public byte TipoIdentificacao {
        get {
            return this.tipoIdentificacaoField;
        }
        set {
            this.tipoIdentificacaoField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class TituloRenegociadoPadraoERPOut_v1 {
    
    private int codigoField;
    
    /// <comentarios/>
    public int Codigo {
        get {
            return this.codigoField;
        }
        set {
            this.codigoField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.gera.com.br/")]
public partial class TituloPadraoERPOut_v1Renegociacao {
    
    private TituloRenegociadoPadraoERPOut_v1[] tituloOriginalField;
    
    private TituloRenegociadoPadraoERPOut_v1[] tituloCriadoField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("TituloOriginal")]
    public TituloRenegociadoPadraoERPOut_v1[] TituloOriginal {
        get {
            return this.tituloOriginalField;
        }
        set {
            this.tituloOriginalField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("TituloCriado")]
    public TituloRenegociadoPadraoERPOut_v1[] TituloCriado {
        get {
            return this.tituloCriadoField;
        }
        set {
            this.tituloCriadoField = value;
        }
    }
}