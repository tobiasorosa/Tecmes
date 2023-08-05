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
        public ProductionOrder(int id, int quantity, Product product, bool isCompleted = false, int quantitySold = 0) : this(id)
        {
            Quantity = quantity;
            ProductId = product.Id;
            IsCompleted = isCompleted;
            QuantitySold = quantitySold;
        }
        public ProductionOrder( int quantity, Product product, bool isCompleted = false, int quantitySold = 0)
        {
            Quantity = quantity;
            ProductId = product.Id;
            IsCompleted = isCompleted;
            QuantitySold = quantitySold;
        }
    }
}
