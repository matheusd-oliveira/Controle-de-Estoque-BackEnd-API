using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("estoque")]
    public class Estoque
    {
        [Key]
        internal int cod_func { get; set; }

        [Key]
        internal int cod_prod { get; set; }

        internal int quantidade { get; set; }
    }
}
