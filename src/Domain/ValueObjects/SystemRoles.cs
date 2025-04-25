namespace CosmeticSalon.Domain.ValueObjects;

public static class SystemRoles
{
    public const string ADMIN = "admin";
    public const string EMPLOYEE = "employee";
    public const string USER = "user";

    public static IEnumerable<string> All => [ADMIN, EMPLOYEE, USER];
}
