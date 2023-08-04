namespace Tecmes.Infrastructure.Results
{
    public interface IValue<out T>
    {
        T Value { get; }
    }
}
