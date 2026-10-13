namespace ControleDeEstoqueApi.Domain.Models.InterfacesRepositories
{
    public interface IAuthRepository
    {
        public object Auth(string username, string password);
    }
}
