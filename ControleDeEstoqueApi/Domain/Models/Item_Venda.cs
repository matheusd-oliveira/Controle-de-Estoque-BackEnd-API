﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("item_venda")]
    [Index(nameof(codigo_item_venda), IsUnique = true)]
    public class Item_Venda
    {
        [Key]
        internal int id_item_venda { get; set; }
        internal int codigo_item_venda { get; set; }

        [ForeignKey("cod_produto")]
        public int cod_prod { get; set; }

        [ForeignKey("cod_funcionario")]
        public int cod_func { get; set; }

        [ForeignKey("cod_venda")]
        public int cod_venda { get; set; }
        public int quantidade { get; set; }
        public decimal valor_unitario { get; set; }
    }
}
