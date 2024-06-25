using ControleDeEstoqueApi.Domain.Models.Agents;

namespace ControleDeEstoqueApi.Domain.Models.InterfacesRepositories
{
    public interface IVendedorRepository
    {
        // Login
        public void EfetuarLogin() { }

        // Mantem o Produto
        public Task CadastrarProduto(Produto produto);
        public Task AlterarProduto(int codigoDoProduto, Produto novoProduto);
        public Task<Produto> BuscarProduto(string nomeDoProduto); // Retorna os produtos através do nome, pois o nome é mais facil de achar já que é UNIQUE.

        // Mantem o Estoque
        public Task<IEnumerable<Estoque>> BuscarTodosOsProdutosNoEstoque(); // Retorna uma lista de Produtos
        public Task<Produto> BuscarProdutoNoEstoquePorId(int codigoDoProduto); // Retorna o produto dentro do estoque. 
        public Task EntradaDoProdutoNoEstoque(Produto produto, Funcionario funcionario); // O produto já está cadastrado, ele só vai buscar da lista de produtos cadastrados e dar ENTRADA no estoque.
        public Task SaidaDoProdutoNoEstoque(Produto produto, Funcionario funcionario); // Dar a SAIDA do estoque por meio da propriedade cod_prod que é UNIQUE.

        // Manter Vendas
        public Task<Venda> EfetuarVenda(Venda venda); 
        public Task<Venda> CancelarVenda(Venda venda); // Cancelar venda através do codigo da venda.
        public Task AdicionarItemDeVenda(Item_Venda itemDaVenda); // Adicionar item da venda na Venda.
        public Task CancelarItemDeVenda(Item_Venda itemDaVenda); // Cancelar item da venda através do codigo do item , que é UNIQUE.
        public Task<IEnumerable<Produto>> ListarProdutosPorNomeNaTelaDeVenda(string nomeDoProduto); // Listar todos os produtos através do nome na tela Venda.


    }
}
