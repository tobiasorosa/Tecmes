using Tecmes.Infrastructure.Domain;

namespace Tecmes.Entities
{
    public class ProductionOrder : Entity, IAggregateRoot
    {
        public ProductionOrder() { }
        public int Quantity { get; private set; }
        public int ProductId { get; private set; }
        public bool IsCompleted { get; private set; }
        public int QuantitySold { get; private set; }
        public ProductionOrder(int id)
        {
            Id = id;
        }
        public ProductionOrder(int id, int quantity, int productId, bool isCompleted = false, int quantitySold = 0) : this(id)
        {
            Quantity = quantity;
            ProductId = productId;
            IsCompleted = isCompleted;
            QuantitySold = quantitySold;
        }
        public ProductionOrder( int quantity, int productId, bool isCompleted = false, int quantitySold = 0)
        {
            Quantity = quantity;
            ProductId = productId;
            IsCompleted = isCompleted;
            QuantitySold = quantitySold;
        }
    }
}
