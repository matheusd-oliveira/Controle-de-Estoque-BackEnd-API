using ControleDeEstoqueApi.Domain.Models.Agents;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    public class Fabricante
    {
        public Fabricante(int funcionarioId, string nomeFabricante)
        {
            FuncionarioId = funcionarioId;
            NomeFabricante = nomeFabricante;

            if (FuncionarioId <= 0)
                throw new Exception("Id inválido!");

            if (string.IsNullOrWhiteSpace(NomeFabricante))
                throw new Exception("Nome do fabricante é obrigatório.");
        }

        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public string NomeFabricante { get; set; }

        
        /// <summary>
        /// Propriedades de navegação entre as tabelas para mapamento do EntityFramework
        /// </summary>
        public Funcionario Funcionario { get; set; } 
        public ICollection<Produto> Produto { get; set; }
    }
}
