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
public partial class ArrayOfPessoaPadraoERPOut_v1 {
    
    private PessoaPadraoERPOut_v1[] registroField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("Registro", IsNullable=true)]
    public PessoaPadraoERPOut_v1[] Registro {
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
public partial class PessoaPadraoERPOut_v1 {
    
    private long codigoDocumentoField;
    
    private int codigoField;
    
    private string nomeField;
    
    private string apelidoField;
    
    private byte tipoField;
    
    private PessoaDocumentoPadraoERPOut_v1[] documentoField;
    
    private PessoaEnderecoPadraoERPOut_v1[] enderecoField;
    
    private PessoaTelefonePadraoERPOut_v1[] telefoneField;
    
    private PessoaEmailPadraoERPOut_v1[] emailField;
    
    private PessoaFisicaPadraoERPOut_v1 pessoaFisicaField;
    
    private PessoaJuridicaPadraoERPOut_v1 pessoaJuridicaField;
    
    private PessoaFuncaoPadraoERPOut_v1[] funcaoField;
    
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
    public string Apelido {
        get {
            return this.apelidoField;
        }
        set {
            this.apelidoField = value;
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
    [System.Xml.Serialization.XmlElementAttribute("Documento")]
    public PessoaDocumentoPadraoERPOut_v1[] Documento {
        get {
            return this.documentoField;
        }
        set {
            this.documentoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("Endereco")]
    public PessoaEnderecoPadraoERPOut_v1[] Endereco {
        get {
            return this.enderecoField;
        }
        set {
            this.enderecoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("Telefone")]
    public PessoaTelefonePadraoERPOut_v1[] Telefone {
        get {
            return this.telefoneField;
        }
        set {
            this.telefoneField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("Email")]
    public PessoaEmailPadraoERPOut_v1[] Email {
        get {
            return this.emailField;
        }
        set {
            this.emailField = value;
        }
    }
    
    /// <comentarios/>
    public PessoaFisicaPadraoERPOut_v1 PessoaFisica {
        get {
            return this.pessoaFisicaField;
        }
        set {
            this.pessoaFisicaField = value;
        }
    }
    
    /// <comentarios/>
    public PessoaJuridicaPadraoERPOut_v1 PessoaJuridica {
        get {
            return this.pessoaJuridicaField;
        }
        set {
            this.pessoaJuridicaField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("Funcao")]
    public PessoaFuncaoPadraoERPOut_v1[] Funcao {
        get {
            return this.funcaoField;
        }
        set {
            this.funcaoField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class PessoaDocumentoPadraoERPOut_v1 {
    
    private byte tipoField;
    
    private string documentoField;
    
    private string informacaoExtraField;
    
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
    public string Documento {
        get {
            return this.documentoField;
        }
        set {
            this.documentoField = value;
        }
    }
    
    /// <comentarios/>
    public string InformacaoExtra {
        get {
            return this.informacaoExtraField;
        }
        set {
            this.informacaoExtraField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class PessoaFuncaoPadraoERPOut_v1 {
    
    private int codigoFuncaoField;
    
    private string nomeFuncaoField;
    
    private byte situacaoComercialField;
    
    private bool situacaoComercialFieldSpecified;
    
    private int campanhaField;
    
    private bool campanhaFieldSpecified;
    
    private int saldoCreditoField;
    
    private bool saldoCreditoFieldSpecified;
    
    private int limiteCreditoField;
    
    private bool limiteCreditoFieldSpecified;
    
    private string estruturaComercial0Field;
    
    private string estruturaComercial1Field;
    
    private string estruturaComercial2Field;
    
    private string estruturaComercial3Field;
    
    private string estruturaComercial4Field;
    
    private string estruturaComercial5Field;
    
    private string estruturaComercial6Field;
    
    private string estruturaComercial7Field;
    
    private string estruturaComercial8Field;
    
    private string estruturaComercial9Field;
    
    /// <comentarios/>
    public int CodigoFuncao {
        get {
            return this.codigoFuncaoField;
        }
        set {
            this.codigoFuncaoField = value;
        }
    }
    
    /// <comentarios/>
    public string NomeFuncao {
        get {
            return this.nomeFuncaoField;
        }
        set {
            this.nomeFuncaoField = value;
        }
    }
    
    /// <comentarios/>
    public byte SituacaoComercial {
        get {
            return this.situacaoComercialField;
        }
        set {
            this.situacaoComercialField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool SituacaoComercialSpecified {
        get {
            return this.situacaoComercialFieldSpecified;
        }
        set {
            this.situacaoComercialFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public int Campanha {
        get {
            return this.campanhaField;
        }
        set {
            this.campanhaField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool CampanhaSpecified {
        get {
            return this.campanhaFieldSpecified;
        }
        set {
            this.campanhaFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public int SaldoCredito {
        get {
            return this.saldoCreditoField;
        }
        set {
            this.saldoCreditoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool SaldoCreditoSpecified {
        get {
            return this.saldoCreditoFieldSpecified;
        }
        set {
            this.saldoCreditoFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public int LimiteCredito {
        get {
            return this.limiteCreditoField;
        }
        set {
            this.limiteCreditoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool LimiteCreditoSpecified {
        get {
            return this.limiteCreditoFieldSpecified;
        }
        set {
            this.limiteCreditoFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaComercial0 {
        get {
            return this.estruturaComercial0Field;
        }
        set {
            this.estruturaComercial0Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaComercial1 {
        get {
            return this.estruturaComercial1Field;
        }
        set {
            this.estruturaComercial1Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaComercial2 {
        get {
            return this.estruturaComercial2Field;
        }
        set {
            this.estruturaComercial2Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaComercial3 {
        get {
            return this.estruturaComercial3Field;
        }
        set {
            this.estruturaComercial3Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaComercial4 {
        get {
            return this.estruturaComercial4Field;
        }
        set {
            this.estruturaComercial4Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaComercial5 {
        get {
            return this.estruturaComercial5Field;
        }
        set {
            this.estruturaComercial5Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaComercial6 {
        get {
            return this.estruturaComercial6Field;
        }
        set {
            this.estruturaComercial6Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaComercial7 {
        get {
            return this.estruturaComercial7Field;
        }
        set {
            this.estruturaComercial7Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaComercial8 {
        get {
            return this.estruturaComercial8Field;
        }
        set {
            this.estruturaComercial8Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaComercial9 {
        get {
            return this.estruturaComercial9Field;
        }
        set {
            this.estruturaComercial9Field = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class PessoaJuridicaPadraoERPOut_v1 {
    
    private byte tipoField;
    
    private byte contribuinteICMSField;
    
    private bool contribuinteICMSFieldSpecified;
    
    private string codigoExternoField;
    
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
    public byte ContribuinteICMS {
        get {
            return this.contribuinteICMSField;
        }
        set {
            this.contribuinteICMSField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ContribuinteICMSSpecified {
        get {
            return this.contribuinteICMSFieldSpecified;
        }
        set {
            this.contribuinteICMSFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public string CodigoExterno {
        get {
            return this.codigoExternoField;
        }
        set {
            this.codigoExternoField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class PessoaFisicaPadraoERPOut_v1 {
    
    private System.DateTime dataNascimentoField;
    
    private bool dataNascimentoFieldSpecified;
    
    private byte sexoField;
    
    private bool sexoFieldSpecified;
    
    private byte estadoCivilField;
    
    private bool estadoCivilFieldSpecified;
    
    private byte filhosField;
    
    private bool filhosFieldSpecified;
    
    /// <comentarios/>
    public System.DateTime DataNascimento {
        get {
            return this.dataNascimentoField;
        }
        set {
            this.dataNascimentoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool DataNascimentoSpecified {
        get {
            return this.dataNascimentoFieldSpecified;
        }
        set {
            this.dataNascimentoFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public byte Sexo {
        get {
            return this.sexoField;
        }
        set {
            this.sexoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool SexoSpecified {
        get {
            return this.sexoFieldSpecified;
        }
        set {
            this.sexoFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public byte EstadoCivil {
        get {
            return this.estadoCivilField;
        }
        set {
            this.estadoCivilField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool EstadoCivilSpecified {
        get {
            return this.estadoCivilFieldSpecified;
        }
        set {
            this.estadoCivilFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public byte Filhos {
        get {
            return this.filhosField;
        }
        set {
            this.filhosField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool FilhosSpecified {
        get {
            return this.filhosFieldSpecified;
        }
        set {
            this.filhosFieldSpecified = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class PessoaEmailPadraoERPOut_v1 {
    
    private byte tipoField;
    
    private string emailField;
    
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
    public string Email {
        get {
            return this.emailField;
        }
        set {
            this.emailField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class PessoaTelefonePadraoERPOut_v1 {
    
    private byte tipoField;
    
    private string telefoneField;
    
    private string ramalField;
    
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
    public string Telefone {
        get {
            return this.telefoneField;
        }
        set {
            this.telefoneField = value;
        }
    }
    
    /// <comentarios/>
    public string Ramal {
        get {
            return this.ramalField;
        }
        set {
            this.ramalField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class PessoaEnderecoPadraoERPOut_v1 {
    
    private byte tipoField;
    
    private string codigoAreaField;
    
    private string estruturaGeo0Field;
    
    private string estruturaGeo1Field;
    
    private string estruturaGeo2Field;
    
    private string estruturaGeo3Field;
    
    private string estruturaGeo4Field;
    
    private string estruturaGeo5Field;
    
    private string estruturaGeo6Field;
    
    private string estruturaGeo7Field;
    
    private string estruturaGeo8Field;
    
    private string estruturaGeo9Field;
    
    private string numeroField;
    
    private string complementoField;
    
    private string referenciaField;
    
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
    public string CodigoArea {
        get {
            return this.codigoAreaField;
        }
        set {
            this.codigoAreaField = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaGeo0 {
        get {
            return this.estruturaGeo0Field;
        }
        set {
            this.estruturaGeo0Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaGeo1 {
        get {
            return this.estruturaGeo1Field;
        }
        set {
            this.estruturaGeo1Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaGeo2 {
        get {
            return this.estruturaGeo2Field;
        }
        set {
            this.estruturaGeo2Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaGeo3 {
        get {
            return this.estruturaGeo3Field;
        }
        set {
            this.estruturaGeo3Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaGeo4 {
        get {
            return this.estruturaGeo4Field;
        }
        set {
            this.estruturaGeo4Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaGeo5 {
        get {
            return this.estruturaGeo5Field;
        }
        set {
            this.estruturaGeo5Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaGeo6 {
        get {
            return this.estruturaGeo6Field;
        }
        set {
            this.estruturaGeo6Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaGeo7 {
        get {
            return this.estruturaGeo7Field;
        }
        set {
            this.estruturaGeo7Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaGeo8 {
        get {
            return this.estruturaGeo8Field;
        }
        set {
            this.estruturaGeo8Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaGeo9 {
        get {
            return this.estruturaGeo9Field;
        }
        set {
            this.estruturaGeo9Field = value;
        }
    }
    
    /// <comentarios/>
    public string Numero {
        get {
            return this.numeroField;
        }
        set {
            this.numeroField = value;
        }
    }
    
    /// <comentarios/>
    public string Complemento {
        get {
            return this.complementoField;
        }
        set {
            this.complementoField = value;
        }
    }
    
    /// <comentarios/>
    public string Referencia {
        get {
            return this.referenciaField;
        }
        set {
            this.referenciaField = value;
        }
    }
}
