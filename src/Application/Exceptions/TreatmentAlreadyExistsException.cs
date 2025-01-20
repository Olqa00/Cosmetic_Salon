namespace CosmeticSalon.Application.Exceptions;

public sealed class TreatmentAlreadyExistsException : ApplicationException
{
    public TreatmentAlreadyExistsException(TreatmentId id)
        : base($"Treatment with id {id.Value} already exists")
    {
        this.Id = id.Value;
    }
}
