using Tecmes.Infrastructure.Domain;

namespace Tecmes.Infrastructure.Repository
{
    public interface IRepository<TAggregate> where TAggregate : IAggregateRoot
    {
        ValueTask<TAggregate> ObterAsync(int id);
        ValueTask<bool> ExisteAsync(int id);
        ValueTask IncluirAsync(TAggregate entity);
        ValueTask AtualizarAsync(TAggregate entity);
        ValueTask ExcluirAsync(int id);
    }
}
