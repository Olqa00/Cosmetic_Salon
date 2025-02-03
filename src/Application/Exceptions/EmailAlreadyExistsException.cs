namespace CosmeticSalon.Application.Exceptions;

using CosmeticSalon.Domain.ValueObjects;

public sealed class EmailAlreadyExistsException : ApplicationException
{
    public EmailAlreadyExistsException(Email email)
        : base($"Email {email.Value} already exists")
    {
    }
}
