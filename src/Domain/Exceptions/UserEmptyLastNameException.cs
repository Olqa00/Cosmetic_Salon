namespace CosmeticSalon.Domain.Exceptions;

public sealed class UserEmptyLastNameException : DomainException
{
    public UserEmptyLastNameException(UserId id)
        : base($"User last name can not be empty. User id: {id.Value}")
    {
        this.Id = id.Value;
    }
}
