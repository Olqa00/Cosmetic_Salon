namespace CosmeticSalon.Domain.Exceptions;

public sealed class UsernameAlreadyExistsException : DomainException
{
    public UsernameAlreadyExistsException(string username)
        : base($"Username {username} already exists")
    {
    }
}
