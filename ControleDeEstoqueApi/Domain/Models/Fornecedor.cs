using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("fornecedor")]
    [Index(nameof(cnpj), IsUnique = true)] // CNPJ como CONSTRAINT UNIQUE
    [Index(nameof(nome_fant), IsUnique = true)] // nome fantasia como CONSTRAINT UNIQUE
    public class Fornecedor
    {
        // TODO: Criar um Id para cada classe como Primary Key.
        [Key]
        public int cod_fornc{ get; set; }

        [ForeignKey("cod_funcionario")]
        public int cod_func { get; set; }

        [Column("nome_fantasia")]
        public string nome_fant { get; set; }
        public string cnpj { get; set; }
        public string endereco { get; set; }
        public string email { get; set; }
        public string site { get; set; }

        [MaxLength(20)]
        public string telefone { get; set; }
        public string tempo_entrega { get; set; }

    }
}
