namespace Tecmes.Infrastructure.Results
{
    public interface IError<out E>
    {
        E ErrorValue { get; }
    }
}
