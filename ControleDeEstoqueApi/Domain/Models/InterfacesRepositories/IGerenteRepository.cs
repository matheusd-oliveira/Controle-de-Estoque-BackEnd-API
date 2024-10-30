using ControleDeEstoqueApi.Domain.Models.Agents;

namespace ControleDeEstoqueApi.Domain.Models.InterfacesRepositories
{
    public interface IGerenteRepository
    {
        // Adicionando regras de negócio pertinentes a todos os funcionarios.

        // Login
        public void EfetuarLogin() { }

        // Mantem o Produto
        public Task<Produto> CadastrarProduto(Produto produto);
        public Task<Produto> AlterarProduto(int codigoDoProduto, Produto novoProduto);
        public Task<IEnumerable<Produto>> BuscarProduto(string nomeDoProduto); // Retorna os produtos através do nome, pois o nome é mais facil de achar já que é UNIQUE.

        // Mantem o Estoque
        public Task<IEnumerable<Estoque>> BuscarTodosOsProdutosNoEstoque(); // Retorna uma lista de Produtos
        public Task<Estoque> BuscarProdutoNoEstoquePorId(int codigoDoProduto); // Retorna o produto dentro do estoque. 
        public Task EntradaDoProdutoNoEstoque(Produto produto, Funcionario funcionario); // O produto já está cadastrado, ele só vai buscar da lista de produtos cadastrados e dar ENTRADA no estoque.
        public Task SaidaDoProdutoNoEstoque(Produto produto, Funcionario funcionario); // Dar a SAIDA do estoque por meio da propriedade cod_prod que é UNIQUE.

        // Manter Vendas
        public Task<Venda> EfetuarVenda(Venda venda);
        public Task<Venda> CancelarVenda(Venda venda); // Cancelar venda através do codigo da venda.
        public Task AdicionarItemDeVenda(Item_Venda itemDaVenda); // Adicionar item da venda na Venda.
        public Task CancelarItemDeVenda(Item_Venda itemDaVenda); // Cancelar item da venda através do codigo do item , que é UNIQUE.
        public Task<IEnumerable<Estoque>> ListarProdutosPorNomeNaTelaDeVenda(string nomeDoProduto); // Listar todos os produtos através do nome na tela Venda.
        
        // TODO: Adicionar async aos métodos
        // Gerar Relatorio
        // TODO: PENSAR EM COMO EXIBIR ESSAS VENDAS.
        public Task ExibirRelatorioDeVendasDoMes();
        public Task<IEnumerable<Venda>> ExibirRelatorioDeVendasNoDiaVigente(DateTime diaVigente);

        // Manter Funcionario
        public Task CadastrarFuncionario(Funcionario funcionario);
        public Task AlterarFuncionario(int codigoDoFuncionario);
        public Task<IEnumerable<Funcionario>> ListarFuncionarios();

        // Manter Fornecedor
        public Task CadastrarFornecedor(Fornecedor fornecedor);
        public Task AlterarFornecedor(int codigoDoFornecedor);
        public Task<IEnumerable<Fornecedor>> ListarFornecedores();

        // Manter Fabricante
        public Task CadastrarFabricante(Fabricante fabricante);
        public Task AlterarFabricante(int codigoDoFabricante);
        public Task<IEnumerable<Fabricante>> ListarFabricantes();

    }
}
