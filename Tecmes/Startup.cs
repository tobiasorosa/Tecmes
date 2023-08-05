using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Tecmes.Contexts;
using Microsoft.OpenApi.Models;
using Tecmes.Application.Services.Auth;
using Scrutor;
using System.Security.Cryptography;
using Tecmes.Application.Repositories.Users;
using LibSassHost;
using Tecmes.Infrastructure.Middlewares;
using Tecmes.Application.Repositories.Production;
using Tecmes.Application.Services.Production;

namespace Tecmes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tecmes API", Version = "v1" });
            });

            services.AddDbContext<TecmesDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            byte[] jwtSecretKey = GenerateJwtKey(32);
            var key = new SymmetricSecurityKey(jwtSecretKey);
            var tokenString = Convert.ToBase64String(jwtSecretKey);

            Configuration["Jwt:Secret"] = tokenString;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key
                    };
                });

            services.AddControllers();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IProductionRepository,  ProductionRepository>();
            services.AddScoped<IProductionService, ProductionService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStaticFiles();
                app.UseMiddleware<SassMiddleware>();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
                app.UseStaticFiles();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tecmes API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
        public static byte[] GenerateJwtKey(int keyLengthInBytes)
        {
            using var rng = RandomNumberGenerator.Create();
            byte[] key = new byte[keyLengthInBytes];
            rng.GetBytes(key);
            return key;
        }
    }
}