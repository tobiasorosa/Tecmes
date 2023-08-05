using Microsoft.AspNetCore.Mvc;
using Tecmes.Application.Repositories.Production;

namespace Tecmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionController : Controller
    {
        private readonly IProductionRepository _productionRepository;

        public ProductionController(IProductionRepository productionRepository)
        {
            _productionRepository = productionRepository;
        }

        [HttpGet]
        [Route("orders")]
        public async ValueTask<IActionResult> GetProductionOrders()
        {
            var result = await _productionRepository.GetProductionOrders();
            return Ok(result);
        }
    }
}
