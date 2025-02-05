namespace CosmeticSalon.Domain.Exceptions;

using CosmeticSalon.Domain.ValueObjects;

public sealed class EmailAlreadyExistsException : DomainException
{
    public EmailAlreadyExistsException(Email email)
        : base($"Email {email.Value} already exists")
    {
    }
}
