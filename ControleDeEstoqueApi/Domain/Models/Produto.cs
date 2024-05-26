using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("produto")]
    public class Produto
    {
        [Key]
        internal long cod_prod { get; set; }

        [ForeignKey("cod_fabricante")]
        internal int cod_fabricante { get; set; }

        [ForeignKey("cod_fornecedor")]
        internal int cod_fornecedor { get; set; }

        [MaxLength(250)]
        internal string nome_prod { get; set; }

        internal decimal valor_compra { get; set; }

        internal decimal valor_venda { get; set; }

        [MaxLength(250)]
        internal string descricao { get; set; }

        internal int quantidade_min { get; set; }    

    }
    
}
