namespace CosmeticSalon.Application.CommandHandlers;

using CosmeticSalon.Application.Commands;
using CosmeticSalon.Application.Exceptions;
using CosmeticSalon.Domain.Entities;
using CosmeticSalon.Domain.Interfaces;

internal sealed class AddTreatmentHandler : IRequestHandler<AddTreatment>
{
    private readonly ITreatmentRepository repository;

    public AddTreatmentHandler(ITreatmentRepository repository)
    {
        this.repository = repository;
    }

    public async Task Handle(AddTreatment request, CancellationToken cancellationToken)
    {
        var treatmentId = new TreatmentId(request.Id);
        var treatment = await this.repository.GetByIdAsync(treatmentId);

        if (treatment is not null)
        {
            throw new TreatmentAlreadyExistsException(treatmentId);
        }

        var treatmentEntity = new TreatmentEntity(treatmentId, request.Type, request.Name);

        await this.repository.AddTreatmentAsync(treatmentEntity);
    }
}
