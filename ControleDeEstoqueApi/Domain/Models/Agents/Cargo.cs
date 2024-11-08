using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models.Agents
{
    [Table("Cargos")]
    public class Cargo 
    {
        public int id_Cargo { get; set; }
        public string name { get; set; }
    }
}