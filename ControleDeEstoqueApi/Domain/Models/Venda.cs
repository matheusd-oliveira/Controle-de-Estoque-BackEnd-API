using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("venda")]
    public class Venda
    {
        // TODO: Criar um Id para cada classe como Primary Key.

        [Key]
        public int cod_venda { get; set; }

        [ForeignKey("cod_funcionario")]
        public int cod_func { get; set; }

        [ForeignKey("cod_pagamento")]
        public int cod_pagmt { get; set; }
        public double valor_total { get; set; }
        public DateTime data_venda { get; set; }
    }
}
