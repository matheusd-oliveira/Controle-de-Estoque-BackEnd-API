using ControleDeEstoqueApi.Domain.Models.Agents;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    public class Fornecedor
    {
        public Fornecedor(int funcionarioId, string nomeFantasia, string cnpj, string endereco, string email, string site, string telefone, string tempoEntrega)
        {
            FuncionarioId = funcionarioId;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Endereco = endereco;
            Email = email;
            Site = site;
            Telefone = telefone;
            TempoEntrega = tempoEntrega;

            if (FuncionarioId <= 0)
                throw new Exception("Id inválido!");
            if (string.IsNullOrWhiteSpace(NomeFantasia))
                throw new Exception("Nome fantasia é obrigatório.");
            if (string.IsNullOrWhiteSpace(Cnpj))
                throw new Exception("CNPJ é obrigatório.");
            if (string.IsNullOrWhiteSpace(Endereco))
                throw new Exception("Endereço é obrigatório");
            if (string.IsNullOrWhiteSpace(Email))
                throw new Exception("Email é obrigatório");
            if (string.IsNullOrWhiteSpace(Site))
                throw new Exception("Site é obrigatório");
            if (string.IsNullOrWhiteSpace(TempoEntrega))
                throw new Exception("Tempo de entrega inválido");
        }
        public int Id { get; private set; }
        public int FuncionarioId { get; private set; }
        public string NomeFantasia { get; private set; }
        public string Cnpj { get; private set; }
        public string Endereco { get; private set; }
        public string Email { get; private set; }
        public string Site { get; private set; }
        public string Telefone { get; private set; }
        public string TempoEntrega { get; private set; }

        public Funcionario Funcionario { get; set; }

    }
}
