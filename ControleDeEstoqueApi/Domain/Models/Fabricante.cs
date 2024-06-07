using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("fabricante")]
    public class Fabricante
    {
        // TODO: Criar um Id para cada classe como Primary Key.

        [Key]
        internal int cod_fab { get; set; }

        [MaxLength(255)]
        internal string nome_fab { get; set; }

    }
}
