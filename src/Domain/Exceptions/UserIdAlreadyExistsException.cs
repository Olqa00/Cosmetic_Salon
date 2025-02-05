namespace CosmeticSalon.Domain.Exceptions;

public sealed class UserIdAlreadyExistsException : DomainException
{
    public UserIdAlreadyExistsException(UserId id)
        : base($"User with id {id.Value} already exists")
    {
        this.Id = id.Value;
    }
}
