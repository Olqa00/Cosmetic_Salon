namespace CosmeticSalon.Application.Exceptions;

public sealed class UsernameAlreadyExistsException : ApplicationException
{
    public UsernameAlreadyExistsException(string username)
        : base($"Username {username} already exists")
    {
    }
}
