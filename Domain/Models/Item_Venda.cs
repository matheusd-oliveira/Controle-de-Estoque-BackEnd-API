using ControleDeEstoqueApi.Domain.Models.Agents;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    public class Item_Venda
    {
        public Item_Venda(int produtoId, int vendaId, int quantidade, decimal valorUnitario)
        {
            ProdutoId = produtoId;
            VendaId = vendaId;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int VendaId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }

        public Produto Produto { get; set; }
        public Venda Venda { get; set; }
    }
}
