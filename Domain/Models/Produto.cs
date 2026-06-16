using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ControleDeEstoqueApi.Domain.Models
{
    public class Produto
    {

        public Produto(int fabricanteId, string produtoNome, decimal valorDaCompra, decimal valorDeVenda, string descricaoDoProduto, int quantidadeMinimaDeCompra, DateTime cadastroDoProduto)
        {
            if (string.IsNullOrWhiteSpace(produtoNome))
                throw new Exception("Nome inválido");

            if (valorDeVenda <= 0)
                throw new Exception("Valor de venda inválido");

            if (fabricanteId <= 0)
                throw new Exception("Fornecedor obrigatório");

            FabricanteId = fabricanteId;
            Nome = produtoNome;
            ValorCompra = valorDaCompra;
            ValorVenda = valorDeVenda;
            Descricao = descricaoDoProduto;
            QuantidadeMinima = quantidadeMinimaDeCompra;

            
        }

        public int Id { get; private set; }
        public int FabricanteId { get; private set; }
        public string Nome { get; private set; }
        public decimal ValorCompra { get; private set; }
        public decimal ValorVenda { get; private set; }
        public string Descricao { get; private set; } 
        public int QuantidadeMinima { get; private set; }
        public DateTime DataCadastro { get; private set; } = DateTime.UtcNow;

        public Fabricante Fabricante { get; set; }
        public Estoque Estoque { get; set; }
        public ICollection<Item_Venda> Item_Venda { get; set; } = new List<Item_Venda>();
    }

}
