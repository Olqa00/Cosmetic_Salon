namespace CosmeticSalon.Domain.Types;

public sealed class UserId
{
    public Guid Value { get; init; }

    public UserId(Guid value) => this.Value = value;
}
