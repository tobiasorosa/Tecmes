using Tecmes.Infrastructure.Domain;

namespace Tecmes.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        public Product() { }
        public string Name { get; private set; }
        public Product(int id)
        {
            Id = id;
        }
        public Product(string name)
        {
            Name = name;
        }
        public Product(int id, string name) : this(id)
        {
            Name = name;
        }
    }
}
