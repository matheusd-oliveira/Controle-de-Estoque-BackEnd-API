namespace ControleDeEstoqueApi.Application.ViewModels
{
    public class EstoqueViewModel
    {
        public int CodigoDoFuncionario { get; set; }
        public int CodigoDoProduto { get; set; }
        public string NomeDoProduto { get; set; }
        public string NomeFantasiaDoFornecedor { get; set; }
        public string NomeDoFabricante { get; set; }
        public int QuantidadeDoProduto { get; set; }
    }
}
