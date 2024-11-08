using ControleDeEstoqueApi.Domain.Models.Agents;
using ControleDeEstoqueApi.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ControleDeEstoqueApi.Services
{
    public class TokenService
    {   
        // Configurar o Token
        public static object GenerateToken(Funcionario funcionario) 
        {
            // Chave do token
            var key = Encoding.ASCII.GetBytes(Key.Secret);

            // Payload do Token
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim("funcionarioId", funcionario.id_funcionario.ToString()),
                    new Claim("funcionarioCargo", funcionario.cargo.name)
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Gerar o token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            var tokenString = tokenHandler.WriteToken(token);

            return new
            {
                token = tokenString
            };
        }
    }
}
