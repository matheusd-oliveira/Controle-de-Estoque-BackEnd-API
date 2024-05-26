using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("fabricante")]
    public class Fabricante
    {
        [Key]
        internal long cod_fab { get; set; }

        [MaxLength(255)]
        internal string nome_fab { get; set; }

    }
}
