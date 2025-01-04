namespace CosmeticSalon.Domain.Exceptions;

using CosmeticSalon.Domain.Types;

public sealed class TreatmentEmptyTypeException : DomainException
{
    public TreatmentEmptyTypeException(TreatmentId id)
        : base($"Treatment type can not be empty. Treatment id: {id.Value}")
    {
        this.Id = id.Value;
    }
}
