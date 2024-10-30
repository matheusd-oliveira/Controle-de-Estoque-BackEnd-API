using Asp.Versioning;
using ControleDeEstoqueApi.Application.Services;
using ControleDeEstoqueApi.Application.ViewModels;
using ControleDeEstoqueApi.Domain.Models;
using ControleDeEstoqueApi.Domain.Models.InterfacesRepositories;
using Microsoft.AspNetCore.Authorization;
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
  
        

        [Authorize]
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

        [Authorize]
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

        [Authorize]
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
