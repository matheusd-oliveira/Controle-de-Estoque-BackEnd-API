using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoqueApi.Application.ViewModels
{
    public class FornecedorViewModel
    {
        public int CodigoDoFuncionario { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public string Telefone { get; set; }
        public string TempoDeEntrega { get; set; }

    }
}
