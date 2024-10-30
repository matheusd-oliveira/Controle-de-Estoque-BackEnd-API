using ControleDeEstoqueApi.Application.ViewModels;
using ControleDeEstoqueApi.Domain.Models.Agents;

namespace ControleDeEstoqueApi.Domain.Models.InterfacesRepositories
{
    public interface IVendedorRepository
    {
        // Login
        public void EfetuarLogin() { }

        public Task<IEnumerable<Produto>> BuscarProduto(string nomeDoProduto); // OK // Retorna os produtos através do nome, pois o nome é mais facil de achar já que é UNIQUE.

        // Mantem o Estoque
        public Task<IEnumerable<Estoque>> BuscarTodosOsProdutosNoEstoque(); // OK // Retorna uma lista de Produtos
        public Task<Estoque> BuscarProdutoNoEstoquePorId(int codigoDoProduto);  // OK // Retorna o produto dentro do estoque. 

        // Manter Vendas
        public Task<Venda> EfetuarVenda(Venda venda); 
        public Task AdicionarItemDeVenda(Item_Venda itemDaVenda); // Adicionar item da venda na Venda.
        public Task CancelarItemDeVenda(Item_Venda itemDaVenda); // Cancelar item da venda através do codigo do item , que é UNIQUE.
        public Task<IEnumerable<Estoque>> ListarProdutosPorNomeNaTelaDeVenda(string nomeDoProduto); // Listar todos os produtos através do nome na tela Venda.
        
        // public Task<IEnumerable<Produto>> ListarProdutosPorCodigoNaTelaDeVenda(int codigoDoProduto); // Listar todos os produtos através do código na tela Venda.
    }
}
