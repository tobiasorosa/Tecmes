using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Tecmes.Application.Repositories.Users;
using Tecmes.Entities;
using Tecmes.Infrastructure.Results;

namespace Tecmes.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsersRepository _usersRepository;
        public AuthService(IConfiguration configuration, IUsersRepository usersRepository)
        {
            _configuration = configuration;
            _usersRepository = usersRepository;
        }
        public async ValueTask<Result<string>> GenerateJwtToken(string userName, string password)
        {
            var user = await _usersRepository.GetByUserNameAndPassword(userName, password);

            if (user == null)
                return Result<string>.Failure("Não foi encontrado usuário com esse acesso");

            var jwtSecretKeyString = _configuration["Jwt:Secret"];
            var jwtSecretKey = Convert.FromBase64String(jwtSecretKeyString);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(jwtSecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtSecretKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Result<string>.Success(tokenString);
        }

        public async ValueTask<Result<string>> CalculatePassword(string password)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to a hexadecimal string representation
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return Result<string>.Success(sb.ToString());
            }
        }

        public async ValueTask<Result<string>> RegisterUser(string username, string password)
        {
            var user = new User(username, password);

            if (user == null)
            {
                return Result<string>.Failure("Erro ao criar usuário");
            }

            await _usersRepository.RegisterUser(user);

            return Result<string>.Success("Registrado com sucesso");
        }
    }
}
