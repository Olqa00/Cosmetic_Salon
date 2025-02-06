namespace CosmeticSalon.Domain.Exceptions;

public sealed class InvalidRoleException : DomainException
{
    public InvalidRoleException(string role)
        : base($"Given role is invalid {role}")
    {
    }
}
