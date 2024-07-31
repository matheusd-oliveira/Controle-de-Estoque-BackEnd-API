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
        [Key]
        public int id_venda { get; set; }
        public int cod_venda { get; set; }
        
        // Pensar sobre essa propriedade
        // internal List<Item_Venda> itens_da_venda { get; set; }

        [ForeignKey("cod_funcionario")]
        public int cod_func { get; set; }

        [ForeignKey("cod_pagamento")]
        public int cod_pagmt { get; set; }
        public double valor_total { get; set; }
        public DateTime data_venda { get; set; }
    }
}
