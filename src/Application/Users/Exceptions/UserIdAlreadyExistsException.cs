namespace CosmeticSalon.Application.Users.Exceptions;

using CosmeticSalon.Application.Common.Exceptions;

public sealed class UserIdAlreadyExistsException : ApplicationException
{
    public UserIdAlreadyExistsException(UserId id)
        : base($"User with id {id.Value} already exists")
    {
        this.Id = id.Value;
    }
}
