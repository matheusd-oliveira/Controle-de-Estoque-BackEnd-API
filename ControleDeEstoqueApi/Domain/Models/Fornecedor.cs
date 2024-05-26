using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("fornecedor")]
    public class Fornecedor
    {
        [Key]
        internal int cod_fornc{ get; set; }

        [ForeignKey("cod_funcionario")]
        internal int cod_funcionario { get; set; }

        internal string nome_fant { get; set; }
        internal string cnpj { get; set; }
        internal string endereco { get; set; }
        internal string email { get; set; }
        internal string site { get; set; }
        internal string situacao { get; set; }
        internal string tempo_entrega { get; set; }

    }
}
