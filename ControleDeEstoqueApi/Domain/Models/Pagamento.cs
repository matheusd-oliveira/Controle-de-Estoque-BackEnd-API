using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("pagamento")]
    [Index(nameof(nome_pagmt), IsUnique = true)] // Nome do pagamento como CONSTRAINT UNIQUE
    public class Pagamento
    {
        public Pagamento(int cod_pagmt, string nome_pagmt)
        {
            this.cod_pagmt = cod_pagmt;
            this.nome_pagmt = nome_pagmt ?? throw new ArgumentNullException(nameof(nome_pagmt));
        }

        [Key]
        public int id_pagamento { get; set; }
        public int cod_pagmt { get; set; }
        public string nome_pagmt { get; set; }
    }
}
