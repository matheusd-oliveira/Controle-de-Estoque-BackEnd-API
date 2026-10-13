using ControleDeEstoqueApi.Domain.Models.Agents;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Runtime.InteropServices;

namespace ControleDeEstoqueApi.Domain.Models
{
    public class Venda
    {
        public Venda(int funcionarioId, double valorTotal, DateTime dataVenda)
        {
            FuncionarioId = funcionarioId;
            ValorTotal = valorTotal;
            DataVenda = dataVenda;
        }

        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public double ValorTotal { get; set; }
        public Pagamento FormaDePagamento { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataVenda { get; set; } = DateTime.UtcNow;


        /// <summary>
        /// Propriedades de navegação entre as tabelas para mapeamento do EntityFramework
        /// </summary>
        public ICollection<Item_Venda> Item_Venda { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
