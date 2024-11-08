using ControleDeEstoqueApi.Domain.Models.InterfacesRepositories;
using ControleDeEstoqueApi.Services;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using System.Data.Common;


namespace ControleDeEstoqueApi.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        DbConnection _dbConnection = new DbConnection();

        public object Auth(string username, string password)
        {
            try
            {
                var user = _dbConnection.Funcionario.FirstOrDefaultAsync(x => x.login == username).Result;

                if (!PasswordHasher.Verify(user.senhaHash, password))
                {
                    var ErrorMessage = "Dados incorretos, tente novamente!";
                    return ErrorMessage; 
                }


                var token = TokenService.GenerateToken(new Domain.Models.Agents.Funcionario());
                return token;

            }
            catch (Exception db)
            {
                throw new Exception("Erro Interno -" + db.Message);
            }
        }
    }
}
