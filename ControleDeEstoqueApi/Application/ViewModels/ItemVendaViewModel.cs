using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Application.ViewModels
{
    public class ItemVendaViewModel
    {
        public int CodigoDoProduto { get; set; }
        public int CodigoDaVenda { get; set; }
        public int QuantidadeDoProduto { get; set; }

    }
}
