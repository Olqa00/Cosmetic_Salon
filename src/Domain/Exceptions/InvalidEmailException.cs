namespace CosmeticSalon.Domain.Exceptions;

public sealed class InvalidEmailException : DomainException
{
    public InvalidEmailException(string email)
        : base($"Given email is invalid {email}")
    {
    }
}
