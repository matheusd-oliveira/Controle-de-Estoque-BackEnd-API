using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("pagamento")]
    [Index(nameof(nome_pagmt), IsUnique = true)] // Nome do pagamento como CONSTRAINT UNIQUE
    public class Pagamento
    {
        // TODO: Criar um Id para cada classe como Primary Key.
        [Key]
        internal int id_pagamento { get; set; }
        internal string nome_pagmt { get; set; }
    }
}
