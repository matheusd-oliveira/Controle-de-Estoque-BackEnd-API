using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("estoque")]
    public class Estoque
    {
        public Estoque(int cod_func, int cod_prod, int quantidade, string nome_prod)
        {
            this.cod_func = cod_func;
            this.cod_prod = cod_prod;
            this.quantidade = quantidade;
            this.nome_prod = nome_prod;
        }

        [Key]
        internal int id_estoque { get; set; }

        [ForeignKey("cod_funcionario")]
        internal int cod_func { get; set; }

        [ForeignKey("cod_produto")]
        internal int cod_prod { get; set; }
        
        [MaxLength(250)] // Adicionado o nome para ser identificado no estoque
        internal string nome_prod { get; set; }

        [ForeignKey("cod_fornecedor")]
        internal int cod_fornc { get; set; }

        [ForeignKey("cod_fabricante")]
        internal int cod_fab { get; set; }
        internal int quantidade { get; set; }
    }
}
