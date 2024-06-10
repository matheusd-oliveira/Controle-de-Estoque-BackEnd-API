using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("item_venda")]
    public class Item_Venda
    {
        // TODO: Criar um Id para cada classe como Primary Key.
        [Key]
        internal int id_item_venda { get; set; }

        [ForeignKey("cod_produto")]
        public int cod_prod { get; set; }

        [ForeignKey("cod_funcionario")]
        public int cod_func { get; set; }

        [ForeignKey("cod_venda")]
        public int cod_venda { get; set; }
        public int quantidade { get; set; }
        public decimal valor_unitario { get; set; }
    }
}
