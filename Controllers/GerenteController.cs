using Asp.Versioning;
using ControleDeEstoqueApi.Application.ViewModels;
using ControleDeEstoqueApi.Domain.Models;
using ControleDeEstoqueApi.Domain.Models.Agents;
using ControleDeEstoqueApi.Domain.Models.InterfacesRepositories;
using ControleDeEstoqueApi.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using SQLitePCL;
using System.Security.Claims;

namespace ControleDeEstoqueApi.Controllers
{
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[Controller]/[action]")]
    public class GerenteController : ControllerBase
    {
        private readonly IGerenteRepository _gerenteRepository;

        public GerenteController(IGerenteRepository gerenteRepository)
        {
            _gerenteRepository = gerenteRepository ?? throw new ArgumentNullException(nameof(gerenteRepository));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public async Task<IActionResult> CadastroDeCargos([FromBody] CargoViewModel model)
        {
            var cargo = new Cargo
            {
                nome = model.NomeDoCargo.ToUpper()
            };

            try
            {
                await _gerenteRepository.CadastrarCargo(cargo);
                return Ok(model);
            }
            catch (DbUpdateException)
            {
                return StatusCode(400, "Verifique se o cargo não está duplicado.");
            }
            catch
            {
                return StatusCode(500, "Internal Error");
            }
        }

        // [Authorize(Roles = "1")]
        [HttpPost]
        public async Task<IActionResult> CadastroDeProdutos(ProdutoViewModel produtoView)
        {
            try
            {
                var produto = new Produto(
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

        // [Authorize(Roles = "1")]
        [HttpPost]
        public async Task<IActionResult> CadastrarFuncionarios([FromBody] FuncionarioViewModel modelFuncionario)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var funcionario = new Funcionario
            {
                nome_do_funcionario = modelFuncionario.NomeDoFuncionario.ToUpper(),
                endereco = modelFuncionario.Endereco.ToUpper(),
                telefone = modelFuncionario.Telefone,
                data_nascimento = modelFuncionario.DataDeNascimento,
                cpf = modelFuncionario.Cpf,
                salario = modelFuncionario.Salario,
                login = modelFuncionario.Login.ToUpper(),
                senhaHash = PasswordHasher.Hash(modelFuncionario.Senha),
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

        [HttpPost]
        public async Task<IActionResult> CadastrarFornecedores([FromBody] FornecedorViewModel modelFornecedor)
        {
            var fornecedor = new Fornecedor(
                modelFornecedor.CodigoDoFuncionario,
                modelFornecedor.NomeFantasia.ToUpper(),
                modelFornecedor.Cnpj,
                modelFornecedor.Endereco.ToUpper(),
                modelFornecedor.Email,
                modelFornecedor.Site,
                modelFornecedor.Telefone,
                modelFornecedor.TempoDeEntrega
                );

            var novoFornecedor = await _gerenteRepository.CadastrarFornecedor(fornecedor);

            return Ok(novoFornecedor);

        }
        [HttpPost]
        public async Task<IActionResult> CadastrarFabricantes([FromBody] FabricanteViewModel modelFabricante)
        {
            var fabricante = new Fabricante(
             modelFabricante.CodigoDoFuncionario,
             modelFabricante.NomeDoFabricante.ToUpper()
             );

            var novoFabricante = await _gerenteRepository.CadastrarFabricante(fabricante);

            return Ok(novoFabricante);
        }

        [HttpPost]
        public async Task<IActionResult> EfetuarVenda(VendaViewModel vendaView)
        {
            var venda = new Venda
            (
                vendaView.CodigoDaVenda,
                vendaView.CodigoDoFuncionario,
                vendaView.ValorTotalDaVenda,
                vendaView.DataDaVenda
            );


            try
            {
                var novaVenda = await _gerenteRepository.EfetuarVenda(venda);
                return Ok(novaVenda);
            }
            catch (DbUpdateException)
            {
                return StatusCode(400, "Verifique se a venda não está duplicada.");
            }
            catch
            {
                return StatusCode(500, "Internal Error");
            }


        }

        [HttpPost]
        public async Task<IActionResult> AdicionarItemVenda(ItemVendaViewModel itemVenda)
        {
            try
            {
                var novoItemDaVenda = new Item_Venda
                (
                    itemVenda.CodigoDoProduto,
                    itemVenda.CodigoDaVenda,
                    itemVenda.QuantidadeDoProduto,
                    itemVenda.ValorUnitario
                );

                await _gerenteRepository.AdicionarItemDeVenda(novoItemDaVenda);
                return Ok(novoItemDaVenda);
            }
            catch (DbUpdateException)
            {
                return StatusCode(400, "Erro ao inserir informações no banco. Contate o administrador. ");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro inesperado. {e.Message}");
            }
        }

        // [Authorize(Roles = "1")]
        [HttpPut]
        public async Task<IActionResult> AlteracaoDeProdutos(int codigoDoProduto, ProdutoViewModel produtoView)
        {
            try
            {
                var produto = new Produto(
                    produtoView.CodigoDoFabricante,
                    produtoView.CodigoDoFornecedor,
                    produtoView.NomeDoProduto.ToUpper(),
                    produtoView.ValorDeCompra,
                    produtoView.ValorDeVenda,
                    produtoView.DescricaoDoProduto.ToUpper(),
                    produtoView.QuantidadeMinimaParaComprar
                    );

                var novoProduto = await _gerenteRepository.AlterarProduto(codigoDoProduto, produto);

                return Ok(novoProduto);
            }
            catch (ArgumentNullException argNull)
            {
                return BadRequest("Algum elemento está nulo.");
            }
            catch (DbUpdateException dbException)
            {
                return StatusCode(400, "Erro ao atualizar o banco de dados. Verifique o código-fonte. ");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar o Produto - {ex.Message}.");
            }
        }

        // [Authorize(Roles = "1")]
        [HttpPut]
        public async Task<IActionResult> AlteracaoDeFuncionarios(int codigoDoFuncionario, FuncionarioViewModel funcionarioView)
        {
            try
            {
                var funcionario = new Funcionario(
                    funcionarioView.NomeDoFuncionario.ToUpper(),
                    funcionarioView.Endereco.ToUpper(),
                    funcionarioView.Telefone,
                    funcionarioView.Cpf,
                    funcionarioView.Salario,
                    funcionarioView.DataDeNascimento,
                    funcionarioView.Situacao
                    );

                var novoFuncionario = await _gerenteRepository.AlterarFuncionario(codigoDoFuncionario, funcionario);
                return Ok(novoFuncionario);
            }
            catch (ArgumentNullException argNull)
            {
                return BadRequest("Algum elemento está nulo.");
            }
            catch (DbUpdateException dbException)
            {
                return StatusCode(400, "Erro ao atualizar o banco de dados. Verifique o código-fonte. ");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar o Funcionário - {ex.Message}.");
            }
        }

        // [Authorize(Roles = "1")]
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

        // [Authorize(Roles = "1")]
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

        //  [Authorize(Roles = "1")]
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

        //  [Authorize(Roles = "1")]
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


        [HttpGet]
        public async Task<IActionResult> ListarFabricantes(string nomeDoFabricante)
        {
            try
            {
                var result = await _gerenteRepository.ListarFabricantes(nomeDoFabricante.ToUpper());

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

        [HttpGet]
        public async Task<IActionResult> ListarFornecedores(string nomeDoFornecedor)
        {
            try
            {
                var result = _gerenteRepository.ListarFornecedores(nomeDoFornecedor.ToUpper());

                if (result != null)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest($"Erro de requisição: {e.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListarFuncionarios(string nomeDoFuncionario) 
        {
            try
            {
                var result = _gerenteRepository.ListarFuncionarios(nomeDoFuncionario.ToUpper());

                if (result != null)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest($"Erro de requisição: {e.Message}");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> CancelarVenda(int id)
        {
            try
            {


                var vendaRemove = await _gerenteRepository.CancelarVenda(id);


                if (vendaRemove == null)
                    return NotFound("Id inexistente.");

                return Ok(vendaRemove);

            }
            catch (Exception e)
            {
                return StatusCode(500, $"Ocorreu um erro na aplicação. Debugue! {e.Message}");
            }

        }



    }

}
