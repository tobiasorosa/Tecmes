using Tecmes.Models.Production;

namespace Tecmes.Application.Repositories.Production
{
    public interface IProductionRepository
    {
        public ValueTask<IEnumerable<ProductionOrderViewModel>> GetProductionOrders();
    }
}
