using ControleDeEstoqueApi.Domain.Models.Agents;
using System.Security.Claims;

namespace ControleDeEstoqueApi.Application.Services
{
    public static class ServiceRoleClaim
    {
        public static IEnumerable<Claim> GetClaims(this Funcionario funcionario)
        {
            var result = new List<Claim>
            {
                new(ClaimTypes.Name, funcionario.nome_do_funcionario),
                new(ClaimTypes.NameIdentifier, funcionario.login),
                new(ClaimTypes.Role, funcionario.cargoId.ToString())
            };
            return result;
        }
    }
}
