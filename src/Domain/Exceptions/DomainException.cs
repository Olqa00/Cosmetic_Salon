namespace CosmeticSalon.Domain.Exceptions;

public abstract class DomainException : Exception
{
    public Guid Id { get; protected init; } = Guid.Empty;

    protected DomainException(string message) : base(message)
    {
    }
}
