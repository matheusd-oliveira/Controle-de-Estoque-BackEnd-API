using Asp.Versioning;
using ControleDeEstoqueApi.Application.ViewModels;
using ControleDeEstoqueApi.Domain.Models;
using ControleDeEstoqueApi.Domain.Models.InterfacesRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoqueApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
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
                    produtoView.NomeDoProduto,
                    produtoView.ValorDeCompra,
                    produtoView.ValorDeVenda,
                    produtoView.DescricaoDoProduto,
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

        [HttpPut]
        public async Task<IActionResult> AlteracaoDeProdutos(ProdutoViewModel produtoView)
        {
            try
            {
                var produto = new Produto(
                    produtoView.CodigoDoProduto,
                    produtoView.CodigoDoFabricante,
                    produtoView.CodigoDoFornecedor,
                    produtoView.NomeDoProduto,
                    produtoView.ValorDeCompra,
                    produtoView.ValorDeVenda,
                    produtoView.DescricaoDoProduto,
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


        // TODO: CONSERTAR O CADASTRO DE PRODUTOS NO BANCO, POIS SÓ PUXA A LISTA DE PRODUTOS SE COLOCAR O NOME IGUAL. 
        // TEM QUE PUXAR INDEPENDENTE DA LETRA SER MAISCULA OU MINUSCULA
        [HttpGet]
        public async Task<IActionResult> BuscarProduto(string nomeDoProduto)
        {
            var result = await _vendedorRepository.BuscarProduto(nomeDoProduto);

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
    }
}
