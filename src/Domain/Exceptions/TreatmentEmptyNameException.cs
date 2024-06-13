namespace CosmeticSalon.Domain.Exceptions;

public sealed class TreatmentEmptyNameException : DomainException
{
    public TreatmentEmptyNameException(Guid id)
        : base($"Treatment name can not be empty. Treatment id: {id}")
    {
        this.Id = id;
    }
}
