using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueApi.Domain.Models
{
    [Table("pagamento")]
    public class Pagamento
    {
        // TODO: Criar um Id para cada classe como Primary Key.
        public int cod_pagmt { get; set; }
        public string nome_pagmt { get; set; }
    }
}
