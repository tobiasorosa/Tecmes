using Tecmes.Infrastructure.Domain;

namespace Tecmes.Entities
{
    public class SaleOrder : Entity, IAggregateRoot
    {
        public SaleOrder() { }
        public SaleOrder(int id)
        {
            Id = id;
        }
        public int ProductionOrderId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public bool IsCompleted { get; private set; }
        public SaleOrder(int productionOrderId, int productId, int quantity, bool isCompleted)
        {
            ProductionOrderId = productionOrderId;
            ProductId = productId;
            Quantity = quantity;
            IsCompleted = isCompleted;
        }
        public SaleOrder(int id, int productionOrderId, int productId, int quantity, bool isCompleted) : this(id)
        {
            ProductionOrderId = productionOrderId;
            ProductId = productId;
            Quantity = quantity;
            IsCompleted = isCompleted;
        }
    }
}
