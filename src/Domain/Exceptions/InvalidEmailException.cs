namespace CosmeticSalon.Domain.Exceptions;

using CosmeticSalon.Domain.ValueObjects;

public sealed class InvalidEmailException : DomainException
{
    public InvalidEmailException(Email email)
        : base($"Given email is invalid {email}")
    {
    }
}
