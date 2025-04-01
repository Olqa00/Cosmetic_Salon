namespace CosmeticSalon.Domain.ValueObjects;

using CosmeticSalon.Domain.Exceptions;

public sealed record Role
{
    public string Value { get; }

    public Role(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length > 30)
        {
            throw new InvalidRoleException(value);
        }

        if (SystemRoles.All.Contains(value) is false)
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
