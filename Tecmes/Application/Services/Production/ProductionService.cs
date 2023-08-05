using Tecmes.Application.Repositories.Production;

namespace Tecmes.Application.Services.Production
{
    public class ProductionService : IProductionService
    {
        private readonly IProductionRepository _productionRepository;

        public ProductionService(IProductionRepository productionRepository)
        {
            _productionRepository = productionRepository;
        }
    }
}
