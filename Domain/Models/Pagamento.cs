using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    public class Pagamento
    {
        public Pagamento(string nomePagamento)
        {
            nomePagamento = NomePagamento.ToUpper() ?? throw new ArgumentNullException(nameof(nomePagamento));
        }

        public int Id { get; set; }
        public string NomePagamento { get; set; }

        /// <summary>
        /// Propriedades de navegação entre as tabelas para mapeamento do EntityFramework
        /// </summary>
        public ICollection<VendaPagamento> VendaPagamentos { get; set; } // Relação muitos-para-muitos

    }
}
