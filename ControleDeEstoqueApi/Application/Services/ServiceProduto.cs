using ControleDeEstoqueApi.Infrastructure;

namespace ControleDeEstoqueApi.Application.Services
{
    public class ServiceProduto
    {
        DbConnection _dbConnection = new DbConnection();
        public int codigo { get; set; }

        public List<int> CodigosDoSistema { get; set; } = new();


        public ServiceProduto(int codigo_do_produto) 
        {
            codigo = codigo_do_produto;
        }

        public ServiceProduto() { }

        public int AdicionarUnidadeAoCodigo() 
        {
            var produtos = _dbConnection.Produto;
            foreach (var produto in produtos)
            {
                CodigosDoSistema.Add(produto.codigo_do_produto);
            }

            while (true)
            {
                if (CodigosDoSistema.Contains(codigo))
                    codigo++;
                else
                    break;
            }
            return codigo;
        }
    }
}
