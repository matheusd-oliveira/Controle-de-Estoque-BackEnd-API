using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models.Agents
{
    [Table("Cargos")]
    public class Cargo 
    {
        [Key]
        public int id_Cargo { get; set; }
        public string nome { get; set; }
    }
}