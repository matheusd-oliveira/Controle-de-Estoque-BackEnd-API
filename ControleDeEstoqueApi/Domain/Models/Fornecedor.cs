using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("fornecedor")]
    [Index(nameof(cnpj), IsUnique = true)] // CNPJ como CONSTRAINT UNIQUE
    public class Fornecedor
    {
        // TODO: Criar um Id para cada classe como Primary Key.
        [Key]
        internal int cod_fornc{ get; set; }

        [ForeignKey("cod_funcionario")]
        internal int cod_func { get; set; }

        [Column("nome_fantasia")]
        internal string nome_fant { get; set; }
        internal string cnpj { get; set; }
        internal string endereco { get; set; }
        internal string email { get; set; }
        internal string site { get; set; }

        [MaxLength(20)]
        internal string telefone { get; set; }
        internal string tempo_entrega { get; set; }

    }
}
