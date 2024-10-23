using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("produto")]
    [Index(nameof(codigo_do_produto), IsUnique = true)] // Código do produto como CONSTRAINT UNIQUE
    public class Produto
    {
        public Produto(
            int codigo_do_produto, 
            int codigo_do_fabricante, 
            int codigo_do_fornecedor, 
            string nome_do_produto, 
            decimal valor_de_compra, 
            decimal valor_de_venda, 
            string descricao_do_produto, 
            int quantidade_minima_para_compra )
        {
            this.codigo_do_produto = codigo_do_produto;
            this.codigo_do_fabricante = codigo_do_fabricante;
            this.codigo_do_fornecedor = codigo_do_fornecedor;
            this.nome_do_produto = nome_do_produto;
            this.valor_de_compra = valor_de_compra;
            this.valor_de_venda = valor_de_venda;
            this.descricao_do_produto = descricao_do_produto;
            this.quantidade_minima_para_compra = quantidade_minima_para_compra;
        }
        

        [Key]
        public int id_produto { get; set; }
        public int codigo_do_produto { get; set; }

        [ForeignKey("Fabricante")]
        public int codigo_do_fabricante { get; set; }

        [ForeignKey("Fornecedor")]
        public int codigo_do_fornecedor { get; set; }

        [MaxLength(250)]
        public string nome_do_produto { get; set; }

        public decimal valor_de_compra { get; set; }

        public decimal valor_de_venda { get; set; }

        [MaxLength(250)]
        public string descricao_do_produto { get; set;} 

        public int quantidade_minima_para_compra { get; set; }
        public DateTime data_do_cadastro_do_produto { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Propriedades de navegação entre as tabelas para mapeamento do EntityFramework
        /// </summary>
        public Estoque Estoque { get; set; }
        public Item_Venda Item_Venda { get; set; }
        public Fabricante Fabricante { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }

}
