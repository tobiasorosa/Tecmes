using Tecmes.Entities;

namespace Tecmes.Application.Repositories.Users
{
    public interface IUsersRepository
    {
        public ValueTask<User> GetByUserNameAndPassword(string username, string password);
        public ValueTask RegisterUser(User obj);
    }
}
