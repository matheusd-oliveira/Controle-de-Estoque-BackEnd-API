using ControleDeEstoqueApi.Application.Services;
using ControleDeEstoqueApi.Domain.Models;
using ControleDeEstoqueApi.Domain.Models.Agents;
using ControleDeEstoqueApi.Domain.Models.InterfacesRepositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Linq;

namespace ControleDeEstoqueApi.Infrastructure.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        DbConnection _dbConnection = new DbConnection();
       
        

        /// <summary>
        /// Retornando o produto através do Nome, já que o nome é único vai sempre retornar o que foi pedido e não uma lista com nomes semelhantes.
        /// </summary>
        /// <param name="nomeDoProduto"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Produto>> BuscarProduto(string nomeDoProduto)
        {
            return await _dbConnection.Produto.Where(x => x.nome_do_produto.Contains(nomeDoProduto)).ToListAsync();
        }

        public async Task<Estoque> BuscarProdutoNoEstoquePorId(int codigoDoProduto)
        {
            // Estou pegando uma entidade de "Estoque", que vai ser o meu produto estocado. 
            var produtoNoEstoque = await _dbConnection.Estoque.FirstOrDefaultAsync(x => x.codigo_do_produto == codigoDoProduto);

            // Aqui eu busco o produto correspondente ao código na entidade "Estoque" acima.
            //return await _dbConnection.Produto.FirstOrDefaultAsync(y => y.cod_prod == produtoNoEstoque.cod_prod);
            return produtoNoEstoque;

        }
        public async Task<IEnumerable<Estoque>> BuscarTodosOsProdutosNoEstoque()
        {
            return await _dbConnection.Estoque.ToListAsync();
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
        // TODO
        public async Task<Venda> EfetuarVenda(Venda venda)
        {   
            if (venda != null)
            {
                _dbConnection.Venda.Add(venda);
                await _dbConnection.SaveChangesAsync();
            }
            return venda;
        }

        public async Task<IEnumerable<Estoque>> ListarProdutosPorNomeNaTelaDeVenda(string nomeDoProduto)
        {
            return await _dbConnection.Estoque.Where(produto => produto.nome_do_produto == nomeDoProduto).ToListAsync();
        }
    }
}
