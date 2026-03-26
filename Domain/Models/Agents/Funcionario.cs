using Amazon.RDS.Model.Internal.MarshallTransformations;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace ControleDeEstoqueApi.Domain.Models.Agents
{
    public class Funcionario
    {
        // private readonly string _senhaHash;


        public Funcionario(string nomeFuncionario, string endereco, string telefone, string cpf, string login, string senha, bool situacao, int cargoId, DateTime dataNascimento)
        {
            NomeFuncionario = nomeFuncionario;
            Endereco = endereco;
            Telefone = telefone;
            Cpf = cpf;
            Login = login;
            Senha = senha;
            Situacao = situacao;
            CargoId = cargoId;
            DataNascimento = dataNascimento;

            if (string.IsNullOrWhiteSpace(NomeFuncionario))
                throw new Exception("Nome do Funcionário é obrigatório.");
            if (string.IsNullOrWhiteSpace(Endereco))
                throw new Exception("Endereço está inválido.");
            if (string.IsNullOrWhiteSpace(Cpf))
                throw new Exception("Cpf  é obrigatório.");
            if (string.IsNullOrWhiteSpace(Login))
                throw new Exception("Login inválido");
            if (string.IsNullOrWhiteSpace(Senha))
                throw new Exception("Senha inválida");
            if (bool.Equals(Situacao, null))
                throw new Exception("Preencha o campo 'Situação' corretamente");
            if (CargoId <= 0)
                throw new Exception("O cargo é obrigatório.");
            if (DataNascimento == null)
                throw new Exception("Data de nascimento é obrigatória.");

        }

        public int Id { get; set; }
        public string NomeFuncionario { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Situacao { get; set; }
        public int CargoId { get; set; } // Criando propriedade para referenciar ao Cargo
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Propriedades de navegação entre as tabelas para mapeamento do EntityFramework
        /// </summary>
        public Fornecedor Fornecedor { get; set; }
        public Fabricante Fabricante { get; set; }
        public Cargo Cargo { get; set; }
    }
}
