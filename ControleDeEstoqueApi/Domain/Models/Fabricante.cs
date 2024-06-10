using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("fabricante")]
    [Index(nameof(cod_fab), IsUnique = true)] // Código do fabricante como CONSTRAINT UNIQUE
    public class Fabricante
    {
        // TODO: Criar um Id para cada classe como Primary Key.

        [Key]
        public int id_fabricante { get; set; }
        internal int cod_fab { get; set; }

        [MaxLength(255)]
        internal string nome_fab { get; set; }

    }
}
