using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models.Agents
{
    public class Cargo 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}