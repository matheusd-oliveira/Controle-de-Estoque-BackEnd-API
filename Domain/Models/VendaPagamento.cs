namespace ControleDeEstoqueApi.Domain.Models
{
    public class VendaPagamento
    {
        public int id_venda { get; set; }
        public Venda Venda { get; set; }

        public int id_pagamento { get; set; }
        public Pagamento Pagamento { get; set; }

        public double valor_do_pagamento { get; set; }
    }
}
