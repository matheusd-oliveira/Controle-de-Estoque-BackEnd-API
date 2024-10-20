using ControleDeEstoqueApi.Domain.Models.Agents;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Runtime.InteropServices;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("venda")]
    [Index(nameof(codigo_da_venda), IsUnique = true)] // Código de venda como CONSTRAINT UNIQUE
    public class Venda
    {
        public Venda(int codigo_da_venda, int codigo_do_funcionario, double valor_total_da_venda, DateTime data_da_venda)
        {
            this.codigo_da_venda = codigo_da_venda;
            this.codigo_do_funcionario = codigo_do_funcionario;
            this.valor_total_da_venda = valor_total_da_venda;
            this.data_da_venda = data_da_venda;
        }

        [Key]
        public int id_venda { get; set; }
        public int codigo_da_venda { get; set; }

        [ForeignKey("Funcionario")]
        public int codigo_do_funcionario { get; set; }
        public double valor_total_da_venda { get; set; }
        public DateTime data_da_venda { get; set; } = DateTime.UtcNow;


        /// <summary>
        /// Propriedades de navegação entre as tabelas para mapeamento do EntityFramework
        /// </summary>
        public ICollection<Item_Venda> Item_Venda { get; set; }
        public Funcionario Funcionario { get; set; }
        public ICollection<VendaPagamento> VendaPagamentos { get; set; } // Relação muitos-para-muitos
    }
}
