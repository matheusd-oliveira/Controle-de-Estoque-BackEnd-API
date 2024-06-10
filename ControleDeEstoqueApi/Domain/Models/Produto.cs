using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("produto")]
    [Index(nameof(cod_prod), IsUnique = true)] // Código do produto como CONSTRAINT UNIQUE
    public class Produto
    {
        [Key]
        internal int id_produto { get; set; }
        internal int cod_prod { get; set; }

        [ForeignKey("cod_fabricante")]
        internal int cod_fab{ get; set; }

        [ForeignKey("cod_fornecedor")]
        internal int cod_fornc { get; set; }

        [MaxLength(250)]
        internal string nome_prod { get; set; }

        internal decimal valor_compra { get; set; }

        internal decimal valor_venda { get; set; }

        [MaxLength(250)]
        internal string descricao { get; set; }

        internal int quantidade_min { get; set; }    

    }
    
}
