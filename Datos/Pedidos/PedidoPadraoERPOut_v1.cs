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
public partial class ArrayOfPedidoPadraoERPOut_v1 {
    
    private PedidoPadraoERPOut_v1[] registroField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("Registro", IsNullable=true)]
    public PedidoPadraoERPOut_v1[] Registro {
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
public partial class PedidoPadraoERPOut_v1 {
    
    private long codigoDocumentoField;
    
    private int codigoPedidoField;
    
    private byte situacaoComercialField;
    
    private byte situacaoFiscalField;
    
    private int campanhaField;
    
    private int campanhaMarketingField;
    
    private int campanhaIndicadorField;
    
    private bool campanhaIndicadorFieldSpecified;
    
    private string funcaoField;
    
    private string papelField;
    
    private string centroDistribuicaoField;
    
    private byte tipoCentroDistribuicaoField;
    
    private string centroDistribuicaoFaturamentoField;
    
    private System.DateTime dataHoraPedidoField;
    
    private System.DateTime dataHoraAprovacaoField;
    
    private int codigoContaContabilField;
    
    private string contaContabilField;
    
    private byte meioCaptacaoField;
    
    private byte sistemaOrigemField;
    
    private int codigoModeloComercialField;
    
    private string modeloComercialField;
    
    private decimal volumeField;
    
    private decimal pesoField;
    
    private int codigoExternoPoliticaEntregaField;
    
    private string opcaoEntregaField;
    
    private EntregaPedidoPadraoERPOut_v1 entregaPedidoField;
    
    private PessoaPedidoPadraoERPOut_v1 pessoaPedidoField;
    
    private ItemPedidoPadraoERPOut_v1[] itensPedidoField;
    
    private PedidoBrindePadraoERPOut_v1[] brindesField;
    
    private PedidoItemCortadoPadraoERPOut_v1[] itensCortadosField;
    
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
    public int CodigoPedido {
        get {
            return this.codigoPedidoField;
        }
        set {
            this.codigoPedidoField = value;
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
    public byte SituacaoFiscal {
        get {
            return this.situacaoFiscalField;
        }
        set {
            this.situacaoFiscalField = value;
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
    public int CampanhaMarketing {
        get {
            return this.campanhaMarketingField;
        }
        set {
            this.campanhaMarketingField = value;
        }
    }
    
    /// <comentarios/>
    public int CampanhaIndicador {
        get {
            return this.campanhaIndicadorField;
        }
        set {
            this.campanhaIndicadorField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool CampanhaIndicadorSpecified {
        get {
            return this.campanhaIndicadorFieldSpecified;
        }
        set {
            this.campanhaIndicadorFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public string Funcao {
        get {
            return this.funcaoField;
        }
        set {
            this.funcaoField = value;
        }
    }
    
    /// <comentarios/>
    public string Papel {
        get {
            return this.papelField;
        }
        set {
            this.papelField = value;
        }
    }
    
    /// <comentarios/>
    public string CentroDistribuicao {
        get {
            return this.centroDistribuicaoField;
        }
        set {
            this.centroDistribuicaoField = value;
        }
    }
    
    /// <comentarios/>
    public byte TipoCentroDistribuicao {
        get {
            return this.tipoCentroDistribuicaoField;
        }
        set {
            this.tipoCentroDistribuicaoField = value;
        }
    }
    
    /// <comentarios/>
    public string CentroDistribuicaoFaturamento {
        get {
            return this.centroDistribuicaoFaturamentoField;
        }
        set {
            this.centroDistribuicaoFaturamentoField = value;
        }
    }
    
    /// <comentarios/>
    public System.DateTime DataHoraPedido {
        get {
            return this.dataHoraPedidoField;
        }
        set {
            this.dataHoraPedidoField = value;
        }
    }
    
    /// <comentarios/>
    public System.DateTime DataHoraAprovacao {
        get {
            return this.dataHoraAprovacaoField;
        }
        set {
            this.dataHoraAprovacaoField = value;
        }
    }
    
    /// <comentarios/>
    public int CodigoContaContabil {
        get {
            return this.codigoContaContabilField;
        }
        set {
            this.codigoContaContabilField = value;
        }
    }
    
    /// <comentarios/>
    public string ContaContabil {
        get {
            return this.contaContabilField;
        }
        set {
            this.contaContabilField = value;
        }
    }
    
    /// <comentarios/>
    public byte MeioCaptacao {
        get {
            return this.meioCaptacaoField;
        }
        set {
            this.meioCaptacaoField = value;
        }
    }
    
    /// <comentarios/>
    public byte SistemaOrigem {
        get {
            return this.sistemaOrigemField;
        }
        set {
            this.sistemaOrigemField = value;
        }
    }
    
    /// <comentarios/>
    public int CodigoModeloComercial {
        get {
            return this.codigoModeloComercialField;
        }
        set {
            this.codigoModeloComercialField = value;
        }
    }
    
    /// <comentarios/>
    public string ModeloComercial {
        get {
            return this.modeloComercialField;
        }
        set {
            this.modeloComercialField = value;
        }
    }
    
    /// <comentarios/>
    public decimal Volume {
        get {
            return this.volumeField;
        }
        set {
            this.volumeField = value;
        }
    }
    
    /// <comentarios/>
    public decimal Peso {
        get {
            return this.pesoField;
        }
        set {
            this.pesoField = value;
        }
    }
    
    /// <comentarios/>
    public int CodigoExternoPoliticaEntrega {
        get {
            return this.codigoExternoPoliticaEntregaField;
        }
        set {
            this.codigoExternoPoliticaEntregaField = value;
        }
    }
    
    /// <comentarios/>
    public string OpcaoEntrega {
        get {
            return this.opcaoEntregaField;
        }
        set {
            this.opcaoEntregaField = value;
        }
    }
    
    /// <comentarios/>
    public EntregaPedidoPadraoERPOut_v1 EntregaPedido {
        get {
            return this.entregaPedidoField;
        }
        set {
            this.entregaPedidoField = value;
        }
    }
    
    /// <comentarios/>
    public PessoaPedidoPadraoERPOut_v1 PessoaPedido {
        get {
            return this.pessoaPedidoField;
        }
        set {
            this.pessoaPedidoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ItemPedido")]
    public ItemPedidoPadraoERPOut_v1[] ItensPedido {
        get {
            return this.itensPedidoField;
        }
        set {
            this.itensPedidoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ItemBrinde")]
    public PedidoBrindePadraoERPOut_v1[] Brindes {
        get {
            return this.brindesField;
        }
        set {
            this.brindesField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ItemCortado")]
    public PedidoItemCortadoPadraoERPOut_v1[] ItensCortados {
        get {
            return this.itensCortadosField;
        }
        set {
            this.itensCortadosField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class EntregaPedidoPadraoERPOut_v1 {
    
    private string politicaEntregaField;
    
    private decimal valorEntregaField;
    
    private bool valorEntregaFieldSpecified;
    
    private string entregaCodigoAreaField;
    
    private string estruturaGeograficaNivel0Field;
    
    private string estruturaGeograficaNivel1Field;
    
    private string estruturaGeograficaNivel2Field;
    
    private string estruturaGeograficaNivel3Field;
    
    private string estruturaGeograficaNivel4Field;
    
    private string estruturaGeograficaNivel5Field;
    
    private string estruturaGeograficaNivel6Field;
    
    private string estruturaGeograficaNivel7Field;
    
    private string estruturaGeograficaNivel8Field;
    
    private string estruturaGeograficaNivel9Field;
    
    private string entregaNumeroField;
    
    private string entregaComplementoField;
    
    private string entregaReferenciaField;
    
    private System.DateTime dataPrevisaoEntregaField;
    
    private bool dataPrevisaoEntregaFieldSpecified;
    
    private byte entregaVizinhoField;
    
    private bool entregaVizinhoFieldSpecified;
    
    private string entregaNumeroVizinhoField;
    
    /// <comentarios/>
    public string PoliticaEntrega {
        get {
            return this.politicaEntregaField;
        }
        set {
            this.politicaEntregaField = value;
        }
    }
    
    /// <comentarios/>
    public decimal ValorEntrega {
        get {
            return this.valorEntregaField;
        }
        set {
            this.valorEntregaField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ValorEntregaSpecified {
        get {
            return this.valorEntregaFieldSpecified;
        }
        set {
            this.valorEntregaFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public string EntregaCodigoArea {
        get {
            return this.entregaCodigoAreaField;
        }
        set {
            this.entregaCodigoAreaField = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaGeograficaNivel0 {
        get {
            return this.estruturaGeograficaNivel0Field;
        }
        set {
            this.estruturaGeograficaNivel0Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaGeograficaNivel1 {
        get {
            return this.estruturaGeograficaNivel1Field;
        }
        set {
            this.estruturaGeograficaNivel1Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaGeograficaNivel2 {
        get {
            return this.estruturaGeograficaNivel2Field;
        }
        set {
            this.estruturaGeograficaNivel2Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaGeograficaNivel3 {
        get {
            return this.estruturaGeograficaNivel3Field;
        }
        set {
            this.estruturaGeograficaNivel3Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaGeograficaNivel4 {
        get {
            return this.estruturaGeograficaNivel4Field;
        }
        set {
            this.estruturaGeograficaNivel4Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaGeograficaNivel5 {
        get {
            return this.estruturaGeograficaNivel5Field;
        }
        set {
            this.estruturaGeograficaNivel5Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaGeograficaNivel6 {
        get {
            return this.estruturaGeograficaNivel6Field;
        }
        set {
            this.estruturaGeograficaNivel6Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaGeograficaNivel7 {
        get {
            return this.estruturaGeograficaNivel7Field;
        }
        set {
            this.estruturaGeograficaNivel7Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaGeograficaNivel8 {
        get {
            return this.estruturaGeograficaNivel8Field;
        }
        set {
            this.estruturaGeograficaNivel8Field = value;
        }
    }
    
    /// <comentarios/>
    public string EstruturaGeograficaNivel9 {
        get {
            return this.estruturaGeograficaNivel9Field;
        }
        set {
            this.estruturaGeograficaNivel9Field = value;
        }
    }
    
    /// <comentarios/>
    public string EntregaNumero {
        get {
            return this.entregaNumeroField;
        }
        set {
            this.entregaNumeroField = value;
        }
    }
    
    /// <comentarios/>
    public string EntregaComplemento {
        get {
            return this.entregaComplementoField;
        }
        set {
            this.entregaComplementoField = value;
        }
    }
    
    /// <comentarios/>
    public string EntregaReferencia {
        get {
            return this.entregaReferenciaField;
        }
        set {
            this.entregaReferenciaField = value;
        }
    }
    
    /// <comentarios/>
    public System.DateTime DataPrevisaoEntrega {
        get {
            return this.dataPrevisaoEntregaField;
        }
        set {
            this.dataPrevisaoEntregaField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool DataPrevisaoEntregaSpecified {
        get {
            return this.dataPrevisaoEntregaFieldSpecified;
        }
        set {
            this.dataPrevisaoEntregaFieldSpecified = value;
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
    public string EntregaNumeroVizinho {
        get {
            return this.entregaNumeroVizinhoField;
        }
        set {
            this.entregaNumeroVizinhoField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class PedidoItemCortadoPadraoERPOut_v1 {
    
    private decimal precoTabelaField;
    
    private decimal precoPraticadoField;
    
    private int quantidadeField;
    
    private byte motivoCorteItemPedidoField;
    
    private PedidoProdutoPadraoERPOut_v1 produtoField;
    
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
    public decimal PrecoPraticado {
        get {
            return this.precoPraticadoField;
        }
        set {
            this.precoPraticadoField = value;
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
    public byte MotivoCorteItemPedido {
        get {
            return this.motivoCorteItemPedidoField;
        }
        set {
            this.motivoCorteItemPedidoField = value;
        }
    }
    
    /// <comentarios/>
    public PedidoProdutoPadraoERPOut_v1 Produto {
        get {
            return this.produtoField;
        }
        set {
            this.produtoField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class PedidoProdutoPadraoERPOut_v1 {
    
    private int codigoProdutoField;
    
    private string nomeProdutoField;
    
    private PedidoMaterialPadraoERPOut_v1[] materiaisField;
    
    /// <comentarios/>
    public int CodigoProduto {
        get {
            return this.codigoProdutoField;
        }
        set {
            this.codigoProdutoField = value;
        }
    }
    
    /// <comentarios/>
    public string NomeProduto {
        get {
            return this.nomeProdutoField;
        }
        set {
            this.nomeProdutoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Material")]
    public PedidoMaterialPadraoERPOut_v1[] Materiais {
        get {
            return this.materiaisField;
        }
        set {
            this.materiaisField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class PedidoMaterialPadraoERPOut_v1 {
    
    private string codigoMaterialSKUField;
    
    private int quantidadeField;
    
    private decimal precoTabelaField;
    
    private decimal precoPraticadoField;
    
    private decimal precoLiquidoField;
    
    private bool precoLiquidoFieldSpecified;
    
    private decimal precoCustoField;
    
    private bool precoCustoFieldSpecified;
    
    private decimal valorComissaoField;
    
    private bool valorComissaoFieldSpecified;
    
    /// <comentarios/>
    public string CodigoMaterialSKU {
        get {
            return this.codigoMaterialSKUField;
        }
        set {
            this.codigoMaterialSKUField = value;
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
    public decimal PrecoTabela {
        get {
            return this.precoTabelaField;
        }
        set {
            this.precoTabelaField = value;
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
    public decimal PrecoCusto {
        get {
            return this.precoCustoField;
        }
        set {
            this.precoCustoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool PrecoCustoSpecified {
        get {
            return this.precoCustoFieldSpecified;
        }
        set {
            this.precoCustoFieldSpecified = value;
        }
    }
    
    /// <comentarios/>
    public decimal ValorComissao {
        get {
            return this.valorComissaoField;
        }
        set {
            this.valorComissaoField = value;
        }
    }
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ValorComissaoSpecified {
        get {
            return this.valorComissaoFieldSpecified;
        }
        set {
            this.valorComissaoFieldSpecified = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class PedidoPromocaoPadraoERPOut_v1 {
    
    private int codigoPromocaoField;
    
    private string nomePromocaoField;
    
    /// <comentarios/>
    public int CodigoPromocao {
        get {
            return this.codigoPromocaoField;
        }
        set {
            this.codigoPromocaoField = value;
        }
    }
    
    /// <comentarios/>
    public string NomePromocao {
        get {
            return this.nomePromocaoField;
        }
        set {
            this.nomePromocaoField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class PedidoBrindePadraoERPOut_v1 {
    
    private int numeroItemBrindeField;
    
    private int quantidadeField;
    
    private decimal precoTabelaField;
    
    private decimal precoCustoField;
    
    private byte kitField;
    
    private byte tipoProdutoField;
    
    private PedidoProdutoPadraoERPOut_v1 produtoField;
    
    private PedidoPromocaoPadraoERPOut_v1 promocaoField;
    
    /// <comentarios/>
    public int NumeroItemBrinde {
        get {
            return this.numeroItemBrindeField;
        }
        set {
            this.numeroItemBrindeField = value;
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
    public decimal PrecoTabela {
        get {
            return this.precoTabelaField;
        }
        set {
            this.precoTabelaField = value;
        }
    }
    
    /// <comentarios/>
    public decimal PrecoCusto {
        get {
            return this.precoCustoField;
        }
        set {
            this.precoCustoField = value;
        }
    }
    
    /// <comentarios/>
    public byte Kit {
        get {
            return this.kitField;
        }
        set {
            this.kitField = value;
        }
    }
    
    /// <comentarios/>
    public byte TipoProduto {
        get {
            return this.tipoProdutoField;
        }
        set {
            this.tipoProdutoField = value;
        }
    }
    
    /// <comentarios/>
    public PedidoProdutoPadraoERPOut_v1 Produto {
        get {
            return this.produtoField;
        }
        set {
            this.produtoField = value;
        }
    }
    
    /// <comentarios/>
    public PedidoPromocaoPadraoERPOut_v1 Promocao {
        get {
            return this.promocaoField;
        }
        set {
            this.promocaoField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class ItemPedidoPadraoERPOut_v1 {
    
    private int numeroItemField;
    
    private int quantidadeField;
    
    private decimal precoTabelaField;
    
    private decimal precoPraticadoField;
    
    private decimal precoLiquidoField;
    
    private decimal precoCustoField;
    
    private decimal valorComissaoField;
    
    private int quantidadePontosField;
    
    private byte kitField;
    
    private byte tipoProdutoField;
    
    private PedidoProdutoPadraoERPOut_v1 produtoField;
    
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
    public int Quantidade {
        get {
            return this.quantidadeField;
        }
        set {
            this.quantidadeField = value;
        }
    }
    
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
    public decimal PrecoPraticado {
        get {
            return this.precoPraticadoField;
        }
        set {
            this.precoPraticadoField = value;
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
    public decimal PrecoCusto {
        get {
            return this.precoCustoField;
        }
        set {
            this.precoCustoField = value;
        }
    }
    
    /// <comentarios/>
    public decimal ValorComissao {
        get {
            return this.valorComissaoField;
        }
        set {
            this.valorComissaoField = value;
        }
    }
    
    /// <comentarios/>
    public int QuantidadePontos {
        get {
            return this.quantidadePontosField;
        }
        set {
            this.quantidadePontosField = value;
        }
    }
    
    /// <comentarios/>
    public byte Kit {
        get {
            return this.kitField;
        }
        set {
            this.kitField = value;
        }
    }
    
    /// <comentarios/>
    public byte TipoProduto {
        get {
            return this.tipoProdutoField;
        }
        set {
            this.tipoProdutoField = value;
        }
    }
    
    /// <comentarios/>
    public PedidoProdutoPadraoERPOut_v1 Produto {
        get {
            return this.produtoField;
        }
        set {
            this.produtoField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
public partial class PessoaPedidoPadraoERPOut_v1 {
    
    private int codigoPessoaField;
    
    private string pessoaNomeField;
    
    private byte tipoPessoaField;
    
    private string identificacaoField;
    
    private byte tipoIdentificacaoField;
    
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
    public string PessoaNome {
        get {
            return this.pessoaNomeField;
        }
        set {
            this.pessoaNomeField = value;
        }
    }
    
    /// <comentarios/>
    public byte TipoPessoa {
        get {
            return this.tipoPessoaField;
        }
        set {
            this.tipoPessoaField = value;
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
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.gera.com.br/", IsNullable=true)]
public partial class ArrayOfItemPedidoPadraoERPOut_v1 {
    
    private ItemPedidoPadraoERPOut_v1[] itemPedidoField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("ItemPedido", IsNullable=true)]
    public ItemPedidoPadraoERPOut_v1[] ItemPedido {
        get {
            return this.itemPedidoField;
        }
        set {
            this.itemPedidoField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.gera.com.br/", IsNullable=true)]
public partial class ArrayOfPedidoBrindePadraoERPOut_v1 {
    
    private PedidoBrindePadraoERPOut_v1[] itemBrindeField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("ItemBrinde", IsNullable=true)]
    public PedidoBrindePadraoERPOut_v1[] ItemBrinde {
        get {
            return this.itemBrindeField;
        }
        set {
            this.itemBrindeField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.gera.com.br/", IsNullable=true)]
public partial class ArrayOfPedidoItemCortadoPadraoERPOut_v1 {
    
    private PedidoItemCortadoPadraoERPOut_v1[] itemCortadoField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("ItemCortado", IsNullable=true)]
    public PedidoItemCortadoPadraoERPOut_v1[] ItemCortado {
        get {
            return this.itemCortadoField;
        }
        set {
            this.itemCortadoField = value;
        }
    }
}

/// <comentarios/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.gera.com.br/")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.gera.com.br/", IsNullable=true)]
public partial class ArrayOfPedidoMaterialPadraoERPOut_v1 {
    
    private PedidoMaterialPadraoERPOut_v1[] materialField;
    
    /// <comentarios/>
    [System.Xml.Serialization.XmlElementAttribute("Material", IsNullable=true)]
    public PedidoMaterialPadraoERPOut_v1[] Material {
        get {
            return this.materialField;
        }
        set {
            this.materialField = value;
        }
    }
}
