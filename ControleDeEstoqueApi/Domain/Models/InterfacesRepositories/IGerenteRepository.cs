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
        public Task<Estoque> EntradaDoProdutoNoEstoque(Estoque produto); // O produto já está cadastrado, ele só vai buscar da lista de produtos cadastrados e dar ENTRADA no estoque.
        public Task<Estoque> SaidaDoProdutoNoEstoque(Estoque produto); // Dar a SAIDA do estoque por meio da propriedade cod_prod que é UNIQUE.

        // Manter Vendas
        public Task<Venda> EfetuarVenda(Venda venda);
        public Task<Venda> CancelarVenda(Venda venda); // Cancelar venda através do codigo da venda.
        public Task<Item_Venda> AdicionarItemDeVenda(Item_Venda itemDaVenda); // Adicionar item da venda na Venda.
        public Task<Item_Venda> CancelarItemDeVenda(Item_Venda itemDaVenda); // Cancelar item da venda através do codigo do item , que é UNIQUE.
        public Task<IEnumerable<Estoque>> ListarProdutosPorNomeNaTelaDeVenda(string nomeDoProduto); // Listar todos os produtos através do nome na tela Venda.
        
        // TODO: Adicionar async aos métodos
        // Gerar Relatorio
        // TODO: PENSAR EM COMO EXIBIR ESSAS VENDAS.
        public Task<IEnumerable<Venda>> ExibirRelatorioDeVendasDoMes();
        public Task<IEnumerable<Venda>> ExibirRelatorioDeVendasNoDiaVigente(DateTime diaVigente);

        // Manter Funcionario
        public Task<Funcionario> CadastrarFuncionario(Funcionario funcionario);
        public Task<Funcionario> AlterarFuncionario(int codigoDoFuncionario, Funcionario novoFuncionario);
        public Task<IEnumerable<Funcionario>> ListarFuncionarios();

        // Manter Fornecedor
        public Task<Fornecedor> CadastrarFornecedor(Fornecedor fornecedor);
        public Task<Fornecedor> AlterarFornecedor(int codigoDoFornecedor, Fornecedor novoFornecedor);
        public Task<IEnumerable<Fornecedor>> ListarFornecedores();

        // Manter Fabricante
        public Task<Fabricante> CadastrarFabricante(Fabricante fabricante);
        public Task<Fabricante> AlterarFabricante(int codigoDoFabricante, Fabricante novoFabricante);
        public Task<IEnumerable<Fabricante>> ListarFabricantes();

    }
}
