namespace CosmeticSalon.Domain.Exceptions;

using CosmeticSalon.Domain.ValueObjects;

public sealed class InvalidRoleException : DomainException
{
    public InvalidRoleException(Role role)
        : base($"Given role is invalid {role}")
    {
    }
}
