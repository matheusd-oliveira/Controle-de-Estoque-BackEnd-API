using Asp.Versioning;
using ControleDeEstoqueApi.Application.ViewModels;
using ControleDeEstoqueApi.Domain.Models;
using ControleDeEstoqueApi.Domain.Models.InterfacesRepositories;
using ControleDeEstoqueApi.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoqueApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[Controller]/[action]")]
    public class GerenteController :ControllerBase
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
    
        
    }
    
}
