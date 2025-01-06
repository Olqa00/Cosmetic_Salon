namespace CosmeticSalon.Infrastructure.Security;

using CosmeticSalon.Application.Security;
using CosmeticSalon.Domain.Entities;

internal sealed class PasswordManager : IPasswordManager
{
    private readonly IPasswordHasher<UserEntity> passwordHasher;

    public PasswordManager(IPasswordHasher<UserEntity> passwordHasher)
    {
        this.passwordHasher = passwordHasher;
    }

    public string Secure(string password) => this.passwordHasher.HashPassword(user: default, password);

    public bool Validate(string password, string securedPassword)
        => this.passwordHasher.VerifyHashedPassword(user: default, securedPassword, password) is PasswordVerificationResult.Success;
}
