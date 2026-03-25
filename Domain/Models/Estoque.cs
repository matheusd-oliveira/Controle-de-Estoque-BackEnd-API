using ControleDeEstoqueApi.Domain.Models.Agents;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    public class Estoque
    {

        public Estoque(int produtoId, int quantidade)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;

            if (ProdutoId <= 0)
                throw new Exception("Produto obrigatório");
            if (Quantidade <= 0)
                throw new Exception("Quantidade inválida");

        }
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
