using ControleDeEstoqueApi.Domain.Models.InterfacesRepositories;
using ControleDeEstoqueApi.Services;
using Microsoft.EntityFrameworkCore;


namespace ControleDeEstoqueApi.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        DbConnection _dbConnection = new DbConnection();

        public object Auth(string username , string password) 
        {   
            // TODO: AUTENTICAR COM SENHA HASH POSTERIORMENTE.
            var userLogin = _dbConnection.Funcionario.FirstOrDefaultAsync(x => x.login == username);
            var userPass = _dbConnection.Funcionario.FirstOrDefaultAsync(x => x.senha == password);

            if (userLogin != null && userPass != null)
            {
                var token = TokenService.GenerateToken(new Domain.Models.Agents.Funcionario());
                return token;
            }

            return false;       
        }
    }
}
