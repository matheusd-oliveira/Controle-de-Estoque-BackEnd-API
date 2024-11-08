using Asp.Versioning;
using ControleDeEstoqueApi.Application.ViewModels;
using ControleDeEstoqueApi.Domain.Models;
using ControleDeEstoqueApi.Domain.Models.Agents;
using ControleDeEstoqueApi.Domain.Models.InterfacesRepositories;
using ControleDeEstoqueApi.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace ControleDeEstoqueApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[Controller]/[action]")]
    public class GerenteController : ControllerBase
    {
        private readonly IGerenteRepository _gerenteRepository;

        public GerenteController(IGerenteRepository gerenteRepository)
        {
            _gerenteRepository = gerenteRepository ?? throw new ArgumentNullException(nameof(gerenteRepository));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CadastroDeProdutos(ProdutoViewModel produtoView)
        {
            try
            {
                var produto = new Produto(
                    produtoView.CodigoDoProduto,
                    produtoView.CodigoDoFabricante,
                    produtoView.CodigoDoFornecedor,
                    produtoView.NomeDoProduto.ToUpper(),
                    produtoView.ValorDeCompra,
                    produtoView.ValorDeVenda,
                    produtoView.DescricaoDoProduto.ToUpper(),
                    produtoView.QuantidadeMinimaParaComprar
                    );

                var novoProduto = await _gerenteRepository.CadastrarProduto(produto);

                if (novoProduto == null)
                    return NotFound("Produto não foi cadastrado! Entre em contato com o suporte.");

                return Ok(novoProduto);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Ocorreu um erro na aplicação. Debugue! {e.Message}");
            }
        }


        [Authorize]
        [HttpPut]
        public async Task<IActionResult> AlteracaoDeProdutos(ProdutoViewModel produtoView)
        {
            try
            {
                var produto = new Produto(
                    produtoView.CodigoDoProduto,
                    produtoView.CodigoDoFabricante,
                    produtoView.CodigoDoFornecedor,
                    produtoView.NomeDoProduto.ToUpper(),
                    produtoView.ValorDeCompra,
                    produtoView.ValorDeVenda,
                    produtoView.DescricaoDoProduto.ToUpper(),
                    produtoView.QuantidadeMinimaParaComprar
                    );

                var novoProduto = await _gerenteRepository.AlterarProduto(produtoView.CodigoDoProduto, produto);

                return Ok(novoProduto);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> BuscarProduto(string nomeDoProduto)
        {
            var result = await _gerenteRepository.BuscarProduto(nomeDoProduto.ToUpper());

            try
            {
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode(404, $"{e.Message}");
            }
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> BuscarProdutoNoEstoquePorId(int codigoDoProduto)
        {


            try
            {
                if (codigoDoProduto != null)
                {
                    var result = await _gerenteRepository.BuscarProdutoNoEstoquePorId(codigoDoProduto);

                    if (result != null)
                        return Ok(result);
                    else
                        return NotFound();
                }
                else
                    return BadRequest();

            }
            catch (Exception e)
            {
                return StatusCode(400, $"Mensagem de erro: {e.Message}");
            }
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> BuscarTodosOsProdutosNoEstoque()
        {
            var result = await _gerenteRepository.BuscarTodosOsProdutosNoEstoque();

            try
            {
                if (result != null)
                    return Ok(result);

                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest($"Erro na requisição: {e.Message}");
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ListarProdutosDoEstoquePorNomeNaTela(string nomeDoProduto)
        {
            try
            {
                var result = await _gerenteRepository.ListarProdutosPorNomeNaTelaDeVenda(nomeDoProduto);

                if (result != null)
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest($"Erro na requisição: {e.Message} ");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CadastrarFuncionarios([FromBody] FuncionarioViewModel modelFuncionario) 
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var funcionario = new Funcionario
            {
                nome_do_funcionario = modelFuncionario.NomeDoFuncionario,
                endereco = modelFuncionario.Endereco,
                telefone = modelFuncionario.Telefone,
                cpf = modelFuncionario.Cpf,
                salario = modelFuncionario.Salario,
                login = modelFuncionario.login,
                senhaHash = PasswordHasher.Hash(modelFuncionario.senha),
                situacao = true,
                cargoId = 1,
            };

            try
            {
                await _gerenteRepository.CadastrarFuncionario(funcionario);
                return Ok($"Login: {funcionario.login} \nSenha: {funcionario.senhaHash}");
            }
            catch (DbUpdateException)
            {
                return StatusCode(400, "Verifique se o funcionário não está duplicado.");
            }
            catch
            {
                return StatusCode(500, "Internal Error");
            }
        }

        //[Authorize]
        //[HttpPut]

        //public async Task<IActionResult> AlteracaoDeFuncionarios(Funcionario funcionario) { }
        //[Authorize]
        //[HttpGet]
        //public async Task<IActionResult> ListarFuncionarios() { }
    }

}
