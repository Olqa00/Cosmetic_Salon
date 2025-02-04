namespace CosmeticSalon.Application.Exceptions;

public sealed class UserIdAlreadyExistsException : ApplicationException
{
    public UserIdAlreadyExistsException(UserId id)
        : base($"User with id {id.Value} already exists")
    {
        this.Id = id.Value;
    }
}
