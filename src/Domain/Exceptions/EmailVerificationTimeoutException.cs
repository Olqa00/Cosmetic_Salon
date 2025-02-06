namespace CosmeticSalon.Domain.Exceptions;

public sealed class EmailVerificationTimeoutException : DomainException
{
    public EmailVerificationTimeoutException(string email)
        : base($"Email address verification timed out {email}")
    {
    }
}
