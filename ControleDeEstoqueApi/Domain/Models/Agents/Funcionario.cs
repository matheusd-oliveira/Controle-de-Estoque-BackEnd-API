using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models.Agents
{
    [Table("funcionario")]
    [Index(nameof(cod_func), IsUnique = true)] // Código de funcionario como CONSTRAINT UNIQUE
    [Index(nameof(cpf), IsUnique = true)] // Cpf como CONSTRAINT UNIQUE
    public class Funcionario
    {
        [Key]
        internal int id_funcionario { get; set; }

        [MaxLength(250)]
        internal string nome { get; set; }
        internal int cod_func { get; set; }
        internal Cargo cargo { get; set; }
        internal decimal salario { get; set; }

        [MaxLength(250)]
        internal string endereco { get; set; }

        [MaxLength(255)]
        internal string telefone { get; set; }

        [MaxLength(250)]
        internal string cpf { get; set; }

        // TODO: Tratar essas propriedades, pois não é legal colocar senha no banco de dados.
        internal string login { get; set; }
        internal string senha { get; set; }

        [MaxLength(250)]
        internal string data_nasc { get; set; }
        internal bool situacao { get; set; }


        // Escopo dos métodos criados de acordo com o PDF da documentação original.
        // Lendo um pouco mais sobre as funcionalidades da classe "Funcionario", descobri que o diagrama de classes e o diagrama relacional posusi alguns erros, que foram corrigidos.
        // Esses métodos abaixo foram criados conforme a explicação do material, e isso está correto e faz sentido. 
        // O funcionario possui as funcionalides de Cadastrar/Alterar/Buscar um/Buscar todos os produtos. 
        // Criei apenas o escopo dos métodos. O resto fica com Biel.
        // Foi criado um padrão repository para os métodos. - 02/06/2024

        //public void CadastrarProduto() { }
        //public void AlterarProduto() { }
        //public void BuscarProduto() { }
        //public void BuscarTodosOsProdutosNoEstoque() { }
        //public void EfetuaLogin() { }
    }
}
