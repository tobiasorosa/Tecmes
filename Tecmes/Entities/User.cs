using Tecmes.Infrastructure.Domain;

namespace Tecmes.Entities
{
    public class User : Entity, IAggregateRoot
    {
        private User()
        {

        }

        public User(int id)
        {
            Id = id;
        }
        public User(int id, string name) : this(id)
        {
            Name = name;
        }
        public User(int id, string name, string password) : this(id)
        {
            Name = name;
            Password = password;
        }
        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }
        public string Name { get; private set; }
        public string Password { get; private set; }
    }
}
