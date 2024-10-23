namespace ControleDeEstoqueApi.Application.ViewModels
{   
    public class ProdutoViewModel
    {
        public int CodigoDoProduto { get; set; }
        public int CodigoDoFornecedor { get; set; }
        public int CodigoDoFabricante { get; set; }
        public string NomeDoProduto { get; set; }
        public decimal ValorDeCompra { get; set; }
        public decimal ValorDeVenda { get; set; }
        public string DescricaoDoProduto { get; set; }
        public int QuantidadeMinimaParaComprar { get; set; }

    }
}
