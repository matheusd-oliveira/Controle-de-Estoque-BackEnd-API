using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoqueApi.Application.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O usuário é necessário.")]
        public string login { get; set; }
        [Required(ErrorMessage = "A senha é necessária.")]
        public string password { get; set; }
    }
}
