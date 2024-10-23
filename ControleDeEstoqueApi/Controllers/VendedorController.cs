using Asp.Versioning;
using ControleDeEstoqueApi.Application.Services;
using ControleDeEstoqueApi.Application.ViewModels;
using ControleDeEstoqueApi.Domain.Models;
using ControleDeEstoqueApi.Domain.Models.InterfacesRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoqueApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[Controller]/[action]")]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorRepository _vendedorRepository;

        public VendedorController(IVendedorRepository vendedorRepository)
        {
            _vendedorRepository = vendedorRepository ?? throw new ArgumentNullException(nameof(vendedorRepository));
        }


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

                var novoProduto = await _vendedorRepository.CadastrarProduto(produto);

                if (novoProduto == null)
                    return NotFound("Produto não foi cadastrado! Entre em contato com o suporte.");

                return Ok(novoProduto);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Ocorreu um erro na aplicação. Debugue! {e.Message}");
            }
        }

        // TODO: COLOCAR NOME_PROD COMO MAIUSCULO TAMBÉM
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

                var novoProduto = await _vendedorRepository.AlterarProduto(produtoView.CodigoDoProduto, produto);

                return Ok(novoProduto);
            }
            catch (Exception e)
            {

                throw;
            }
        }


        [HttpGet]
        public async Task<IActionResult> BuscarProduto(string nomeDoProduto)
        {
            var result = await _vendedorRepository.BuscarProduto(nomeDoProduto.ToUpper());

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

        [HttpGet]
        public async Task<IActionResult> BuscarProdutoNoEstoquePorId(int codigoDoProduto)
        {


            try
            {
                if (codigoDoProduto != null)
                {
                    var result = await _vendedorRepository.BuscarProdutoNoEstoquePorId(codigoDoProduto);

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

        [HttpGet]
        public async Task<IActionResult> BuscarTodosOsProdutosNoEstoque()
        {
            var result = await _vendedorRepository.BuscarTodosOsProdutosNoEstoque();

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
    }
}
