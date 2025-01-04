namespace CosmeticSalon.Domain.Exceptions;

using CosmeticSalon.Domain.Types;

public sealed class TreatmentEmptyNameException : DomainException
{
    public TreatmentEmptyNameException(TreatmentId id)
        : base($"Treatment name can not be empty. Treatment id: {id.Value}")
    {
        this.Id = id.Value;
    }
}
