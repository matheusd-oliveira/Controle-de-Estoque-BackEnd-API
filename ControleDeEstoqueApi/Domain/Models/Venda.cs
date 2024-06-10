using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("venda")]
    [Index(nameof(cod_venda), IsUnique = true)] // Código de venda como CONSTRAINT UNIQUE
    public class Venda
    {
        [Key()]
        internal int id_venda { get; set; }
        internal int cod_venda { get; set; }

        [ForeignKey("cod_funcionario")]
        internal int cod_func { get; set; }

        [ForeignKey("cod_pagamento")]
        internal int cod_pagmt { get; set; }
        internal double valor_total { get; set; }
        internal DateTime data_venda { get; set; }
    }
}
