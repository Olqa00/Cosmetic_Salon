namespace CosmeticSalon.Domain.ValueObjects;

using CosmeticSalon.Domain.Exceptions;

public sealed record Role
{
    public static IEnumerable<string> AvailableRoles { get; } = ["admin", "employee", "user"];

    public string Value { get; }

    public Role(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > 30)
        {
            throw new InvalidRoleException(value);
        }

        if (AvailableRoles.Contains(value) is false)
        {
            throw new InvalidRoleException(value);
        }

        this.Value = value;
    }

    public override string ToString() => this.Value;

    public static Role Admin() => new("admin");
    public static Role Employee() => new("employee");
    public static Role User() => new("user");
}
