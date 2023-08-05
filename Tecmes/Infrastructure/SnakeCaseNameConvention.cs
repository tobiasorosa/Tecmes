using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Tecmes.Infrastructure
{
    public class SnakeCaseNameConvention : IConvention
    {
        public void ProcessModelFinalized(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
        {
            foreach (var entityType in modelBuilder.Metadata.GetEntityTypes())
            {
                foreach (var index in entityType.GetDeclaredIndexes())
                {
                    if (string.IsNullOrEmpty(index.GetDatabaseName()))
                    {
                        var tableName = entityType.GetTableName();
                        var propertyNames = index.Properties.Select(p => p.GetColumnName()).ToArray();
                        var indexName = $"idx_{tableName}_{string.Join("_", propertyNames)}";
                        index.SetDatabaseName(indexName);
                    }
                }
            }
        }
    }
}
