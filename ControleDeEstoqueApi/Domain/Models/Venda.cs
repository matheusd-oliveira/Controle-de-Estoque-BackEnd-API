using ControleDeEstoqueApi.Domain.Models.Agents;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("venda")]
    [Index(nameof(cod_venda), IsUnique = true)] // Código de venda como CONSTRAINT UNIQUE
    public class Venda
    {
        [Key]
        public int id_venda { get; set; }
        public int cod_venda { get; set; }

        [ForeignKey("Funcionario")]
        public int cod_func { get; set; }
        public double valor_total { get; set; }
        public DateTime data_venda { get; set; }


        /// <summary>
        /// Propriedades de navegação entre as tabelas para mapeamento do EntityFramework
        /// </summary>
        public ICollection<Item_Venda> Item_Venda { get; set; }
        public Funcionario Funcionario { get; set; }
        public ICollection<VendaPagamento> VendaPagamentos { get; set; } // Relação muitos-para-muitos
    }
}
