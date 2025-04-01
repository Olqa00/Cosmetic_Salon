namespace CosmeticSalon.Infrastructure.Identity.Settings;

internal sealed class UserAccountSettings
{
    public string AllowedUserNameCharacters { get; init; }
    public bool PasswordRequireDigit { get; init; }
    public int PasswordRequiredLength { get; init; }
    public bool PasswordRequireLowercase { get; init; }
    public bool PasswordRequireNonAlphanumeric { get; init; }
    public bool PasswordRequireUppercase { get; init; }
    public bool RequireUniqueEmail { get; init; }
}
