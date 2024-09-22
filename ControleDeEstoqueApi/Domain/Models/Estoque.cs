using ControleDeEstoqueApi.Domain.Models.Agents;
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

        [ForeignKey("Funcionario")]
        public int cod_func { get; set; }

        [ForeignKey("Produto")]
        public int cod_prod { get; set; }

        [MaxLength(250)] // Adicionado o nome para ser identificado no estoque
        public string nome_prod { get; set; }

        [ForeignKey("Fornecedor")]
        public string nome_fant { get; set; } // Criando propriedade de navegação para acessar a tabela Fabricante

        [ForeignKey("Fabricante")]
        public string nome_fab { get; set; }
        public int quantidade { get; set; }
        public Produto Produto { get; set; } // Criando propriedade de navegação para acessar a tabela Produto
        public Fabricante Fabricante { get; set; } // Criando propriedade de navegação para acessar a tabela Fabricante
        public Fornecedor Fornecedor { get; set; } // Criando propriedade de navegação para acessar a tabela Fornecedor
        public Funcionario Funcionario { get; set; } // Criando propriedade de naveção para acessar a tabela Funcionário
    }
}
