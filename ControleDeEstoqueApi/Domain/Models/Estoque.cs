using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("estoque")]
    public class Estoque
    {
        public Estoque(int cod_func, int cod_prod, int quantidade)
        {
            this.cod_func = cod_func;
            this.cod_prod = cod_prod;
            this.quantidade = quantidade;
        }

        [Key]
        internal int id_estoque { get; set; }

        [ForeignKey("cod_funcionario")]
        internal int cod_func { get; set; }

        
        [ForeignKey("cod_produto")]
        internal int cod_prod { get; set; }

        internal int quantidade { get; set; }
    }
}
