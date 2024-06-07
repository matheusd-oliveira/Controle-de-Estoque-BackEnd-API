using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("estoque")]
    public class Estoque
    {
        // TODO: Criar um Id para cada classe como Primary Key.

        [ForeignKey("cod_funcionario")]
        internal int cod_func { get; set; }

        
        [ForeignKey("cod_produto")]
        internal int cod_prod { get; set; }

        internal int quantidade { get; set; }
    }
}
