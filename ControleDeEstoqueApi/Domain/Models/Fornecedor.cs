using ControleDeEstoqueApi.Domain.Models.Agents;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("fornecedor")]
    [Index(nameof(cnpj), IsUnique = true)] // CNPJ como CONSTRAINT UNIQUE
    [Index(nameof(nome_fantasia_do_fornecedor), IsUnique = true)] // nome fantasia como CONSTRAINT UNIQUE
    [Index(nameof(codigo_do_fornecedor), IsUnique = true)] // codigo do fornecedor como CONSTRAINT UNIQUE
    public class Fornecedor
    {
        public Fornecedor(
            int codigo_do_fornecedor ,
            int codigo_do_funcionario, 
            string nome_fantasia_do_fornecedor, 
            string cnpj,
            string endereco, 
            string email,
            string site,
            string telefone,
            string tempo_de_entrega )
        {
            this.codigo_do_fornecedor = codigo_do_fornecedor;
            this.codigo_do_funcionario = codigo_do_funcionario;
            this.nome_fantasia_do_fornecedor = nome_fantasia_do_fornecedor;
            this.cnpj = cnpj;
            this.endereco = endereco;
            this.email = email;
            this.site = site;
            this.telefone = telefone;
            this.tempo_de_entrega = tempo_de_entrega;
        }

        [Key]
        public int id_fornecedor{ get; set; }

        public int codigo_do_fornecedor { get; set; }

        [ForeignKey("Funcionario")]
        public int codigo_do_funcionario { get; set; }
        public string nome_fantasia_do_fornecedor { get; set; }
        public string cnpj { get; set; }
        public string endereco { get; set; }
        public string email { get; set; }
        public string site { get; set; }

        [MaxLength(20)]
        public string telefone { get; set; }
        public string tempo_de_entrega { get; set; }

        /// <summary>
        /// Propriedades de navegação entre as tabelas para mapamento do EntityFramework
        /// </summary>
        public ICollection<Estoque> Estoque { get; set; } 
        public Funcionario Funcionario { get; set; } 
        public ICollection<Produto> Produto { get; set; }
    }
}
