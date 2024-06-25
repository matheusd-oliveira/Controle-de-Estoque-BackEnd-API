using ControleDeEstoqueApi.Domain.Models;
using ControleDeEstoqueApi.Domain.Models.Agents;
using ControleDeEstoqueApi.Domain.Models.InterfacesRepositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoqueApi.Infrastructure.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        DbConnection _dbConnection = new DbConnection();

        public async Task CadastrarProduto(Produto produto)
        {
            _dbConnection.Produto.Add(produto);
            await _dbConnection.SaveChangesAsync();
        }

        /// <summary>
        /// TODO: Testar assim que conectar ao banco e realizar as migrations
        /// </summary>
        /// <param name="codigoDoProduto">Código do produto a ser alterado</param>
        /// <param name="novoProduto">Produto Alterado</param>
        public async Task AlterarProduto(int codigoDoProduto, Produto novoProduto)
        {
            var produtoEncontrado =  await _dbConnection.Produto.FirstOrDefaultAsync(x => x.cod_prod == codigoDoProduto);

            if (produtoEncontrado != null)
            {
                // Atualizando as propriedades
                produtoEncontrado.cod_prod = novoProduto.cod_prod;
                produtoEncontrado.cod_fab = novoProduto.cod_fab;
                produtoEncontrado.cod_fornc = novoProduto.cod_fornc;
                produtoEncontrado.nome_prod = novoProduto.nome_prod;
                produtoEncontrado.valor_compra = novoProduto.valor_compra;
                produtoEncontrado.valor_venda = novoProduto.valor_venda;
                produtoEncontrado.descricao = novoProduto.descricao;

                // Salvando no banco
                await _dbConnection.SaveChangesAsync();
            }
            else
            {
                // TODO: MELHORAR ESSA EXCEÇÃO NO FUTURO
                throw new Exception("Produto não encontrado");
            }
            
        }

        /// <summary>
        /// Retornando o produto através do Nome, já que o nome é único vai sempre retornar o que foi pedido e não uma lista com nomes semelhantes.
        /// </summary>
        /// <param name="nomeDoProduto"></param>
        /// <returns></returns>
        public async Task<Produto> BuscarProduto(string nomeDoProduto)
        {
            return await _dbConnection.Produto.FirstOrDefaultAsync(x => x.nome_prod == nomeDoProduto);
        }

        public async Task<Produto> BuscarProdutoNoEstoquePorId(int codigoDoProduto)
        {
            // Estou pegando uma entidade de "Estoque", que vai ser o meu produto estocado. 
            var produtoNoEstoque =  await _dbConnection.Estoque.FirstOrDefaultAsync(x => x.cod_prod == codigoDoProduto);
           
            // TODO: Criar uma verificação caso não encontre o produto no estoque.

            // Aqui eu busco o produto correspondente ao código na entidade "Estoque" acima.
            return await _dbConnection.Produto.FirstOrDefaultAsync(y => y.cod_prod == produtoNoEstoque.cod_prod);
        }

        public async Task<IEnumerable<Estoque>> BuscarTodosOsProdutosNoEstoque()
        {   
            return await _dbConnection.Estoque.ToListAsync();
        }

        public async Task EntradaDoProdutoNoEstoque(Produto produto, Funcionario funcionario)
        {

        }
        public Task SaidaDoProdutoNoEstoque(Produto produto, Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public Task AdicionarItemDeVenda(Item_Venda itemDaVenda)
        {
            throw new NotImplementedException();
        }

        public Task CancelarItemDeVenda(Item_Venda itemDaVenda)
        {
            throw new NotImplementedException();
        }

        public Task<Venda> CancelarVenda(Venda venda)
        {
            throw new NotImplementedException();
        }

        public Task<Venda> EfetuarVenda(Venda venda)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> ListarProdutosPorNomeNaTelaDeVenda(string nomeDoProduto)
        {
            throw new NotImplementedException();
        }


    }
}
