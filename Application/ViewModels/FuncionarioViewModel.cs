using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoqueApi.Application.ViewModels
{
    public class FuncionarioViewModel
    {
        public string NomeDoFuncionario { get; set; }
        //public int CodigoDoFuncionario { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataDeNascimento { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Situacao{ get; set; }

        public FuncionarioViewModel()
        {
            
        }

        //public FuncionarioViewModel(
        //    string nomeDofuncionario, 
        //    int codigoDoFuncionario, 
        //    string endereco, 
        //    string telefone, 
        //    string cpf, 
        //    decimal salario, 
        //    string dataDeNascimento,
        //    string login,
        //    string senha,
        //    bool situacao)
        //{
        //    NomeDoFuncionario = nomeDofuncionario;
        //    CodigoDoFuncionario = codigoDoFuncionario;
        //    Endereco = endereco;
        //    Telefone = telefone;
        //    Cpf = cpf;
        //    Salario = salario;
        //    DataDeNascimento = dataDeNascimento;
        //    Login = login;
        //    Senha = senha;
        //    Situacao = situacao;
        //}

        //public FuncionarioViewModel(
        //    string nomeDofuncionario,
        //    string endereco,
        //    string telefone,
        //    string cpf,
        //    decimal salario,
        //    string dataDeNascimento,
        //    bool situacao)
        //{
        //    NomeDoFuncionario = nomeDofuncionario;
        //    Endereco = endereco;
        //    Telefone = telefone;
        //    Cpf = cpf;
        //    Salario = salario;
        //    DataDeNascimento = dataDeNascimento;
        //    Situacao = situacao;
        //}
    }
}
