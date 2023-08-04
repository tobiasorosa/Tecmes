using Microsoft.EntityFrameworkCore;
using Tecmes.Contexts;
using Tecmes.Entities;

namespace Tecmes.Application.Repositories.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly TecmesDbContext _context;

        public UsersRepository(TecmesDbContext context)
        {
            _context = context;
        }

        public async ValueTask<User> GetByUserNameAndPassword(string username, string password)
        {
            var result = await _context.UserTb.Where(p => p.Name == username && p.Password == password).Select(p => new User(p.Id, p.Name)).SingleOrDefaultAsync();

            return result;
        }

        public async ValueTask RegisterUser(User obj)
        {
            _context.UserTb.Add(obj);
            await _context.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}
