using ControleDeEstoqueApi.Application.Services;
using ControleDeEstoqueApi.Domain.Models;
using ControleDeEstoqueApi.Domain.Models.Agents;
using ControleDeEstoqueApi.Domain.Models.InterfacesRepositories;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoqueApi.Infrastructure.Repositories
{
    public class GerenteRepository : IGerenteRepository
    {
        DbConnection _dbConnection = new DbConnection();
        ServiceProduto _serviceProduto = new ServiceProduto();

        public async Task<Produto> CadastrarProduto(Produto produto)
        {
            try
            {
                if (produto != null)
                {
                    var codigo = _serviceProduto.AdicionarUnidadeAoCodigo();
                    produto.codigo_do_produto = codigo;

                    _dbConnection.Produto.Add(produto);
                    await _dbConnection.SaveChangesAsync();
                }
                return produto;
            }
            catch (Exception e)
            {

                throw new ArgumentException(e.Message);
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoDoProduto">Código do produto a ser alterado</param>
        /// <param name="novoProduto">Produto Alterado</param>
        public async Task<Produto> AlterarProduto(int codigoDoProduto, Produto novoProduto)
        {
            var produtoEncontrado = await _dbConnection.Produto.FirstOrDefaultAsync(x => x.codigo_do_produto == codigoDoProduto);

            if (produtoEncontrado != null)
            {
                // Atualizando as propriedades
                produtoEncontrado.codigo_do_produto = novoProduto.codigo_do_produto;
                produtoEncontrado.codigo_do_fabricante = novoProduto.codigo_do_fabricante;
                produtoEncontrado.codigo_do_fornecedor = novoProduto.codigo_do_fornecedor;
                produtoEncontrado.nome_do_produto = novoProduto.nome_do_produto;
                produtoEncontrado.valor_de_compra = novoProduto.valor_de_compra;
                produtoEncontrado.valor_de_venda = novoProduto.valor_de_venda;
                produtoEncontrado.descricao_do_produto = novoProduto.descricao_do_produto;

                // Salvando no banco
                await _dbConnection.SaveChangesAsync();

                return produtoEncontrado;
            }
            else
            {
                // TODO: MELHORAR ESSA EXCEÇÃO NO FUTURO
                throw new Exception("Produto não encontrado");
            }

        }

        public async Task<IEnumerable<Produto>> BuscarProduto(string nomeDoProduto)
        {
            return await _dbConnection.Produto.Where(x => x.nome_do_produto.Contains(nomeDoProduto)).ToListAsync();
        }

        public async Task<IEnumerable<Estoque>> BuscarTodosOsProdutosNoEstoque()
        {
            return await _dbConnection.Estoque.ToListAsync();
        }

        public async Task<Estoque> BuscarProdutoNoEstoquePorId(int codigoDoProduto)
        {
            // Estou pegando uma entidade de "Estoque", que vai ser o meu produto estocado. 
            var produtoNoEstoque = await _dbConnection.Estoque.FirstOrDefaultAsync(x => x.codigo_do_produto == codigoDoProduto);

            // Aqui eu busco o produto correspondente ao código na entidade "Estoque" acima.
            //return await _dbConnection.Produto.FirstOrDefaultAsync(y => y.cod_prod == produtoNoEstoque.cod_prod);
            return produtoNoEstoque;
        }

        // TODO
        public async Task EntradaDoProdutoNoEstoque(Produto produto, Funcionario funcionario)
        {
            throw new NotImplementedException();
        }
        // TODO
        public async Task SaidaDoProdutoNoEstoque(Produto produto, Funcionario funcionario)
        {
            throw new NotImplementedException();
        }
        // TODO
        public async Task<Venda> EfetuarVenda(Venda venda)
        {
            throw new NotImplementedException();
        }
        // TODO
        public async Task<Venda> CancelarVenda(Venda venda)
        {
            throw new NotImplementedException();
        }

        public async Task AdicionarItemDeVenda(Item_Venda itemDaVenda)
        {
            try
            {
                if (itemDaVenda != null)
                {
                    _dbConnection.Item_Venda.Add(itemDaVenda);
                    await _dbConnection.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task CancelarItemDeVenda(Item_Venda itemDaVenda)
        {
            try
            {
                if (itemDaVenda != null)
                {
                    _dbConnection.Item_Venda.Remove(itemDaVenda);
                    await _dbConnection.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {

                throw new ArgumentException(e.Message);
            }
        }

        public async Task<IEnumerable<Estoque>> ListarProdutosPorNomeNaTelaDeVenda(string nomeDoProduto)
        {
            return await _dbConnection.Estoque.Where(produto => produto.nome_do_produto == nomeDoProduto).ToListAsync();
        }
        // TODO
        public async Task ExibirRelatorioDeVendasDoMes()
        {
            throw new NotImplementedException();
        }
        // TODO
        public async Task<IEnumerable<Venda>> ExibirRelatorioDeVendasNoDiaVigente(DateTime diaVigente)
        {
            throw new NotImplementedException();
        }
        // TODO
        public async Task CadastrarFuncionario(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }
        // TODO
        public async Task AlterarFuncionario(int codigoDoFuncionario)
        {
            throw new NotImplementedException();
        }
        // TODO
        public async Task<IEnumerable<Funcionario>> ListarFuncionarios()
        {
            throw new NotImplementedException();
        }
        // TODO
        public async Task CadastrarFornecedor(Fornecedor fornecedor)
        {
            throw new NotImplementedException();
        }
        // TODO
        public async Task AlterarFornecedor(int codigoDoFornecedor)
        {
            throw new NotImplementedException();
        }
        // TODO
        public async Task<IEnumerable<Fornecedor>> ListarFornecedores()
        {
            throw new NotImplementedException();
        }
        // TODO
        public async Task CadastrarFabricante(Fabricante fabricante)
        {
            throw new NotImplementedException();
        }
        // TODO
        public async Task AlterarFabricante(int codigoDoFabricante)
        {
            throw new NotImplementedException();
        }
        // TODO
        public async Task<IEnumerable<Fabricante>> ListarFabricantes()
        {
            throw new NotImplementedException();
        }
    }
}
