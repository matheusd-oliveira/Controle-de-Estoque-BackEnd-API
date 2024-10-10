using ControleDeEstoqueApi.Domain.Models.Agents;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("estoque")]
    public class Estoque
    {
        public Estoque(
            int codigo_do_funcionario, 
            int codigo_do_produto, 
            string nome_do_produto, 
            string nome_fantasia_do_fornecedor, 
            string nome_do_fabricante, 
            int quantidade_do_produto)
        {
            this.codigo_do_funcionario = codigo_do_funcionario;
            this.codigo_do_produto = codigo_do_produto;
            this.nome_do_produto = nome_do_produto;
            this.nome_fantasia_do_fornecedor = nome_fantasia_do_fornecedor;
            this.nome_do_fabricante = nome_do_fabricante;
            this.quantidade_do_produto = quantidade_do_produto;
        }

        [Key]
        public int id_estoque { get; set; }

        [ForeignKey("Funcionario")]
        public int codigo_do_funcionario { get; set; }

        [ForeignKey("Produto")]
        public int codigo_do_produto { get; set; }

        [MaxLength(250)] // Adicionado o nome para ser identificado no estoque
        public string nome_do_produto { get; set; }

        [ForeignKey("Fornecedor")]
        public string nome_fantasia_do_fornecedor { get; set; } 

        [ForeignKey("Fabricante")]
        public string nome_do_fabricante { get; set; }
        public int quantidade_do_produto { get; set; }
        public Produto Produto { get; set; } // Criando propriedade de navegação para acessar a tabela Produto
        public Fabricante Fabricante { get; set; } // Criando propriedade de navegação para acessar a tabela Fabricante
        public Fornecedor Fornecedor { get; set; } // Criando propriedade de navegação para acessar a tabela Fornecedor
        public Funcionario Funcionario { get; set; } // Criando propriedade de naveção para acessar a tabela Funcionário
    }
}
