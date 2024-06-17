using ControleDeEstoqueApi.Domain.Models.Agents;

namespace ControleDeEstoqueApi.Domain.Models.InterfacesRepositories
{
    public interface IGerenteRepository : IVendedorRepository
    {
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
