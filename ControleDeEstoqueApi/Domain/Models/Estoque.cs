using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("estoque")]
    public class Estoque
    {
        public Estoque(int cod_func, int cod_prod, string nome_prod, string nome_fant, string nome_fab, int quantidade)
        {
            this.cod_func = cod_func;
            this.cod_prod = cod_prod;
            this.nome_prod = nome_prod;
            this.nome_fant = nome_fant;
            this.nome_fab = nome_fab;
            this.quantidade = quantidade;
        }

        [Key]
        internal int id_estoque { get; set; }

        [ForeignKey("cod_funcionario")]
        internal int cod_func { get; set; }

        [ForeignKey("cod_produto")]
        internal int cod_prod { get; set; }
        
        [MaxLength(250)] // Adicionado o nome para ser identificado no estoque
        internal string nome_prod { get; set; }

        [ForeignKey("nome_fantasia_fornecedor")]
        internal string nome_fant { get; set; }

        [ForeignKey("nome_fabricante")]
        internal string nome_fab { get; set; }
        internal int quantidade { get; set; }
    }
}
