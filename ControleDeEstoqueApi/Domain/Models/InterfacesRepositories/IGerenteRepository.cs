namespace ControleDeEstoqueApi.Domain.Models.InterfacesRepositories
{
    public interface IGerenteRepository : IVendedorRepository
    {   
        // Gerar Relatorio
        public void ExibirRelatorioDeVendasDoMes() { }
        public void ExibirRelatorioDeVendasNoDiaVigente() { }

        // Manter Funcionario
        public void CadastrarFuncionario() { }
        public void AlterarFuncionario() { }
        public void ListarFuncionarios() { }

        // Manter Fornecedor
        public void CadastrarFornecedor() { }
        public void AlterarFornecedor() { }
        public void ListarFornecedores() { }

        // Manter Fabricante
        public void CadastrarFabricante() { }
        public void AlterarFabricante() { }
        public void ListarFabricantes() { }

    }
}
