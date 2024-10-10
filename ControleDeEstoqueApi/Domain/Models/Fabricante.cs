using ControleDeEstoqueApi.Domain.Models.Agents;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("fabricante")]
    [Index(nameof(codigo_do_fabricante), IsUnique = true)] // Código do fabricante como CONSTRAINT UNIQUE
    [Index(nameof(nome_do_fabricante), IsUnique = true)] // Nome do fabricante como CONSTRAINT UNIQUE
    public class Fabricante
    {
        public Fabricante(int codigo_do_fabricante, int codigo_do_funcionario, string nome_do_fabricante)
        {
            this.codigo_do_fabricante = codigo_do_fabricante;
            this.codigo_do_funcionario = codigo_do_funcionario;
            this.nome_do_fabricante = nome_do_fabricante;
        }

        [Key]
        public int id_fabricante { get; set; }
        public int codigo_do_fabricante { get; set; }

        [ForeignKey("Funcionario")]
        public int codigo_do_funcionario { get; set; }

        [MaxLength(255)]
        public string nome_do_fabricante { get; set; }

        
        /// <summary>
        /// Propriedades de navegação entre as tabelas para mapamento do EntityFramework
        /// </summary>
        public ICollection<Estoque> Estoque { get; set; }  // Relação muitos para um. Onde o fabricante pode ter vários produtos dentro de um estoque geral.
        public Funcionario Funcionario { get; set; } 
        public ICollection<Produto> Produto { get; set; }
    }
}
