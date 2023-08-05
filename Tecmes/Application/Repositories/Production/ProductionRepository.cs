using Microsoft.EntityFrameworkCore;
using Tecmes.Contexts;
using Tecmes.Models.Production;

namespace Tecmes.Application.Repositories.Production
{
    public class ProductionRepository : IProductionRepository
    {
        private readonly TecmesDbContext _context;
        public ProductionRepository(TecmesDbContext context)
        {
            _context = context;
        }
        public async ValueTask<IEnumerable<ProductionOrderViewModel>> GetProductionOrders()
        {
            var result = await (from pot in _context.ProductionOrderTb
                                join pt in _context.ProductTb on pot.ProductId equals pt.Id
                                select new ProductionOrderViewModel
                                {
                                    Id = pot.Id,
                                    Produto = pt.Name,
                                    Quantidade = pot.Quantity,
                                    Produzido = pot.IsCompleted,
                                    Vendido = pot.QuantitySold,
                                }).ToListAsync();

            return result;
        }
    }
}
