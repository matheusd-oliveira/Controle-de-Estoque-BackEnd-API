using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models.Agents
{
    [Table("funcionario")]
    public class Funcionario
    {
        [MaxLength(250)]
        public string nome { get; set; }

        [Key]
        public int cod_func { get; set; }
        public Cargo cargo { get; set; }
        public decimal salario { get; set; }

        [MaxLength(250)]
        public string endereco { get; set; }

        [MaxLength(255)]
        public string telefone { get; set; }

        [MaxLength(250)]
        public string cpf { get; set; }
        
        // TODO: Tratar essas propriedades, pois não é legal colocar senha no banco de dados.
        public string login { get; set; }
        public string senha { get; set; }

        [MaxLength(250)]
        public string data_nasc { get; set; }
        public bool situacao { get; set; }


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
