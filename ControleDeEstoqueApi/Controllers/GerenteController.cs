using ControleDeEstoqueApi.Domain.Models.InterfacesRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoqueApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    public class GerenteController :ControllerBase
    {
        private readonly IGerenteRepository _gerenteRepository; 

        public GerenteController(IGerenteRepository gerenteRepository)
        {
            _gerenteRepository = gerenteRepository ?? throw new ArgumentNullException(nameof(gerenteRepository));   
        }
    }
    
}
