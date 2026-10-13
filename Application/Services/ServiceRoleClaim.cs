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
                new(ClaimTypes.Name, funcionario.NomeFuncionario),
                new(ClaimTypes.NameIdentifier, funcionario.Login),
                new(ClaimTypes.Role, funcionario.CargoId.ToString())
            };
            return result;
        }
    }
}
