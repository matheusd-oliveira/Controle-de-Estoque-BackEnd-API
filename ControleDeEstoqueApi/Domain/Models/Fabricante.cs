using ControleDeEstoqueApi.Domain.Models.Agents;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("fabricante")]
    [Index(nameof(cod_fab), IsUnique = true)] // Código do fabricante como CONSTRAINT UNIQUE
    [Index(nameof(nome_fab), IsUnique = true)] // Nome do fabricante como CONSTRAINT UNIQUE
    public class Fabricante
    {
        // TODO: Criar um Id para cada classe como Primary Key.

        [Key]
        public int id_fabricante { get; set; }
        public int cod_fab { get; set; }

        [ForeignKey("Funcionario")]
        public int cod_func { get; set; }

        [MaxLength(255)]
        public string nome_fab { get; set; }

        
        /// <summary>
        /// Propriedades de navegação entre as tabelas para mapamento do EntityFramework
        /// </summary>
        public ICollection<Estoque> Estoque { get; set; }  // Relação muitos para um. Onde o fabricante pode ter vários produtos dentro de um estoque geral.
        public Funcionario Funcionario { get; set; } 
        public ICollection<Produto> Produto { get; set; }
    }
}
