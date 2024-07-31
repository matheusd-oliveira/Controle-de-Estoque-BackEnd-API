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
        public int id_estoque { get; set; }

        [ForeignKey("cod_funcionario")]
        public int cod_func { get; set; }

        [ForeignKey("cod_produto")]
        public int cod_prod { get; set; }
        
        [MaxLength(250)] // Adicionado o nome para ser identificado no estoque
        public string nome_prod { get; set; }

        [ForeignKey("nome_fantasia_fornecedor")]
        public string nome_fant { get; set; }

        [ForeignKey("nome_fabricante")]
        public string nome_fab { get; set; }
        public int quantidade { get; set; }
    }
}
