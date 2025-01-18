using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models.Agents
{
    [Table("funcionario")]
    [Index(nameof(codigo_do_funcionario), IsUnique = true)] // Código de funcionario como CONSTRAINT UNIQUE
    [Index(nameof(cpf), IsUnique = true)] // Cpf como CONSTRAINT UNIQUE
    public class Funcionario
    {
        [Key]
        public int id_funcionario { get; set; }

        [MaxLength(250)]
        public string nome_do_funcionario { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int codigo_do_funcionario { get; set; }

        [MaxLength(250)]
        public string endereco { get; set; }

        [MaxLength(255)]
        public string telefone { get; set; }

        [MaxLength(250)]
        public string cpf { get; set; }
        public decimal salario { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [MaxLength(250)]
        public string data_nascimento { get; set; }

        public string login { get; set; }
        public string senhaHash { get; set; }

        public bool situacao { get; set; }

        // Criando propriedade para referenciar ao Cargo
        public int cargoId { get; set; }

        public Funcionario(
            string nome_do_funcionario, string endereco, string telefone, string cpf, decimal salario,
            string data_nascimento, string login, string senhaHash, bool situacao)
        {
            this.nome_do_funcionario = nome_do_funcionario;
            this.endereco = endereco;
            this.telefone = telefone;
            this.cpf = cpf;
            this.salario = salario;
            this.data_nascimento = data_nascimento;
            this.login = login;
            this.senhaHash = senhaHash;
            this.situacao = situacao;
        }

        public Funcionario(
        string nome_do_funcionario, string endereco, string telefone, string cpf, decimal salario,
        string data_nascimento, bool situacao)
        {
            this.nome_do_funcionario = nome_do_funcionario;
            this.endereco = endereco;
            this.telefone = telefone;
            this.cpf = cpf;
            this.salario = salario;
            this.data_nascimento = data_nascimento;
            this.situacao = situacao;
        }
        public Funcionario()
        {
            
        }
        /// <summary>
        /// Propriedades de navegação entre as tabelas para mapeamento do EntityFramework
        /// </summary>
        public ICollection<Estoque> Estoque { get; set; }
        public Fornecedor Fornecedor { get; set; } 
        public Fabricante Fabricante { get; set; } 
        public ICollection<Venda> Venda { get; set; }
        public Cargo Cargo { get; set; }
    }
}
