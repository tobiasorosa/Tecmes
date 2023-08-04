using Tecmes.Infrastructure.Results;

namespace Tecmes.Application.Services.Auth
{
    public interface IAuthService
    {
        ValueTask<Result<string>> GenerateJwtToken(string username, string password);
        ValueTask<Result<string>> CalculatePassword(string password);
        ValueTask<Result<string>> RegisterUser(string username, string password);
    }
}
