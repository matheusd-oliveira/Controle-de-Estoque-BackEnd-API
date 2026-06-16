namespace ControleDeEstoqueApi.Domain.Models
{
    public class VendaPagamento
    {
        public int VendaId { get; set; }
        public Venda Venda { get; set; }

        public int PagamentoId { get; set; }
        public Pagamento Pagamento { get; set; }

        public double ValorPagamento { get; set; }
    }
}
