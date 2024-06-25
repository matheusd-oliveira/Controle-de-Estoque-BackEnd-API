using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Application.ViewModels
{
    public class ItemVendaViewModel
    {
        public int CodigoDoProduto { get; set; }
        public int QuantidadeDoItem { get; set; }
        public decimal ValorUnitario { get; set; }

    }
}
