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
public partial class ArrayOfNotaFiscalBoliviaPadraoERPOut_v1 {
    
    private NotaFiscalBoliviaPadraoERPOut_v1[] registroField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("Registro", IsNullable=true)]
    public NotaFiscalBoliviaPadraoERPOut_v1[] Registro {
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
public partial class NotaFiscalBoliviaPadraoERPOut_v1 {
    
    private long codigoDocumentoField;
    
    private int codigoField;
    
    private int numeroField;
    
    private int serieField;
    
    private System.DateTime dataField;
    
    private decimal pesoLiquidoField;
    
    private bool pesoLiquidoFieldSpecified;
    
    private decimal pesoBrutoField;
    
    private bool pesoBrutoFieldSpecified;
    
    private decimal quantidadeVolumesField;
    
    private bool quantidadeVolumesFieldSpecified;
    
    private byte tipoField;
    
    private int codigoPedidoField;
    
    private byte situacaoField;
    
    private byte tipoFreteField;
    
    private string centroFaturamentoField;
    
    private string dadosAdicionaisField;
    
    private NotaFiscalBoliviaReferenciaPadraoERPOut_v1 notaFiscalReferenciaField;
    
    private NotaFiscalBoliviaPessoaPadraoERPOut_v1 pessoaEmissorField;
    
    private NotaFiscalBoliviaDestinatarioPadraoERPOut_v1 destinatarioField;
    
    private NotaFiscalBoliviaPessoaPadraoERPOut_v1 transportadoraField;
    
    private NotaFiscalBoliviaValoresPadraoERPOut_v1 valoresField;
    
    private NotaFiscalBoliviaDadosBoliviaPadraoERPOut_v1 dadosBoliviaField;
    
    private NotaFiscalBoliviaItensPadraoERPOut_v1[] itensNotaFiscalField;
    
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
    public int Numero {
        get {
            return this.numeroField;
        }
        set {
            this.numeroField = value;
        }
    }
    
    /// <comentarios/>
    public int Serie {
        get {
            return this.serieField;
        }
        set {
            this.serieField = value;
        }
    }
    
    /// <comentarios/>
    public System.DateTime Data {
        get {
            return this.dataField;
        }
        set {
            this.dataField = value;
        }
    }
    
    /// <comentarios/>
    public decimal PesoLiquido {
        get {
            return this.pesoLiquidoField;
        }
        set {
            this.pesoLiquidoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool PesoLiquidoSpecified {
        get {
            return this.pesoLiquidoFieldSpecified;
        }
        set {
            this.pesoLiquidoFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public decimal PesoBruto {
        get {
            return this.pesoBrutoField;
        }
        set {
            this.pesoBrutoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool PesoBrutoSpecified {
        get {
            return this.pesoBrutoFieldSpecified;
        }
        set {
            this.pesoBrutoFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public decimal QuantidadeVolumes {
        get {
            return this.quantidadeVolumesField;
        }
        set {
            this.quantidadeVolumesField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool QuantidadeVolumesSpecified {
        get {
            return this.quantidadeVolumesFieldSpecified;
        }
        set {
            this.quantidadeVolumesFieldSpecified = value;
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
    public int CodigoPedido {
        get {
            return this.codigoPedidoField;
        }
        set {
            this.codigoPedidoField = value;
        }
    }
    
    /// <comentarios/>
    public byte Situacao {
        get {
            return this.situacaoField;
        }
        set {
            this.situacaoField = value;
        }
    }
    
    /// <comentarios/>
    public byte TipoFrete {
        get {
            return this.tipoFreteField;
        }
        set {
            this.tipoFreteField = value;
        }
    }
    
    /// <comentarios/>
    public string CentroFaturamento {
        get {
            return this.centroFaturamentoField;
        }
        set {
            this.centroFaturamentoField = value;
        }
    }
    
    /// <comentarios/>
    public string DadosAdicionais {
        get {
            return this.dadosAdicionaisField;
        }
        set {
            this.dadosAdicionaisField = value;
        }
    }
    
    /// <comentarios/>
    public NotaFiscalBoliviaReferenciaPadraoERPOut_v1 NotaFiscalReferencia {
        get {
            return this.notaFiscalReferenciaField;
        }
        set {
            this.notaFiscalReferenciaField = value;
        }
    }
    
    /// <comentarios/>
    public NotaFiscalBoliviaPessoaPadraoERPOut_v1 PessoaEmissor {
        get {
            return this.pessoaEmissorField;
        }
        set {
            this.pessoaEmissorField = value;
        }
    }
    
    /// <comentarios/>
    public NotaFiscalBoliviaDestinatarioPadraoERPOut_v1 Destinatario {
        get {
            return this.destinatarioField;
        }
        set {
            this.destinatarioField = value;
        }
    }
    
    /// <comentarios/>
    public NotaFiscalBoliviaPessoaPadraoERPOut_v1 Transportadora {
        get {
            return this.transportadoraField;
        }
        set {
            this.transportadoraField = value;
        }
    }
    
    /// <comentarios/>
    public NotaFiscalBoliviaValoresPadraoERPOut_v1 Valores {
        get {
            return this.valoresField;
        }
        set {
            this.valoresField = value;
        }
    }
    
    /// <comentarios/>
    public NotaFiscalBoliviaDadosBoliviaPadraoERPOut_v1 DadosBolivia {
        get {
            return this.dadosBoliviaField;
        }
        set {
            this.dadosBoliviaField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("ItensNotaFiscal")]
    public NotaFiscalBoliviaItensPadraoERPOut_v1[] ItensNotaFiscal {
        get {
            return this.itensNotaFiscalField;
        }
        set {
            this.itensNotaFiscalField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class NotaFiscalBoliviaReferenciaPadraoERPOut_v1 {
    
    private int codigoNotaFiscalField;
    
    private int numeroField;
    
    private int serieField;
    
    private System.DateTime dataEmissaoField;
    
    private int codigoPessoaEmissorField;
    
    /// <comentarios/>
    public int CodigoNotaFiscal {
        get {
            return this.codigoNotaFiscalField;
        }
        set {
            this.codigoNotaFiscalField = value;
        }
    }
    
    /// <comentarios/>
    public int Numero {
        get {
            return this.numeroField;
        }
        set {
            this.numeroField = value;
        }
    }
    
    /// <comentarios/>
    public int Serie {
        get {
            return this.serieField;
        }
        set {
            this.serieField = value;
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
    public int CodigoPessoaEmissor {
        get {
            return this.codigoPessoaEmissorField;
        }
        set {
            this.codigoPessoaEmissorField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class NotaFiscalBoliviaItensValoresPadraoERPOut_v1 {
    
    private decimal precoTabelaField;
    
    private bool precoTabelaFieldSpecified;
    
    private decimal precoPraticadoField;
    
    private bool precoPraticadoFieldSpecified;
    
    private decimal precoLiquidoField;
    
    private bool precoLiquidoFieldSpecified;
    
    private decimal precoFaturamentoField;
    
    private decimal aliquotaImposto1Field;
    
    private decimal aliquotaImposto2Field;
    
    private decimal aliquotaImposto3Field;
    
    private decimal aliquotaImposto4Field;
    
    private decimal aliquotaImposto5Field;
    
    private decimal baseCalculoImposto1Field;
    
    private decimal baseCalculoImposto2Field;
    
    private decimal baseCalculoImposto3Field;
    
    private decimal baseCalculoImposto4Field;
    
    private decimal baseCalculoImposto5Field;
    
    private decimal valorImposto1Field;
    
    private decimal valorImposto2Field;
    
    private decimal valorImposto3Field;
    
    private decimal valorImposto4Field;
    
    private decimal valorImposto5Field;
    
    private decimal freteField;
    
    private decimal seguroField;
    
    private decimal outrasDespesasField;
    
    private bool outrasDespesasFieldSpecified;
    
    private decimal totalDiferencialAliquotasField;
    
    private bool totalDiferencialAliquotasFieldSpecified;
    
    /// <comentarios/>
    public decimal PrecoTabela {
        get {
            return this.precoTabelaField;
        }
        set {
            this.precoTabelaField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool PrecoTabelaSpecified {
        get {
            return this.precoTabelaFieldSpecified;
        }
        set {
            this.precoTabelaFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public decimal PrecoPraticado {
        get {
            return this.precoPraticadoField;
        }
        set {
            this.precoPraticadoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool PrecoPraticadoSpecified {
        get {
            return this.precoPraticadoFieldSpecified;
        }
        set {
            this.precoPraticadoFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public decimal PrecoLiquido {
        get {
            return this.precoLiquidoField;
        }
        set {
            this.precoLiquidoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool PrecoLiquidoSpecified {
        get {
            return this.precoLiquidoFieldSpecified;
        }
        set {
            this.precoLiquidoFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public decimal PrecoFaturamento {
        get {
            return this.precoFaturamentoField;
        }
        set {
            this.precoFaturamentoField = value;
        }
    }
    
    /// <comentarios/>
    public decimal AliquotaImposto1 {
        get {
            return this.aliquotaImposto1Field;
        }
        set {
            this.aliquotaImposto1Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal AliquotaImposto2 {
        get {
            return this.aliquotaImposto2Field;
        }
        set {
            this.aliquotaImposto2Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal AliquotaImposto3 {
        get {
            return this.aliquotaImposto3Field;
        }
        set {
            this.aliquotaImposto3Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal AliquotaImposto4 {
        get {
            return this.aliquotaImposto4Field;
        }
        set {
            this.aliquotaImposto4Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal AliquotaImposto5 {
        get {
            return this.aliquotaImposto5Field;
        }
        set {
            this.aliquotaImposto5Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal BaseCalculoImposto1 {
        get {
            return this.baseCalculoImposto1Field;
        }
        set {
            this.baseCalculoImposto1Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal BaseCalculoImposto2 {
        get {
            return this.baseCalculoImposto2Field;
        }
        set {
            this.baseCalculoImposto2Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal BaseCalculoImposto3 {
        get {
            return this.baseCalculoImposto3Field;
        }
        set {
            this.baseCalculoImposto3Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal BaseCalculoImposto4 {
        get {
            return this.baseCalculoImposto4Field;
        }
        set {
            this.baseCalculoImposto4Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal BaseCalculoImposto5 {
        get {
            return this.baseCalculoImposto5Field;
        }
        set {
            this.baseCalculoImposto5Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal ValorImposto1 {
        get {
            return this.valorImposto1Field;
        }
        set {
            this.valorImposto1Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal ValorImposto2 {
        get {
            return this.valorImposto2Field;
        }
        set {
            this.valorImposto2Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal ValorImposto3 {
        get {
            return this.valorImposto3Field;
        }
        set {
            this.valorImposto3Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal ValorImposto4 {
        get {
            return this.valorImposto4Field;
        }
        set {
            this.valorImposto4Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal ValorImposto5 {
        get {
            return this.valorImposto5Field;
        }
        set {
            this.valorImposto5Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal Frete {
        get {
            return this.freteField;
        }
        set {
            this.freteField = value;
        }
    }
    
    /// <comentarios/>
    public decimal Seguro {
        get {
            return this.seguroField;
        }
        set {
            this.seguroField = value;
        }
    }
    
    /// <comentarios/>
    public decimal OutrasDespesas {
        get {
            return this.outrasDespesasField;
        }
        set {
            this.outrasDespesasField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool OutrasDespesasSpecified {
        get {
            return this.outrasDespesasFieldSpecified;
        }
        set {
            this.outrasDespesasFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public decimal TotalDiferencialAliquotas {
        get {
            return this.totalDiferencialAliquotasField;
        }
        set {
            this.totalDiferencialAliquotasField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool TotalDiferencialAliquotasSpecified {
        get {
            return this.totalDiferencialAliquotasFieldSpecified;
        }
        set {
            this.totalDiferencialAliquotasFieldSpecified = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class NotaFiscalBoliviaItensPadraoERPOut_v1 {
    
    private int numeroItemField;
    
    private string codigoSKUField;
    
    private string materialField;
    
    private int quantidadeField;
    
    private string codigoEstoqueField;
    
    private int cFOPField;
    
    private string classificacaoFiscalField;
    
    private decimal percentualMVAField;
    
    private byte unidadeMedidaField;
    
    private byte operacaoFiscalField;
    
    private NotaFiscalBoliviaItensValoresPadraoERPOut_v1 valoresField;
    
    /// <comentarios/>
    public int NumeroItem {
        get {
            return this.numeroItemField;
        }
        set {
            this.numeroItemField = value;
        }
    }
    
    /// <comentarios/>
    public string CodigoSKU {
        get {
            return this.codigoSKUField;
        }
        set {
            this.codigoSKUField = value;
        }
    }
    
    /// <comentarios/>
    public string Material {
        get {
            return this.materialField;
        }
        set {
            this.materialField = value;
        }
    }
    
    /// <comentarios/>
    public int Quantidade {
        get {
            return this.quantidadeField;
        }
        set {
            this.quantidadeField = value;
        }
    }
    
    /// <comentarios/>
    public string CodigoEstoque {
        get {
            return this.codigoEstoqueField;
        }
        set {
            this.codigoEstoqueField = value;
        }
    }
    
    /// <comentarios/>
    public int CFOP {
        get {
            return this.cFOPField;
        }
        set {
            this.cFOPField = value;
        }
    }
    
    /// <comentarios/>
    public string ClassificacaoFiscal {
        get {
            return this.classificacaoFiscalField;
        }
        set {
            this.classificacaoFiscalField = value;
        }
    }
    
    /// <comentarios/>
    public decimal PercentualMVA {
        get {
            return this.percentualMVAField;
        }
        set {
            this.percentualMVAField = value;
        }
    }
    
    /// <comentarios/>
    public byte UnidadeMedida {
        get {
            return this.unidadeMedidaField;
        }
        set {
            this.unidadeMedidaField = value;
        }
    }
    
    /// <comentarios/>
    public byte OperacaoFiscal {
        get {
            return this.operacaoFiscalField;
        }
        set {
            this.operacaoFiscalField = value;
        }
    }
    
    /// <comentarios/>
    public NotaFiscalBoliviaItensValoresPadraoERPOut_v1 Valores {
        get {
            return this.valoresField;
        }
        set {
            this.valoresField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class NotaFiscalBoliviaDadosBoliviaPadraoERPOut_v1 {
    
    private long numeroAutorizacaoField;
    
    private string codigoControleField;
    
    private long numeroDocumentoFiscalBOField;
    
    private System.DateTime dataEmissaoField;
    
    private System.DateTime dataLimiteEmissaoField;
    
    private string chaveDosificacaoField;
    
    /// <comentarios/>
    public long NumeroAutorizacao {
        get {
            return this.numeroAutorizacaoField;
        }
        set {
            this.numeroAutorizacaoField = value;
        }
    }
    
    /// <comentarios/>
    public string CodigoControle {
        get {
            return this.codigoControleField;
        }
        set {
            this.codigoControleField = value;
        }
    }
    
    /// <comentarios/>
    public long NumeroDocumentoFiscalBO {
        get {
            return this.numeroDocumentoFiscalBOField;
        }
        set {
            this.numeroDocumentoFiscalBOField = value;
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
    public System.DateTime DataLimiteEmissao {
        get {
            return this.dataLimiteEmissaoField;
        }
        set {
            this.dataLimiteEmissaoField = value;
        }
    }
    
    /// <comentarios/>
    public string ChaveDosificacao {
        get {
            return this.chaveDosificacaoField;
        }
        set {
            this.chaveDosificacaoField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class NotaFiscalBoliviaValoresPadraoERPOut_v1 {
    
    private decimal valorTotalNotaField;
    
    private decimal valorProdutosField;
    
    private decimal baseCalculoImposto1Field;
    
    private decimal baseCalculoImposto2Field;
    
    private decimal baseCalculoImposto3Field;
    
    private decimal baseCalculoImposto4Field;
    
    private decimal baseCalculoImposto5Field;
    
    private decimal valorImposto1Field;
    
    private decimal valorImposto2Field;
    
    private decimal valorImposto3Field;
    
    private decimal valorImposto4Field;
    
    private decimal valorImposto5Field;
    
    private decimal freteField;
    
    private decimal seguroField;
    
    private decimal outrasDespesasField;
    
    private bool outrasDespesasFieldSpecified;
    
    private decimal totalDiferencialAliquotasField;
    
    private bool totalDiferencialAliquotasFieldSpecified;
    
    /// <comentarios/>
    public decimal ValorTotalNota {
        get {
            return this.valorTotalNotaField;
        }
        set {
            this.valorTotalNotaField = value;
        }
    }
    
    /// <comentarios/>
    public decimal ValorProdutos {
        get {
            return this.valorProdutosField;
        }
        set {
            this.valorProdutosField = value;
        }
    }
    
    /// <comentarios/>
    public decimal BaseCalculoImposto1 {
        get {
            return this.baseCalculoImposto1Field;
        }
        set {
            this.baseCalculoImposto1Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal BaseCalculoImposto2 {
        get {
            return this.baseCalculoImposto2Field;
        }
        set {
            this.baseCalculoImposto2Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal BaseCalculoImposto3 {
        get {
            return this.baseCalculoImposto3Field;
        }
        set {
            this.baseCalculoImposto3Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal BaseCalculoImposto4 {
        get {
            return this.baseCalculoImposto4Field;
        }
        set {
            this.baseCalculoImposto4Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal BaseCalculoImposto5 {
        get {
            return this.baseCalculoImposto5Field;
        }
        set {
            this.baseCalculoImposto5Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal ValorImposto1 {
        get {
            return this.valorImposto1Field;
        }
        set {
            this.valorImposto1Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal ValorImposto2 {
        get {
            return this.valorImposto2Field;
        }
        set {
            this.valorImposto2Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal ValorImposto3 {
        get {
            return this.valorImposto3Field;
        }
        set {
            this.valorImposto3Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal ValorImposto4 {
        get {
            return this.valorImposto4Field;
        }
        set {
            this.valorImposto4Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal ValorImposto5 {
        get {
            return this.valorImposto5Field;
        }
        set {
            this.valorImposto5Field = value;
        }
    }
    
    /// <comentarios/>
    public decimal Frete {
        get {
            return this.freteField;
        }
        set {
            this.freteField = value;
        }
    }
    
    /// <comentarios/>
    public decimal Seguro {
        get {
            return this.seguroField;
        }
        set {
            this.seguroField = value;
        }
    }
    
    /// <comentarios/>
    public decimal OutrasDespesas {
        get {
            return this.outrasDespesasField;
        }
        set {
            this.outrasDespesasField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool OutrasDespesasSpecified {
        get {
            return this.outrasDespesasFieldSpecified;
        }
        set {
            this.outrasDespesasFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public decimal TotalDiferencialAliquotas {
        get {
            return this.totalDiferencialAliquotasField;
        }
        set {
            this.totalDiferencialAliquotasField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool TotalDiferencialAliquotasSpecified {
        get {
            return this.totalDiferencialAliquotasFieldSpecified;
        }
        set {
            this.totalDiferencialAliquotasFieldSpecified = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class NotaFiscalBoliviaDestinatarioPadraoERPOut_v1 {
    
    private int codigoField;
    
    private string nomeField;
    
    private byte tipoField;
    
    private string identificacaoField;
    
    private byte tipoIdentificacaoField;
    
    private bool tipoIdentificacaoFieldSpecified;
    
    private string telefoneField;
    
    private string emailField;
    
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
    
    private byte entregaVizinhoField;
    
    private bool entregaVizinhoFieldSpecified;
    
    private string numeroVizinhoField;
    
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
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool TipoIdentificacaoSpecified {
        get {
            return this.tipoIdentificacaoFieldSpecified;
        }
        set {
            this.tipoIdentificacaoFieldSpecified = value;
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
    public string Email {
        get {
            return this.emailField;
        }
        set {
            this.emailField = value;
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
    
    /// <comentarios/>
    public byte EntregaVizinho {
        get {
            return this.entregaVizinhoField;
        }
        set {
            this.entregaVizinhoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool EntregaVizinhoSpecified {
        get {
            return this.entregaVizinhoFieldSpecified;
        }
        set {
            this.entregaVizinhoFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public string NumeroVizinho {
        get {
            return this.numeroVizinhoField;
        }
        set {
            this.numeroVizinhoField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class NotaFiscalBoliviaPessoaPadraoERPOut_v1 {
    
    private int codigoField;
    
    private string nomeField;
    
    private byte tipoField;
    
    private string identificacaoField;
    
    private byte tipoIdentificacaoField;
    
    private bool tipoIdentificacaoFieldSpecified;
    
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
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool TipoIdentificacaoSpecified {
        get {
            return this.tipoIdentificacaoFieldSpecified;
        }
        set {
            this.tipoIdentificacaoFieldSpecified = value;
        }
    }
}
