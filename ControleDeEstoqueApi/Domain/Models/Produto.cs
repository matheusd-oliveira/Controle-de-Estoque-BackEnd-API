using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("produto")]
    [Index(nameof(cod_prod), IsUnique = true)] // Código do produto como CONSTRAINT UNIQUE
    public class Produto
    {
        public Produto(int cod_prod, int cod_fab, int cod_fornc, string nome_prod, decimal valor_compra, decimal valor_venda, string descricao, int quantidade_min)
        {
            this.cod_prod = cod_prod;
            this.cod_fab = cod_fab;
            this.cod_fornc = cod_fornc;
            this.nome_prod = nome_prod;
            this.valor_compra = valor_compra;
            this.valor_venda = valor_venda;
            this.descricao = descricao;
            this.quantidade_min = quantidade_min;
        }

        [Key]
        public int id_produto { get; set; }
        public int cod_prod { get; set; }

        [ForeignKey("Fabricante")]
        public int cod_fab{ get; set; }

        [ForeignKey("Fornecedor")]
        public int cod_fornc { get; set; }

        [MaxLength(250)]
        public string nome_prod { get; set; }

        public decimal valor_compra { get; set; }

        public decimal valor_venda { get; set; }

        [MaxLength(250)]
        public string descricao { get; set; }

        public int quantidade_min { get; set; }

        /// <summary>
        /// Propriedades de navegação entre as tabelas para mapeamento do EntityFramework
        /// </summary>
        public Estoque Estoque { get; set; } 
        public Item_Venda Item_Venda { get; set; } 
        public Fabricante Fabricante { get; set;}
        public Fornecedor Fornecedor { get; set; }
    }
    
}
