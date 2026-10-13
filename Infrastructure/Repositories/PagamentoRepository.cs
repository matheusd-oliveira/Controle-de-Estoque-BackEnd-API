using ControleDeEstoqueApi.Domain.Models;
using ControleDeEstoqueApi.Domain.Models.InterfacesRepositories;
using Microsoft.EntityFrameworkCore;
namespace ControleDeEstoqueApi.Infrastructure.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly DbConnection _dbConnection = new DbConnection();
        public void Add(Pagamento pagamento)
        {
            _dbConnection.Pagamento.Add(pagamento);
            _dbConnection.SaveChanges();
        }
    }
}
