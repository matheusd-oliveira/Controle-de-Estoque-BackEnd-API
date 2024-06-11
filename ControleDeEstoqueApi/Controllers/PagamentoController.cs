using ControleDeEstoqueApi.Application.ViewModels;
using ControleDeEstoqueApi.Domain.Models;
using ControleDeEstoqueApi.Domain.Models.InterfacesRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoqueApi.Controllers
{
    [ApiController]
    [Route("api/v1/pagamento")]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public PagamentoController(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository ?? throw new ArgumentNullException(nameof(pagamentoRepository));
        }



        [HttpPost]
        public IActionResult Add(PagamentoViewModel pagamentoView)
        {
            var pagamento = new Pagamento(pagamentoView.CodPagamento, pagamentoView.NomePagamento);

            _pagamentoRepository.Add(pagamento);
            return Ok();

        }
    }
}
