namespace ControleDeEstoqueApi.Domain.Models.InterfacesRepositories
{
    public interface IVendedorRepository
    {   
        // Login
        public void EfetuarLogin() { }

        // Mantem o Produto
        public void CadastrarProduto() { }
        public void AlterarProduto() { }
        public void BuscarProduto() { }

        // Mantem o Estoque
        public void BuscarTodosOsProdutosNoEstoque() { }
        public void BuscarProdutoNoEstoquePorId() { }
        public void EntradaDoProdutoNoEstoque() { }
        public void SaidaDoProdutoNoEstoque() { }

        // Manter Vendas
        public void EfetuarVenda() { }
        public void CancelarVenda() { }
        public void AdicionarItemDeVenda() { }
        public void CancelarItemDeVenda() { }
        public void ListarProdutosPorNomeNaTelaDeVenda() { }
        
    }
}
