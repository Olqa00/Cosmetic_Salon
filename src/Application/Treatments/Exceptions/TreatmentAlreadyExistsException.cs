namespace CosmeticSalon.Application.Treatments.Exceptions;

using CosmeticSalon.Application.Common.Exceptions;

public sealed class TreatmentAlreadyExistsException : ApplicationException
{
    public TreatmentAlreadyExistsException(TreatmentId id)
        : base($"Treatment with id {id.Value} already exists")
    {
        this.Id = id.Value;
    }
}
