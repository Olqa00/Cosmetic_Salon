namespace CosmeticSalon.Domain.Types;

public sealed class TreatmentId
{
    public Guid Value { get; init; }

    public TreatmentId(Guid value) => this.Value = value;
}
