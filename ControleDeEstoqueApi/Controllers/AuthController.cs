using ControleDeEstoqueApi.Application.ViewModels;
using ControleDeEstoqueApi.Domain.Models.InterfacesRepositories;
using ControleDeEstoqueApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ControleDeEstoqueApi.Controllers
{
    [ApiController]
    [Route("/api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost]
        public IActionResult AuthUser(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("username or password invalid");


            var token = _authRepository.Auth(model.login, model.password);
            return Ok(token);
        }
    }
}
