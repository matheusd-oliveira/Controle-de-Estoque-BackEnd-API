using ControleDeEstoqueApi.Application.Services;
using ControleDeEstoqueApi.Domain.Models;
using ControleDeEstoqueApi.Domain.Models.Agents;
using ControleDeEstoqueApi.Domain.Models.InterfacesRepositories;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace ControleDeEstoqueApi.Infrastructure.Repositories
{
    public class GerenteRepository : IGerenteRepository
    {
        DbConnection _dbConnection = new DbConnection();
        ServiceProduto _serviceProduto = new ServiceProduto();

        public async Task<Cargo> CadastrarCargo(Cargo cargo)
        {
            if (cargo != null)
            {
                _dbConnection.Cargos.Add(cargo);
                await _dbConnection.SaveChangesAsync();
                return cargo;
            }
            else
            {
                throw new Exception("Tente novamente!");
            }  
        }
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

       
        public async Task<Estoque> EntradaDoProdutoNoEstoque(Estoque produtoNoEstoque)
        {
            if (_dbConnection.Produto.FindAsync(produtoNoEstoque.codigo_do_produto) != null)
            {
                _dbConnection.Estoque.Add(produtoNoEstoque);
                await _dbConnection.SaveChangesAsync();

                return produtoNoEstoque;
            }
            else
            {
                throw new Exception("Produto não cadastrado no sistema. Volte para a tela de cadastro e faça manualmente a sua inserção.");
            }
        }
        
        public async Task<Estoque> SaidaDoProdutoNoEstoque(Estoque produtoNoEstoque)
        {
            if (produtoNoEstoque != null)
            {
                _dbConnection.Estoque.Remove(produtoNoEstoque);
                await _dbConnection.SaveChangesAsync();

                return produtoNoEstoque;
            }
            else
            {
                throw new Exception("Não foi possivel realizar a saída do produto. Verifique com o desenvolvedor.");
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
        // TODO
        public async Task<Venda> CancelarVenda(Venda venda)
        {
            if (venda != null)
            {
                _dbConnection.Venda.Remove(venda);
                await _dbConnection.SaveChangesAsync();
            }
            return venda;

        }

        public async Task<Item_Venda> AdicionarItemDeVenda(Item_Venda itemDaVenda)
        {
            try
            {
                if (itemDaVenda != null)
                {
                    _dbConnection.Item_Venda.Add(itemDaVenda);
                    await _dbConnection.SaveChangesAsync();
                }
                return itemDaVenda;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Item_Venda> CancelarItemDeVenda(Item_Venda itemDaVenda)
        {
            try
            {
                if (itemDaVenda != null)
                {
                    _dbConnection.Item_Venda.Remove(itemDaVenda);
                    await _dbConnection.SaveChangesAsync();
                }
                return itemDaVenda;
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
        public async Task<IEnumerable<Venda>> ExibirRelatorioDeVendasDoMes()
        {
            throw new NotImplementedException();
        }
        // TODO
        public async Task<IEnumerable<Venda>> ExibirRelatorioDeVendasNoDiaVigente(DateTime diaVigente)
        {
            throw new NotImplementedException();
        }
        
        public async Task<Funcionario> CadastrarFuncionario(Funcionario funcionario)
        {
            if (funcionario != null)
            { 
                _dbConnection.Funcionario.Add(funcionario);
                await _dbConnection.SaveChangesAsync();
            }

            return funcionario;
        }
        
        public async Task<Funcionario> AlterarFuncionario(int codigoDoFuncionario, Funcionario novoFuncionario)
        {
            var funcionarioEncontrado = await _dbConnection.Funcionario.FirstOrDefaultAsync(x => x.codigo_do_funcionario == codigoDoFuncionario);

            if (funcionarioEncontrado != null)
            {   
                funcionarioEncontrado.nome_do_funcionario = novoFuncionario.nome_do_funcionario;
                funcionarioEncontrado.salario = novoFuncionario.salario;
                funcionarioEncontrado.cargoId = novoFuncionario.cargoId;
                funcionarioEncontrado.cpf = novoFuncionario.cpf;
                funcionarioEncontrado.situacao = novoFuncionario.situacao;
                funcionarioEncontrado.telefone = funcionarioEncontrado.telefone;

                await _dbConnection.SaveChangesAsync();

                return novoFuncionario;
            }

            else
            {
                throw new Exception("Funcionario não encontrado");
            }       
        }
        
        public async Task<IEnumerable<Funcionario>> ListarFuncionarios()
        {
            return await _dbConnection.Funcionario.ToListAsync();
        }
        

        public async Task<Fornecedor> CadastrarFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor != null)
            {
                _dbConnection.Fornecedor.Add(fornecedor);
                await _dbConnection.SaveChangesAsync();
            }

            return fornecedor;
        }
        
        public async Task<Fornecedor> AlterarFornecedor(int codigoDoFornecedor, Fornecedor novoFornecedor)
        {
            var fornecedorEncontrado = await _dbConnection.Fornecedor.FirstOrDefaultAsync(x => x.codigo_do_fornecedor == codigoDoFornecedor);

            if (fornecedorEncontrado != null)
            {  
                fornecedorEncontrado.nome_fantasia_do_fornecedor = novoFornecedor.nome_fantasia_do_fornecedor;
                fornecedorEncontrado.email = novoFornecedor.email;
                fornecedorEncontrado.cnpj = novoFornecedor.cnpj;
                fornecedorEncontrado.endereco = novoFornecedor.endereco;
                fornecedorEncontrado.telefone = novoFornecedor.telefone;
                fornecedorEncontrado.tempo_de_entrega = novoFornecedor.tempo_de_entrega;
                fornecedorEncontrado.site = novoFornecedor.site;

                await _dbConnection.SaveChangesAsync();

                return novoFornecedor;
            }
            else
            {
                throw new Exception("Fornecedor não encontrado.");
            }
        }
        
        public async Task<IEnumerable<Fornecedor>> ListarFornecedores()
        {
            return await _dbConnection.Fornecedor.ToListAsync();
        }
        

        public async Task<Fabricante> CadastrarFabricante(Fabricante fabricante)
        {
            if (fabricante != null)
            { 
                _dbConnection.Fabricante.Add(fabricante);
                await _dbConnection.SaveChangesAsync();
            }

            return fabricante;
        }
        
        public async Task<Fabricante> AlterarFabricante(int codigoDoFabricante, Fabricante novoFabricante)
        {
            var fabricanteEncontrado = await _dbConnection.Fabricante.FirstOrDefaultAsync(x => x.codigo_do_fabricante == codigoDoFabricante);

            if (fabricanteEncontrado != null)
            {
                fabricanteEncontrado.nome_do_fabricante = fabricanteEncontrado.nome_do_fabricante;

                await _dbConnection.SaveChangesAsync();

                return novoFabricante;
            }
            else
            {
                throw new Exception("Fabricante não encontrado.");
            }
        }
        
        public async Task<IEnumerable<Fabricante>> ListarFabricantes()
        {
            return await _dbConnection.Fabricante.ToListAsync();
        }
    }
}
