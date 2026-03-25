using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("pagamento")]
    [Index(nameof(nome_do_pagamento), IsUnique = true)] // Nome do pagamento como CONSTRAINT UNIQUE
    public class Pagamento
    {
        public Pagamento(string nome_do_pagamento)
        {
            this.nome_do_pagamento = nome_do_pagamento.ToUpper() ?? throw new ArgumentNullException(nameof(nome_do_pagamento));
        }

        [Key]
        public int id_pagamento { get; set; }
        public string nome_do_pagamento { get; set; }

        /// <summary>
        /// Propriedades de navegação entre as tabelas para mapeamento do EntityFramework
        /// </summary>
        public ICollection<VendaPagamento> VendaPagamentos { get; set; } // Relação muitos-para-muitos

    }
}
