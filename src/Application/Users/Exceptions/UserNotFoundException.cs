namespace CosmeticSalon.Application.Users.Exceptions;

public sealed class UserNotFoundException : ApplicationException
{
    public string UserName { get; }

    public UserNotFoundException(string userName)
        : base($"User with name {userName} not found")
    {
        this.UserName = userName;
    }
}
