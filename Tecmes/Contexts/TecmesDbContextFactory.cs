using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Tecmes.Contexts
{
    public class TecmesDbContextFactory : IDesignTimeDbContextFactory<TecmesDbContext>
    {
        public TecmesDbContextFactory()
        {
        }
        public TecmesDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TecmesDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql(connectionString);

            return new TecmesDbContext(optionsBuilder.Options);
        }
    }
}
