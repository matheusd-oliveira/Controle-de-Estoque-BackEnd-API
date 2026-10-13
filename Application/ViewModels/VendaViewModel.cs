using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoqueApi.Application.ViewModels
{
    public class VendaViewModel
    {
        public int CodigoDaVenda { get; set; }
        public int CodigoDoFuncionario { get; set; }
        public double ValorTotalDaVenda { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataDaVenda { get; set; }

    }
}
