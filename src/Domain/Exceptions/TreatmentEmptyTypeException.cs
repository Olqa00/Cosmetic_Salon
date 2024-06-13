namespace CosmeticSalon.Domain.Exceptions;

public sealed class TreatmentEmptyTypeException : DomainException
{
    public TreatmentEmptyTypeException(Guid id)
        : base($"Treatment type can not be empty. Treatment id: {id}")
    {
        this.Id = id;
    }
}
