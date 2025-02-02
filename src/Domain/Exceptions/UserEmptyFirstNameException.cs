namespace CosmeticSalon.Domain.Exceptions;

public sealed class UserEmptyFirstNameException : DomainException
{
    public UserEmptyFirstNameException(UserId id)
        : base($"User first name can not be empty. User id: {id.Value}")
    {
        this.Id = id.Value;
    }
}
