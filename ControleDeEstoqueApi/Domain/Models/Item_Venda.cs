using ControleDeEstoqueApi.Domain.Models.Agents;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("item_venda")]
    public class Item_Venda
    {
        public Item_Venda(int cod_prod, int cod_venda, int quantidade, decimal valor_unitario)
        {
            this.cod_prod = cod_prod;
            this.cod_venda = cod_venda;
            this.quantidade = quantidade;
            this.valor_unitario = valor_unitario;
        }

        [Key]
        public int id_item_venda { get; set; }

        [ForeignKey("Produto")]
        public int cod_prod { get; set; }

        [ForeignKey("Venda")]
        public int cod_venda { get; set; }
        public int quantidade { get; set; }
        public decimal valor_unitario { get; set; }

        public Produto Produto { get; set; }
        public Venda Venda { get; set; }
    }
}
