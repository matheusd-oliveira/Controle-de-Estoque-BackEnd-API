using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoqueApi.Application.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string login { get; set; }
        [Required]
        public string password { get; set; }
    }
}
