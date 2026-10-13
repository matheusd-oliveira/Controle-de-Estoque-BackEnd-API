using ControleDeEstoqueApi.Domain.Models.Agents;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("item_venda")]
    public class Item_Venda
    {
        public Item_Venda(int codigo_do_produto, int codigo_da_venda, int quantidade_do_produto, decimal valor_unitario)
        {
            this.codigo_do_produto = codigo_do_produto;
            this.codigo_da_venda = codigo_da_venda;
            this.quantidade_do_produto = quantidade_do_produto;
            this.valor_unitario = valor_unitario;
        }

        [Key]
        public int id_item_venda { get; set; }

        [ForeignKey("Produto")]
        public int codigo_do_produto { get; set; }

        [ForeignKey("Venda")]
        public int codigo_da_venda { get; set; }
        public int quantidade_do_produto { get; set; }
        public decimal valor_unitario { get; set; }

        public Produto Produto { get; set; }
        public Venda Venda { get; set; }
    }
}
